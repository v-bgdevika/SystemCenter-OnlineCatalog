// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RequestResultDetailsDialogHttpRequestTab.cs">
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
    
    #region Interface Definition - IRequestResultDetailsDialogHttpRequestTabControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRequestResultDetailsDialogHttpRequestTabControls, for RequestResultDetailsDialogHttpRequestTab.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRequestResultDetailsDialogHttpRequestTabControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
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
        /// Read-only property to access HTTPRequestStaticControl
        /// </summary>
        StaticControl HTTPRequestStaticControl
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
    public class RequestResultDetailsDialogHttpRequestTab : Dialog, IRequestResultDetailsDialogHttpRequestTabControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedRequestProcessedSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTTPRequestStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHTTPRequestStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RequestResultDetailsDialogHttpRequestTab of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RequestResultDetailsDialogHttpRequestTab(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRequestResultDetailsDialogHttpRequestTab Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRequestResultDetailsDialogHttpRequestTabControls Controls
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
        Button IRequestResultDetailsDialogHttpRequestTabControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, RequestResultDetailsDialogHttpRequestTab.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRequestResultDetailsDialogHttpRequestTabControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, RequestResultDetailsDialogHttpRequestTab.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
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
        TextBox IRequestResultDetailsDialogHttpRequestTabControls.RequestProcessedSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyTextBox == null))
                {
                    this.cachedRequestProcessedSuccessfullyTextBox = new TextBox(this, RequestResultDetailsDialogHttpRequestTab.ControlIDs.RequestProcessedSuccessfullyTextBox);
                }
                return this.cachedRequestProcessedSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTTPRequestStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRequestResultDetailsDialogHttpRequestTabControls.HTTPRequestStaticControl
        {
            get
            {
                if ((this.cachedHTTPRequestStaticControl == null))
                {
                    this.cachedHTTPRequestStaticControl = new StaticControl(this, RequestResultDetailsDialogHttpRequestTab.ControlIDs.HTTPRequestStaticControl);
                }
                return this.cachedHTTPRequestStaticControl;
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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HTTPRequest
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHTTPRequest = ";H&TTP Request:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.PagesURLTemplatePage.RequestResultForm;l" +
                "abelRequest.Text";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HTTPRequest
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHTTPRequest;
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HTTPRequest translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HTTPRequest
            {
                get
                {
                    if ((cachedHTTPRequest == null))
                    {
                        cachedHTTPRequest = CoreManager.MomConsole.GetIntlStr(ResourceHTTPRequest);
                    }
                    return cachedHTTPRequest;
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabControl";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyTextBox
            /// </summary>
            public const string RequestProcessedSuccessfullyTextBox = "textBoxRequest";
            
            /// <summary>
            /// Control ID for HTTPRequestStaticControl
            /// </summary>
            public const string HTTPRequestStaticControl = "labelRequest";
        }
        #endregion
    }
}
