using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace Mom.Test.UI.Core.Common
{
    /// <summary>
    /// Manages OM10 Web Console configuration.
    /// 
    /// Is a Singleton. Uses static initialization instead of double-check locking, as C# and the CLR explicitly
    /// define how and when a static variable is initialized and therefore avoids thread concurrency problems.
    /// </summary>
    public sealed class WebConsoleConfigurationManager
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static readonly WebConsoleConfigurationManager instance = new WebConsoleConfigurationManager();

        /// <summary>
        /// WebConfig object for the current Web.Config.
        /// </summary>
        private WebConfig webConfig;

        /// <summary>
        /// Constructor
        /// </summary>
        private WebConsoleConfigurationManager() { }

        /// <summary>
        /// Instance property responsible for handing the only instance of the 
        /// WebConsoleConfigurationManager to the caller.
        /// </summary>
        public static WebConsoleConfigurationManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// WebConfig object
        /// </summary>
        public WebConfig WebConfig
        {
            get
            {
                if (this.webConfig == null)
                {
                    // We default to using the Web Console Web Server that we retrieve from the SDK and Web Console installation path
                    // we pull from that web server machine. You can always override this on the WebConfig object by doing one of the following:
                    // 1. Setting a new web server name and/or the web.config path and filename on the WebConfig object.
                    // 2. Instantiate your own WebConfig instance and assign it to this property.
                    string webConsoleWebServerName = Utilities.WebConsoleWebServerName;
                    this.webConfig = new WebConfig(webConsoleWebServerName, String.Format(@"{0}\WebHost\Web.Config", Utilities.GetWebConsoleInstallPath(webConsoleWebServerName)));
                }
            
                return this.webConfig;
            }

            set
            {
                this.webConfig = value;
            }

        }

        /// <summary>
        /// Set the AutoSignIn feature {true | false}.
        /// </summary>
        /// <param name="onOff">On or Off</param>
        public void SetAutoSignIn(bool onOff)
        {
            this.WebConfig.SetAutoSignIn(onOff);
        }

        /// <summary>
        /// Set the AutoSignOutInterval (0 is Off).
        /// </summary>
        /// <param name="interval">Timeout in seconds.</param>
        public void SetAutoSignOutInterval(int interval)
        {
            if (interval < 0)
            {
                throw new ArgumentException("interval must be greater than or equal to zero");
            }

            this.WebConfig.SetAutoSignOutInterval(interval);
        }

        /// <summary>
        /// Sets the Windowsless mode parameter for the Silverlight app.
        /// 
        /// ON enables R2 (legacy views) to be rendered in the OM10 Web Console,
        /// but accessbility is non-existant when this mode is ON.
        /// OFF disables R2 (legacy views) in the OM10 Web Console, but accessibility
        /// works as expected when this mode is OFF.
        /// </summary>
        /// <param name="onOff">On (True) or Off (False)</param>
        public void SetWindowlessMode(bool onOff)
        {
            this.WebConfig.SetWindowlessMode(onOff);
        }

        /// <summary>
        /// Reset IIS
        /// 
        /// Needs to handle remote iisreset
        /// </summary>
        private void ResetIIS()
        {
            Process p = new Process();
            p.StartInfo.FileName = System.Environment.SystemDirectory + "\\iisreset.exe";
            p.Start();
        }
    }

    /// <summary>
    /// Class that encapsulates the Web Console Web.Config file.
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// Web Console Web.Config file.
        /// </summary>
        private string webConfigPathAndFilename;

        /// <summary>
        /// Web Console Web.Config file.
        /// </summary>
        private string webConfigUncPathAndFilename;

        /// <summary>
        /// XmlDocument for the current Web.Config.
        /// </summary>
        private XmlDocument xDoc;

        /// <summary>
        /// XmlNode encapsulating the Web.Config <configuration> section/node.
        /// </summary>
        private XmlNode configurationSection;

        /// <summary>
        /// XmlNode encapsulating the Web.Config <add key="WindowlessMode" value="true"> section/node.
        /// </summary>
        private XmlNode windowlessmodeConfigurationSection;

        /// <summary>
        /// XmlNode encapsulating the Web.Config <appSettings> section/node.
        /// </summary>
        private XmlNode appSettingsConfigurationSection;

        /// <summary>
        /// XmlNode encapsulating the Web.Config <connection> section/node.
        /// </summary>
        private XmlNode connectionConfigurationSection;

        /// <summary>
        /// XmlNode encapsulating the Web.Config <encryption> section.
        /// </summary>
        private XmlNode encryptionConfigurationSection;

        /// <summary>
        /// Web Console Web Server hostname.
        /// </summary>
        private string webConsoleServerName;

        /// <summary>
        /// Constructor
        /// </summary>
        public WebConfig(string webConfigPathAndFilename)
        {
            // in this version of the constructor we set the web console 
            // web server name to the value we pull from the SDK
            this.webConsoleServerName = Utilities.WebConsoleWebServerName;
            this.webConfigPathAndFilename = webConfigPathAndFilename;
            this.xDoc = new XmlDocument();
            this.Reload();
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public WebConfig(string webServerName, string webConfigPathAndFilename)
        {
            this.webConsoleServerName = webServerName;
            this.webConfigPathAndFilename = webConfigPathAndFilename;
            this.xDoc = new XmlDocument();
            this.Reload();
        }

        /// <summary>
        /// Web Console Server Name
        /// 
        /// Setting this property will cause the WebConfig Xml document
        /// to be reloaded and all cached configuration sections will
        /// be killed.
        /// </summary>
        public string WebConsoleServerName
        {
            get
            {
                return webConsoleServerName;
            }

            set
            {
                webConsoleServerName = value;
                this.Reload();
            }
        }

        /// <summary>
        /// Web Console Web.Config Path.
        /// 
        /// Setting this property will cause the WebConfig Xml document
        /// to be reloaded and all cached configuration sections will
        /// be killed.
        /// </summary>
        public string WebConfigPathAndFilename
        {
            get
            {
                return this.webConfigPathAndFilename;
            }

            set
            {
                this.webConfigPathAndFilename = value;
                this.Reload();
            }
        }


        /// <summary>
        /// Set the AutoSignIn feature {true | false}.
        /// </summary>
        /// <param name="onOff">On or Off</param>
        public void SetAutoSignIn(bool onOff)
        {
            XmlAttribute autoSignInAttrib = this.ConnectionConfigurationSection.Attributes[Strings.AutoSignInAttributeName];

            // autoSignIn attribute doesn't exist - create it.
            if (null == autoSignInAttrib)
            {
                Utilities.LogMessage("WebConfig.SetAutoSignIn :: autoSignIn attribute does not exist in the web.config file... Creating...");

                autoSignInAttrib = this.xDoc.CreateAttribute(Strings.AutoSignInAttributeName);
                autoSignInAttrib.Value = onOff.ToString().ToLowerInvariant();
                this.ConnectionConfigurationSection.Attributes.Append(autoSignInAttrib);
                this.Save();
            }
            else
            {
                // autoSignIn attribute exists - check its current value and do nothing
                // if the autoSignIn value is already set to the requested value.
                if (String.Equals(autoSignInAttrib.Value, onOff.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    Utilities.LogMessage(String.Format("WebConfig.SetAutoSignIn :: autoSignIn value in the web.config file is already set to {0}... taking no action...", onOff.ToString()));
                }
                else
                {
                    // set autoSignIn attribute
                    autoSignInAttrib.Value = onOff.ToString().ToLowerInvariant();
                    this.Save();
                }
            }
        }

        /// <summary>
        /// Set the AutoSignOutInterval (0 is Off).
        /// </summary>
        /// <param name="interval">Timeout in seconds.</param>
        public void SetAutoSignOutInterval(int interval)
        {
            if (interval < 0)
            {
                throw new ArgumentException("interval must be greater than or equal to zero");
            }

            XmlAttribute autoSignOutIntervalAttrib = this.ConnectionConfigurationSection.Attributes[Strings.AutoSignOutIntervalAttributeName];

            // autoSignOutInterval attribute doesn't exist - create it.
            if (null == autoSignOutIntervalAttrib)
            {
                Utilities.LogMessage("WebConfig.SetAutoSignIn :: autoSignOutInterval attribute does not exist in the web.config file... Creating...");

                autoSignOutIntervalAttrib = this.xDoc.CreateAttribute(Strings.AutoSignOutIntervalAttributeName);
                autoSignOutIntervalAttrib.Value = interval.ToString().ToLowerInvariant();
                this.ConnectionConfigurationSection.Attributes.Append(autoSignOutIntervalAttrib);
                this.Save();
            }
            else
            {
                // autoSignOutInterval attribute exists - check its current value and do nothing
                // if the autoSignOutInterval value is already set to the requested value.
                if (String.Equals(autoSignOutIntervalAttrib.Value, interval.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    Utilities.LogMessage(String.Format("WebConfig.SetAutoSignOutInterval :: auto-signout value in the web.config file is already set to {0}... taking no action...", interval.ToString()));
                }
                else
                {
                    // set autoSignOutInterval attribute
                    autoSignOutIntervalAttrib.Value = interval.ToString();
                    this.Save();
                }
            }
        }

        /// <summary>
        /// Sets the Windowsless mode parameter for the Silverlight app.
        /// 
        /// ON enables R2 (legacy views) to be rendered in the OM10 Web Console,
        /// but accessbility is non-existant when this mode is ON.
        /// OFF disables R2 (legacy views) in the OM10 Web Console, but accessibility
        /// works as expected when this mode is OFF.
        /// </summary>
        /// <param name="onOff">On (True) or Off (False)</param>
        public void SetWindowlessMode(bool onOff)
        {
            string method = "SetWindowlessMode :: ";

            // Do nothing if the windowlessmode value is already set to the requested value.
            if (String.Equals(this.WindowlessModeConfigurationSection.Attributes["value"].Value, onOff.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                Utilities.LogMessage(String.Format("{0} windowless mode value in the web.config file is already set to {0}... taking no action...", method, onOff.ToString()));
            }
            else
            {
                // Set Windowless Mode
                this.WindowlessModeConfigurationSection.Attributes["value"].Value = onOff.ToString().ToLowerInvariant();
                Utilities.LogMessage(String.Format("{0} Writing app setting 'WindowlessMode' to {1} in {2} on machine {3}",
                    method,
                    onOff,
                    this.webConfigPathAndFilename,
                    this.webConsoleServerName));
                this.Save();
            }
        }

        /// <summary>
        /// Reloads the Web.Config Xml document and kills any cached
        /// configuration sections.
        /// </summary>
        private void Reload()
        {
            // Error Handling
            if (String.IsNullOrEmpty(this.webConsoleServerName))
            {
                throw new ArgumentNullException("webConsoleServerName is null or empty");
            }

            if (String.IsNullOrEmpty(this.webConfigPathAndFilename))
            {
                throw new ArgumentNullException("webConfigPathAndFilename is null or empty");
            }

            // build up UNC file path to web.config
            // replace ':' with '$'
            string tmpWebConfigPathAndFilename = Regex.Replace(this.webConfigPathAndFilename, ":", "$");
            
            // complete UNC file path build up
            this.webConfigUncPathAndFilename = String.Format(@"\\{0}\{1}",
                    this.webConsoleServerName,
                    tmpWebConfigPathAndFilename);

            Utilities.LogMessage(String.Format("WebConfig.Reload :: Web.Config UNC file path = '{0}'", this.webConfigUncPathAndFilename));
            Utilities.LogMessage("WebConfig.Reload :: Loading XmlDocument...");

            this.xDoc.Load(webConfigUncPathAndFilename);

            // Kill any cached Web.Config sections/nodes...
            this.configurationSection = null;
            this.windowlessmodeConfigurationSection = null;
            this.appSettingsConfigurationSection = null;
            this.connectionConfigurationSection = null;
            this.encryptionConfigurationSection = null;
        }

        /// <summary>
        /// Saves the Web.Config Xml document to file.
        /// </summary>
        private void Save()
        {
            this.xDoc.Save(this.webConfigUncPathAndFilename);
        }

        /// <summary>
        /// XmlNode for the <appSettings> section of web.config.
        /// </summary>
        private XmlNode WindowlessModeConfigurationSection
        {
            get
            {
                if (null == this.windowlessmodeConfigurationSection)
                {
                    // Get all settings in the appSettings config section
                    XmlNodeList appSettings = this.xDoc.SelectNodes("/configuration/appSettings/add");

                    // Find the WindowlessMode setting
                    foreach (XmlNode setting in appSettings)
                    {
                        if (setting.Attributes["key"].Value.ToString().Equals(Strings.WindowlessAttributeName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            // Found the WindowlessMode appSetting
                            windowlessmodeConfigurationSection = setting;
                            break;
                        }
                    }

                    // If we got here there is no WindowlessMode app setting and we need to create one.
                    if (null == windowlessmodeConfigurationSection)
                    {
                        // Create Nodes
                        XmlNode addNode = this.xDoc.CreateNode(XmlNodeType.Element, "add", "");

                        // Create Attributes
                        XmlAttribute keyAttribute = this.xDoc.CreateAttribute("key");
                        XmlAttribute valueAttribute = this.xDoc.CreateAttribute("value");

                        // Add Attributes
                        addNode.Attributes.Append(keyAttribute).Value = Strings.WindowlessAttributeName;
                        addNode.Attributes.Append(valueAttribute);

                        // Add Nodes
                        this.AppSettingsConfigurationSection.AppendChild(addNode);

                        // Save Changes
                        this.Save();

                        // Cache the node
                        windowlessmodeConfigurationSection = addNode;
                    }
                }

                return windowlessmodeConfigurationSection;
            }
        }

        /// <summary>
        /// XmlNode for the <configuration> section of web.config.
        /// </summary>
        private XmlNode ConfigurationSection
        {
            get
            {
                if (configurationSection == null)
                {
                    configurationSection = this.xDoc.SelectSingleNode("/configuration");
                }
                return configurationSection;
            }
        }

        /// <summary>
        /// XmlNode for the <appSettings> section of web.config.
        /// </summary>
        private XmlNode AppSettingsConfigurationSection
        {
            get
            {
                if (null == appSettingsConfigurationSection)
                {
                    appSettingsConfigurationSection = this.xDoc.SelectSingleNode("/configuration/appSettings");

                    // if still null then we need to create the appSettings node
                    if (null == appSettingsConfigurationSection)
                    {
                        // Create Node
                        XmlNode appSettingsNode = this.xDoc.CreateNode(XmlNodeType.Element, "appSettings", "");

                        // Add Node
                        ConfigurationSection.InsertAfter(appSettingsNode, this.xDoc.SelectSingleNode("/configuration/configSections"));

                        // Save Changes
                        this.Save();

                        // Cache the AppSettings node
                        appSettingsConfigurationSection = appSettingsNode;
                    }
                }

                return appSettingsConfigurationSection;
            }
        }

        /// <summary>
        /// XmlNode for the <connection> section of web.config.
        /// </summary>
        private XmlNode ConnectionConfigurationSection
        {
            get
            {
                if (connectionConfigurationSection == null)
                {
                    connectionConfigurationSection = this.xDoc.SelectSingleNode("/configuration/enterpriseManagement/connection");
                }
                return connectionConfigurationSection;
            }
        }

        /// <summary>
        /// XmlNode for the <encryption> section of web.config.
        /// </summary>
        private XmlNode EncryptionConfigurationSection
        {
            get
            {
                if (encryptionConfigurationSection == null)
                {
                    encryptionConfigurationSection = this.xDoc.SelectSingleNode("/configuration/enterpriseManagement/encryption");
                }
                return encryptionConfigurationSection;
            }
        }
    }

    /// <summary>
    /// Application Setting exposed through Web.Config
    /// </summary>
    public enum AppSetting
    {
        WindowlessMode
    };

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// All the strings used by the WebConsoleConfigurationManager class.
    /// </summary>
    /// <history>
    ///   [nathd] 8/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class Strings
    {
        public static string WindowlessAttributeName = "WindowlessMode";
        public static string AutoSignInAttributeName = "autoSignIn";
        public static string AutoSignOutIntervalAttributeName = "autoSignOutInterval";
    }
}
