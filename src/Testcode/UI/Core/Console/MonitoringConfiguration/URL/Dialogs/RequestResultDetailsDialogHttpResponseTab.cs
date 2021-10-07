// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestResultDetailsDialogHttpResponseTab.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRequestResultDetailsDialogHttpResponseTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestResultDetailsDialogHttpResponseTabControls, for RequestResultDetailsDialogHttpResponseTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestResultDetailsDialogHttpResponseTabControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyTextBox
        /// </summary>
        TextBox RequestProcessedSuccessfullyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTTPResponseStaticControl
        /// </summary>
        StaticControl HTTPResponseStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RequestResultDetailsDialogHttpResponseTab : Dialog, IRequestResultDetailsDialogHttpResponseTabControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestProcessedSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPResponseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPResponseStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RequestResultDetailsDialogHttpResponseTab of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestResultDetailsDialogHttpResponseTab(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRequestResultDetailsDialogHttpResponseTab Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestResultDetailsDialogHttpResponseTabControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RequestProcessedSuccessfully
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RequestProcessedSuccessfullyText
        {
            get
            {
                return this.Controls.RequestProcessedSuccessfullyTextBox.Text;
            }
            
            set
            {
                this.Controls.RequestProcessedSuccessfullyTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRequestResultDetailsDialogHttpResponseTabControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, RequestResultDetailsDialogHttpResponseTab.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestResultDetailsDialogHttpResponseTabControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, RequestResultDetailsDialogHttpResponseTab.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRequestResultDetailsDialogHttpResponseTabControls.RequestProcessedSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyTextBox == null))
                {
                    this.cachedRequestProcessedSuccessfullyTextBox = new TextBox(this, RequestResultDetailsDialogHttpResponseTab.ControlIDs.RequestProcessedSuccessfullyTextBox);
                }
                return this.cachedRequestProcessedSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPResponseStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogHttpResponseTabControls.HTTPResponseStaticControl
        {
            get
            {
                if ((this.cachedHTTPResponseStaticControl == null))
                {
                    this.cachedHTTPResponseStaticControl = new StaticControl(this, RequestResultDetailsDialogHttpResponseTab.ControlIDs.HTTPResponseStaticControl);
                }
                return this.cachedHTTPResponseStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Request Result Details;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RequestResultForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";&Close;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.PageFrameworks.SheetFramework;menuExit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HTTPResponse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHTTPResponse = ";H&TTP Response:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.PagesURLTemplatePage.RequestResultForm;" +
                "labelResponse.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HTTPResponse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHTTPResponse;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    return cachedClose;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HTTPResponse translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HTTPResponse
            {
                get
                {
                    if ((cachedHTTPResponse == null))
                    {
                        cachedHTTPResponse = CoreManager.MomConsole.GetIntlStr(ResourceHTTPResponse);
                    }
                    return cachedHTTPResponse;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "buttonClose";
            
            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyTextBox
            /// </summary>
            public const string RequestProcessedSuccessfullyTextBox = "textBoxResponse";
            
            /// <summary>
            /// Control ID for HTTPResponseStaticControl
            /// </summary>
            public const string HTTPResponseStaticControl = "labelResponse";
        }
        #endregion
    }
}
