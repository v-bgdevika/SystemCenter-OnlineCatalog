// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ExclusionCriteriaWindow.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 10/24/2007 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AutoAgentAssignment
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IExclusionCriteriaWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IExclusionCriteriaWindowControls, for ExclusionCriteriaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IExclusionCriteriaWindowControls
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access IntroductionStaticControl
        /// </summary>
        StaticControl IntroductionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainStaticControl
        /// </summary>
        StaticControl DomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InclusionCriteriaStaticControl
        /// </summary>
        StaticControl InclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionCriteriaStaticControl
        /// </summary>
        StaticControl ExclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentFailoverStaticControl
        /// </summary>
        StaticControl AgentFailoverStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedComputersExampleStaticControl
        /// </summary>
        StaticControl ExcludedComputersExampleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedComputersDirectionsStaticControl
        /// </summary>
        StaticControl ExcludedComputersDirectionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedComputersTextBox
        /// </summary>
        TextBox ExcludedComputersTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedComputersDescriptionStaticControl
        /// </summary>
        StaticControl ExcludedComputersDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateAnExclusionRuleStaticControl
        /// </summary>
        StaticControl CreateAnExclusionRuleStaticControl
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
        /// Read-only property to access ExclusionCriteriaStaticControl2
        /// </summary>
        StaticControl ExclusionCriteriaStaticControl2
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ExclusionCriteriaWindow : Window, IExclusionCriteriaWindowControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentFailoverStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedComputersExampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludedComputersExampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedComputersDirectionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludedComputersDirectionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedComputersTextBox of type TextBox
        /// </summary>
        private TextBox cachedExcludedComputersTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedComputersDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludedComputersDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateAnExclusionRuleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateAnExclusionRuleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionCriteriaStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedExclusionCriteriaStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ExclusionCriteriaWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExclusionCriteriaWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IExclusionCriteriaWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IExclusionCriteriaWindowControls Controls
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
        ///  Routine to set/get the text in control ExcludedComputersTextBox
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[KellyMor]  10/24/2007  Created
        /// 	[nathd]     24SEP2009   Maui 2.0: Calling Trim() on the text property to 
        /// 	                        remove any non-printable/whitespace characters.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExcludedComputersTextBoxText
        {
            get
            {
                // [nathd] - Maui 2.0: After upgrading to Maui 2.0 the Text property
                // for this control contained some non-printable/whitespace characters
                // even when the control was empty. Previously (in Maui 1.0) the Text property 
                // was really empty if the control was empty. Calling Trim() on the Text 
                // property to strip all whitespace characters.
                return this.Controls.ExcludedComputersTextBox.Text.Trim();
            }
            
            set
            {
                this.Controls.ExcludedComputersTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExclusionCriteriaWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ExclusionCriteriaWindow.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExclusionCriteriaWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ExclusionCriteriaWindow.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExclusionCriteriaWindowControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ExclusionCriteriaWindow.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExclusionCriteriaWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ExclusionCriteriaWindow.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.IntroductionStaticControl);
                }
                
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.DomainStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDomainStaticControl == null))
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
                    this.cachedDomainStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.InclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedInclusionCriteriaStaticControl == null))
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
                    this.cachedInclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedInclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.ExclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExclusionCriteriaStaticControl == null))
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
                    this.cachedExclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedExclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentFailoverStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.AgentFailoverStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAgentFailoverStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAgentFailoverStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedAgentFailoverStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedComputersExampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.ExcludedComputersExampleStaticControl
        {
            get
            {
                if ((this.cachedExcludedComputersExampleStaticControl == null))
                {
                    this.cachedExcludedComputersExampleStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.ExcludedComputersExampleStaticControl);
                }
                
                return this.cachedExcludedComputersExampleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedComputersDirectionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.ExcludedComputersDirectionsStaticControl
        {
            get
            {
                if ((this.cachedExcludedComputersDirectionsStaticControl == null))
                {
                    this.cachedExcludedComputersDirectionsStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.ExcludedComputersDirectionsStaticControl);
                }
                
                return this.cachedExcludedComputersDirectionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedComputersTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExclusionCriteriaWindowControls.ExcludedComputersTextBox
        {
            get
            {
                if ((this.cachedExcludedComputersTextBox == null))
                {
                    this.cachedExcludedComputersTextBox = new TextBox(this, ExclusionCriteriaWindow.ControlIDs.ExcludedComputersTextBox);
                }
                
                return this.cachedExcludedComputersTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedComputersDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.ExcludedComputersDescriptionStaticControl
        {
            get
            {
                if ((this.cachedExcludedComputersDescriptionStaticControl == null))
                {
                    this.cachedExcludedComputersDescriptionStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.ExcludedComputersDescriptionStaticControl);
                }
                
                return this.cachedExcludedComputersDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateAnExclusionRuleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.CreateAnExclusionRuleStaticControl
        {
            get
            {
                if ((this.cachedCreateAnExclusionRuleStaticControl == null))
                {
                    this.cachedCreateAnExclusionRuleStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.CreateAnExclusionRuleStaticControl);
                }
                
                return this.cachedCreateAnExclusionRuleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionCriteriaStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExclusionCriteriaWindowControls.ExclusionCriteriaStaticControl2
        {
            get
            {
                if ((this.cachedExclusionCriteriaStaticControl2 == null))
                {
                    this.cachedExclusionCriteriaStaticControl2 = new StaticControl(this, ExclusionCriteriaWindow.ControlIDs.ExclusionCriteriaStaticControl2);
                }
                
                return this.cachedExclusionCriteriaStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = 
                    new Window(
                        Strings.WindowTitle, 
                        StringMatchSyntax.WildCard, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        ownerWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.WindowTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title := '" +
                        Strings.WindowTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
            private const string ResourceWindowTitle =
                ";Agent Assignment and Failover Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ADIntegrationWizardCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious =
                ";< &Previous" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext =
                ";&Next >" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";nextButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate =
                ";&Create;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework" +
                ";buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp =
                ";Help" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework" +
                ";buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction =
                ";Introduction" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";WelcomeTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain =
                ";Domain" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnDomain";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInclusionCriteria =
                ";Inclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;InclusionRuleTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExclusionCriteria =
                ";Exclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ExclusionRuleTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentFailover =
                ";Agent Failover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AgentFailoverTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludedComputersExample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedComputersExample =
                ";E.g. SALES.CONTOSO.COM" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ExclusionRule" +
                ";labelExample.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SeparateEachComputerNameByASemiColonCommaOrANewLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedComputersDirections=
                ";Separate each computer name by a semi-colon, comma, or a new line:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ExclusionRule" +
                ";label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludedComputersDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedComputersDescriptionStaticControl = @";Exclude computers from the previous inclusion query by manually typing in the Fully Qualified Domain Name (FQDN) of the computer(s) you would like to exclude from the rule.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ExclusionRule;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateAnExclusionRule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateAnExclusionRule =
                ";Create an exclusion rule" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ExclusionRule" +
                ";labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExclusionCriteria2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExclusionCriteria2 =
                ";Exclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ExclusionRuleTitle";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
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
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludedComputersExample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedComputersExample;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SeparateEachComputerNameByASemiColonCommaOrANewLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedComputersDirections;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludedComputersDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedComputersDescriptionStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateAnExclusionRule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateAnExclusionRule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExclusionCriteria2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExclusionCriteria2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction
            {
                get
                {
                    if ((cachedIntroduction == null))
                    {
                        cachedIntroduction = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction);
                    }
                    
                    return cachedIntroduction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Domain
            {
                get
                {
                    if ((cachedDomain == null))
                    {
                        cachedDomain = CoreManager.MomConsole.GetIntlStr(ResourceDomain);
                    }
                    
                    return cachedDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InclusionCriteria
            {
                get
                {
                    if ((cachedInclusionCriteria == null))
                    {
                        cachedInclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceInclusionCriteria);
                    }
                    
                    return cachedInclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExclusionCriteria
            {
                get
                {
                    if ((cachedExclusionCriteria == null))
                    {
                        cachedExclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceExclusionCriteria);
                    }
                    
                    return cachedExclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentFailover
            {
                get
                {
                    if ((cachedAgentFailover == null))
                    {
                        cachedAgentFailover = CoreManager.MomConsole.GetIntlStr(ResourceAgentFailover);
                    }
                    
                    return cachedAgentFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedComputersExample translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludedComputersExample
            {
                get
                {
                    if ((cachedExcludedComputersExample == null))
                    {
                        cachedExcludedComputersExample = CoreManager.MomConsole.GetIntlStr(ResourceExcludedComputersExample);
                    }
                    
                    return cachedExcludedComputersExample;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedComputersDirectionstranslated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludedComputersDirections
            {
                get
                {
                    if ((cachedExcludedComputersDirections == null))
                    {
                        cachedExcludedComputersDirections = CoreManager.MomConsole.GetIntlStr(ResourceExcludedComputersDirections);
                    }

                    return cachedExcludedComputersDirections;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedComputersDescriptionStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludedComputersDescriptionStaticControl
            {
                get
                {
                    if ((cachedExcludedComputersDescriptionStaticControl == null))
                    {
                        cachedExcludedComputersDescriptionStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceExcludedComputersDescriptionStaticControl);
                    }
                    
                    return cachedExcludedComputersDescriptionStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateAnExclusionRule translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateAnExclusionRule
            {
                get
                {
                    if ((cachedCreateAnExclusionRule == null))
                    {
                        cachedCreateAnExclusionRule = CoreManager.MomConsole.GetIntlStr(ResourceCreateAnExclusionRule);
                    }
                    
                    return cachedCreateAnExclusionRule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the ExclusionCriteria2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExclusionCriteria2
            {
                get
                {
                    if ((cachedExclusionCriteria2 == null))
                    {
                        cachedExclusionCriteria2 = CoreManager.MomConsole.GetIntlStr(ResourceExclusionCriteria2);
                    }
                    
                    return cachedExclusionCriteria2;
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
        /// 	[KellyMor] 10/24/2007 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for InclusionCriteriaStaticControl
            /// </summary>
            public const string InclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExclusionCriteriaStaticControl
            /// </summary>
            public const string ExclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AgentFailoverStaticControl
            /// </summary>
            public const string AgentFailoverStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExcludedComputersExampleStaticControl
            /// </summary>
            public const string ExcludedComputersExampleStaticControl = "labelExample";
            
            /// <summary>
            /// Control ID for ExcludedComputersDirectionsStaticControl
            /// </summary>
            public const string ExcludedComputersDirectionsStaticControl = "label1";
            
            /// <summary>
            /// Control ID for ExcludedComputersTextBox
            /// </summary>
            public const string ExcludedComputersTextBox = "richTextBoxComputers";
            
            /// <summary>
            /// Control ID for ExcludedComputersDescriptionStaticControl
            /// </summary>
            public const string ExcludedComputersDescriptionStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for CreateAnExclusionRuleStaticControl
            /// </summary>
            public const string CreateAnExclusionRuleStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ExclusionCriteriaStaticControl2
            /// </summary>
            public const string ExclusionCriteriaStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
