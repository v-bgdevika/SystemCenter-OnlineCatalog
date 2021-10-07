// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelTrackingGeneralDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy Class that represents the General Dialog in the SLA Wizard
// </project>
// <summary>
// 	Proxy Class that represents the General Dialog in the SLA Wizard
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
    using Maui.GlobalExceptions;
    
    #region Interface Definition - IServiceLevelTrackingGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelTrackingGeneralDialogControls, for ServiceLevelTrackingGeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelTrackingGeneralDialogControls
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
        /// Read-only property to access ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
        /// </summary>
        StaticControl ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalTextBox
        /// </summary>
        TextBox DescriptionOptionalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalStaticControl
        /// </summary>
        StaticControl DescriptionOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
        /// Read-only property to access GeneralHeaderLabelStaticControl
        /// </summary>
        StaticControl GeneralHeaderLabelStaticControl
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
    public class ServiceLevelTrackingGeneralDialog : Dialog, IServiceLevelTrackingGeneralDialogControls
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
        /// Cache to hold a reference to ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralHeaderLabelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralHeaderLabelStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelTrackingGeneralDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelTrackingGeneralDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            //UISynchronization.WaitForUIObjectReady(this, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout); 
 
        }
        #endregion
        
        #region IServiceLevelTrackingGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelTrackingGeneralDialogControls Controls
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
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionOptionalText
        {
            get
            {
                Sleeper.Delay(1000 * 30);
                int retrytimes = 0;
                while ( retrytimes++ < Common.Constants.DefaultMaxRetry)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(this.Controls.DescriptionOptionalTextBox.Text))
                        {
                            return this.Controls.DescriptionOptionalTextBox.Text;
                        }
                    }
                    catch (MauiException e)
                    {
                        Common.Utilities.LogMessage("Maui failed to get DescriptionOptionalTextBox.Text value"+" retry="+retrytimes+" Exception:"+e.Message);
                        Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond*5);

                        if (retrytimes >= Common.Constants.DefaultMaxRetry)
                        {
                            Common.Utilities.LogMessage("Maui failed to get DescriptionOptionalTextBox.Text value, already reach max retry times.");
                            break;
                        }
                    }
                }

                return this.Controls.DescriptionOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionOptionalTextBox.Text = value;
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
        public virtual string NameText
        {
            get
            {
                Sleeper.Delay(1000*30);
                int retrytimes = 1;
                while (string.IsNullOrEmpty(this.Controls.NameTextBox.Text))
                {
                    Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.DefaultContextMenuTimeout*10);
                    retrytimes++;
                    if (retrytimes > Common.Constants.DefaultMaxRetry)
                    {
                        Common.Utilities.LogMessage("maui failed to get NameTextBox.Text value");
                        break;
                    }
                }
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
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
        Button IServiceLevelTrackingGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ServiceLevelTrackingGeneralDialog.ControlIDs.PreviousButton);
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
        Button IServiceLevelTrackingGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ServiceLevelTrackingGeneralDialog.ControlIDs.NextButton);
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
        Button IServiceLevelTrackingGeneralDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ServiceLevelTrackingGeneralDialog.ControlIDs.FinishButton);
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
        Button IServiceLevelTrackingGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelTrackingGeneralDialog.ControlIDs.CancelButton);
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
        StaticControl IServiceLevelTrackingGeneralDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.GeneralStaticControl);
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
        StaticControl IServiceLevelTrackingGeneralDialogControls.ObjectsToTrackStaticControl
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
        StaticControl IServiceLevelTrackingGeneralDialogControls.ServiceLevelObjectivesStaticControl
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
        StaticControl IServiceLevelTrackingGeneralDialogControls.SummaryStaticControl
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
        ///  Exposes access to the ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingGeneralDialogControls.ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
        {
            get
            {
                if ((this.cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack == null))
                {
                    this.cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack);
                }
                
                return this.cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelTrackingGeneralDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, ServiceLevelTrackingGeneralDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingGeneralDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelTrackingGeneralDialogControls.NameTextBox
        {
            get
            {
                int retrytimes = 1;
                while (this.cachedNameTextBox == null)
                {
                    try
                    {
                        Sleeper.Delay(1000 * 60);
                        if (retrytimes > Common.Constants.DefaultMaxRetry)
                        {
                            System.Exception ex = new System.Exception("maui failed to get the control NameTextBox");
                            throw ex;
                        }
                        Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.DefaultContextMenuTimeout);
                        var parentDialog = new  ServiceLevelTrackingGeneralDialog(CoreManager.MomConsole);
                        this.cachedNameTextBox = new TextBox(parentDialog, ServiceLevelTrackingGeneralDialog.ControlIDs.NameTextBox);
                    }
                    catch(Window.Exceptions.WindowNotFoundException)
                    {
                        Common.Utilities.LogMessage(string.Format("the {0} times retry to get the NameTextBox", retrytimes - 1));
                    }

                    retrytimes++;
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingGeneralDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
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
        StaticControl IServiceLevelTrackingGeneralDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralHeaderLabelStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingGeneralDialogControls.GeneralHeaderLabelStaticControl
        {
            get
            {
                if ((this.cachedGeneralHeaderLabelStaticControl == null))
                {
                    this.cachedGeneralHeaderLabelStaticControl = new StaticControl(this, ServiceLevelTrackingGeneralDialog.ControlIDs.GeneralHeaderLabelStaticControl);
                }
                
                return this.cachedGeneralHeaderLabelStaticControl;
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
                //tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);

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
            /// Contains resource string for:  ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack = @";This wizard sets the parameters that track service levels for specified objects. You can run reports against this tracking data.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaGeneralPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionOptional = ";&Description (optional):;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaGeneralP" +
                "age;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";N&ame:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaGeneralPage;nameLabel.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderLabelGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryGeneralPage;$this.T" +
                "abName";
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
            /// Caches the translated resource string for:  ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralHeaderLabel;
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
            /// Exposes access to the ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
            {
                get
                {
                    if ((cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack == null))
                    {
                        cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack);
                    }
                    
                    return cachedThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DescriptionOptional
            {
                get
                {
                    if ((cachedDescriptionOptional == null))
                    {
                        cachedDescriptionOptional = CoreManager.MomConsole.GetIntlStr(ResourceDescriptionOptional);
                    }
                    
                    return cachedDescriptionOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    
                    return cachedName;
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
            /// Exposes access to the GeneralHeaderLabel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralHeaderLabel
            {
                get
                {
                    if ((cachedGeneralHeaderLabel == null))
                    {
                        cachedGeneralHeaderLabel = CoreManager.MomConsole.GetIntlStr(ResourceHeaderLabelGeneral);
                    }
                    
                    return cachedGeneralHeaderLabel;
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
            /// Control ID for ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack
            /// </summary>
            public const string ThisWizardSetsTheParametersThatTrackServiceLevelsForSpecifiedObjectsYouCanRunReportsAgainstThisTrack = "label1";
            
            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for DescriptionOptionalStaticControl
            /// </summary>
            public const string DescriptionOptionalStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralHeaderLabelStaticControl
            /// </summary>
            public const string GeneralHeaderLabelStaticControl = "headerLabel";
        }
        #endregion
    }
}
