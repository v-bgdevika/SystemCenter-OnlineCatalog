using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Collections.Specialized;
using Mom.Test.UI.Core.Common;
using System.Timers;
using System.Diagnostics;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class DataQueryOutputReadinessIndicator
    {
        private const int TIME_PERIOD_OF_NO_CHANGE_IN_OUTPUT = 5000; //5 seconds

        #region private fields

        private ComponentRequest componentRequest = null;
        private INotifyCollectionChanged currentOutput = null;
        private Timer timer = null;
        private volatile bool busyIndicator = false;
        private object lockObject = new object();

        #endregion

        #region public properties

        public bool IsBusy
        {
            get
            {
                lock (lockObject)
                {
                    return busyIndicator;
                }
            }

            private set
            {
                lock (lockObject)
                {
                    busyIndicator = value;

                    if (busyIndicator == true)
                    {
                        RestartTimer();
                    }
                }
            }
        }

        #endregion

        #region Constructor

        public DataQueryOutputReadinessIndicator(ComponentRequest componentRequest)
        {
            this.componentRequest = componentRequest;
            this.componentRequest.ParameterChanged += this.OutputChanged;

            this.timer = new Timer(TIME_PERIOD_OF_NO_CHANGE_IN_OUTPUT);            
            this.timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        #endregion

        #region private methods

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var prefix = "DataQueryOutputReadinessIndicator.timer_Elapsed";

            //Utilities.LogMessage(prefix);

            IsBusy = false;
        }
            
        private void OutputChanged(object sender, ComponentRequestParameterChangedEventArgs e)
        {
            var prefix = "DataQueryOutputReadinessIndicator.compRequest_ParameterChanged: ";

            if (e.ParameterName != "Output")
            {
                return;
            }

            IsBusy = true;

            Utilities.LogMessage(prefix + "Output changed! New value = " + e.Value);

            currentOutput = e.Value as INotifyCollectionChanged;

            if (currentOutput != null)
            {
                currentOutput.CollectionChanged += new NotifyCollectionChangedEventHandler(currentOutput_CollectionChanged);
            }
            else
            {
                Utilities.LogMessage(prefix + "New output is not of the expected type.");
            }
        }

        private void currentOutput_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var prefix = "DataQueryOutputReadinessIndicator.currentOutput_CollectionChanged: ";

            IsBusy = true;

            Utilities.LogMessage(prefix + "Output collection changed: " + e.Action.ToString());
        }

        private void RestartTimer()
        {
            var prefix = "DataQueryOutputReadinessIndicator.RestartTimer";

            Utilities.LogMessage(prefix);

            timer.Stop();

            timer.Start();
        }

        #endregion

    }
}
