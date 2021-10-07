// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Browser.cs">
//  Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//  WebConsole for OM12
// </project>
// <summary>
//  URI class to hand IE specific functionality for web console testing
// </summary>
// <history>
//  [billhodg]  30Apr10: Created
// </history>
// -------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using Maui.Core;
    using Maui.InternetExplorer;
    //using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using System;
    //using System.Net;
    //using mshtml;
    //using Interop.ShDocVw;
    #endregion

    /// <summary>
    /// Used to indicate which browser the Browser class is using
    /// </summary>
    public enum BrowserType
    {
        InternetExplorer,
        FireFox
    }

    /// <summary>
    /// The Browser class is a wrapper around functionality to manipiulate the Browser shell
    /// For IE this is implemented via Maui's IEApp (which in turn uses SHDocVw for the shell 
    /// and mshtml for the DOM. 
    /// In the future, this class can act as a facade for FireFox support as well, using 
    /// http://toolbox/FireFoxAutomationEngine in the meantime NotImplementedException will 
    /// be thrown if you try to use this for FireFox.
    /// </summary>
    public class Browser
    {
        #region Internal Variables
        /// <summary>
        /// the Browser class encapsulates IEApp to interact with Internet Explorer
        /// </summary>
        private IEApp ieApp = null;

        /// <summary>
        /// BrowserType is used to choose between IE and FireFox
        /// </summary>
        private BrowserType browserType = BrowserType.InternetExplorer;

        /// <summary>
        /// The default page load time is 30 seconds (in milliseconds)
        /// </summary>
        private int pageLoadWaitTime = 30000;
        #endregion

        #region Constructors

        /// <summary>
        /// browserType defaults to IE
        /// Constructors do NOT launch the browser
        /// </summary>        
        public Browser()
        {
        }

        /// <summary>
        /// allows caller to choose browser type
        /// Constructors do NOT launch the browser
        /// </summary>
        /// <param name="Type">IE or FireFox</param>
        public Browser(BrowserType Type)
        {
            this.browserType = Type;

            if (Type == BrowserType.FireFox)
                throw new NotImplementedException("FireFox support is not yet implemented");
        }

        #endregion

        #region Properties
        /// <summary>
        /// Typical time to wait for a page to load in milliseconds
        /// Defaults to 30sec
        /// </summary>
        public int PageLoadWaitTime
        {
            get { return pageLoadWaitTime; }
            set { pageLoadWaitTime = value; }
        }
        /// <summary>
        /// Gets the BrowserType
        /// Set this property through the constructor
        /// </summary>
        public BrowserType Type
        {
            get { return this.browserType; }
        }
        /// <summary>
        /// Gets the current Application. 
        /// Setting the application is done in the constructor (if needed)
        /// </summary>
        public App Application
        {
            get
            {
                return (App)this.ieApp;
            }
        }

        /// <summary>
        /// The HTMLDocument is necessary for some IE specific automation
        /// </summary>
        public HtmlDocument Document
        {
            get
            {
                return new HtmlDocument(this.ieApp.Document);
            }
        }

        /// <summary>
        /// Gets the URL from the Address bar
        /// Setting this property will wait for the page to load (mostly)
        /// 
        /// Maui is not very good about setting the URL to one address after another
        /// it is best to set it first to about:blank, then to your page
        /// very active pages like microsoft.com may cause timing issues.
        /// 
        /// Also, if you change the URL, IE doesn't add it to the cache, so Back and Forward don't do anything.
        /// </summary>
        public string FullUrl
        {
            get
            {
                return this.ieApp.LocationURL;
            }
            set
            {
                //bug#233579
                this.ieApp.WaitForIE(Constants.OneMinute * 2);
                //uses cache, set to wait for page load
                this.ieApp.LoadPage(value, true, true);
            }
        }

        /// <summary>
        /// Gets URL of SharePoint and give more wait time for IE to complete loading page since it could take
        /// around 2 minutes to finish loading the SharePoint page at the first time
        /// </summary>
        public string SharePointFullUrl
        {
            get
            {
                return this.ieApp.LocationURL;
            }
            set
            {
                try
                {
                    //uses cache, set to wait for page load
                    this.ieApp.LoadPage(value, true, true);
                }
                catch (Maui.InternetExplorer.IEApp.Exceptions.WaitForReadyException)
                {
                    //it could take 2 minutes to complete loading the SharePoint home page for the 1st time, so adding a wait
                    this.ieApp.WaitForIE(Constants.OneMinute * 2);
                }
            }
        }

        /// <summary>
        /// The Uri is just whatever the URL has after the '#' sign
        /// This helper method returns that Uri and can add a new Uri to the existing URL.
        /// 
        /// If there is no # sign the full URL is returned
        /// if there is an existing # sign during a set method, then everything after it is replaced.
        /// </summary>
        public string Uri
        {
            get
            {
                string url = this.FullUrl;
                if (url.IndexOf('#') >= 0)
                    return url.Split('#')[1];
                else
                    return url;
            }
            set
            {
                string url = this.FullUrl;
                string uri = value;
                if (!uri.StartsWith("#"))
                    uri = "#" + uri;
                if (url.IndexOf('#') >= 0)
                    this.FullUrl = url.Split('#')[0] + uri;
                else
                    this.FullUrl = url + uri;
            }
        }

        /// <summary>
        /// The state reported by IE (see http://msdn.microsoft.com/en-us/library/bb268229(VS.85).aspx)
        /// </summary>
        public string ReadyState
        {
            get
            {
                return this.ieApp.Document.readyState;
            }
        }

        #endregion

        #region Waiters

        /// <summary>
        /// Waits for a URL to load when this happens outside the test code
        /// The URL is a contains comparison - so "about" is the found for "about:blank"
        /// In this overload the defaul PageLoadWaitTime is used
        /// </summary>
        /// <param name="Url">Url piece to look for</param>
        public void WaitForUrl(string url)
        {
            this.WaitForUrl(url, this.PageLoadWaitTime);
        }

        /// <summary>
        /// Waits for a URL to load when this happens outside the test code
        /// The URL is a contains comparison - so "about" is the found for "about:blank"
        /// In this overload the defaul PageLoadWaitTime is used 
        /// </summary>
        /// <param name="url">Url piece to look for</param>
        /// <param name="waitTime">time in milliseconds to look</param>
        /// <exception cref="ArgumentOutOfRangeException">if waittime is <= 0</exception>
        /// <exception cref="TimeoutException">if the URL didn't change in the waittime</exception>
        public void WaitForUrl(string url, int waitTime)
        {
            if (waitTime <= 0)
                throw new ArgumentOutOfRangeException("waitTime", "WaitTime must be a positive integer");

            string current = this.FullUrl;
            for (int count = 0; !current.Contains(url) && count <= 10; count++)
            {
                Maui.Core.Utilities.Sleeper.Delay(waitTime / 10);
                current = this.FullUrl;
            }

            if (!current.Contains(url))
                throw new TimeoutException("Url didn't change to '" + url + "' in time " + waitTime.ToString());
        }

        /// <summary>
        /// Waits for the Browser to be Ready
        /// This can take the entire timeout on web pages where the page is doing animations or loading data
        /// </summary>
        /// <param name="WaitTime">milliseconds to wait</param>
        /// <exception cref="ArgumentOutOfRangeException">If waittime is <= 0</exception>
        /// <exception cref="WaitForReadyException">if IE is not ready in the timeout</exception>
        public void WaitForReady(int waitTime)
        {
            if (waitTime <= 0)
            {
                throw new ArgumentOutOfRangeException("waitTime", "WaitTime must be a positive integer");
            }

            if (null == this.ieApp)
            {
                return;
            }

            this.ieApp.WaitForIE(waitTime);
        }
        #endregion

        #region Launch and Find methods
        /// <summary>
        /// Launches the browser and sets URL to a blank page
        /// Does not wait for the page to load or browser to be ready
        /// </summary>
        public void Launch()
        {
            // 64-bit IE is launched by default on a 64-bit OS... SilverLight is not support on 
            // this IE version.
            int maxRetry = 5;
            int retry = 0;
            string path;
            string architecture = System.Environment.GetEnvironmentVariable("processor_architecture");

            switch (architecture.ToLowerInvariant())
            {
                case "x86":
                    path = System.Environment.GetEnvironmentVariable("ProgramFiles") +
                        @"\Internet Explorer\iexplore.exe";
                    break;

                case "amd64":
                    path = System.Environment.GetEnvironmentVariable("ProgramFiles(x86)") +
                        @"\Internet Explorer\iexplore.exe";
                    break;

                default:
                    throw new Exception("Unknown Processor Architecture '" + architecture + "'");
            }

            // We have to use System.Diagnostics.Process to launch Internet Explorer
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path;
            p.Start();

            // Attach the correctly instance of IE
            for (retry = 0; retry < maxRetry; ++retry)
            {
                try
                {
                    Window parent = new Window(new QID(";[UIA]ClassName='IEFrame'"), 5000);
                    Utilities.LogMessage("Internet Explorer process ID is " + parent.Extended.ProcID);
                    App app = new App(parent.Extended.ProcID);  
                    this.Find(app, Constants.OneSecond * 15);
                    break;
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage("Browser.Launch :: IE Not Found, " + ex.Message);
                    Utilities.LogMessage("Retrying...");
                }

                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 30);
            }
        }

        /// <summary>
        /// Launches the browser (opening default page) and then navigates to the URL
        /// This doesn't wait for the URL to load or browser to be ready
        /// </summary>
        /// <param name="Url">URL to navigate to</param>        
        public void Launch(string url)
        {
            this.Launch();
            this.FullUrl = url;
        }

        /// <summary>
        /// Launches the browser and then navigates to the URL
        /// This method invokes different properties for Web and SharePoint since they require different timeout
        /// </summary>
        /// <param name="url">URL to navigate to</param>
        /// <param name="sku">SKU: Web or SharePoint</param>
        public void Launch(string url, ProductSkuLevel sku)
        {
            this.Launch();
            switch (sku)
            {
                case ProductSkuLevel.Web:
                    this.FullUrl = url;
                    break;

                case ProductSkuLevel.SharePoint:
                    this.SharePointFullUrl = url;
                    break;
            }
        }

        /// <summary>
        /// This looks for an existing browser instance within the specified wait time.
        /// Where that browser has the specified URL. 
        /// If not found it throws a WindowNotFoundException.
        /// </summary>
        /// <param name="url">URL of browser to look for</param>
        /// <param name="waitTime">milliseconds to wait for URL to load</param>
        /// <exception cref="ArgumentOutOfRangeException">If waittime is <= 0</exception>
        /// <exception cref="WindowNotFoundException">if Browser is not found during the waittime</exception>
        public void Find(string url, int waitTime)
        {
            if (waitTime <= 0)
                throw new ArgumentOutOfRangeException("waitTime", "WaitTime must be a positive integer");

            this.ieApp = new IEApp(waitTime, url);
        }

        /// <summary>
        /// Finds an existing IE/FireFox browser and attaches to it. 
        /// If not found it throws a WindowNotFoundException.
        /// </summary>
        /// <param name="app">the maui application for the browser</param>
        /// <exception cref="ArgumentOutOfRangeException">If waittime is <= 0</exception>
        /// <exception cref="ArgumentNullException">if app is null</exception>
        /// <exception cref="ArgumentNullException">browser caption is null</exception>
        /// <exception cref="NotImplementedException">Firefox is not supported yet</exception>
        /// <exception cref="WindowNotFoundException">if Browser is not found during the waittime</exception>
        public void Find(App app, int waitTime)
        {
            if (app == null)
                throw new ArgumentNullException("app", "Browser.Find: app can not be null");

            if (waitTime <= 0)
                throw new ArgumentOutOfRangeException("waitTime", "WaitTime must be a positive integer");

            string exe = app.Process.ModulesFileNames[0]; //get full exe path
            exe = exe.Split('\\')[exe.Split('\\').Length - 1]; //remove path, leaving filename
            if (exe.ToLower() == "iexplore.exe")
            {
                this.browserType = BrowserType.InternetExplorer;
                if (app.MainWindow.Caption == null)
                    throw new ArgumentNullException("app.MainWindow.Caption", "Browser.Find: caption can not be null");
                else

                this.ieApp = new IEApp(app.MainWindow.Caption, waitTime);
            }
            else
            {
                this.browserType = BrowserType.FireFox;
                //TODO: set firefox app here
                throw new NotImplementedException("FireFox support is not implemented");
            }
        }
        
        #endregion

        #region Navigation methods
        /// <summary>
        /// Refresh the page
        /// </summary>
        public void Refresh()
        {
            this.ieApp.Refresh();
        }

        /// <summary>
        /// Since URL doesn't add the page to the history back and forward don't really work
        /// </summary>
        public void Back()
        {
            this.ieApp.GoBack();
        }

        /// <summary>
        /// Since URL doesn't add the page to the history back and forward don't really work
        /// </summary>
        public void Forward()
        {
            this.ieApp.GoForward();
        }

        /// <summary>
        /// Closes the Browser
        /// </summary>
        public void Quit()
        {
            if (this.ieApp != null)
                this.Application.SendKeys("%({F4})");     
            
            //this.ieApp.CloseIE();
            //we could check this.ieApp.IsRunning to see if the app is still running after this call      
            this.ieApp = null;
        }

        #endregion
    }
}
