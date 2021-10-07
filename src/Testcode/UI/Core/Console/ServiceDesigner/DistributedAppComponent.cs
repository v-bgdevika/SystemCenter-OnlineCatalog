using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mom.Test.UI.Core.Console.ServiceDesigner {
    /// <summary>
    /// Service components used by DistributedAppCollection.
    /// </summary>
    public partial class DistributedAppComponent : Component {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DistributedAppComponent() {
            InitializeComponent();
        }
        /// <summary>
        /// System.ComponentModel-based ctor enables DistributedAppComponent 
        /// to add a constructed component to its container so other clients
        /// of DistributedAppComponent can access it. 
        /// </summary>
        /// <param name="container">System.ComponentModel.IContainer that holds DistributedAppComponents.</param>
        public DistributedAppComponent(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Name of component.
        /// </summary>
        public string Name {
            get {
                return this.Name;
            }
            set {
                this.Name = value;
            }
        }
        /// <summary>
        /// Component description.
        /// </summary>
        public string Description {
            get {
                return this.Description;
            }
            set {
                this.Description = value;
            }
        }
        /// <summary>
        /// Template used to generate default design for new service.
        /// </summary>
        public string Template {
            get {
                return this.Template;
            }
            set {
                this.Template = value;
            }
        }
        DistributedApplicationPropertiesDialog propertySheet=null;
        /// <summary>
        /// Edit Distributed App's name and description from a property sheet.
        /// </summary>
        public DistributedApplicationPropertiesDialog dialog
        {
            get {
                if (null == this.propertySheet) {
                    this.propertySheet = new DistributedApplicationPropertiesDialog(CoreManager.MomConsole);
                }
                return this.propertySheet;
            }
        }

        /// <summary>
        /// Adds a new ServiceComponent group to design surface.
        /// </summary>
        public void AddServiceGroup() {
        }

        /// <summary>
        /// Adds a new ServiceComponent group to design surface.
        /// </summary>
        public void CreateRelationship() {
        }

        /// <summary>
        /// Remove an object from the design surface.
        /// </summary>
        /// <param name="objectType">One of several kinds of UI elements on the design surface.</param>
        public void Remove(object objectType) {
        }

        /// <summary>
        /// Restore design surface to last saved state.
        /// </summary>
        public void Reset() {
        }

        /// <summary>
        /// Select some object from the design surface.
        /// </summary>
        /// <param name="objectType">One of several kinds of UI elements on the design surface.</param>
        public void Select(object objectType) {
        }
    }
}
