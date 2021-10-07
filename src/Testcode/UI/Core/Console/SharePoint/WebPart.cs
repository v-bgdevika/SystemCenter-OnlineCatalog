// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WebPart.cs">
//  Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//  SharePoint WebPart for OM12
// </project>
// <summary>
//  WebPart class to handle specific functionality connection to SharePoint and configuring web parts
// </summary>
// <history>
//  [billhodg]  06Jun10: Created
// </history>
// -------------------
namespace Mom.Test.UI.Core.Console.SharePoint
{
    using System;
    using System.Xml;
    using Microsoft.SharePoint.Client;
    using Microsoft.SharePoint.Client.WebParts;
    using Mom.Test.UI.Core.Common; //Logging
    using Mom.Test.Infrastructure; //PasswordManager
    using Maui.Core;
    using Maui.Core.HtmlControls;
    using Maui.Core.WinControls;
    //using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;

    /// <summary>
    /// Used to setup to manipulate sharepoint, mostly through it's client API
    /// 
    /// </summary>
    public class MomWebPart
    {
        /// <summary>
        /// Which type of web part part do you want to add
        /// </summary>
        public enum WebPartType
        {
            Silverlight,
            OperationsManager
        }

        #region Private Members
        /// <summary>
        /// Global delay time for retry logic
        /// </summary>
        private const int delayTime = 3000;

        private static int createNewPageCount = 0;

        /// <summary>
        /// CHANGE/TODO: need web part name
        /// </summary>
        private const string webPartName = "XML Viewer";//"SCOM Portal WebPart";

        /// <summary>
        /// This is the XML definition of the SharePoint Silverlight webpart. 
        /// </summary>
        private const string silverlightWebPartDefinition =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><webParts><webPart xmlns=\"http://schemas.microsoft.com/WebPart/v3\">" +
                "   <metaData>" +
                "     <type name=\"Microsoft.SharePoint.WebPartPages.SilverlightWebPart, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" />" +
                        @"<importErrorMessage>Cannot import this Web Part.</importErrorMessage>
		            </metaData>
		            <data>
	                    <properties>" +
                            "<property name=\"Title\" type=\"string\">Silverlight Web Part</property>" +
                            "<property name=\"Description\" type=\"string\">A web part to display a Silverlight application.</property>" +
                        @"</properties>
		            </data>
	            </webPart></webParts>";

        /// <summary>
        /// These are Control ID's used by SharePoint for toolpane controls
        /// </summary>
        private string toolPaneConfigButtonID = "ctl00_MSOTlPn_EditorZone*editorPart1_LnkConfig";
        private string toolPaneOKID = "ctl00$MSOTlPn_EditorZone$MSOTlPn_OKBtn";
        private string toolPaneCancelID = "ctl00_MSOTlPn_EditorZone_MSOTlPn_CnclBtn";
        private string toolPaneSaveError = "MSOTlPn_ErrorTextCell";
        private string silverlightLinkID = "MsoFrameworkToolpartDefmsg*";
        private string silverlightWebPartConfigDialog = ";[UIA]Name='Silverlight Web Part'";
        private string editWebPartButton = "ctl00_PageStateActionButton";
        private string momWebPartDropDownMenuID = "WebPartctl00*MenuLink";
        private string momWebPartEditPropertyMenuItemID = "mp1_0_3_Anchor";
        private string toolPaneDashboardParamTextID = "ctl00_MSOTlPn_EditorZone_PortalWebPartEditorg*portalInitParametersTextBox";

        /// <summary>
        /// This is the XML definition of the SCOM SharePoint webpart
        /// </summary>
        private string momWebPartDefinition = LoadWebPartDefinition("SharePointWebPartDefinition.xml");

        /// <summary>
        /// We always use the same webpage name for testing
        /// ex: http://titan003d/testsite/SitePages/Home.aspx
        /// </summary>
        private const string webPageName = "Home.aspx";

        /// <summary>
        /// We always use the same test site name for testing
        /// </summary>
        private const string siteName = "TestSite";

        /// <summary>
        /// The port number in Sharepoint Central Administration URL is randomly generated during installation,
        /// so we need to read the registry key to get the correct url
        /// </summary>
        private const string regKeypathCentralAdminURL = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\15.0\WSS";

        /// <summary>
        /// Store the URL to the SharePoint server (ex: http://titan003D)
        /// </summary>
        private string sharePointUrl;

        /// <summary>
        /// the domain used for SharePoint connection credentials
        /// </summary>
        private string domain = "smx";

        /// <summary>
        /// The username used for SharePoint connection credentials
        /// </summary>
        private string userName = "asttest";

        /// <summary>
        /// The password used for SharePoint connection credentials
        /// this is updated in the username set method 
        /// </summary>
       
        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor - sets the sharePoint server URL, so it could throw a System.Net.WebException
        /// </summary>
        public MomWebPart()
        {
            this.sharePointUrl = SharePointUrl;
        }

        /// <summary>
        /// Constructor, sets the URL so it won't throw any exceptions
        /// </summary>
        /// <param name="Url"></param>
        public MomWebPart(string Url)
        {
            this.SharePointUrl = Url;
        }

        /// <summary>
        /// Constructor - set the URL with user and domain
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="UserName"></param>
        /// <param name="Domain"></param>
        public MomWebPart(string Url, string UserName, string Domain)
        {
            this.sharePointUrl = Url;
            this.UserName = UserName;
            this.Domain = Domain;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Domain that will be used in credential to connect to SharePoint
        /// </summary>
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        /// <summary>
        /// UserName that will be used in credential to connect to SharePoint
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set
            {
                this.password = PasswordManager.GetPassword(this.Domain, value);
                userName = value;
            }
        }

        /// <summary>
        /// Gets or Sets the SharePoint URL
        /// It gets the URL by testing all the servers in the topology to see if any respond
        /// to a SharePoint query
        /// If no SharePoint server is found it will throw a System.Net.WebException
        /// </summary>
        /// <exception cref="System.Net.WebException">if no sharepoint server is found</exception>
        public string SharePointUrl
        {
            get
            {
                //if it's not set, find the SharePoint Url
                if (String.IsNullOrEmpty(this.sharePointUrl))
                {
                    //loop through each machine in the topology
                    Topology.Initialize();
                    if (Topology.MomDevicesInfo != null)
                    {
                        foreach (Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo machine in Topology.MomDevicesInfo)
                        {
                            string url = "http://" + machine.MachineName + "/";

                            //Check for SharePoint on the machine
                            try
                            {
                                ClientContext clientContext = this.GetContext(url);
                                //Web web = clientContext.Site.RootWeb;
                                clientContext.ExecuteQuery();
                            }
                            catch (System.Net.WebException w)
                            {
                                Utilities.LogMessage("MomWebPart.SharePointUrl: tried to find SharePoint URL at '" + url + "' and failed: " + w.Message);
                                //Some time the Sharepoint is giving Http 500 error. So handle that we are supposing that there are only 2 machine used in the test
                                //hence assuming that the other machine than where the setup is running has the sharepoint URL if Setup is successful.
                                if (Environment.MachineName.Equals(machine.MachineName))
                                {
                                    continue;
                                }
                            }
                            catch (Microsoft.SharePoint.Client.ClientRequestException w)
                            {
                                Utilities.LogMessage("MomWebPart.SharePointUrl: tried to find SharePoint URL at '" + url + "' and failed: " + w.Message);
                                //Some time the Sharepoint is giving Http 500 error. So handle that we are supposing that there are only 2 machine used in the test
                                //hence assuming that the other machine than where the setup is running has the sharepoint URL if Setup is successful.
                                if (Environment.MachineName.Equals(machine.MachineName))
                                {
                                    continue;
                                }
                            }
                            catch (Exception w)
                            {
                                Utilities.LogMessage("MomWebPart.SharePointUrl: tried to find SharePoint URL at '" + url + "' and failed: " + w.Message);
                                //Some time the Sharepoint is giving Http 500 error. So handle that we are supposing that there are only 2 machine used in the test
                                //hence assuming that the other machine than where the setup is running has the sharepoint URL if Setup is successful.
                                if (Environment.MachineName.Equals(machine.MachineName))
                                {
                                    continue;
                                }
                            }

                            //if it works, set the URL and return
                            this.SharePointUrl = url;
                            Utilities.LogMessage("MomWebPart.SharePointUrl: Found SharePoint URL at '" + url);
                            break;
                        }

                        //if it doesn't work throw
                        if (this.sharePointUrl == null)
                            throw new System.Net.WebException("MomWebPart.SharePointUrl: No SharePoint Server found.");
                    }
                }

                return this.sharePointUrl.ToLowerInvariant();
            }

            set
            {
                this.sharePointUrl = value;
            }
        }

        #endregion Properties

        #region Test Methods

        /// <summary>
        /// Applies the Team Site template to the server if it's not already done.
        /// This is necessary for Web Parts to show up in the catelog
        /// The template applied is the "team site" template.
        /// </summary>
        public void ApplyServerTemplate()
        {
            string siteUrl = this.SharePointUrl;
            ClientContext clientContext = this.GetContext(siteUrl);

            ListTemplateCollection templates = clientContext.Web.ListTemplates;
            clientContext.Load(templates);
            clientContext.ExecuteQuery();

            if (templates.Count == 0)
            {
                // apply Team Site template to Server.
                // the set of template designations is not documented but can be found in  a blog
                // http://www.toddbaginski.com/blog/archive/2009/11/20/which-sharepoint-2010-site-template-is-right-for-me.aspx
                const string teamTemplate = "STS#0";
                clientContext.Web.ApplyWebTemplate(teamTemplate);
                clientContext.ExecuteQuery();
            }
        }

        /// <summary>
        ///  Creates a Test site if one doesn't exist
        ///  This function works but is not needed for our testing
        /// </summary>
        public void CreateSite()
        {
            //Check to see if the site already exists
            string siteUrl = this.SharePointUrl + "/" + MomWebPart.siteName;
            ClientContext clientContext = this.GetContext(siteUrl);
            Web website = clientContext.Web;

            clientContext.Load(
                website,
                owebsite => owebsite.Title,
                owebsite => owebsite.Created);
            try
            {
                clientContext.ExecuteQuery();

                //if this didn't throw an error return
                Utilities.LogMessage("MomWebPart.CreateSite: Site '" + siteUrl + "' already exists.");
                return;
            }
            catch (System.Net.WebException)
            {
                //ignore the error and go on to create the site
                Utilities.LogMessage("MomWebPart.CreateSite: Site '" + siteUrl + "' not found, creating it.");
            }

            // Create the site
            clientContext = this.GetContext(this.SharePointUrl);
            website = clientContext.Web;

            WebCreationInformation webCreateInfo = new WebCreationInformation();
            webCreateInfo.Description = "Test Site";
            webCreateInfo.Language = 1033;
            webCreateInfo.Title = MomWebPart.siteName;
            webCreateInfo.Url = MomWebPart.siteName;
            webCreateInfo.UseSamePermissionsAsParentSite = true;
            webCreateInfo.WebTemplate = "Team Site";

            Web newWebsite = website.Webs.Add(webCreateInfo);

            clientContext.Load(
                newWebsite,
                owebsite => owebsite.ServerRelativeUrl,
                owebsite => owebsite.Created);
            clientContext.ExecuteQuery();
        }

        /// <summary>
        /// Determines if our WebPart is installed on the SharePoint Server
        /// WARNING - if you don't apply the server template first, then no web parts will be visible
        /// example web address to check the web parts: http://titan003d/_catalogs/wp/Forms/AllItems.aspx
        /// </summary>
        /// <returns>true if exists</returns>
        public bool WebPartExists()
        {
            //get the web part gallery
            ClientContext clientContext = this.GetContext(this.SharePointUrl);
            List list = clientContext.Web.Lists.GetByTitle("Web Part Gallery");
            clientContext.Load(list);
            clientContext.ExecuteQuery();

            //get the list of web parts
            CamlQuery caml = new CamlQuery();
            caml.ViewXml = "<View/>";
            ListItemCollection listItems = list.GetItems(caml);
            clientContext.Load(listItems);
            clientContext.ExecuteQuery();

            //if our custom web part exists return true
            bool webPartFound = false;
            foreach (ListItem item in listItems)
            {
                //Utilities.LogMessage("Web Part: " + item["Title"]);
                if (item["Title"].ToString() == MomWebPart.webPartName)
                {
                    webPartFound = true;
                    break;
                }
            }

            return webPartFound;
        }

        /// <summary>
        /// Always uses the same webpage and simply overwrites it if it exists
        /// This will throw a WebException if the site is not created first
        /// </summary>
        public void AddWebPartToPage(WebPartType type)
        {
            /* ClientContext clientContext = this.GetContext(this.SharePointUrl);

            // Define SharePoint site page
            File file = clientContext.Web.GetFileByServerRelativeUrl("/SitePages/" + MomWebPart.webPageName);
            LimitedWebPartManager wpm = file.GetLimitedWebPartManager(PersonalizationScope.Shared);
            clientContext.Load(wpm.WebParts);
            clientContext.ExecuteQuery();

            WebPartDefinition newWpd;
            if (type == WebPartType.Silverlight)
                newWpd = wpm.ImportWebPart(silverlightWebPartDefinition);
            else
                newWpd = wpm.ImportWebPart(momWebPartDefinition);
            wpm.AddWebPart(newWpd.WebPart, "Bottom", 2);
            clientContext.Load(wpm);
            clientContext.ExecuteQuery();*/

            Browser browser = new Browser();
            string url = this.SharePointUrl + @"SitePages/" + MomWebPart.webPageName;
            // always check if there's existing instance to attach
            try
            {
                Utilities.LogMessage(
                    "MomWebPart.AddWebPartToPage :: Trying to find existing instance of SharePoint page, timeout 10 seconds 1.");
                browser.Find(url, Common.Constants.OneSecond * 10);
            }
            catch
            {
                Utilities.LogMessage(
                    "MomWebPart.AddWebPartToPage :: No existing SharePoint page instance found, launching a new instance 1.");
                browser.Launch(url);
            }
            HtmlDocument doc = browser.Document;
            Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Click edit Button on Home.aspx.");
            this.ClickBrowserElement(doc, "a", "id", this.editWebPartButton, 0, true);
            Maui.Core.Utilities.Sleeper.Delay(30000);
            Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Adding the Webpart to Home.aspx.");
            this.ClickBrowserElement(doc, "a", "title", "Insert", 0, true);
            this.ClickBrowserElement(doc, "a", "id", "Ribbon.EditingTools.CPInsert.WebParts.WebPart-Large", 0, true);
            try
            {
                this.ClickBrowserElement(doc, "div", "title", "Microsoft System Center", 0, false);
            }
            catch (HtmlControl.Exceptions.ControlNotFoundException e)
            {
                // If the Control is not found means that the the Enable-SPFeature was not successful from the PowerShell and hence trying to Enable the webpart from UI
                Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Operation Manager web part is not enabled.");
                this.ClickBrowserElement(doc, "a", "title", "Save", 0, true);
                Maui.Core.Utilities.Sleeper.Delay(60000);
                browser.Quit();
                Maui.Core.Utilities.Sleeper.Delay(30000);
                browser = new Browser();
                url = this.SharePointUrl + "/_layouts/15/ManageFeatures.aspx?Scope=Site";
                // always check if there's existing instance to attach
                try
                {
                    Utilities.LogMessage(
                        "MomWebPart.AddWebPartToPage :: Trying to find existing instance of SharePoint page, timeout 10 seconds 2.");
                    browser.Launch(url);
                }
                catch
                {
                    Utilities.LogMessage(
                        "MomWebPart.AddWebPartToPage :: No existing SharePoint page instance found, launching a new instance 2.");
                    browser.Find(url, Common.Constants.OneSecond * 10);
                }
                Maui.Core.Utilities.Sleeper.Delay(60000);
                doc = browser.Document;
                this.ClickBrowserElement(doc, "input", "name", "ctl00$PlaceHolderMain$featact$rptrFeatureList$ctl25$ctl00$btnActivate", 0, false);
                Maui.Core.Utilities.Sleeper.Delay(60000);
                browser.Quit();
                Maui.Core.Utilities.Sleeper.Delay(30000);
                browser = new Browser();

                url = this.SharePointUrl + @"SitePages/" + MomWebPart.webPageName;
                // always check if there's existing instance to attach
                try
                {
                    Utilities.LogMessage(
                        "MomWebPart.AddWebPartToPage :: Trying to find existing instance of SharePoint page, timeout 10 seconds 3.");
                    browser.Launch(url);
                }
                catch
                {
                    Utilities.LogMessage(
                        "MomWebPart.AddWebPartToPage :: No existing SharePoint page instance found, launching a new instance 3.");
                    browser.Find(url, Common.Constants.OneSecond * 10);
                }

                doc = browser.Document;
                Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Click edit Button on Home.aspx.");
                this.ClickBrowserElement(doc, "a", "id", this.editWebPartButton, 0, true);
                Maui.Core.Utilities.Sleeper.Delay(30000);
                Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Adding the Webpart to Home.aspx.");
                this.ClickBrowserElement(doc, "a", "title", "Insert", 0, true);
                this.ClickBrowserElement(doc, "a", "id", "Ribbon.EditingTools.CPInsert.WebParts.WebPart-Large", 0, true);
                this.ClickBrowserElement(doc, "div", "title", "Microsoft System Center", 0, false);
            }

            this.ClickBrowserElement(doc, "div", "title", "Operations Manager Dashboard Viewer Web Part", 0, false);
            HtmlButton button = new HtmlButton(doc, 3, "button");
            button.Focus();
            button.Click();

            Maui.Core.Utilities.Sleeper.Delay(90000);
            Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Clicking Save.");
            this.ClickBrowserElement(doc, "a", "title", "Save", 0, true);
            Maui.Core.Utilities.Sleeper.Delay(120000);
            browser.Quit();
            Utilities.LogMessage("MomWebPart.AddWebPartToPage :: Exiting Method.");
        }

        /// <summary>
        /// gets config values for web part
        /// </summary>
        /// <param name="index">index for webpart to target</param>
        /// <returns></returns>
        public WebPartConfigurationParameters GetWebPartProperties(int index, WebPartType type)
        {
            WebPartConfigurationParameters configurationParameters = new WebPartConfigurationParameters();

            // open the web page
            Browser browser = new Browser();
            string url = this.SharePointUrl + @"SitePages/" + MomWebPart.webPageName;
            // always check if there's existing instance to attach
            try
            {
                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: Trying to find existing instance of SharePoint page, timeout 10 seconds.");
                browser.Find(url, Common.Constants.OneSecond * 10);
            }
            catch
            {
                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: No existing SharePoint page instance found, launching a new instance.");
                browser.Launch(url);
            }
            Maui.Core.Utilities.Sleeper.Delay(30000);
            HtmlDocument doc = browser.Document;

            if (type == WebPartType.Silverlight)
            {
                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: click on the\"open the toolpane\" link.");
                this.ClickBrowserElement(doc, "a", "id", this.silverlightLinkID, index, false);

                //wait for the toolpane to open
                browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

                //click the configure button
                this.ClickBrowserElement(doc, "input", "id", this.toolPaneConfigButtonID, 0, true);

                //when the title bar says "Silverlight Web Part"
                App app = browser.Application;
                Window silverlightConfigDialog = new Window(app.MainWindow, new QID(silverlightWebPartConfigDialog), ConsoleConstants.DefaultDialogTimeout);

                //get the URL
                TextBox urlText = new TextBox(silverlightConfigDialog, new QID(";[UIA]Instance='1'"));
                configurationParameters.SilverlightUrl = urlText.Text;

                //hit cancel - using send keys because SharePoint doesn't have ID's on it's silverlight controls
                silverlightConfigDialog.SendKeys("{Tab}{Tab}{Enter}");

                //Button silverlightConfigCancel = new Button(app.MainWindow, new QID("[UIA]Name='Cancel'"));
                //silverlightConfigCancel.Click();

                //wait for dialog close
                silverlightConfigDialog.ScreenElement.WaitForGone(ConsoleConstants.DefaultDialogTimeout, 100);
            }
            else // OM Web part
            {
                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: Click edit on web page.");
                this.ClickBrowserElement(doc, "a", "id", this.editWebPartButton, 0, true);
                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: click on the SCOM Portal WebPart drop down menu icon.");
                this.ClickBrowserElement(doc, "a", "id", this.momWebPartDropDownMenuID, index, false);

                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: click on \"Edit Web Part\" menu item link.");
                this.ClickBrowserElement(doc, "a", "id", this.momWebPartEditPropertyMenuItemID, 0, true);

                //wait for the toolpane to open
                browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

                Utilities.LogMessage("MomWebPart.GetWebPartProperties :: get Dashboard Parameters.");
                HtmlTextBox dashboardParamTextbox = new HtmlTextBox(new HtmlControl(doc, "input", "id", this.toolPaneDashboardParamTextID, 0, Maui.Core.Utilities.StringMatchSyntax.WildCard));
                configurationParameters.DashboardParameters = dashboardParamTextbox.Text;
            }

            //press web config cancel
            HtmlButton toolpaneCancel = new HtmlButton(doc, this.toolPaneCancelID);
            toolpaneCancel.Focus();
            toolpaneCancel.Click();

            //wait for toolpane to close (optional)
            browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

            //close IE
            //browser.Quit();

            return configurationParameters;
        }

        /// <summary>
        /// Updates the properties of the the webpart for a particular instance
        /// </summary>
        /// <param name="index"></param>
        /// <param name="configurationParameters"></param>
        /// <exception cref="Exception">if unable to set properties</exception>
        public void SetWebPartProperties(int index, WebPartType type, WebPartConfigurationParameters configurationParameters)
        {
            // open the web page
            Browser browser = new Browser();
            string url = this.SharePointUrl + @"SitePages/" + MomWebPart.webPageName;
            // always check if there's existing instance to attach
            try
            {
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: Trying to find existing instance of SharePoint page, timeout 10 seconds.");
                browser.Find(url, Common.Constants.OneSecond * 10);
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: sleep 3 minutes for an unexpected windows installer");
                //Checking if the unexpected windows installer is already handled, to decrease this waiting time.
                if (createNewPageCount == 0)
                {
                    //sleep 3 minutes for an unexpected windows installer
                    Maui.Core.Utilities.Sleeper.Delay(180000);
                    browser.Refresh();
                    Maui.Core.Utilities.Sleeper.Delay(60000);    //increase delay time to one minute to wait for dashboard ready
                }
            }
            catch
            {
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: No existing SharePoint page instance found, launching a new instance.");
                browser.Launch(url);
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: sleep 3 minutes for an unexpected windows installer");
                if (createNewPageCount == 0)
                {
                    //sleep 3 minutes for an unexpected windows installer
                    Maui.Core.Utilities.Sleeper.Delay(180000);
                    browser.Refresh();
                    Maui.Core.Utilities.Sleeper.Delay(delayTime);
                }
            }
            HtmlDocument doc = browser.Document;

            if (type == WebPartType.Silverlight)
            {
                //blank value won't be accepted, so we skip it. It will assert later as an invalid property value.
                if (!String.IsNullOrEmpty(configurationParameters.SilverlightUrl))
                {
                    Utilities.LogMessage("MomWebPart.SetWebPartProperties :: click on the \"open the toolpane\" link.");
                    this.ClickBrowserElement(doc, "a", "id", this.silverlightLinkID, index, false);

                    Utilities.LogMessage("MomWebPart.SetWebPartProperties :: wait for the toolpane to open.");
                    browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

                    Utilities.LogMessage("MomWebPart.SetWebPartProperties :: click the configure button.");
                    this.ClickBrowserElement(doc, "input", "id", this.toolPaneConfigButtonID, 0, true);

                    //when the title bar says "Silverlight Web Part"
                    App app = browser.Application;
                    Window silverlightConfigDialog = new Window(app.MainWindow, new QID(silverlightWebPartConfigDialog), ConsoleConstants.DefaultDialogTimeout);

                    //set the URL
                    TextBox urlText = new TextBox(silverlightConfigDialog, new QID(";[UIA]Instance='1'"));
                    urlText.ScreenElement.SendKeys(configurationParameters.SilverlightUrl);

                    //hit OK - using send keys because SharePoint doesn't have ID's on it's silverlight controls
                    silverlightConfigDialog.SendKeys("{Tab}{Enter}");

                    //wait for dialog close
                    silverlightConfigDialog.ScreenElement.WaitForGone(ConsoleConstants.DefaultDialogTimeout, 100);
                }
            }
            else // OM Web part
            {
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: click the edit web part.");
                this.ClickBrowserElement(doc, "a", "id", this.editWebPartButton, 0, true);
                browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: click on the SCOM Portal WebPart drop down menu icon.");
                this.ClickBrowserElement(doc, "a", "id", this.momWebPartDropDownMenuID, index, false);
                Maui.Core.Utilities.Sleeper.Delay(60000);
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: click on \"Edit Web Part\" menu item link.");
                this.ClickBrowserElement(doc, "a", "id", this.momWebPartEditPropertyMenuItemID, 0, true);
                Maui.Core.Utilities.Sleeper.Delay(90000);
                Utilities.LogMessage("MomWebPart.SetWebPartProperties :: set Dashboard Parameters.");
                HtmlTextBox dashboardParamTextbox = new HtmlTextBox(new HtmlControl(doc, "input", "id", this.toolPaneDashboardParamTextID, 0, Maui.Core.Utilities.StringMatchSyntax.WildCard));
                dashboardParamTextbox.Text = configurationParameters.DashboardParameters;
                Maui.Core.Utilities.Sleeper.Delay(90000);
                // browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);
            }

            //press web config OK
            HtmlButton toolpaneOK = new HtmlButton(doc, this.toolPaneOKID);
            toolpaneOK.Focus();
            toolpaneOK.Click();
            Maui.Core.Utilities.Sleeper.Delay(90000);
            Utilities.LogMessage("MomWebPart.SetWebPartProperties :: Click Save.");
            this.ClickBrowserElement(doc, "a", "title", "Save", 0, true);
            Maui.Core.Utilities.Sleeper.Delay(120000);
            //check to see if there's an error message after setting the properties
            bool errorFound = false;
            try
            {
                browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);
                HTMLTableCell cell = new HTMLTableCell(doc, toolPaneSaveError);
                if (!cell.InnerText.Equals(null))
                {
                    errorFound = true;
                }
            }
            catch
            {
                //if the error was thrown there is no error message and we are good.
            }

            //wait for toolpane to close (optional)
            browser.WaitForReady(ConsoleConstants.DefaultDialogTimeout);

            //close IE
            //browser.Quit();

            if (errorFound)
                throw new Exception("SetWebPartProperties: Unable to set properties");
            Utilities.LogMessage("MomWebPart.SetWebPartProperties :: Exit Method.");
        }

        /// <summary>
        /// Delete all the web parts on a page
        /// This allows us to revert to a known state
        /// We always use the same home page for this operation
        /// </summary>
        public void DeleteAllWebParts()
        {
            Utilities.LogMessage("MomWebPart.DeleteAllWebParts :: Deleting All Web parts.");
            try
            {
                ClientContext clientContext = this.GetContext(this.sharePointUrl);
                File file = clientContext.Web.GetFileByServerRelativeUrl("/SitePages/" + MomWebPart.webPageName);
                LimitedWebPartManager limitedWebPartManager =
                    file.GetLimitedWebPartManager(PersonalizationScope.Shared);

                clientContext.Load(limitedWebPartManager.WebParts);
                clientContext.ExecuteQuery();

                for (int i = 0; i < limitedWebPartManager.WebParts.Count; i++)
                {
                    limitedWebPartManager.WebParts[i].DeleteWebPart();
                }

                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                // Sometimes the Page gets created and the WebPart is not added as its not enabled, the above code will throw exception again so not point in creating the page second time.
                if (createNewPageCount == 0)
                {
                    createNewPageCount = 1;
                    // The Home.aspx is not available until a new page is added to the sharepoint
                    Browser browser = new Browser();
                    Maui.Core.Utilities.Sleeper.Delay(60000);
                    browser.Quit();
                    Maui.Core.Utilities.Sleeper.Delay(60000);
                    CreateNewPage();
                }
            }
            Utilities.LogMessage("MomWebPart.DeleteAllWebParts ::Exiting Method.");
        }

        /// <summary>
        /// We are using the Home.aspx page for testing the scenarios 
        /// The Home.aspx page is not created until a new page is added to the Site, this method adds a new page "TestPage.aspx"
        /// </summary>
        private void CreateNewPage()
        {

            Utilities.LogMessage("MomWebPart.CreateNewPage :: Need to create a page so that the Home.aspx is available!!");
            Browser browser = new Browser();
            String url = this.SharePointUrl + "_layouts/15/CreateV4PagesLib.aspx";
            // always check if there's existing instance to attach
            try
            {
                Utilities.LogMessage("MomWebPart.CreateNewPage :: Trying to find existing instance of SharePoint page, timeout 10 seconds.");
                browser.Find(url, Common.Constants.OneSecond * 10);
                Utilities.LogMessage("MomWebPart.CreateNewPage :: sleep 3 minutes for an unexpected windows installer");
                //sleep 3 minutes for an unexpected windows installer
                Maui.Core.Utilities.Sleeper.Delay(180000);
                browser.Refresh();
                Maui.Core.Utilities.Sleeper.Delay(60000);    //increase delay time to one minute to wait for dashboard ready
            }
            catch
            {
                Maui.Core.Utilities.Sleeper.Delay(60000);
                Utilities.LogMessage("MomWebPart.CreateNewPage :: Trying to find existing instance of SharePoint page, timeout 10 seconds.");
                browser.Launch(url);
                Utilities.LogMessage("MomWebPart.CreateNewPage :: sleep 3 minutes for an unexpected windows installer");
                //sleep 3 minutes for an unexpected windows installer
                Maui.Core.Utilities.Sleeper.Delay(180000);
                browser.Refresh();
                Maui.Core.Utilities.Sleeper.Delay(60000);    //increase delay time to one minute to wait for dashboard ready
            }
            HtmlDocument doc = browser.Document;
            Maui.Core.Utilities.Sleeper.Delay(60000);
            Utilities.LogMessage("MomWebPart.CreateNewPage :: Clicking on Create New Page.");
            this.ClickBrowserElement(doc, "input", "id", "ctl00_PlaceHolderMain_btnConfirm", 0, true);
            Maui.Core.Utilities.Sleeper.Delay(120000);
            Utilities.LogMessage("MomWebPart.CreateNewPage :: Filling in the textbox with the test page to be created.");
            HtmlTextBox createPageTextBox = new HtmlTextBox(new HtmlControl(doc, "input", "id", "ctl00_PlaceHolderMain_nameInput", 0, Maui.Core.Utilities.StringMatchSyntax.WildCard));
            createPageTextBox.Text = "TestPage";
            try
            {
                this.ClickBrowserElement(doc, "input", "id", "ctl00_PlaceHolderMain_createButton", 0, true);
                Maui.Core.Utilities.Sleeper.Delay(90000);
                Utilities.LogMessage("MomWebPart.CreateNewPage :: Click Save to save the test page.");
                this.ClickBrowserElement(doc, "a", "title", "Save", 0, true);
                Maui.Core.Utilities.Sleeper.Delay(90000);
            }
            catch (HtmlControl.Exceptions.ControlNotFoundException cne)
            {
                Utilities.LogMessage("MomWebPart.CreateNewPage :: No need to fail the test even if an exception is thrown.");
            }
            browser.Quit();
            Maui.Core.Utilities.Sleeper.Delay(30000);
            try
            {
                ClientContext clientContext = this.GetContext(this.sharePointUrl);
                File file = clientContext.Web.GetFileByServerRelativeUrl("/SitePages/" + MomWebPart.webPageName);
                LimitedWebPartManager limitedWebPartManager =
                    file.GetLimitedWebPartManager(PersonalizationScope.Shared);

                clientContext.Load(limitedWebPartManager.WebParts);
                clientContext.ExecuteQuery();

                for (int i = 0; i < limitedWebPartManager.WebParts.Count; i++)
                {
                    limitedWebPartManager.WebParts[i].DeleteWebPart();
                }
                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                Utilities.LogMessage("MomWebPart.CreateNewPage :: Neglecting the Exception as if we are not able to delete the web part then also the test should run fine.");
            }

            Utilities.LogMessage("MomWebPart.CreateNewPage :: Exiting CreateNewPage.");
        }

        /// <summary>
        /// Creates a ClientContext and applies the credential to it based on the
        /// current username and domain.
        /// </summary>
        /// <param name="Url">the SharePoint URL to connect to</param>
        /// <returns>the context</returns>
        private ClientContext GetContext(string Url)
        {
            ClientContext ctx = new ClientContext(Url);

            System.Net.NetworkCredential cred = new System.Net.NetworkCredential
                (this.UserName, this.password, this.Domain);
            ctx.Credentials = cred;
            return ctx;
        }

        /// <summary>
        /// Clicks on an HTML element as specified by an HTML tag in the doc
        /// </summary>
        /// <param name="doc">HtmlDocument to search on</param>
        /// <param name="tagName">element name to look for ex: 'a' for hypertext link or 'input' for button</param>
        /// <param name="attribute">the attribute name in the element that identifies this element. Ex: id</param>
        /// <param name="attributeValue">the attribute value that identifies this element</param>
        /// <param name="index">a zero based index of the element if more than one match </param>
        /// <param name="troublesome">some IE elements require a slight pause and to set focus, set this to true if that is required</param>
        private void ClickBrowserElement(HtmlDocument doc, string tagName, string attribute, string attributeValue, int index, bool troublesome)
        {
            HtmlControl ieControl = null;
            int retry = 0;
            int delay = 10000;
            int maxTries = Common.Constants.DefaultDialogTimeout / delayTime;
            while (ieControl == null && retry < maxTries)
            {
                retry++;
                try
                {
                    ieControl = new HtmlControl(doc, tagName, attribute, attributeValue, 0, Maui.Core.Utilities.StringMatchSyntax.WildCard);
                    break;
                }
                catch (HtmlControl.Exceptions.ControlNotFoundException)
                {
                    if (retry == maxTries)
                    {
                        throw;
                    }
                    else
                    {
                        Utilities.LogMessage("MomWebPart.ClickBrowserElement :: control not found, retry " + retry);
                        Maui.Core.Utilities.Sleeper.Delay(delay);  //extend delay time to 10 seconds to workarround an unexpected windows installer
                    }
                }
            }

            if (troublesome)
            {
                //intermittant timing issue with IE here requires a small wait
                Maui.Core.Utilities.Sleeper.Delay(Common.Constants.OneSecond);
                ieControl.Focus();
            }
            ieControl.Click();
        }

        /// <summary>
        /// Get configuration of OM Webpart Setup properties
        /// </summary>
        /// <returns></returns>
        public WebPartConfigurationParameters GetOMWebpartSetupProperties(string sharepointServerName)
        {
            WebPartConfigurationParameters configurationParameters = new WebPartConfigurationParameters();
            try
            {
                //get the correct Sharepoint Central Administration URL
                string sharepointCentralAdminURL = Microsoft.EnterpriseManagement.Test.BaseCommon.Registry
                    .RegistryHelper.QueryRegistryString(
                        sharepointServerName,
                        MomWebPart.regKeypathCentralAdminURL,
                        "CentralAdministrationURL");
                ClientContext clientContext = new ClientContext(sharepointCentralAdminURL);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(this.UserName, this.password, this.Domain);
                clientContext.Credentials = credentials;
                //get first item in "SCOM Web Consoles" list
                ListItem itemWebConsole = this.GetFisrtItemInList(clientContext,
                    "Operations Manager Web Console Environments");
                //get the configuration info
                configurationParameters.Title = itemWebConsole["Title"].ToString();
                configurationParameters.HostUri = itemWebConsole["HostUri"].ToString();
                configurationParameters.Source = itemWebConsole["Source"].ToString();
            }
            catch (System.Net.WebException w)
            {
                //Used NetworkCredential which should prevent Internal 500 error. But still catching it as the 500 error does not
                //affect the tests. : http://stackoverflow.com/questions/14332498/net-client-object-model-in-sharepoint-returns-500-internal-server-error-while-e
                Utilities.LogMessage("MomWebPart.GetOMWebpartSetupProperties :: Thrown 500 Internal Server Error");
            }
            catch (Exception e)
            {
                //This is just a preventive fix. As the Test will not be affected even if any error occurs in the code.
                Utilities.LogMessage("MomWebPart.GetOMWebpartSetupProperties :: Thrown Error" + e.Message);
            }
            return configurationParameters;
        }

        /// <summary>
        /// Set configuration of OM Webpart Setup properties
        /// </summary>
        /// <param name="configurationParameters"></param>
        public void SetOMWebpartSetupProperties(WebPartConfigurationParameters configurationParameters, string sharepointServerName)
        {
            //get the correct Sharepoint Central Administration URL
            string sharepointCentralAdminURL = Microsoft.EnterpriseManagement.Test.BaseCommon.Registry.RegistryHelper.QueryRegistryString(
                sharepointServerName,
                MomWebPart.regKeypathCentralAdminURL,
                "CentralAdministrationURL");
            ClientContext clientContext = new ClientContext(sharepointCentralAdminURL);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(this.UserName, this.password, this.Domain);
            clientContext.Credentials = credentials;
            //get first item in "SCOM Web Consoles" list
            try
            {
                ListItem itemWebConsole = this.GetFisrtItemInList(clientContext,
                    "Operations Manager Web Console Environments");
                //set the configuration info
                itemWebConsole.ParseAndSetFieldValue("Title", configurationParameters.Title);
                itemWebConsole.ParseAndSetFieldValue("HostUri", configurationParameters.HostUri);
                itemWebConsole.ParseAndSetFieldValue("Source", configurationParameters.Source);
                itemWebConsole.Update();
            }
            catch (Microsoft.SharePoint.Client.CollectionNotInitializedException e)
            {
                Utilities.LogMessage("MomWebPart.SetOMWebpartSetupProperties :: Thrown 500 Internal Server Error");
            }
            try
            {
                clientContext.ExecuteQuery();
            }
            catch (System.Net.WebException w)
            {
                Utilities.LogMessage("MomWebPart.SetOMWebpartSetupProperties :: Thrown 500 Internal Server Error");
            }
        }

        /// <summary>
        /// Get the first entry in Sharepoint list
        /// </summary>
        /// <param name="clientContext">Sharepoint ClientContext</param>
        /// <param name="listName">The name of the Sharepoint list</param>
        /// <returns>The first entry of the list</returns>
        private ListItem GetFisrtItemInList(ClientContext clientContext, string listName)
        {
            List list = clientContext.Web.Lists.GetByTitle(listName);
            ListItemCollection items = list.GetItems(new CamlQuery());
            clientContext.Load(items);
            try
            {
                clientContext.ExecuteQuery();
            }
            catch (System.Net.WebException w)
            {
                Utilities.LogMessage("MomWebPart.GetFisrtItemInList :: Thrown 500 Internal Server Error");
            }
            catch (Microsoft.SharePoint.Client.CollectionNotInitializedException e)
            {
                Utilities.LogMessage("MomWebPart.SetOMWebpartSetupProperties :: CollectionNotInitializedException");
            }

            //get the first item in the list
            return items[0];
        }

        #endregion Test Methods

        private static string LoadWebPartDefinition(string xmlFileURL)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileURL);

            System.IO.StringWriter sw = new System.IO.StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);

            return sw.ToString();
        }

        /// <summary>
        /// uses sharepoint API to delete page
        /// This method is no longer needed because CreatePage simply replaces the page
        /// </summary>
        /// <param name="Url"></param>
        //        public void DeletePage(string Url)
        //        {   
        //            ClientContext clientContext = this.GetContext(this.SharePointUrl);

        //            File oFile = clientContext.Web.geGetFileByServerRelativeUrl(this.webPageName);

        //            clientContext.Web.Webs.

        //            List list = clientContext.Web.Lists.GetByTitle("Client API Test List");
        //            CamlQuery camlQuery = new CamlQuery();
        //            camlQuery.ViewXml =
        //                @"<View>
        //                <Query>
        //                  <Where>
        //                    <Eq>
        //                      <FieldRef Name='Category'/>
        //                      <Value Type='Text'>Test</Value>
        //                    </Eq>
        //                  </Where>
        //                </Query>
        //                <RowLimit>100</RowLimit>
        //              </View>";
        //            ListItemCollection listItems = list.GetItems(camlQuery);
        //            clientContext.Load(
        //                 listItems,
        //                 items => items.Include(
        //                     item => item["Title"]));
        //            clientContext.ExecuteQuery();
        //            foreach (ListItem listItem in listItems.ToList())
        //                listItem.DeleteObject();
        //            clientContext.ExecuteQuery();

        //        }

    }
}
