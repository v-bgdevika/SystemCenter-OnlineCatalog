// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectComputersDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 Test UI Automation
// </summary>
// <history>
// 	[KellyMor] 22-Sep-05 Created
//  [KellyMor] 18-Nov-05 Added logging to search loop and exception block
//                       Removed variable name for exception in first catch
//                       block per FxCop.
//  [KellyMor] 28-Feb-06 Updated resource string for window title on Japanese systems
//  [KellyMor] 10-Jan-07 Added support for German
//                       Added delay for inner WindowNotFoundException block
//  [KellyMor] 02-Feb-07 Added support for Italian language
//                       Modified default case to be same for all European languages
//  [a-joelj]   24DEC09 Fixed Select Computers DialogTitle so we don't have to
//                      build custom strings for each language SM# 162944
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectComputersDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectComputersDialogControls, for SelectComputersDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectComputersDialogControls
    {
        /// <summary>
        /// Read-only property to access SelectThisObjectTypeStaticControl
        /// </summary>
        StaticControl SelectThisObjectTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectThisObjectTypeTextBox
        /// </summary>
        TextBox SelectThisObjectTypeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectTypesButton
        /// </summary>
        Button ObjectTypesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromThisLocationStaticControl
        /// </summary>
        StaticControl FromThisLocationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromThisLocationTextBox
        /// </summary>
        TextBox FromThisLocationTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LocationsButton
        /// </summary>
        Button LocationsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectNamesTextBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox ObjectNamesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CheckNamesButton
        /// </summary>
        Button CheckNamesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedButton
        /// </summary>
        Button AdvancedButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Select Computers dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectComputersDialog : Dialog, ISelectComputersDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectThisObjectTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectThisObjectTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectThisObjectTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedSelectThisObjectTypeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTypesButton of type Button
        /// </summary>
        private Button cachedObjectTypesButton;
        
        /// <summary>
        /// Cache to hold a reference to FromThisLocationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromThisLocationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FromThisLocationTextBox of type TextBox
        /// </summary>
        private TextBox cachedFromThisLocationTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LocationsButton of type Button
        /// </summary>
        private Button cachedLocationsButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectNamesTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectNamesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CheckNamesButton of type Button
        /// </summary>
        private Button cachedCheckNamesButton;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedButton of type Button
        /// </summary>
        private Button cachedAdvancedButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectComputersDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectComputersDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectComputersDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectComputersDialogControls Controls
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
        ///  Routine to set/get the text in control SelectThisObjectType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectThisObjectTypeText
        {
            get
            {
                return this.Controls.SelectThisObjectTypeTextBox.Text;
            }
            
            set
            {
                this.Controls.SelectThisObjectTypeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FromThisLocation
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FromThisLocationText
        {
            get
            {
                return this.Controls.FromThisLocationTextBox.Text;
            }
            
            set
            {
                this.Controls.FromThisLocationTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ObjectNamesTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectNamesText
        {
            get
            {
                return this.Controls.ObjectNamesTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectNamesTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectThisObjectTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComputersDialogControls.SelectThisObjectTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectThisObjectTypeStaticControl == null))
                {
                    this.cachedSelectThisObjectTypeStaticControl = new StaticControl(this, SelectComputersDialog.ControlIDs.SelectThisObjectTypeStaticControl);
                }
                return this.cachedSelectThisObjectTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectThisObjectTypeTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectComputersDialogControls.SelectThisObjectTypeTextBox
        {
            get
            {
                if ((this.cachedSelectThisObjectTypeTextBox == null))
                {
                    this.cachedSelectThisObjectTypeTextBox = new TextBox(this, SelectComputersDialog.ControlIDs.SelectThisObjectTypeTextBox);
                }
                return this.cachedSelectThisObjectTypeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTypesButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.ObjectTypesButton
        {
            get
            {
                if ((this.cachedObjectTypesButton == null))
                {
                    this.cachedObjectTypesButton = new Button(this, SelectComputersDialog.ControlIDs.ObjectTypesButton);
                }
                return this.cachedObjectTypesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromThisLocationStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectComputersDialogControls.FromThisLocationStaticControl
        {
            get
            {
                if ((this.cachedFromThisLocationStaticControl == null))
                {
                    this.cachedFromThisLocationStaticControl = new StaticControl(this, SelectComputersDialog.ControlIDs.FromThisLocationStaticControl);
                }
                return this.cachedFromThisLocationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromThisLocationTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectComputersDialogControls.FromThisLocationTextBox
        {
            get
            {
                if ((this.cachedFromThisLocationTextBox == null))
                {
                    this.cachedFromThisLocationTextBox = new TextBox(this, SelectComputersDialog.ControlIDs.FromThisLocationTextBox);
                }
                return this.cachedFromThisLocationTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LocationsButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.LocationsButton
        {
            get
            {
                if ((this.cachedLocationsButton == null))
                {
                    this.cachedLocationsButton = new Button(this, SelectComputersDialog.ControlIDs.LocationsButton);
                }
                return this.cachedLocationsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectNamesTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectComputersDialogControls.ObjectNamesTextBox
        {
            get
            {
                if ((this.cachedObjectNamesTextBox == null))
                {
                    this.cachedObjectNamesTextBox = new TextBox(this, SelectComputersDialog.ControlIDs.ObjectNamesTextBox);
                }
                return this.cachedObjectNamesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckNamesButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.CheckNamesButton
        {
            get
            {
                if ((this.cachedCheckNamesButton == null))
                {
                    this.cachedCheckNamesButton = new Button(this, SelectComputersDialog.ControlIDs.CheckNamesButton);
                }
                return this.cachedCheckNamesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.AdvancedButton
        {
            get
            {
                if ((this.cachedAdvancedButton == null))
                {
                    this.cachedAdvancedButton = new Button(this, SelectComputersDialog.ControlIDs.AdvancedButton);
                }
                return this.cachedAdvancedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectComputersDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectComputersDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectComputersDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ObjectTypes
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickObjectTypes()
        {
            this.Controls.ObjectTypesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Locations
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickLocations()
        {
            this.Controls.LocationsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CheckNames
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCheckNames()
        {
            this.Controls.CheckNamesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Advanced
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdvanced()
        {
            this.Controls.AdvancedButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        ///     [KellyMor] 18-Nov-05 Added logging to search loop and exception block
        ///                          Removed variable name for exception in first catch
        ///                          block per FxCop.
        ///     [KellyMor] 10-Jan-07 Added delay for inner WindowNotFoundException block
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.Dialog,
                                StringMatchSyntax.ExactMatch,
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
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                        Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage("Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-Sep-05 Created
        /// 	[a-joelj]   24DEC09 Fixed ResourceDialogTitlePrefix and ResourceDialogTitleSuffix to
        /// 	                    work with every localized language build.  Also removed the 
        /// 	                    DEU ResourceDialogTitleObjectFormula string as its no longer needed.
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title:  "Select"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitlePrefix = ";Select %1;Win32String;objsel.dll;600";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix:  "Computers"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Computers;Win32String;objsel.dll;145";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectThisObjectType
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectThisObjectType = "&Select this object type:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectTypes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectTypes = "&Object Types...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FromThisLocation
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceFromThisLocation = "&From this location:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Locations
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceLocations = "&Locations...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CheckNames
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckNames = "&Check Names";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Advanced
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvanced = "&Advanced...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = "OK";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource to hold the character used as a spacer in concatentated titles
            /// on Japanese systems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceJapaneseTitleSpacer = " \u306E";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource to hold the character used as a spacer in concatentated titles
            /// on English systems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnglishTitleSpacer = " ";

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
            /// Caches the translated resource string for:  SelectThisObjectType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectThisObjectType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ObjectTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectTypes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FromThisLocation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFromThisLocation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Locations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLocations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CheckNames
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckNames;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Advanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvanced;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            ///     [KellyMor] 10-Jan-07 Added support for German
            ///     [a-joelj]   24DEC09 Fixed Select Computers DialogTitle so we don't have to
            ///                         build custom strings for each language.
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        // Combine the Localized Dialog Prefix + Suffix to make the "Select Computers" title
                        cachedDialogTitle = (CoreManager.MomConsole.GetIntlStr(ResourceDialogTitlePrefix).Replace("%1", CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix)));
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectThisObjectType translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectThisObjectType
            {
                get
                {
                    if ((cachedSelectThisObjectType == null))
                    {
                        cachedSelectThisObjectType = CoreManager.MomConsole.GetIntlStr(ResourceSelectThisObjectType);
                    }
                    return cachedSelectThisObjectType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectTypes
            {
                get
                {
                    if ((cachedObjectTypes == null))
                    {
                        cachedObjectTypes = CoreManager.MomConsole.GetIntlStr(ResourceObjectTypes);
                    }
                    return cachedObjectTypes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FromThisLocation translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FromThisLocation
            {
                get
                {
                    if ((cachedFromThisLocation == null))
                    {
                        cachedFromThisLocation = CoreManager.MomConsole.GetIntlStr(ResourceFromThisLocation);
                    }
                    return cachedFromThisLocation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Locations translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Locations
            {
                get
                {
                    if ((cachedLocations == null))
                    {
                        cachedLocations = CoreManager.MomConsole.GetIntlStr(ResourceLocations);
                    }
                    return cachedLocations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckNames translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CheckNames
            {
                get
                {
                    if ((cachedCheckNames == null))
                    {
                        cachedCheckNames = CoreManager.MomConsole.GetIntlStr(ResourceCheckNames);
                    }
                    return cachedCheckNames;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Advanced translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Advanced
            {
                get
                {
                    if ((cachedAdvanced == null))
                    {
                        cachedAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAdvanced);
                    }
                    return cachedAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
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
        /// 	[KellyMor] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectThisObjectTypeStaticControl
            /// </summary>
            public const int SelectThisObjectTypeStaticControl = 323;
            
            /// <summary>
            /// Control ID for SelectThisObjectTypeTextBox
            /// </summary>
            public const int SelectThisObjectTypeTextBox = 231;
            
            /// <summary>
            /// Control ID for ObjectTypesButton
            /// </summary>
            public const int ObjectTypesButton = 230;
            
            /// <summary>
            /// Control ID for FromThisLocationStaticControl
            /// </summary>
            public const int FromThisLocationStaticControl = 324;
            
            /// <summary>
            /// Control ID for FromThisLocationTextBox
            /// </summary>
            public const int FromThisLocationTextBox = 233;
            
            /// <summary>
            /// Control ID for LocationsButton
            /// </summary>
            public const int LocationsButton = 232;
            
            /// <summary>
            /// Control ID for ObjectNamesTextBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int ObjectNamesTextBox = 214;
            
            /// <summary>
            /// Control ID for CheckNamesButton
            /// </summary>
            public const int CheckNamesButton = 235;
            
            /// <summary>
            /// Control ID for AdvancedButton
            /// </summary>
            public const int AdvancedButton = 236;
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
        }
        #endregion
    }
}
