// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PersonalizeViewChartAreaDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 5/31/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    
    #region Interface Definition - IPersonalizeViewChartAreaDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPersonalizeViewChartAreaDialogControls, for PersonalizeViewChartAreaDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPersonalizeViewChartAreaDialogControls
    {
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
        /// Read-only property to access ShowYAxisCheckBox
        /// </summary>
        CheckBox ShowYAxisCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MicrosoftSansSerifStaticControl
        /// </summary>
        StaticControl MicrosoftSansSerifStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton
        /// </summary>
        Button ChangeButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton2
        /// </summary>
        Button ChangeButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FontStaticControl
        /// </summary>
        StaticControl FontStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowSideMarginCheckBox
        /// </summary>
        CheckBox ShowSideMarginCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InterlacedStripsCheckBox
        /// </summary>
        CheckBox InterlacedStripsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinorGridlinesCheckBox
        /// </summary>
        CheckBox MinorGridlinesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MajorGridlinesCheckBox
        /// </summary>
        CheckBox MajorGridlinesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowXAxisCheckBox
        /// </summary>
        CheckBox ShowXAxisCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MicrosoftSansSerifStaticControl2
        /// </summary>
        StaticControl MicrosoftSansSerifStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton3
        /// </summary>
        Button ChangeButton3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton4
        /// </summary>
        Button ChangeButton4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FontStaticControl2
        /// </summary>
        StaticControl FontStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowSideMarginCheckBox2
        /// </summary>
        CheckBox ShowSideMarginCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InterlacedStripsCheckBox2
        /// </summary>
        CheckBox InterlacedStripsCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinorGridlinesCheckBox2
        /// </summary>
        CheckBox MinorGridlinesCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MajorGridlinesCheckBox2
        /// </summary>
        CheckBox MajorGridlinesCheckBox2
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
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PersonalizeViewChartAreaDialog : Dialog, IPersonalizeViewChartAreaDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowYAxisCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedShowYAxisCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MicrosoftSansSerifStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMicrosoftSansSerifStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton of type Button
        /// </summary>
        private Button cachedChangeButton;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton2 of type Button
        /// </summary>
        private Button cachedChangeButton2;
        
        /// <summary>
        /// Cache to hold a reference to FontStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFontStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowSideMarginCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedShowSideMarginCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to InterlacedStripsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedInterlacedStripsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MinorGridlinesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMinorGridlinesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MajorGridlinesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMajorGridlinesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ShowXAxisCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedShowXAxisCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MicrosoftSansSerifStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMicrosoftSansSerifStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton3 of type Button
        /// </summary>
        private Button cachedChangeButton3;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton4 of type Button
        /// </summary>
        private Button cachedChangeButton4;
        
        /// <summary>
        /// Cache to hold a reference to FontStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedFontStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ShowSideMarginCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedShowSideMarginCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to InterlacedStripsCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedInterlacedStripsCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to MinorGridlinesCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedMinorGridlinesCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to MajorGridlinesCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedMajorGridlinesCheckBox2;
        
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
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PersonalizeViewChartAreaDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PersonalizeViewChartAreaDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPersonalizeViewChartAreaDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPersonalizeViewChartAreaDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ShowYAxis
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowYAxis
        {
            get
            {
                return this.Controls.ShowYAxisCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ShowYAxisCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ShowSideMargin
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowSideMargin
        {
            get
            {
                return this.Controls.ShowSideMarginCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ShowSideMarginCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox InterlacedStrips
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool InterlacedStrips
        {
            get
            {
                return this.Controls.InterlacedStripsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.InterlacedStripsCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MinorGridlines
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MinorGridlines
        {
            get
            {
                return this.Controls.MinorGridlinesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MinorGridlinesCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MajorGridlines
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MajorGridlines
        {
            get
            {
                return this.Controls.MajorGridlinesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MajorGridlinesCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ShowXAxis
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowXAxis
        {
            get
            {
                return this.Controls.ShowXAxisCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ShowXAxisCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ShowSideMargin2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowSideMargin2
        {
            get
            {
                return this.Controls.ShowSideMarginCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.ShowSideMarginCheckBox2.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox InterlacedStrips2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool InterlacedStrips2
        {
            get
            {
                return this.Controls.InterlacedStripsCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.InterlacedStripsCheckBox2.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MinorGridlines2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MinorGridlines2
        {
            get
            {
                return this.Controls.MinorGridlinesCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.MinorGridlinesCheckBox2.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MajorGridlines2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MajorGridlines2
        {
            get
            {
                return this.Controls.MajorGridlinesCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.MajorGridlinesCheckBox2.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IPersonalizeViewChartAreaDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, PersonalizeViewChartAreaDialog.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowYAxisCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.ShowYAxisCheckBox
        {
            get
            {
                if ((this.cachedShowYAxisCheckBox == null))
                {
                    this.cachedShowYAxisCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.ShowYAxisCheckBox);
                }
                
                return this.cachedShowYAxisCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MicrosoftSansSerifStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewChartAreaDialogControls.MicrosoftSansSerifStaticControl
        {
            get
            {
                if ((this.cachedMicrosoftSansSerifStaticControl == null))
                {
                    this.cachedMicrosoftSansSerifStaticControl = new StaticControl(this, PersonalizeViewChartAreaDialog.ControlIDs.MicrosoftSansSerifStaticControl);
                }
                
                return this.cachedMicrosoftSansSerifStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.ChangeButton
        {
            get
            {
                if ((this.cachedChangeButton == null))
                {
                    this.cachedChangeButton = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.ChangeButton);
                }
                
                return this.cachedChangeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.ChangeButton2
        {
            get
            {
                if ((this.cachedChangeButton2 == null))
                {
                    this.cachedChangeButton2 = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.ChangeButton2);
                }
                
                return this.cachedChangeButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FontStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewChartAreaDialogControls.FontStaticControl
        {
            get
            {
                if ((this.cachedFontStaticControl == null))
                {
                    this.cachedFontStaticControl = new StaticControl(this, PersonalizeViewChartAreaDialog.ControlIDs.FontStaticControl);
                }
                
                return this.cachedFontStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowSideMarginCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.ShowSideMarginCheckBox
        {
            get
            {
                if ((this.cachedShowSideMarginCheckBox == null))
                {
                    this.cachedShowSideMarginCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.ShowSideMarginCheckBox);
                }
                
                return this.cachedShowSideMarginCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InterlacedStripsCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.InterlacedStripsCheckBox
        {
            get
            {
                if ((this.cachedInterlacedStripsCheckBox == null))
                {
                    this.cachedInterlacedStripsCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.InterlacedStripsCheckBox);
                }
                
                return this.cachedInterlacedStripsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinorGridlinesCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.MinorGridlinesCheckBox
        {
            get
            {
                if ((this.cachedMinorGridlinesCheckBox == null))
                {
                    this.cachedMinorGridlinesCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.MinorGridlinesCheckBox);
                }
                
                return this.cachedMinorGridlinesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MajorGridlinesCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.MajorGridlinesCheckBox
        {
            get
            {
                if ((this.cachedMajorGridlinesCheckBox == null))
                {
                    this.cachedMajorGridlinesCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.MajorGridlinesCheckBox);
                }
                
                return this.cachedMajorGridlinesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowXAxisCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.ShowXAxisCheckBox
        {
            get
            {
                if ((this.cachedShowXAxisCheckBox == null))
                {
                    this.cachedShowXAxisCheckBox = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.ShowXAxisCheckBox);
                }
                
                return this.cachedShowXAxisCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MicrosoftSansSerifStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewChartAreaDialogControls.MicrosoftSansSerifStaticControl2
        {
            get
            {
                if ((this.cachedMicrosoftSansSerifStaticControl2 == null))
                {
                    this.cachedMicrosoftSansSerifStaticControl2 = new StaticControl(this, PersonalizeViewChartAreaDialog.ControlIDs.MicrosoftSansSerifStaticControl2);
                }
                
                return this.cachedMicrosoftSansSerifStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.ChangeButton3
        {
            get
            {
                if ((this.cachedChangeButton3 == null))
                {
                    this.cachedChangeButton3 = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.ChangeButton3);
                }
                
                return this.cachedChangeButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton4 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.ChangeButton4
        {
            get
            {
                if ((this.cachedChangeButton4 == null))
                {
                    this.cachedChangeButton4 = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.ChangeButton4);
                }
                
                return this.cachedChangeButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FontStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewChartAreaDialogControls.FontStaticControl2
        {
            get
            {
                if ((this.cachedFontStaticControl2 == null))
                {
                    this.cachedFontStaticControl2 = new StaticControl(this, PersonalizeViewChartAreaDialog.ControlIDs.FontStaticControl2);
                }
                
                return this.cachedFontStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowSideMarginCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.ShowSideMarginCheckBox2
        {
            get
            {
                if ((this.cachedShowSideMarginCheckBox2 == null))
                {
                    this.cachedShowSideMarginCheckBox2 = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.ShowSideMarginCheckBox2);
                }
                
                return this.cachedShowSideMarginCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InterlacedStripsCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.InterlacedStripsCheckBox2
        {
            get
            {
                if ((this.cachedInterlacedStripsCheckBox2 == null))
                {
                    this.cachedInterlacedStripsCheckBox2 = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.InterlacedStripsCheckBox2);
                }
                
                return this.cachedInterlacedStripsCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinorGridlinesCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.MinorGridlinesCheckBox2
        {
            get
            {
                if ((this.cachedMinorGridlinesCheckBox2 == null))
                {
                    this.cachedMinorGridlinesCheckBox2 = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.MinorGridlinesCheckBox2);
                }
                
                return this.cachedMinorGridlinesCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MajorGridlinesCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPersonalizeViewChartAreaDialogControls.MajorGridlinesCheckBox2
        {
            get
            {
                if ((this.cachedMajorGridlinesCheckBox2 == null))
                {
                    this.cachedMajorGridlinesCheckBox2 = new CheckBox(this, PersonalizeViewChartAreaDialog.ControlIDs.MajorGridlinesCheckBox2);
                }
                
                return this.cachedMajorGridlinesCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewChartAreaDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PersonalizeViewChartAreaDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowYAxis
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowYAxis()
        {
            this.Controls.ShowYAxisCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange()
        {
            this.Controls.ChangeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange2()
        {
            this.Controls.ChangeButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowSideMargin
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowSideMargin()
        {
            this.Controls.ShowSideMarginCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InterlacedStrips
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInterlacedStrips()
        {
            this.Controls.InterlacedStripsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MinorGridlines
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMinorGridlines()
        {
            this.Controls.MinorGridlinesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MajorGridlines
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMajorGridlines()
        {
            this.Controls.MajorGridlinesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowXAxis
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowXAxis()
        {
            this.Controls.ShowXAxisCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change3
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange3()
        {
            this.Controls.ChangeButton3.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change4
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange4()
        {
            this.Controls.ChangeButton4.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowSideMargin2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowSideMargin2()
        {
            this.Controls.ShowSideMarginCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button InterlacedStrips2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInterlacedStrips2()
        {
            this.Controls.InterlacedStripsCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MinorGridlines2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMinorGridlines2()
        {
            this.Controls.MinorGridlinesCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MajorGridlines2
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMajorGridlines2()
        {
            this.Controls.MajorGridlinesCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
        /// 	[mbickle] 5/31/2007 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

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
        /// 	[mbickle] 5/31/2007 Created
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
            private const string ResourceDialogTitle = ";Personalize View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;$this.Text";
            
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
            /// Contains resource string for:  ShowYAxis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowYAxis = ";Show Y Axis;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.PerformanceViewPropertiesDialog;yShowAxisCheckbox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MicrosoftSansSerif
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceMicrosoftSansSerif = "Microsoft Sans Serif";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange = ";Change...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlOb" +
                "jectGrid;editButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange2 = ";Change...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlOb" +
                "jectGrid;editButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Font
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFont = ";Font;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.UI.PerformanceViewPropertiesDialog;xFontLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowSideMargin
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowSideMargin = ";Show side margin;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.PerformanceViewPropertiesDialog;yShowSideMarginCheckbox.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InterlacedStrips
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterlacedStrips = ";Interlaced strips;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.UI.PerformanceViewPropertiesDialog;yInterlacedStripsCheckbox." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MinorGridlines
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinorGridlines = ";Minor gridlines;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.PerformanceViewPropertiesDialog;yMinorGridlinesCheckbox.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MajorGridlines
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMajorGridlines = ";Major gridlines;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.PerformanceViewPropertiesDialog;xMajorGridlinesCheckbox.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowXAxis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowXAxis = ";Show X Axis;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.PerformanceViewPropertiesDialog;xShowAxisCheckbox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MicrosoftSansSerif2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceMicrosoftSansSerif2 = "Microsoft Sans Serif";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange3 = ";Change...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlOb" +
                "jectGrid;editButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange4 = ";Change...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlOb" +
                "jectGrid;editButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Font2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFont2 = ";Font;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.UI.PerformanceViewPropertiesDialog;xFontLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowSideMargin2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowSideMargin2 = ";Show side margin;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.UI.PerformanceViewPropertiesDialog;yShowSideMarginCheckbox.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InterlacedStrips2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterlacedStrips2 = ";Interlaced strips;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.UI.PerformanceViewPropertiesDialog;yInterlacedStripsCheckbox." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MinorGridlines2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinorGridlines2 = ";Minor gridlines;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.PerformanceViewPropertiesDialog;yMinorGridlinesCheckbox.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MajorGridlines2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMajorGridlines2 = ";Major gridlines;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.UI.PerformanceViewPropertiesDialog;xMajorGridlinesCheckbox.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowYAxis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowYAxis;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MicrosoftSansSerif
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMicrosoftSansSerif;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Font
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFont;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowSideMargin
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowSideMargin;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InterlacedStrips
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterlacedStrips;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MinorGridlines
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinorGridlines;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MajorGridlines
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMajorGridlines;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowXAxis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowXAxis;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MicrosoftSansSerif2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMicrosoftSansSerif2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Font2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFont2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowSideMargin2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowSideMargin2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InterlacedStrips2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterlacedStrips2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MinorGridlines2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinorGridlines2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MajorGridlines2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMajorGridlines2;
            
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
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the ShowYAxis translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowYAxis
            {
                get
                {
                    if ((cachedShowYAxis == null))
                    {
                        cachedShowYAxis = CoreManager.MomConsole.GetIntlStr(ResourceShowYAxis);
                    }
                    
                    return cachedShowYAxis;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MicrosoftSansSerif translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MicrosoftSansSerif
            {
                get
                {
                    if ((cachedMicrosoftSansSerif == null))
                    {
                        cachedMicrosoftSansSerif = CoreManager.MomConsole.GetIntlStr(ResourceMicrosoftSansSerif);
                    }
                    
                    return cachedMicrosoftSansSerif;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Change
            {
                get
                {
                    if ((cachedChange == null))
                    {
                        cachedChange = CoreManager.MomConsole.GetIntlStr(ResourceChange);
                    }
                    
                    return cachedChange;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Change2
            {
                get
                {
                    if ((cachedChange2 == null))
                    {
                        cachedChange2 = CoreManager.MomConsole.GetIntlStr(ResourceChange2);
                    }
                    
                    return cachedChange2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Font translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Font
            {
                get
                {
                    if ((cachedFont == null))
                    {
                        cachedFont = CoreManager.MomConsole.GetIntlStr(ResourceFont);
                    }
                    
                    return cachedFont;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowSideMargin translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowSideMargin
            {
                get
                {
                    if ((cachedShowSideMargin == null))
                    {
                        cachedShowSideMargin = CoreManager.MomConsole.GetIntlStr(ResourceShowSideMargin);
                    }
                    
                    return cachedShowSideMargin;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InterlacedStrips translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InterlacedStrips
            {
                get
                {
                    if ((cachedInterlacedStrips == null))
                    {
                        cachedInterlacedStrips = CoreManager.MomConsole.GetIntlStr(ResourceInterlacedStrips);
                    }
                    
                    return cachedInterlacedStrips;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MinorGridlines translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MinorGridlines
            {
                get
                {
                    if ((cachedMinorGridlines == null))
                    {
                        cachedMinorGridlines = CoreManager.MomConsole.GetIntlStr(ResourceMinorGridlines);
                    }
                    
                    return cachedMinorGridlines;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MajorGridlines translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MajorGridlines
            {
                get
                {
                    if ((cachedMajorGridlines == null))
                    {
                        cachedMajorGridlines = CoreManager.MomConsole.GetIntlStr(ResourceMajorGridlines);
                    }
                    
                    return cachedMajorGridlines;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowXAxis translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowXAxis
            {
                get
                {
                    if ((cachedShowXAxis == null))
                    {
                        cachedShowXAxis = CoreManager.MomConsole.GetIntlStr(ResourceShowXAxis);
                    }
                    
                    return cachedShowXAxis;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MicrosoftSansSerif2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MicrosoftSansSerif2
            {
                get
                {
                    if ((cachedMicrosoftSansSerif2 == null))
                    {
                        cachedMicrosoftSansSerif2 = CoreManager.MomConsole.GetIntlStr(ResourceMicrosoftSansSerif2);
                    }
                    
                    return cachedMicrosoftSansSerif2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Change3
            {
                get
                {
                    if ((cachedChange3 == null))
                    {
                        cachedChange3 = CoreManager.MomConsole.GetIntlStr(ResourceChange3);
                    }
                    
                    return cachedChange3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change4 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Change4
            {
                get
                {
                    if ((cachedChange4 == null))
                    {
                        cachedChange4 = CoreManager.MomConsole.GetIntlStr(ResourceChange4);
                    }
                    
                    return cachedChange4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Font2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Font2
            {
                get
                {
                    if ((cachedFont2 == null))
                    {
                        cachedFont2 = CoreManager.MomConsole.GetIntlStr(ResourceFont2);
                    }
                    
                    return cachedFont2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowSideMargin2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowSideMargin2
            {
                get
                {
                    if ((cachedShowSideMargin2 == null))
                    {
                        cachedShowSideMargin2 = CoreManager.MomConsole.GetIntlStr(ResourceShowSideMargin2);
                    }
                    
                    return cachedShowSideMargin2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InterlacedStrips2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InterlacedStrips2
            {
                get
                {
                    if ((cachedInterlacedStrips2 == null))
                    {
                        cachedInterlacedStrips2 = CoreManager.MomConsole.GetIntlStr(ResourceInterlacedStrips2);
                    }
                    
                    return cachedInterlacedStrips2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MinorGridlines2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MinorGridlines2
            {
                get
                {
                    if ((cachedMinorGridlines2 == null))
                    {
                        cachedMinorGridlines2 = CoreManager.MomConsole.GetIntlStr(ResourceMinorGridlines2);
                    }
                    
                    return cachedMinorGridlines2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MajorGridlines2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MajorGridlines2
            {
                get
                {
                    if ((cachedMajorGridlines2 == null))
                    {
                        cachedMajorGridlines2 = CoreManager.MomConsole.GetIntlStr(ResourceMajorGridlines2);
                    }
                    
                    return cachedMajorGridlines2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// 	[mbickle] 5/31/2007 Created
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
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for ShowYAxisCheckBox
            /// </summary>
            public const string ShowYAxisCheckBox = "yShowAxisCheckbox";
            
            /// <summary>
            /// Control ID for MicrosoftSansSerifStaticControl
            /// </summary>
            public const string MicrosoftSansSerifStaticControl = "yFontSampleLabel";
            
            /// <summary>
            /// Control ID for ChangeButton
            /// </summary>
            public const string ChangeButton = "yStripChangeColorButton";
            
            /// <summary>
            /// Control ID for ChangeButton2
            /// </summary>
            public const string ChangeButton2 = "yChangeFontButton";
            
            /// <summary>
            /// Control ID for FontStaticControl
            /// </summary>
            public const string FontStaticControl = "yFontLabel";
            
            /// <summary>
            /// Control ID for ShowSideMarginCheckBox
            /// </summary>
            public const string ShowSideMarginCheckBox = "yShowSideMarginCheckbox";
            
            /// <summary>
            /// Control ID for InterlacedStripsCheckBox
            /// </summary>
            public const string InterlacedStripsCheckBox = "yInterlacedStripsCheckbox";
            
            /// <summary>
            /// Control ID for MinorGridlinesCheckBox
            /// </summary>
            public const string MinorGridlinesCheckBox = "yMinorGridlinesCheckbox";
            
            /// <summary>
            /// Control ID for MajorGridlinesCheckBox
            /// </summary>
            public const string MajorGridlinesCheckBox = "yMajorGridlinesCheckbox";
            
            /// <summary>
            /// Control ID for ShowXAxisCheckBox
            /// </summary>
            public const string ShowXAxisCheckBox = "xShowAxisCheckbox";
            
            /// <summary>
            /// Control ID for MicrosoftSansSerifStaticControl2
            /// </summary>
            public const string MicrosoftSansSerifStaticControl2 = "xFontSampleLabel";
            
            /// <summary>
            /// Control ID for ChangeButton3
            /// </summary>
            public const string ChangeButton3 = "xStripColorChangeButton";
            
            /// <summary>
            /// Control ID for ChangeButton4
            /// </summary>
            public const string ChangeButton4 = "xFontChangeButton";
            
            /// <summary>
            /// Control ID for FontStaticControl2
            /// </summary>
            public const string FontStaticControl2 = "xFontLabel";
            
            /// <summary>
            /// Control ID for ShowSideMarginCheckBox2
            /// </summary>
            public const string ShowSideMarginCheckBox2 = "xSideMarginCheckbox";
            
            /// <summary>
            /// Control ID for InterlacedStripsCheckBox2
            /// </summary>
            public const string InterlacedStripsCheckBox2 = "xInterlacedStripsCheckbox";
            
            /// <summary>
            /// Control ID for MinorGridlinesCheckBox2
            /// </summary>
            public const string MinorGridlinesCheckBox2 = "xMinorGridlinesCheckbox";
            
            /// <summary>
            /// Control ID for MajorGridlinesCheckBox2
            /// </summary>
            public const string MajorGridlinesCheckBox2 = "xMajorGridlinesCheckbox";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
