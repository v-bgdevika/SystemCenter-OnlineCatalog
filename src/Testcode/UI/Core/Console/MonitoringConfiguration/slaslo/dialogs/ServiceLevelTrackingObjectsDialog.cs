// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelTrackingObjectsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy Class that represents the Object to Track Dialog in the SLA Wizard. 
// </project>
// <summary>
// 	Proxy Class that represents the Object to Track Dialog in the SLA Wizard. 
// </summary>
// <history>
// 	[dialac] 9/12/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroupScopeType

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupScopeType
    /// </summary>
    /// <history>
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupScopeType
    {
        /// <summary>
        /// AllObjectsOfTheTargetedClass = 0
        /// </summary>
        AllObjectsOfTheTargetedClass = 0,
        
        /// <summary>
        /// AGroupOrObjectThatContainsObjectsOfTheTargetedClass = 1
        /// </summary>
        AGroupOrObjectThatContainsObjectsOfTheTargetedClass = 1,
    }
    #endregion
    
    #region Interface Definition - IServiceLevelTrackingObjectsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelTrackingObjectsDialogControls, for ServiceLevelTrackingObjectsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelTrackingObjectsDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsToTrackStaticControl
        /// </summary>
        StaticControl ObjectsToTrackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectivesStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectivesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackComboBox
        /// </summary>
        ComboBox SelectDestinationManagementPackComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackStaticControl
        /// </summary>
        StaticControl SelectDestinationManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllObjectsOfTheTargetedClassRadioButton
        /// </summary>
        RadioButton AllObjectsOfTheTargetedClassRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheObjectsWithinTheClassStaticControl
        /// </summary>
        StaticControl SpecifyTheObjectsWithinTheClassStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectScopeButton
        /// </summary>
        Button SelectScopeButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScopeTextBox
        /// </summary>
        TextBox ScopeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton
        /// </summary>
        RadioButton AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
        /// </summary>
        StaticControl SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTargetClassButton
        /// </summary>
        Button SelectTargetClassButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetTextBox
        /// </summary>
        TextBox TargetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassStaticControl
        /// </summary>
        StaticControl TargetedClassStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsToTrackHeaderLabelStaticControl
        /// </summary>
        StaticControl ObjectsToTrackHeaderLabelStaticControl
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
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceLevelTrackingObjectsDialog : Dialog, IServiceLevelTrackingObjectsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToTrackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsToTrackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectivesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllObjectsOfTheTargetedClassRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllObjectsOfTheTargetedClassRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheObjectsWithinTheClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheObjectsWithinTheClassStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectScopeButton of type Button
        /// </summary>
        private Button cachedSelectScopeButton;
        
        /// <summary>
        /// Cache to hold a reference to ScopeTextBox of type TextBox
        /// </summary>
        private TextBox cachedScopeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO;
        
        /// <summary>
        /// Cache to hold a reference to SelectTargetClassButton of type Button
        /// </summary>
        private Button cachedSelectTargetClassButton;
        
        /// <summary>
        /// Cache to hold a reference to TargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetedClassStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToTrackHeaderLabelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsToTrackHeaderLabelStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelTrackingObjectsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelTrackingObjectsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            //UISynchronization.WaitForUIObjectReady(this, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupScopeType
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupScopeType RadioGroupScopeType
        {
            get
            {
                if ((this.Controls.AllObjectsOfTheTargetedClassRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupScopeType.AllObjectsOfTheTargetedClass;
                }
                
                if ((this.Controls.AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroupScopeType.AllObjectsOfTheTargetedClass))
                {
                    this.Controls.AllObjectsOfTheTargetedClassRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass))
                    {
                        this.Controls.AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IServiceLevelTrackingObjectsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelTrackingObjectsDialogControls Controls
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
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectDestinationManagementPackText
        {
            get
            {
                return this.Controls.SelectDestinationManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.SelectDestinationManagementPackComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ScopeTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ScopeTextBoxText
        {
            get
            {
                return this.Controls.ScopeTextBox.Text;
            }
            
            set
            {
                this.Controls.ScopeTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetText
        {
            get
            {
                return this.Controls.TargetTextBox.Text;
            }
            
            set
            {
                this.Controls.TargetTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.GeneralStaticControl);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsToTrackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.ObjectsToTrackStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsToTrackStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedObjectsToTrackStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedObjectsToTrackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.ServiceLevelObjectivesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedServiceLevelObjectivesStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedServiceLevelObjectivesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedServiceLevelObjectivesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IServiceLevelTrackingObjectsDialogControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, ServiceLevelTrackingObjectsDialog.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllObjectsOfTheTargetedClassRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServiceLevelTrackingObjectsDialogControls.AllObjectsOfTheTargetedClassRadioButton
        {
            get
            {
                if ((this.cachedAllObjectsOfTheTargetedClassRadioButton == null))
                {
                    this.cachedAllObjectsOfTheTargetedClassRadioButton = new RadioButton(this, ServiceLevelTrackingObjectsDialog.ControlIDs.AllObjectsOfTheTargetedClassRadioButton);
                }
                
                return this.cachedAllObjectsOfTheTargetedClassRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheObjectsWithinTheClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.SpecifyTheObjectsWithinTheClassStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheObjectsWithinTheClassStaticControl == null))
                {
                    this.cachedSpecifyTheObjectsWithinTheClassStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.SpecifyTheObjectsWithinTheClassStaticControl);
                }
                
                return this.cachedSpecifyTheObjectsWithinTheClassStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectScopeButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.SelectScopeButton
        {
            get
            {
                if ((this.cachedSelectScopeButton == null))
                {
                    this.cachedSelectScopeButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.SelectScopeButton);
                }
                
                return this.cachedSelectScopeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScopeTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelTrackingObjectsDialogControls.ScopeTextBox
        {
            get
            {
                if ((this.cachedScopeTextBox == null))
                {
                    this.cachedScopeTextBox = new TextBox(this, ServiceLevelTrackingObjectsDialog.ControlIDs.ScopeTextBox);
                }
                
                return this.cachedScopeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServiceLevelTrackingObjectsDialogControls.AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton
        {
            get
            {
                if ((this.cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton == null))
                {
                    this.cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton = new RadioButton(this, ServiceLevelTrackingObjectsDialog.ControlIDs.AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton);
                }
                
                return this.cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
        {
            get
            {
                // The ID for this control (label1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO = new StaticControl(wndTemp);
                }
                
                return this.cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTargetClassButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingObjectsDialogControls.SelectTargetClassButton
        {
            get
            {
                if ((this.cachedSelectTargetClassButton == null))
                {
                    this.cachedSelectTargetClassButton = new Button(this, ServiceLevelTrackingObjectsDialog.ControlIDs.SelectTargetClassButton);
                }
                
                return this.cachedSelectTargetClassButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelTrackingObjectsDialogControls.TargetTextBox
        {
            get
            {
                if ((this.cachedTargetTextBox == null))
                {
                    this.cachedTargetTextBox = new TextBox(this, ServiceLevelTrackingObjectsDialog.ControlIDs.TargetTextBox);
                }
                
                return this.cachedTargetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.TargetedClassStaticControl
        {
            get
            {
                if ((this.cachedTargetedClassStaticControl == null))
                {
                    this.cachedTargetedClassStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.TargetedClassStaticControl);
                }
                
                return this.cachedTargetedClassStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsToTrackHeaderLabelStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingObjectsDialogControls.ObjectsToTrackHeaderLabelStaticControl
        {
            get
            {
                if ((this.cachedObjectsToTrackHeaderLabelStaticControl == null))
                {
                    this.cachedObjectsToTrackHeaderLabelStaticControl = new StaticControl(this, ServiceLevelTrackingObjectsDialog.ControlIDs.ObjectsToTrackHeaderLabelStaticControl);
                }
                
                return this.cachedObjectsToTrackHeaderLabelStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectScope()
        {
            this.Controls.SelectScopeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectTarget
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectTargetClass()
        {
            this.Controls.SelectTargetClassButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = @";Service Level Tracking;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateSlaWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;FinishTe" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryGeneralPage;$this.T" +
                "abName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectsToTrack = ";Objects to Track;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOL" +
                "D;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaPageResources;Tr" +
                "ackTargetPageTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectives = ";Service Level Objectives;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SloListPage" +
                ";Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.SummaryPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";&New...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryMethodPage;newButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Controls.ManagementPackComboBoxControl;pageSectionL" +
                "abel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDestinationManagementPack = ";S&elect destination management pack:;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ManagementPackComboBo" +
                "xControl;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllObjectsOfTheTargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllObjectsOfTheTargetedClass = ";&All objects of the targeted class;ManagedString;Microsoft.EnterpriseManagement." +
                "UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.S" +
                "laTrackTargetPage;allObjectsRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheObjectsWithinTheClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheObjectsWithinTheClass = ";Specify the objects within the class;ManagedString;Microsoft.EnterpriseManagemen" +
                "t.UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages" +
                ".SlaTrackTargetPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectScope = ";S&elect...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTrackTargetPage;select" +
                "ScopeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AGroupOrObjectThatContainsObjectsOfTheTargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAGroupOrObjectThatContainsObjectsOfTheTargetedClass = ";A g&roup or object that contains objects of the targeted class;ManagedString;Mic" +
                "rosoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.I" +
                "nternal.UI.Authoring.Pages.SlaTrackTargetPage;scopeRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO = @";Specify the class of objects for which you want to track service levels. If necessary, specify a group to reduce the scope of the tracking request.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTrackTargetPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTarget = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browse" +
                "Button.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetedClass = ";&Targeted class;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTrackTargetPage;t" +
                "argetLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsToTrackHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderLabelObjectsToTrack = ";Objects to Track;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOL" +
                "D;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaPageResources;Tr" +
                "ackTargetPageTitle";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ObjectsToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectsToTrack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectives;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDestinationManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllObjectsOfTheTargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllObjectsOfTheTargetedClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheObjectsWithinTheClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheObjectsWithinTheClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectScope;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AGroupOrObjectThatContainsObjectsOfTheTargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetedClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ObjectsToTrackHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectsToTrackHeaderLabel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectsToTrack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectsToTrack
            {
                get
                {
                    if ((cachedObjectsToTrack == null))
                    {
                        cachedObjectsToTrack = CoreManager.MomConsole.GetIntlStr(ResourceObjectsToTrack);
                    }
                    
                    return cachedObjectsToTrack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectives translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectives
            {
                get
                {
                    if ((cachedServiceLevelObjectives == null))
                    {
                        cachedServiceLevelObjectives = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectives);
                    }
                    
                    return cachedServiceLevelObjectives;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }
                    
                    return cachedNew;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    
                    return cachedManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectDestinationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectDestinationManagementPack
            {
                get
                {
                    if ((cachedSelectDestinationManagementPack == null))
                    {
                        cachedSelectDestinationManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceSelectDestinationManagementPack);
                    }
                    
                    return cachedSelectDestinationManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllObjectsOfTheTargetedClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllObjectsOfTheTargetedClass
            {
                get
                {
                    if ((cachedAllObjectsOfTheTargetedClass == null))
                    {
                        cachedAllObjectsOfTheTargetedClass = CoreManager.MomConsole.GetIntlStr(ResourceAllObjectsOfTheTargetedClass);
                    }
                    
                    return cachedAllObjectsOfTheTargetedClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheObjectsWithinTheClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheObjectsWithinTheClass
            {
                get
                {
                    if ((cachedSpecifyTheObjectsWithinTheClass == null))
                    {
                        cachedSpecifyTheObjectsWithinTheClass = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheObjectsWithinTheClass);
                    }
                    
                    return cachedSpecifyTheObjectsWithinTheClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectScope
            {
                get
                {
                    if ((cachedSelectScope == null))
                    {
                        cachedSelectScope = CoreManager.MomConsole.GetIntlStr(ResourceSelectScope);
                    }

                    return cachedSelectScope;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AGroupOrObjectThatContainsObjectsOfTheTargetedClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AGroupOrObjectThatContainsObjectsOfTheTargetedClass
            {
                get
                {
                    if ((cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClass == null))
                    {
                        cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClass = CoreManager.MomConsole.GetIntlStr(ResourceAGroupOrObjectThatContainsObjectsOfTheTargetedClass);
                    }
                    
                    return cachedAGroupOrObjectThatContainsObjectsOfTheTargetedClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
            {
                get
                {
                    if ((cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO == null))
                    {
                        cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO);
                    }
                    
                    return cachedSpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTarget
            {
                get
                {
                    if ((cachedSelectTarget == null))
                    {
                        cachedSelectTarget = CoreManager.MomConsole.GetIntlStr(ResourceSelectTarget);
                    }
                    
                    return cachedSelectTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TargetedClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetedClass
            {
                get
                {
                    if ((cachedTargetedClass == null))
                    {
                        cachedTargetedClass = CoreManager.MomConsole.GetIntlStr(ResourceTargetedClass);
                    }
                    
                    return cachedTargetedClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectsToTrackHeaderLabel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectsToTrackHeaderLabel
            {
                get
                {
                    if ((cachedObjectsToTrackHeaderLabel == null))
                    {
                        cachedObjectsToTrackHeaderLabel = CoreManager.MomConsole.GetIntlStr(ResourceHeaderLabelObjectsToTrack);
                    }
                    
                    return cachedObjectsToTrackHeaderLabel;
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
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ObjectsToTrackStaticControl
            /// </summary>
            public const string ObjectsToTrackStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesStaticControl
            /// </summary>
            public const string ServiceLevelObjectivesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "label1";
            
            /// <summary>
            /// Control ID for AllObjectsOfTheTargetedClassRadioButton
            /// </summary>
            public const string AllObjectsOfTheTargetedClassRadioButton = "allObjectsRadioButton";
            
            /// <summary>
            /// Control ID for SpecifyTheObjectsWithinTheClassStaticControl
            /// </summary>
            public const string SpecifyTheObjectsWithinTheClassStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SelectScopeButton
            /// </summary>
            public const string SelectScopeButton = "selectScopeButton";
            
            /// <summary>
            /// Control ID for ScopeTextBox
            /// </summary>
            /// <remark>
            ///  TODO: Confirm if the text box is the scope. UIClassMaker gave originally TextBox0
            /// </remark>
            public const string ScopeTextBox = "scopeValueTextBox";
            
            /// <summary>
            /// Control ID for AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton
            /// </summary>
            public const string AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton = "scopeRadioButton";
            
            /// <summary>
            /// Control ID for SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO
            /// </summary>
            public const string SpecifyTheClassOfObjectsForWhichYouWantToTrackServiceLevelsIfNecessarySpecifyAGroupToReduceTheScopeO = "label1";
            
            /// <summary>
            /// Control ID for SelectTargetClassButton
            /// </summary>
            public const string SelectTargetClassButton = "browseButton";
            
            /// <summary>
            /// Control ID for TargetTextBox
            /// </summary>
            /// <remark>
            ///  TODO: Confirm if the text box is the target. UIClassMaker gave originally NameTextBox
            /// </remark>
            public const string TargetTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for TargetedClassStaticControl
            /// </summary>
            public const string TargetedClassStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ObjectsToTrackHeaderLabelStaticControl
            /// </summary>
            public const string ObjectsToTrackHeaderLabelStaticControl = "headerLabel";
        }
        #endregion
    }
}
