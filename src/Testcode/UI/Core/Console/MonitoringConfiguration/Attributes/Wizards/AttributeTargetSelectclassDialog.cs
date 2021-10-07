// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AttributeTargetSelectclassDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[visnara] 7/22/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Attributes.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAttributeTargetSelectclassDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAttributeTargetSelectclassDialogControls, for AttributeTargetSelectclassDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAttributeTargetSelectclassDialogControls
    {
        /// <summary>
        /// Read-only property to access GeneralPropertiesTextBox
        /// </summary>
        TextBox GeneralPropertiesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RegistryProbeConfigurationListView
        /// </summary>
        ListView RegistryProbeConfigurationListView
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
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        /// </summary>
        StaticControl EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MatchingClassesStaticControl
        /// </summary>
        StaticControl MatchingClassesStaticControl
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
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AttributeTargetSelectclassDialog : Dialog, IAttributeTargetSelectclassDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesTextBox of type TextBox
        /// </summary>
        private TextBox cachedGeneralPropertiesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RegistryProbeConfigurationListView of type ListView
        /// </summary>
        private ListView cachedRegistryProbeConfigurationListView;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MatchingClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMatchingClassesStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AttributeTargetSelectclassDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AttributeTargetSelectclassDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAttributeTargetSelectclassDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAttributeTargetSelectclassDialogControls Controls
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
        ///  Routine to set/get the text in control GeneralProperties
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GeneralPropertiesText
        {
            get
            {
                return this.Controls.GeneralPropertiesTextBox.Text;
            }
            
            set
            {
                this.Controls.GeneralPropertiesTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAttributeTargetSelectclassDialogControls.GeneralPropertiesTextBox
        {
            get
            {
                if ((this.cachedGeneralPropertiesTextBox == null))
                {
                    this.cachedGeneralPropertiesTextBox = new TextBox(this, AttributeTargetSelectclassDialog.ControlIDs.GeneralPropertiesTextBox);
                }
                
                return this.cachedGeneralPropertiesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RegistryProbeConfigurationListView control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAttributeTargetSelectclassDialogControls.RegistryProbeConfigurationListView
        {
            get
            {
                if ((this.cachedRegistryProbeConfigurationListView == null))
                {
                    this.cachedRegistryProbeConfigurationListView = new ListView(this, AttributeTargetSelectclassDialog.ControlIDs.RegistryProbeConfigurationListView);
                }
                
                return this.cachedRegistryProbeConfigurationListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAttributeTargetSelectclassDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AttributeTargetSelectclassDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAttributeTargetSelectclassDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AttributeTargetSelectclassDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAttributeTargetSelectclassDialogControls.EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
        {
            get
            {
                if ((this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl == null))
                {
                    this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl = new StaticControl(this, AttributeTargetSelectclassDialog.ControlIDs.EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl);
                }
                
                return this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAttributeTargetSelectclassDialogControls.MatchingClassesStaticControl
        {
            get
            {
                if ((this.cachedMatchingClassesStaticControl == null))
                {
                    this.cachedMatchingClassesStaticControl = new StaticControl(this, AttributeTargetSelectclassDialog.ControlIDs.MatchingClassesStaticControl);
                }
                
                return this.cachedMatchingClassesStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException ex)
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
                        Core.Common.Utilities.LogMessage(
                           "Attempt " + numberOfTries + " of " + MaxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");
                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[visnara] 7/22/2006 Created
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
            private const string ResourceDialogTitle = "Select class";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDescription = ";Enter your search text below. This searches both name and description.;ManagedSt" +
                "ring;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.Monit" +
                "oringClassChooser;searchLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MatchingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchingClasses = ";Matching Classes;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.MonitoringClassChooser;classesLabel.Text";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MatchingClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMatchingClasses;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterYourSearchTextBelowThisSearchesBothNameAndDescription
            {
                get
                {
                    if ((cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription == null))
                    {
                        cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription = CoreManager.MomConsole.GetIntlStr(ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDescription);
                    }
                    
                    return cachedEnterYourSearchTextBelowThisSearchesBothNameAndDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchingClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchingClasses
            {
                get
                {
                    if ((cachedMatchingClasses == null))
                    {
                        cachedMatchingClasses = CoreManager.MomConsole.GetIntlStr(ResourceMatchingClasses);
                    }
                    
                    return cachedMatchingClasses;
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
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for GeneralPropertiesTextBox
            /// </summary>
            public const string GeneralPropertiesTextBox = "searchTextBox";
            
            /// <summary>
            /// Control ID for RegistryProbeConfigurationListView
            /// </summary>
            public const string RegistryProbeConfigurationListView = "mainListView";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl
            /// </summary>
            public const string EnterYourSearchTextBelowThisSearchesBothNameAndDescriptionStaticControl = "searchLabel";
            
            /// <summary>
            /// Control ID for MatchingClassesStaticControl
            /// </summary>
            public const string MatchingClassesStaticControl = "classesLabel";
        }
        #endregion
    }
}
