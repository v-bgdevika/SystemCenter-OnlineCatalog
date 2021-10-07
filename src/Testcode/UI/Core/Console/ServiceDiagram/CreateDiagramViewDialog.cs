// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateDiagramViewDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 UI Automation
// </project>
// <summary>
// 	MOMv3 UI Automation
// </summary>
// <history>
// 	[KellyMor]  05APR07 Created
//  [KellyMor]  06APR07 Added resource strings for tabs and direction combobox
//  [KellyMor]  13APR07 Added overloaded constructor to take the view name as parameter for
//                      the dialog title when displaying view properties
//  [KellyMor]  12AUG08 Added support for virtual grouping controls:
//                      Added Radio Group Enumeration VirtualGroupsRadioGroup
//                      Added enumeration element for virtual grouping tab
//                      Added radio buttons to interface for virtual grouping
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.ServiceDiagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Radio Group Enumerations

    #region Radio Group Enumeration - TemplateRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group TemplateRadioGroup
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TemplateRadioGroup
    {
        /// <summary>
        /// CreateYourOwnTemplate = 0
        /// </summary>
        CreateYourOwnTemplate = 0,
        
        /// <summary>
        /// ChooseFromATemplate = 1
        /// </summary>
        ChooseFromATemplate = 1,
    }

    #endregion

    #region Radio Group Enumeration - ContainmentStyleRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ContainmentStyleRadioGroup
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ContainmentStyleRadioGroup
    {
        /// <summary>
        /// BoxLayout = 0
        /// </summary>
        BoxLayout = 0,

        /// <summary>
        /// NonBoxLayout = 1
        /// </summary>
        NonBoxLayout = 1,
    }

    #endregion

    #region Radio Group Enumeration - VirtualGroupsRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group VirtualGroupsRadioGroup
    /// </summary>
    /// <history>
    /// 	[KellyMor] 12AUG08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum VirtualGroupsRadioGroup
    {
        /// <summary>
        /// DoNotVirtuallyGroup = 0
        /// </summary>
        DoNotVirtuallyGroup = 0,

        /// <summary>
        /// VirtuallyGroup  = 1
        /// </summary>
        VirtuallyGroup = 1,
    }

    #endregion

    #endregion

    #region Tab Control Tabs Enumeration

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for tab control tabs
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TabControlTabs
    {
        /// <summary>
        /// DiagramProperties = 0
        /// </summary>
        DiagramProperties = 0,

        /// <summary>
        /// ObjectProperties = 1,
        /// </summary>
        ObjectProperties = 1,

        /// <summary>
        /// LineProperties = 2,
        /// </summary>
        LineProperties = 2,

        /// <summary>
        /// VirtualGrouping = 3
        /// </summary>
        VirtualGrouping = 3,
    }

    #endregion

    #region Interface Definition - ICreateDiagramViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateDiagramViewDialogControls, for CreateDiagramViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateDiagramViewDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewDetailsButton
        /// </summary>
        Button ViewDetailsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateYourOwnTemplateRadioButton
        /// </summary>
        RadioButton CreateYourOwnTemplateRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseFromATemplateRadioButton
        /// </summary>
        RadioButton ChooseFromATemplateRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BoxLayoutRadioButton
        /// </summary>
        RadioButton BoxLayoutRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NonBoxLayoutRadioButton
        /// </summary>
        RadioButton NonBoxLayoutRadioButton
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
        /// Read-only property to access TemplateComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox TemplateComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PropertiesTabControl
        /// </summary>
        TabControl PropertiesTabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic
        /// </summary>
        StaticControl ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl
        /// </summary>
        StaticControl SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LevelsToShowComboBox
        /// </summary>
        TextBox LevelsToShowTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LevelsToShowStaticControl
        /// </summary>
        StaticControl LevelsToShowStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LayoutDirectionStaticControl
        /// </summary>
        StaticControl LayoutDirectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DirectionComboBox
        /// </summary>
        ComboBox DirectionComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NodesPerRowTextBox
        /// </summary>
        Spinner NodesPerRowSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseTargetStaticControl
        /// </summary>
        StaticControl ChooseTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseTargetTextBox
        /// </summary>
        TextBox ChooseTargetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
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
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DoNotVirtuallyGroupRadioButton
        /// </summary>
        RadioButton DoNotVirtuallyGroupRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access VirtuallyGroupRadioButton
        /// </summary>
        RadioButton VirtuallyGroupRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MinimumNumberOfChildNodesOfAVirtualNodeStaticControl
        /// </summary>
        StaticControl MinimumNumberOfChildNodesOfAVirtualNodeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MinimumVirtualGroupChildrenComboBox
        /// </summary>
        ComboBox MinimumVirtualGroupChildrenComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MinimumVirtualGroupChildrenStaticControl
        /// </summary>
        StaticControl MinimumVirtualGroupChildrenStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl
        /// </summary>
        StaticControl VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access VirtualGroupThresholdComboBox
        /// </summary>
        ComboBox VirtualGroupThresholdComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access VirtualGroupThresholdStaticControl
        /// </summary>
        StaticControl VirtualGroupThresholdStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl
        /// </summary>
        StaticControl SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MaximumNumberOfChildrenComboBox
        /// </summary>
        ComboBox MaximumNumberOfChildrenComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MaximumNumberOfChildrenStaticControl
        /// </summary>
        StaticControl MaximumNumberOfChildrenStaticControl
        {
            get;
        }   
    }

    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Create Diagram View dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateDiagramViewDialog : Dialog, ICreateDiagramViewDialogControls
    {
        #region Public Constants

        /// <summary>
        /// Minimum number of levels to display
        /// </summary>
        public const int MinDisplayDepth = 0;

        /// <summary>
        /// Maximum number of levels to display
        /// </summary>
        public const int MaxDisplayDepth = 100;

        /// <summary>
        /// Minimum number of nodes displayed per row in box layout mode
        /// </summary>
        public const int MinNodesPerRow = 1;

        /// <summary>
        /// Maximum number of nodes displayed per row in box layout mode
        /// </summary>
        public const int MaxNodesPerRow = 100;

        #endregion

        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewDetailsButton of type Button
        /// </summary>
        private Button cachedViewDetailsButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateYourOwnTemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedCreateYourOwnTemplateRadioButton;

        #region Object Properties Controls

        /// <summary>
        /// Cache to hold a reference to ChooseFromATemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBoxLayoutRadioButton;

        /// <summary>
        /// Cache to hold a reference to CreateYourOwnTemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNonBoxLayoutRadioButton;

        /// <summary>
        /// Cache to hold a reference to NodesPerRowTextBox of type TextBox
        /// </summary>
        private Spinner cachedNodesPerRowSpinner;

        #endregion Object Properties Controls

        /// <summary>
        /// Cache to hold a reference to ChooseFromATemplateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedChooseFromATemplateRadioButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to TemplateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTemplateComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PropertiesTabControl of type TabControl
        /// </summary>
        private TabControl cachedPropertiesTabControl;

        #region Diagram Properties Controls

        /// <summary>
        /// Cache to hold a reference to ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic of type StaticControl
        /// </summary>
        private StaticControl cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LevelsToShowTextBox of type TextBox
        /// </summary>
        private TextBox cachedLevelsToShowTextBox;

        /// <summary>
        /// Cache to hold a reference to LevelsToShowStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLevelsToShowStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LayoutDirectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLayoutDirectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DirectionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDirectionComboBox;

        #endregion Diagram Properties Controls

        /// <summary>
        /// Cache to hold a reference to ChooseTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseTargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedChooseTargetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        #region Virtual Grouping Controls

        /// <summary>
        /// Cache to hold a reference to DoNotVirtuallyGroupRadioButton of type 
        /// RadioButton
        /// </summary>
        private RadioButton cachedDoNotVirtuallyGroupRadioButton;

        /// <summary>
        /// Cache to hold a reference to VirtuallyGroupRadioButton of type 
        /// RadioButton
        /// </summary>
        private RadioButton cachedVirtuallyGroupRadioButton;

        /// <summary>
        /// Cache to hold a reference to MinimumNumberOfChildNodesOfAVirtualNodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMinimumNumberOfChildNodesOfAVirtualNodeStaticControl;

        /// <summary>
        /// Cache to hold a reference to MinimumVirtualGroupChildrenComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMinimumVirtualGroupChildrenComboBox;

        /// <summary>
        /// Cache to hold a reference to MinimumVirtualGroupChildrenStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMinimumVirtualGroupChildrenStaticControl;

        /// <summary>
        /// Cache to hold a reference to VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedVirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl;

        /// <summary>
        /// Cache to hold a reference to VirtualGroupThresholdComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedVirtualGroupThresholdComboBox;

        /// <summary>
        /// Cache to hold a reference to VirtualGroupThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedVirtualGroupThresholdStaticControl;

        /// <summary>
        /// Cache to hold a reference to SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl;

        /// <summary>
        /// Cache to hold a reference to MaximumNumberOfChildrenComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMaximumNumberOfChildrenComboBox;

        /// <summary>
        /// Cache to hold a reference to MaximumNumberOfChildrenStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaximumNumberOfChildrenStaticControl;

        #endregion Virtual Grouping Controls

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateDiagramViewDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateDiagramViewDialog(Maui.Core.App app)
            : base(app, Init(app, Strings.DialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Custom constructor to find diagram view properties dialog with specified
        /// name as the title.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateDiagramViewDialog of type Maui.Core.App
        /// </param>
        /// <param name="viewNameAsTitle">Title of the view properties dialog</param>
        /// <history>
        /// 	[KellyMor] 13APR07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateDiagramViewDialog(Maui.Core.App app, string viewNameAsTitle)
            : base(app, Init(app, viewNameAsTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        #region TemplateRadioGroup

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group TemplateRadioGroup
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual TemplateRadioGroup TemplateRadioGroup
        {
            get
            {
                if ((this.Controls.CreateYourOwnTemplateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TemplateRadioGroup.CreateYourOwnTemplate;
                }
                
                if ((this.Controls.ChooseFromATemplateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TemplateRadioGroup.ChooseFromATemplate;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == TemplateRadioGroup.CreateYourOwnTemplate))
                {
                    this.Controls.CreateYourOwnTemplateRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == TemplateRadioGroup.ChooseFromATemplate))
                    {
                        this.Controls.ChooseFromATemplateRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion

        #region ContainmentStyleRadioGroup

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ContainmentStyleRadioGroup
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ContainmentStyleRadioGroup ContainmentStyleRadioGroup
        {
            get
            {
                if ((this.Controls.BoxLayoutRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ContainmentStyleRadioGroup.BoxLayout;
                }

                if ((this.Controls.NonBoxLayoutRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ContainmentStyleRadioGroup.NonBoxLayout;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ContainmentStyleRadioGroup.BoxLayout))
                {
                    this.Controls.BoxLayoutRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ContainmentStyleRadioGroup.NonBoxLayout))
                    {
                        this.Controls.NonBoxLayoutRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion

        #region VirtualGroupsRadioGroup

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group VirtualGroupsRadioGroup
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual VirtualGroupsRadioGroup VirtualGroupsRadioGroup
        {
            get
            {
                if ((this.Controls.DoNotVirtuallyGroupRadioButton.ButtonState == ButtonState.Checked))
                {
                    return VirtualGroupsRadioGroup.DoNotVirtuallyGroup;
                }

                if ((this.Controls.VirtuallyGroupRadioButton.ButtonState == ButtonState.Checked))
                {
                    return VirtualGroupsRadioGroup.VirtuallyGroup;
                }

                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == VirtualGroupsRadioGroup.DoNotVirtuallyGroup))
                {
                    this.Controls.DoNotVirtuallyGroupRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == VirtualGroupsRadioGroup.VirtuallyGroup))
                    {
                        this.Controls.VirtuallyGroupRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region ICreateDiagramViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateDiagramViewDialogControls Controls
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
        ///  Routine to set/get the text in control TemplateComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TemplateComboBoxText
        {
            get
            {
                return this.Controls.TemplateComboBox.Text;
            }
            
            set
            {
                this.Controls.TemplateComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LevelsToShow
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LevelsToShowText
        {
            get
            {
                return this.Controls.LevelsToShowTextBox.Text;
            }
            
            set
            {
                //Bug#219262
                this.Controls.LevelsToShowTextBox.ScreenElement.SendKeys(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DirectionComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DirectionComboBoxText
        {
            get
            {
                return this.Controls.DirectionComboBox.Text;
            }
            
            set
            {
                this.Controls.DirectionComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NodesPerRowComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual int NodesPerRowSpinner
        {
            get
            {
                return this.Controls.NodesPerRowSpinner.Value;
            }

            set
            {
                this.Controls.NodesPerRowSpinner.SpinToPos(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ChooseTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ChooseTargetText
        {
            get
            {
                return this.Controls.ChooseTargetTextBox.Text;
            }
            
            set
            {
                this.Controls.ChooseTargetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MinimumVirtualGroupChildren
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinimumVirtualGroupChildrenText
        {
            get
            {
                return this.Controls.MinimumVirtualGroupChildrenComboBox.Text;
            }

            set
            {
                this.Controls.MinimumVirtualGroupChildrenComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control VirtualGroupThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string VirtualGroupThresholdText
        {
            get
            {
                return this.Controls.VirtualGroupThresholdComboBox.Text;
            }

            set
            {
                this.Controls.VirtualGroupThresholdComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MaximumNumberOfChildren
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumNumberOfChildrenText
        {
            get
            {
                return this.Controls.MaximumNumberOfChildrenComboBox.Text;
            }

            set
            {
                this.Controls.MaximumNumberOfChildrenComboBox.SelectByText(value, true);
            }
        }
        
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewDetailsButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.ViewDetailsButton
        {
            get
            {
                if ((this.cachedViewDetailsButton == null))
                {
                    this.cachedViewDetailsButton = new Button(this, CreateDiagramViewDialog.ControlIDs.ViewDetailsButton);
                }
                
                return this.cachedViewDetailsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateYourOwnTemplateRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.CreateYourOwnTemplateRadioButton
        {
            get
            {
                if ((this.cachedCreateYourOwnTemplateRadioButton == null))
                {
                    this.cachedCreateYourOwnTemplateRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.CreateYourOwnTemplateRadioButton);
                }
                
                return this.cachedCreateYourOwnTemplateRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseFromATemplateRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.ChooseFromATemplateRadioButton
        {
            get
            {
                if ((this.cachedChooseFromATemplateRadioButton == null))
                {
                    this.cachedChooseFromATemplateRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.ChooseFromATemplateRadioButton);
                }
                
                return this.cachedChooseFromATemplateRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BoxLayoutRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.BoxLayoutRadioButton
        {
            get
            {
                if ((this.cachedBoxLayoutRadioButton == null))
                {
                    this.ClickTab(TabControlTabs.ObjectProperties);
                    this.cachedBoxLayoutRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.BoxLayoutRadioButton);
                }

                return this.cachedBoxLayoutRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NonBoxLayoutRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.NonBoxLayoutRadioButton
        {
            get
            {
                if ((this.cachedNonBoxLayoutRadioButton == null))
                {
                    this.ClickTab(TabControlTabs.ObjectProperties);
                    this.cachedNonBoxLayoutRadioButton = new RadioButton(this, CreateDiagramViewDialog.ControlIDs.NonBoxLayoutRadioButton);
                }

                return this.cachedNonBoxLayoutRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateDiagramViewDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TemplateComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.TemplateComboBox
        {
            get
            {
                if ((this.cachedTemplateComboBox == null))
                {
                    this.cachedTemplateComboBox = new ComboBox(this, CreateDiagramViewDialog.ControlIDs.TemplateComboBox);
                }
                
                return this.cachedTemplateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertiesTabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ICreateDiagramViewDialogControls.PropertiesTabControl
        {
            get
            {
                if ((this.cachedPropertiesTabControl == null))
                {
                    this.cachedPropertiesTabControl = new TabControl(this, CreateDiagramViewDialog.ControlIDs.PropertiesTabControl);
                }
                
                return this.cachedPropertiesTabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic
        {
            get
            {
                if ((this.cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic == null))
                {
                    this.cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic);
                }
                
                return this.cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl
        {
            get
            {
                if ((this.cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl == null))
                {
                    this.cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl);
                }
                
                return this.cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LevelsToShowTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.LevelsToShowTextBox
        {
            get
            {
                if ((this.cachedLevelsToShowTextBox == null))
                {
                    this.ClickTab(TabControlTabs.DiagramProperties);
                    this.cachedLevelsToShowTextBox = new TextBox(this, CreateDiagramViewDialog.ControlIDs.LevelsToShowTextBox);
                }
                
                return this.cachedLevelsToShowTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NodesPerRowTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ICreateDiagramViewDialogControls.NodesPerRowSpinner
        {
            get
            {
                if ((this.cachedNodesPerRowSpinner == null))
                {
                    this.ClickTab(TabControlTabs.ObjectProperties);
                    this.cachedNodesPerRowSpinner = new Spinner(this, CreateDiagramViewDialog.ControlIDs.NodesPerRowTextBox);
                }

                return this.cachedNodesPerRowSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LevelsToShowStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.LevelsToShowStaticControl
        {
            get
            {
                if ((this.cachedLevelsToShowStaticControl == null))
                {
                    this.ClickTab(TabControlTabs.DiagramProperties);
                    this.cachedLevelsToShowStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.LevelsToShowStaticControl);
                }
                
                return this.cachedLevelsToShowStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LayoutDirectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.LayoutDirectionStaticControl
        {
            get
            {
                if ((this.cachedLayoutDirectionStaticControl == null))
                {
                    this.ClickTab(TabControlTabs.DiagramProperties);
                    this.cachedLayoutDirectionStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.LayoutDirectionStaticControl);
                }
                
                return this.cachedLayoutDirectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectionComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.DirectionComboBox
        {
            get
            {
                if ((this.cachedDirectionComboBox == null))
                {
                    this.cachedDirectionComboBox = new ComboBox(this, CreateDiagramViewDialog.ControlIDs.DirectionComboBox);
                }

                return this.cachedDirectionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.ChooseTargetStaticControl
        {
            get
            {
                if ((this.cachedChooseTargetStaticControl == null))
                {
                    this.cachedChooseTargetStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.ChooseTargetStaticControl);
                }
                
                return this.cachedChooseTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseTargetTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.ChooseTargetTextBox
        {
            get
            {
                if ((this.cachedChooseTargetTextBox == null))
                {
                    this.cachedChooseTargetTextBox = new TextBox(this, CreateDiagramViewDialog.ControlIDs.ChooseTargetTextBox);
                }
                
                return this.cachedChooseTargetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, CreateDiagramViewDialog.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, CreateDiagramViewDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateDiagramViewDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, CreateDiagramViewDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, CreateDiagramViewDialog.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateDiagramViewDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, CreateDiagramViewDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotVirtuallyGroupRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.DoNotVirtuallyGroupRadioButton
        {
            get
            {
                if ((this.cachedDoNotVirtuallyGroupRadioButton == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedDoNotVirtuallyGroupRadioButton =
                        new RadioButton(
                            this,
                            CreateDiagramViewDialog.ControlIDs.DoNotVirtuallyGroupRadioButton);
                }

                return this.cachedDoNotVirtuallyGroupRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VirtuallyGroupRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateDiagramViewDialogControls.VirtuallyGroupRadioButton
        {
            get
            {
                if ((this.cachedVirtuallyGroupRadioButton == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedVirtuallyGroupRadioButton =
                        new RadioButton(
                            this,
                            CreateDiagramViewDialog.ControlIDs.VirtuallyGroupRadioButton);
                }

                return this.cachedVirtuallyGroupRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumNumberOfChildNodesOfAVirtualNodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.MinimumNumberOfChildNodesOfAVirtualNodeStaticControl
        {
            get
            {
                if ((this.cachedMinimumNumberOfChildNodesOfAVirtualNodeStaticControl == null))
                {
                    this.cachedMinimumNumberOfChildNodesOfAVirtualNodeStaticControl = 
                        new StaticControl(
                            this, 
                            CreateDiagramViewDialog.ControlIDs.MinimumNumberOfChildNodesOfAVirtualNodeStaticControl);
                }

                return this.cachedMinimumNumberOfChildNodesOfAVirtualNodeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumVirtualGroupChildrenComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.MinimumVirtualGroupChildrenComboBox
        {
            get
            {
                if ((this.cachedMinimumVirtualGroupChildrenComboBox == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedMinimumVirtualGroupChildrenComboBox =
                        new ComboBox(
                            this,
                            CreateDiagramViewDialog.ControlIDs.MinimumVirtualGroupChildrenComboBox);
                }

                return this.cachedMinimumVirtualGroupChildrenComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumVirtualGroupChildrenStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.MinimumVirtualGroupChildrenStaticControl
        {
            get
            {
                if ((this.cachedMinimumVirtualGroupChildrenStaticControl == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedMinimumVirtualGroupChildrenStaticControl =
                        new StaticControl(
                            this,
                            CreateDiagramViewDialog.ControlIDs.MinimumVirtualGroupChildrenStaticControl);
                }

                return this.cachedMinimumVirtualGroupChildrenStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl
        {
            get
            {
                if ((this.cachedVirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl == null))
                {
                    this.cachedVirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl = 
                        new StaticControl(
                            this, 
                            CreateDiagramViewDialog.ControlIDs.VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl);
                }

                return this.cachedVirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VirtualGroupThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.VirtualGroupThresholdComboBox
        {
            get
            {
                if ((this.cachedVirtualGroupThresholdComboBox == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedVirtualGroupThresholdComboBox =
                        new ComboBox(
                            this,
                            CreateDiagramViewDialog.ControlIDs.VirtualGroupThresholdComboBox);
                }

                return this.cachedVirtualGroupThresholdComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VirtualGroupThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.VirtualGroupThresholdStaticControl
        {
            get
            {
                if ((this.cachedVirtualGroupThresholdStaticControl == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedVirtualGroupThresholdStaticControl =
                        new StaticControl(
                            this,
                            CreateDiagramViewDialog.ControlIDs.VirtualGroupThresholdStaticControl);
                }

                return this.cachedVirtualGroupThresholdStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl
        {
            get
            {
                if ((this.cachedSpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl == null))
                {
                    this.cachedSpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl = 
                        new StaticControl(
                            this, 
                            CreateDiagramViewDialog.ControlIDs.SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl);
                }

                return this.cachedSpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumNumberOfChildrenComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateDiagramViewDialogControls.MaximumNumberOfChildrenComboBox
        {
            get
            {
                if ((this.cachedMaximumNumberOfChildrenComboBox == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedMaximumNumberOfChildrenComboBox =
                        new ComboBox(
                            this,
                            CreateDiagramViewDialog.ControlIDs.MaximumNumberOfChildrenComboBox);
                }

                return this.cachedMaximumNumberOfChildrenComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumNumberOfChildrenStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMOr] 12AUG08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateDiagramViewDialogControls.MaximumNumberOfChildrenStaticControl
        {
            get
            {
                if ((this.cachedMaximumNumberOfChildrenStaticControl == null))
                {
                    this.ClickTab(TabControlTabs.VirtualGrouping);
                    this.cachedMaximumNumberOfChildrenStaticControl =
                        new StaticControl(
                            this,
                            CreateDiagramViewDialog.ControlIDs.MaximumNumberOfChildrenStaticControl);
                }

                return this.cachedMaximumNumberOfChildrenStaticControl;
            }
        }
        
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ViewDetails
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickViewDetails()
        {
            this.Controls.ViewDetailsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the specified tab control
        /// </summary>
        /// <param name="selectedTab">
        /// TabControlTabs enumeration indicating which tab to select.
        /// </param>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTab(TabControlTabs selectedTab)
        {
            this.Controls.PropertiesTabControl[(int)selectedTab].Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">Maui.Core.App owning the dialog.</param>
        /// <param name="dialogTitle">Dialog title text</param>
        /// <history>
        /// 	[KellyMor] 05APR07 Created
        ///     [KellyMor] 13APR07 Added parameter for dialog title
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        dialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
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
                        tempWindow = 
                            new Window(
                                dialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
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
                        "Failed to find the '" +
                        CreateDiagramViewDialog.Strings.DialogTitle +
                        "' window.");

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
        /// 	[KellyMor] 4/5/2007 Created
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
            private const string ResourceDialogTitle = ";Create Diagram View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewDetails = ";&View Details...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;viewTemplateButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateYourOwnTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateYourOwnTemplate = ";Create yo&ur own template;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;customRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseFromATemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseFromATemplate = ";Choose from a tem&plate;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;templateRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere = @";(Choose the layout direction you want to set for your diagram view. All the objects will obey the direction set here);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionInfoLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView = @";(Specify how many levels deep you would like to be displayed when first opening the diagram view);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;levelsToShowInfoLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LevelsToShow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLevelsToShow = ";Levels to S&how : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;levelsToShowLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LayoutDirection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLayoutDirection = ";Layou&t Direction : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseTarget = ";Choo&se Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;targetLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = ";Br&owse ...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;moButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";D&escription : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Cre&ate;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;okButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NorthSouth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNorthSouth = ";North South;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionComboBox.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SouthNorth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSouthNorth = ";South North;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionComboBox.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EastWest
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEastWest = ";East West;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionComboBox.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WestEast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWestEast = ";West East;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;directionComboBox.Items3";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiagramProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagramProperties = ";Diagram Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;diagramTabPage.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectProperties = ";Object Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;objectTabPage.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LineProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLineProperties = ";Line Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;lineTabPage.Text";

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
            /// Caches the translated resource string for:  ViewDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateYourOwnTemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateYourOwnTemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseFromATemplate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseFromATemplate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LevelsToShow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLevelsToShow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LayoutDirection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLayoutDirection;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NorthSouth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNorthSouth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SouthNorth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSouthNorth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EastWest
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEastWest;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WestEast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWestEast;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: DiagramProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagramProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: ObjectProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: LineProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLineProperties;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
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
            /// Exposes access to the ViewDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewDetails
            {
                get
                {
                    if ((cachedViewDetails == null))
                    {
                        cachedViewDetails = CoreManager.MomConsole.GetIntlStr(ResourceViewDetails);
                    }
                    
                    return cachedViewDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateYourOwnTemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateYourOwnTemplate
            {
                get
                {
                    if ((cachedCreateYourOwnTemplate == null))
                    {
                        cachedCreateYourOwnTemplate = CoreManager.MomConsole.GetIntlStr(ResourceCreateYourOwnTemplate);
                    }
                    
                    return cachedCreateYourOwnTemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseFromATemplate translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseFromATemplate
            {
                get
                {
                    if ((cachedChooseFromATemplate == null))
                    {
                        cachedChooseFromATemplate = CoreManager.MomConsole.GetIntlStr(ResourceChooseFromATemplate);
                    }
                    
                    return cachedChooseFromATemplate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere
            {
                get
                {
                    if ((cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere == null))
                    {
                        cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere = CoreManager.MomConsole.GetIntlStr(ResourceChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere);
                    }
                    
                    return cachedChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHere;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView
            {
                get
                {
                    if ((cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView == null))
                    {
                        cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView);
                    }
                    
                    return cachedSpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramView;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LevelsToShow translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LevelsToShow
            {
                get
                {
                    if ((cachedLevelsToShow == null))
                    {
                        cachedLevelsToShow = CoreManager.MomConsole.GetIntlStr(ResourceLevelsToShow);
                    }
                    
                    return cachedLevelsToShow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LayoutDirection translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LayoutDirection
            {
                get
                {
                    if ((cachedLayoutDirection == null))
                    {
                        cachedLayoutDirection = CoreManager.MomConsole.GetIntlStr(ResourceLayoutDirection);
                    }
                    
                    return cachedLayoutDirection;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseTarget
            {
                get
                {
                    if ((cachedChooseTarget == null))
                    {
                        cachedChooseTarget = CoreManager.MomConsole.GetIntlStr(ResourceChooseTarget);
                    }
                    
                    return cachedChooseTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    
                    return cachedBrowse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    
                    return cachedDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
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
            /// Exposes access to the NorthSouth translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NorthSouth
            {
                get
                {
                    if ((cachedNorthSouth == null))
                    {
                        cachedNorthSouth = CoreManager.MomConsole.GetIntlStr(ResourceNorthSouth);
                    }

                    return cachedNorthSouth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SouthNorth translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SouthNorth
            {
                get
                {
                    if ((cachedSouthNorth == null))
                    {
                        cachedSouthNorth = CoreManager.MomConsole.GetIntlStr(ResourceSouthNorth);
                    }

                    return cachedSouthNorth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EastWest translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EastWest
            {
                get
                {
                    if ((cachedEastWest == null))
                    {
                        cachedEastWest = CoreManager.MomConsole.GetIntlStr(ResourceEastWest);
                    }

                    return cachedEastWest;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WestEast translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WestEast
            {
                get
                {
                    if ((cachedWestEast == null))
                    {
                        cachedWestEast = CoreManager.MomConsole.GetIntlStr(ResourceWestEast);
                    }

                    return cachedWestEast;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagramProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagramProperties
            {
                get
                {
                    if ((cachedDiagramProperties == null))
                    {
                        cachedDiagramProperties = CoreManager.MomConsole.GetIntlStr(ResourceDiagramProperties);
                    }

                    return cachedDiagramProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectProperties
            {
                get
                {
                    if ((cachedObjectProperties == null))
                    {
                        cachedObjectProperties = CoreManager.MomConsole.GetIntlStr(ResourceObjectProperties);
                    }

                    return cachedObjectProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LineProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LineProperties
            {
                get
                {
                    if ((cachedLineProperties == null))
                    {
                        cachedLineProperties = CoreManager.MomConsole.GetIntlStr(ResourceLineProperties);
                    }

                    return cachedLineProperties;
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
        /// 	[KellyMor] 4/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewDetailsButton
            /// </summary>
            public const string ViewDetailsButton = "viewTemplateButton";
            
            /// <summary>
            /// Control ID for CreateYourOwnTemplateRadioButton
            /// </summary>
            public const string CreateYourOwnTemplateRadioButton = "customRadioButton";
            
            /// <summary>
            /// Control ID for ChooseFromATemplateRadioButton
            /// </summary>
            public const string ChooseFromATemplateRadioButton = "templateRadioButton";

            /// <summary>
            /// Control ID for BoxLayoutRadioButton
            /// </summary>
            public const string BoxLayoutRadioButton = "boxRadioButton";

            /// <summary>
            /// Control ID for NonBoxLayoutRadioButton
            /// </summary>
            public const string NonBoxLayoutRadioButton = "nonBoxRadioButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for TemplateComboBox
            /// </summary>
            public const string TemplateComboBox = "templateComboBox";

            /// <summary>
            /// Control ID for NodesPerRowTextBox
            /// </summary>
            public const string NodesPerRowTextBox = "nodesPerRowUpDown";
            
            /// <summary>
            /// Control ID for PropertiesTabControl
            /// </summary>
            public const string PropertiesTabControl = "propertiesTabControl";
            
            /// <summary>
            /// Control ID for ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic
            /// </summary>
            public const string ChooseTheLayoutDirectionYouWantToSetForYourDiagramViewAllTheObjectsWillObeyTheDirectionSetHereStatic = "directionInfoLabel";
            
            /// <summary>
            /// Control ID for SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl
            /// </summary>
            public const string SpecifyHowManyLevelsDeepYouWouldLikeToBeDisplayedWhenFirstOpeningTheDiagramViewStaticControl = "levelsToShowInfoLabel";
            
            /// <summary>
            /// Control ID for LevelsToShowTextBox
            /// </summary>
            public const string LevelsToShowTextBox = "levelsToShowUpDown";
            
            /// <summary>
            /// Control ID for LevelsToShowStaticControl
            /// </summary>
            public const string LevelsToShowStaticControl = "levelsToShowLabel";
            
            /// <summary>
            /// Control ID for LayoutDirectionStaticControl
            /// </summary>
            public const string LayoutDirectionStaticControl = "directionLabel";
            
            /// <summary>
            /// Control ID for DirectionComboBox
            /// </summary>
            public const string DirectionComboBox = "directionComboBox";
            
            /// <summary>
            /// Control ID for ChooseTargetStaticControl
            /// </summary>
            public const string ChooseTargetStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for ChooseTargetTextBox
            /// </summary>
            public const string ChooseTargetTextBox = "moTextBox";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "moButton";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "okButton";

            /// <summary>
            /// Control ID for DoNotVirtuallyGroupRadioButton
            /// </summary>
            public const string DoNotVirtuallyGroupRadioButton = "noVgRB";

            /// <summary>
            /// Control ID for VirtuallyGroupRadioButton
            /// </summary>
            public const string VirtuallyGroupRadioButton = "vgRB";

            /// <summary>
            /// Control ID for MinimumNumberOfChildNodesOfAVirtualNodeStaticControl
            /// </summary>
            public const string MinimumNumberOfChildNodesOfAVirtualNodeStaticControl = "minBucketSizeInfo";

            /// <summary>
            /// Control ID for MinimumVirtualGroupChildrenComboBox
            /// </summary>
            public const string MinimumVirtualGroupChildrenComboBox = "minBucketSizeCtrl";

            /// <summary>
            /// Control ID for MinimumVirtualGroupChildrenStaticControl
            /// </summary>
            public const string MinimumVirtualGroupChildrenStaticControl = "minBucketSizeLabel";

            /// <summary>
            /// Control ID for VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl
            /// </summary>
            public const string VirtualGropingWillBeAppliedIfANodeHasMoreChildrenThanThisNumberSpecifiedHereStaticControl = "vgThresholdInfo";

            /// <summary>
            /// Control ID for VirtualGroupThresholdComboBox
            /// </summary>
            public const string VirtualGroupThresholdComboBox = "vgThresholdCtrl";

            /// <summary>
            /// Control ID for VirtualGroupThresholdStaticControl
            /// </summary>
            public const string VirtualGroupThresholdStaticControl = "vgThresholdLabel";

            /// <summary>
            /// Control ID for SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl
            /// </summary>
            public const string SpecifyMaximumNumberOfChildrenOfAVirtualNodeStaticControl = "maxNumChildInfo";

            /// <summary>
            /// Control ID for MaximumNumberOfChildrenComboBox
            /// </summary>
            public const string MaximumNumberOfChildrenComboBox = "maxNumChildrenCtrl";

            /// <summary>
            /// Control ID for MaximumNumberOfChildrenStaticControl
            /// </summary>
            public const string MaximumNumberOfChildrenStaticControl = "maxNumChildLabel";
        }
        #endregion
    }
}
