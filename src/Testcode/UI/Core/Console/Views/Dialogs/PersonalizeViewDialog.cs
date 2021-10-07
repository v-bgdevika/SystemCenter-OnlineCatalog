// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PersonalizeViewDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 2/8/2006 Created
//  [kellymor]  26-Jul-06   Added resource for the context menu
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dialogs
{
    #region Using directives
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion
    
    #region Radio Group Enumeration - GroupItemsBy

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group GroupItemsBy
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum GroupItemsBy
    {
        /// <summary>
        /// Ascending = 0
        /// </summary>
        Ascending = 0,
        
        /// <summary>
        /// Descending = 1
        /// </summary>
        Descending = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - GroupItemsBy2

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group GroupItemsBy2
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum GroupItemsBy2
    {
        /// <summary>
        /// Ascending2 = 0
        /// </summary>
        Ascending2 = 0,
        
        /// <summary>
        /// Descending2 = 1
        /// </summary>
        Descending2 = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - GroupItemsBy3

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group GroupItemsBy3
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum GroupItemsBy3
    {
        /// <summary>
        /// Ascending3 = 0
        /// </summary>
        Ascending3 = 0,
        
        /// <summary>
        /// Descending3 = 1
        /// </summary>
        Descending3 = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - SortColumnsBy

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group SortColumnsBy
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum SortColumnsBy
    {
        /// <summary>
        /// Descending4 = 0
        /// </summary>
        Descending4 = 0,
        
        /// <summary>
        /// Ascending4 = 1
        /// </summary>
        Ascending4 = 1,
    }
    #endregion
    
    #region Interface Definition - IPersonalizeViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPersonalizeViewDialogControls, for PersonalizeViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPersonalizeViewDialogControls
    {
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

        /// <summary>
        /// Read-only property to access PropertyGridView2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        PropertyGridView PropertyGridView2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThenByStaticControl
        /// </summary>
        StaticControl ThenByStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThenByStaticControl2
        /// </summary>
        StaticControl ThenByStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AscendingRadioButton
        /// </summary>
        RadioButton AscendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescendingRadioButton
        /// </summary>
        RadioButton DescendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupBy3ComboBox
        /// </summary>
        ComboBox GroupBy3ComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AscendingRadioButton2
        /// </summary>
        RadioButton AscendingRadioButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescendingRadioButton2
        /// </summary>
        RadioButton DescendingRadioButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupBy2ComboBox
        /// </summary>
        ComboBox GroupBy2ComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AscendingRadioButton3
        /// </summary>
        RadioButton AscendingRadioButton3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescendingRadioButton3
        /// </summary>
        RadioButton DescendingRadioButton3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupBy1ComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox GroupBy1ComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox4
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescendingRadioButton4
        /// </summary>
        RadioButton DescendingRadioButton4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AscendingRadioButton4
        /// </summary>
        RadioButton AscendingRadioButton4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ColumnsToDisplayStaticControl
        /// </summary>
        StaticControl ColumnsToDisplayStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ColumnsToDisplayListBox
        /// </summary>
        ListBox ColumnsToDisplayListBox
        {
            get;
        }

        /// <summary>
        /// [jefftow] 31OCT07 Added this property
        /// Read-only property to access ColumnsToDisplayCheckBox
        /// </summary>
        CheckedListBox ColumnsToDisplayCheckBox
        {
            get;
        }


        /// <summary>
        /// Read-only property to access DialogToolstrip
        /// </summary>
        Toolbar DialogToolstrip
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
    /// 	[lucyra] 2/8/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PersonalizeViewDialog : Dialog, IPersonalizeViewDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to PropertyGridView2 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedPropertyGridView2;
        
        /// <summary>
        /// Cache to hold a reference to ThenByStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThenByStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThenByStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedThenByStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAscendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDescendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupBy3ComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGroupBy3ComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton2 of type RadioButton
        /// </summary>
        private RadioButton cachedAscendingRadioButton2;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton2 of type RadioButton
        /// </summary>
        private RadioButton cachedDescendingRadioButton2;
        
        /// <summary>
        /// Cache to hold a reference to GroupBy2ComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGroupBy2ComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton3 of type RadioButton
        /// </summary>
        private RadioButton cachedAscendingRadioButton3;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton3 of type RadioButton
        /// </summary>
        private RadioButton cachedDescendingRadioButton3;
        
        /// <summary>
        /// Cache to hold a reference to GroupBy1ComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGroupBy1ComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox4 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox4;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton4 of type RadioButton
        /// </summary>
        private RadioButton cachedDescendingRadioButton4;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton4 of type RadioButton
        /// </summary>
        private RadioButton cachedAscendingRadioButton4;
        
        /// <summary>
        /// Cache to hold a reference to ColumnsToDisplayStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedColumnsToDisplayStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to ColumnsToDisplayListBox of type ListBox
        /// </summary>
        private ListBox cachedColumnsToDisplayListBox;

        /// <summary>
        /// Cache to hold a reference to ColumnsToDisplayCheckBox of type CheckBox
        /// </summary>
        private CheckedListBox cachedColumnsToDisplayCheckBox;

        /// <summary>
        /// Cache to hold a reference to DialogToolstrip of type Toolbar
        /// </summary>
        private Toolbar cachedDialogToolstrip;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PersonalizeViewDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PersonalizeViewDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group GroupItemsBy
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual GroupItemsBy GroupItemsBy
        {
            get
            {
                if ((this.Controls.AscendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy.Ascending;
                }
                
                if ((this.Controls.DescendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy.Descending;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == GroupItemsBy.Ascending))
                {
                    this.Controls.AscendingRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == GroupItemsBy.Descending))
                    {
                        this.Controls.DescendingRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group GroupItemsBy2
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual GroupItemsBy2 GroupItemsBy2
        {
            get
            {
                if ((this.Controls.AscendingRadioButton2.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy2.Ascending2;
                }
                
                if ((this.Controls.DescendingRadioButton2.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy2.Descending2;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == GroupItemsBy2.Ascending2))
                {
                    this.Controls.AscendingRadioButton2.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == GroupItemsBy2.Descending2))
                    {
                        this.Controls.DescendingRadioButton2.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group GroupItemsBy3
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual GroupItemsBy3 GroupItemsBy3
        {
            get
            {
                if ((this.Controls.AscendingRadioButton3.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy3.Ascending3;
                }
                
                if ((this.Controls.DescendingRadioButton3.ButtonState == ButtonState.Checked))
                {
                    return GroupItemsBy3.Descending3;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == GroupItemsBy3.Ascending3))
                {
                    this.Controls.AscendingRadioButton3.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == GroupItemsBy3.Descending3))
                    {
                        this.Controls.DescendingRadioButton3.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group SortColumnsBy
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual SortColumnsBy SortColumnsBy
        {
            get
            {
                if ((this.Controls.DescendingRadioButton4.ButtonState == ButtonState.Checked))
                {
                    return SortColumnsBy.Descending4;
                }
                
                if ((this.Controls.AscendingRadioButton4.ButtonState == ButtonState.Checked))
                {
                    return SortColumnsBy.Ascending4;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == SortColumnsBy.Descending4))
                {
                    this.Controls.DescendingRadioButton4.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == SortColumnsBy.Ascending4))
                    {
                        this.Controls.AscendingRadioButton4.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IPersonalizeViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPersonalizeViewDialogControls Controls
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
        ///  Routine to set/get the text in control ThenBy
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ThenByText
        {
            get
            {
                return this.Controls.GroupBy3ComboBox.Text;
            }
            
            set
            {
                this.Controls.GroupBy3ComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ThenBy2
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ThenBy2Text
        {
            get
            {
                return this.Controls.GroupBy2ComboBox.Text;
            }
            
            set
            {
                this.Controls.GroupBy2ComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GroupBy1ComboBox
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupBy1ComboBoxText
        {
            get
            {
                return this.Controls.GroupBy1ComboBox.Text;
            }
            
            set
            {
                this.Controls.GroupBy1ComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox4
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox4Text
        {
            get
            {
                return this.Controls.ComboBox4.Text;
            }
            
            set
            {
                this.Controls.ComboBox4.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PersonalizeViewDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PersonalizeViewDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyGridView2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IPersonalizeViewDialogControls.PropertyGridView2
        {
            get
            {
                if ((this.cachedPropertyGridView2 == null))
                {
                    this.cachedPropertyGridView2 = new PropertyGridView(this, PersonalizeViewDialog.ControlIDs.PropertyGridView2);
                }
                return this.cachedPropertyGridView2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThenByStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDialogControls.ThenByStaticControl
        {
            get
            {
                if ((this.cachedThenByStaticControl == null))
                {
                    this.cachedThenByStaticControl = new StaticControl(this, PersonalizeViewDialog.ControlIDs.ThenByStaticControl);
                }
                return this.cachedThenByStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThenByStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDialogControls.ThenByStaticControl2
        {
            get
            {
                if ((this.cachedThenByStaticControl2 == null))
                {
                    this.cachedThenByStaticControl2 = new StaticControl(this, PersonalizeViewDialog.ControlIDs.ThenByStaticControl2);
                }
                return this.cachedThenByStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AscendingRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.AscendingRadioButton
        {
            get
            {
                if ((this.cachedAscendingRadioButton == null))
                {
                    this.cachedAscendingRadioButton = new RadioButton(this, PersonalizeViewDialog.ControlIDs.AscendingRadioButton);
                }
                return this.cachedAscendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescendingRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.DescendingRadioButton
        {
            get
            {
                if ((this.cachedDescendingRadioButton == null))
                {
                    this.cachedDescendingRadioButton = new RadioButton(this, PersonalizeViewDialog.ControlIDs.DescendingRadioButton);
                }
                return this.cachedDescendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupBy3ComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDialogControls.GroupBy3ComboBox
        {
            get
            {
                if ((this.cachedGroupBy3ComboBox == null))
                {
                    this.cachedGroupBy3ComboBox = new ComboBox(this, PersonalizeViewDialog.ControlIDs.GroupBy3ComboBox);
                }
                return this.cachedGroupBy3ComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AscendingRadioButton2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.AscendingRadioButton2
        {
            get
            {
                if ((this.cachedAscendingRadioButton2 == null))
                {
                    this.cachedAscendingRadioButton2 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.AscendingRadioButton2);
                }
                return this.cachedAscendingRadioButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescendingRadioButton2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.DescendingRadioButton2
        {
            get
            {
                if ((this.cachedDescendingRadioButton2 == null))
                {
                    this.cachedDescendingRadioButton2 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.DescendingRadioButton2);
                }
                return this.cachedDescendingRadioButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupBy2ComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDialogControls.GroupBy2ComboBox
        {
            get
            {
                if ((this.cachedGroupBy2ComboBox == null))
                {
                    this.cachedGroupBy2ComboBox = new ComboBox(this, PersonalizeViewDialog.ControlIDs.GroupBy2ComboBox);
                }
                return this.cachedGroupBy2ComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AscendingRadioButton3 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.AscendingRadioButton3
        {
            get
            {
                if ((this.cachedAscendingRadioButton3 == null))
                {
                    this.cachedAscendingRadioButton3 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.AscendingRadioButton3);
                }
                return this.cachedAscendingRadioButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescendingRadioButton3 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.DescendingRadioButton3
        {
            get
            {
                if ((this.cachedDescendingRadioButton3 == null))
                {
                    this.cachedDescendingRadioButton3 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.DescendingRadioButton3);
                }
                return this.cachedDescendingRadioButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupBy1ComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDialogControls.GroupBy1ComboBox
        {
            get
            {
                if ((this.cachedGroupBy1ComboBox == null))
                {
                    this.cachedGroupBy1ComboBox = new ComboBox(this, PersonalizeViewDialog.ControlIDs.GroupBy1ComboBox);
                }
                return this.cachedGroupBy1ComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox4 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPersonalizeViewDialogControls.ComboBox4
        {
            get
            {
                if ((this.cachedComboBox4 == null))
                {
                    this.cachedComboBox4 = new ComboBox(this, PersonalizeViewDialog.ControlIDs.ComboBox4);
                }
                return this.cachedComboBox4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescendingRadioButton4 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.DescendingRadioButton4
        {
            get
            {
                if ((this.cachedDescendingRadioButton4 == null))
                {
                    this.cachedDescendingRadioButton4 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.DescendingRadioButton4);
                }
                return this.cachedDescendingRadioButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AscendingRadioButton4 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPersonalizeViewDialogControls.AscendingRadioButton4
        {
            get
            {
                if ((this.cachedAscendingRadioButton4 == null))
                {
                    this.cachedAscendingRadioButton4 = new RadioButton(this, PersonalizeViewDialog.ControlIDs.AscendingRadioButton4);
                }
                return this.cachedAscendingRadioButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ColumnsToDisplayStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPersonalizeViewDialogControls.ColumnsToDisplayStaticControl
        {
            get
            {
                if ((this.cachedColumnsToDisplayStaticControl == null))
                {
                    this.cachedColumnsToDisplayStaticControl = new StaticControl(this, PersonalizeViewDialog.ControlIDs.ColumnsToDisplayStaticControl);
                }
                return this.cachedColumnsToDisplayStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, PersonalizeViewDialog.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPersonalizeViewDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, PersonalizeViewDialog.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ColumnsToDisplayListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IPersonalizeViewDialogControls.ColumnsToDisplayListBox
        {
            get
            {
                if ((this.cachedColumnsToDisplayListBox == null))
                {
                    this.cachedColumnsToDisplayListBox = new ListBox(this, PersonalizeViewDialog.ControlIDs.ColumnsToDisplayListBox);
                }
                return this.cachedColumnsToDisplayListBox;
            }
        }


        /// <summary>
        /// Exposes access to the ColumnsToDisplayCheckBox control note this uses the same controlID as the ListBox
        /// </summary>
        /// <history>
        ///     [jefftow] 31OCT2007 Created
        /// </history>
        CheckedListBox IPersonalizeViewDialogControls.ColumnsToDisplayCheckBox
        {
            get
            {
                if ((this.cachedColumnsToDisplayCheckBox == null))
                {
                    this.cachedColumnsToDisplayCheckBox = new CheckedListBox(this, PersonalizeViewDialog.ControlIDs.ColumnsToDisplayListBox);
                }
                return this.cachedColumnsToDisplayCheckBox;
            }
        }


        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DialogToolstrip control
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IPersonalizeViewDialogControls.DialogToolstrip
        {
            get
            {
                if ((this.cachedDialogToolstrip == null))
                {
                    this.cachedDialogToolstrip = new Toolbar(this, PersonalizeViewDialog.ControlIDs.DialogToolstrip);
                }
                return this.cachedDialogToolstrip;
            }
        }
        #endregion
        
        #region Control Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/10/2006 Created
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
        /// 	[lucyra] 2/10/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }

        /// <summary>
        /// Select all columns to display
        /// </summary>
        public virtual void SelectAllColumnsToDisplay()
        {
            foreach (CheckedListBoxItem item in this.Controls.ColumnsToDisplayCheckBox.Items)
            {
                if (!item.Checked)
                {
                    Utilities.LogMessage(item.Text + " is not checked, select it to display");
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Select a column to display
        /// </summary>
        /// <param name="columnName">column name</param>
        public virtual void SelectColumnToDisplay(string columnName)
        {
            SelectColumnToDisplay(columnName, ButtonState.Checked);
        }

        /// <summary>
        /// Unselect a column to display
        /// </summary>
        /// <param name="columnName">column name</param>
        public virtual void UnselectColumnToDisplay(string columnName)
        {
            SelectColumnToDisplay(columnName, ButtonState.UnChecked);
        }

        /// <summary>
        /// Set a column checkbox to a specified button state
        /// </summary>
        /// <param name="columnName">column name</param>
        /// <param name="buttonState">button state</param>
        private void SelectColumnToDisplay(string columnName, ButtonState buttonState)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(columnName);
            }

            bool columnExists = false;

            foreach (CheckedListBoxItem item in this.Controls.ColumnsToDisplayCheckBox.Items)
            {
                if (item.Text.Equals(columnName))
                {
                    columnExists = true;

                    if (item.CheckState != buttonState)
                    {
                        item.CheckState = buttonState;
                    }
                }
            }

            if (!columnExists)
            {
                throw new ListBox.Exceptions.ItemNotFoundException(columnName+" does not exists");
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
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
                                StringMatchSyntax.WildCard);

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

                        Sleeper.Delay(PersonalizeViewDialog.Timeout);
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
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";

            ///// <summary>
            ///// Contains resource string for Save and Close button
            ///// </summary>
            //private const string ResourceSaveAndClose = 
            //    ";&Save and Close;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;saveButton.Text";
            ////";&Save and Close;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog.en;saveButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Select Columns;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThenBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThenBy = ";Then by;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.ColumnPickerControl;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThenBy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThenBy2 = ";Then by;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.ColumnPickerControl;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ascending
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAscending = ";Ascending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.ColumnPickerControl;sortAscendingRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Descending
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescending = ";Descending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.ColumnPickerControl;groupBy3DescRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ascending2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAscending2 = ";Ascending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.ColumnPickerControl;sortAscendingRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Descending2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescending2 = ";Descending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.ColumnPickerControl;groupBy3DescRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ascending3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAscending3 = ";Ascending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.ColumnPickerControl;sortAscendingRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Descending3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescending3 = ";Descending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.ColumnPickerControl;groupBy3DescRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Descending4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescending4 = ";Descending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.ColumnPickerControl;groupBy3DescRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ascending4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAscending4 = ";Ascending;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.ColumnPickerControl;sortAscendingRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ColumnsToDisplay
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnsToDisplay = ";Columns to display:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.UI.ColumnPickerControl;availableColumnsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DialogToolstrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogToolstrip = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContextMenuPersonalizeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuPersonalizeView = 
                ";Person&alize view..." + 
                ";ManagedString" + 
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" + 
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" + 
                ";PersonalizeMenuText";

            #endregion
            
            #region Private Members

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThenBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThenBy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThenBy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThenBy2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ascending
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAscending;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Descending
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescending;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ascending2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAscending2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Descending2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescending2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ascending3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAscending3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Descending3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescending3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Descending4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescending4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ascending4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAscending4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ColumnsToDisplay
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedColumnsToDisplay;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DialogToolstrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogToolstrip;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuPersonalizeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuPersonalizeView;

            ///// <summary>
            ///// Caches the translated resource fir Save and Close
            ///// </summary>
            //private static string cachedSaveAndClose;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/10/2006 Created
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
            /// 	[lucyra] 2/10/2006 Created
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
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
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
            /// Exposes access to the ThenBy translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThenBy
            {
                get
                {
                    if ((cachedThenBy == null))
                    {
                        cachedThenBy = CoreManager.MomConsole.GetIntlStr(ResourceThenBy);
                    }
                    return cachedThenBy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThenBy2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThenBy2
            {
                get
                {
                    if ((cachedThenBy2 == null))
                    {
                        cachedThenBy2 = CoreManager.MomConsole.GetIntlStr(ResourceThenBy2);
                    }
                    return cachedThenBy2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ascending translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ascending
            {
                get
                {
                    if ((cachedAscending == null))
                    {
                        cachedAscending = CoreManager.MomConsole.GetIntlStr(ResourceAscending);
                    }
                    return cachedAscending;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Descending translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Descending
            {
                get
                {
                    if ((cachedDescending == null))
                    {
                        cachedDescending = CoreManager.MomConsole.GetIntlStr(ResourceDescending);
                    }
                    return cachedDescending;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ascending2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ascending2
            {
                get
                {
                    if ((cachedAscending2 == null))
                    {
                        cachedAscending2 = CoreManager.MomConsole.GetIntlStr(ResourceAscending2);
                    }
                    return cachedAscending2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Descending2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Descending2
            {
                get
                {
                    if ((cachedDescending2 == null))
                    {
                        cachedDescending2 = CoreManager.MomConsole.GetIntlStr(ResourceDescending2);
                    }
                    return cachedDescending2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ascending3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ascending3
            {
                get
                {
                    if ((cachedAscending3 == null))
                    {
                        cachedAscending3 = CoreManager.MomConsole.GetIntlStr(ResourceAscending3);
                    }
                    return cachedAscending3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Descending3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Descending3
            {
                get
                {
                    if ((cachedDescending3 == null))
                    {
                        cachedDescending3 = CoreManager.MomConsole.GetIntlStr(ResourceDescending3);
                    }
                    return cachedDescending3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Descending4 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Descending4
            {
                get
                {
                    if ((cachedDescending4 == null))
                    {
                        cachedDescending4 = CoreManager.MomConsole.GetIntlStr(ResourceDescending4);
                    }
                    return cachedDescending4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ascending4 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ascending4
            {
                get
                {
                    if ((cachedAscending4 == null))
                    {
                        cachedAscending4 = CoreManager.MomConsole.GetIntlStr(ResourceAscending4);
                    }
                    return cachedAscending4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ColumnsToDisplay translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ColumnsToDisplay
            {
                get
                {
                    if ((cachedColumnsToDisplay == null))
                    {
                        cachedColumnsToDisplay = CoreManager.MomConsole.GetIntlStr(ResourceColumnsToDisplay);
                    }
                    return cachedColumnsToDisplay;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogToolstrip translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 2/8/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogToolstrip
            {
                get
                {
                    if ((cachedDialogToolstrip == null))
                    {
                        cachedDialogToolstrip = CoreManager.MomConsole.GetIntlStr(ResourceDialogToolstrip);
                    }
                    return cachedDialogToolstrip;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuPersonalizeView translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 8/30/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuPersonalizeView
            {
                get
                {
                    if ((cachedContextMenuPersonalizeView == null))
                    {
                        cachedContextMenuPersonalizeView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuPersonalizeView);
                    }
                    return cachedContextMenuPersonalizeView;
                }
            }

            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Exposes access to the Save and Close translated resource string
            ///// </summary>
            ///// <history>
            ///// 	[lucyra] 8/30/2005 Created
            ///// </history>
            ///// -----------------------------------------------------------------------------
            //public static string SaveAndClose
            //{
            //    get
            //    {
            //        if ((cachedSaveAndClose == null))
            //        {
            //            cachedSaveAndClose = CoreManager.MomConsole.GetIntlStr(ResourceSaveAndClose);
            //        }
            //        return cachedSaveAndClose;
            //    }
            //}
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for PropertyGridView2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string PropertyGridView2 = "previewGrid";
            
            /// <summary>
            /// Control ID for ThenByStaticControl
            /// </summary>
            public const string ThenByStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ThenByStaticControl2
            /// </summary>
            public const string ThenByStaticControl2 = "groupBy2Label";
            
            /// <summary>
            /// Control ID for AscendingRadioButton
            /// </summary>
            public const string AscendingRadioButton = "groupBy3AscRadio";
            
            /// <summary>
            /// Control ID for DescendingRadioButton
            /// </summary>
            public const string DescendingRadioButton = "groupBy3DescRadio";
            
            /// <summary>
            /// Control ID for GroupBy3ComboBox
            /// </summary>
            public const string GroupBy3ComboBox = "groupBy3Combo";
            
            /// <summary>
            /// Control ID for AscendingRadioButton2
            /// </summary>
            public const string AscendingRadioButton2 = "groupBy2AscRadio";
            
            /// <summary>
            /// Control ID for DescendingRadioButton2
            /// </summary>
            public const string DescendingRadioButton2 = "groupBy2DescRadio";
            
            /// <summary>
            /// Control ID for GroupBy2ComboBox
            /// </summary>
            public const string GroupBy2ComboBox = "groupBy2Combo";
            
            /// <summary>
            /// Control ID for AscendingRadioButton3
            /// </summary>
            public const string AscendingRadioButton3 = "groupBy1AscRadio";
            
            /// <summary>
            /// Control ID for DescendingRadioButton3
            /// </summary>
            public const string DescendingRadioButton3 = "groupBy1DescRadio";
            
            /// <summary>
            /// Control ID for GroupBy1ComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string GroupBy1ComboBox = "groupBy1Combo";
            
            /// <summary>
            /// Control ID for ComboBox4
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox4 = "sortColumnCombo";
            
            /// <summary>
            /// Control ID for DescendingRadioButton4
            /// </summary>
            public const string DescendingRadioButton4 = "sortDescendingRadio";
            
            /// <summary>
            /// Control ID for AscendingRadioButton4
            /// </summary>
            public const string AscendingRadioButton4 = "sortAscendingRadio";
            
            /// <summary>
            /// Control ID for ColumnsToDisplayStaticControl
            /// </summary>
            public const string ColumnsToDisplayStaticControl = "availableColumnsLabel";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "upButton";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "downButton";
            
            /// <summary>
            /// Control ID for ColumnsToDisplayListBox
            /// </summary>
            public const string ColumnsToDisplayListBox = "availableColumnsListbox";
            
            /// <summary>
            /// Control ID for DialogToolstrip
            /// </summary>
            public const string DialogToolstrip = "mainToolstrip";
            //public const string DialogToolstrip = "toolStrip1";
        }
        #endregion
    }
}
