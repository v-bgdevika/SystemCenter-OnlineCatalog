using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maui.Core.WinControls;
using Maui.Core;
using MomCommon = Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    public interface ISpeedometerGauge
    {
        StaticControl CurrentValue
        {
            get;
        }
    }

    public class SpeedometerGauge : Control, ISpeedometerGauge
    {
        private const int TIME_OUT = MomCommon.Constants.OneMinute;

        private StaticControl currentValue;

        new public class ControlQIDs
        {
            public static QID CurrentValueQID = new QID(";[UIA]ClassName='TextBlock' && Instance='7'");
        }

        protected virtual QID GetCurrentValueQID()
        {
            return ControlQIDs.CurrentValueQID;
        }

        public StaticControl CurrentValue
        {
            get 
            {
                if (this.currentValue == null)
                {
                    this.currentValue = new StaticControl(
                        this,
                        this.GetCurrentValueQID(),
                        TIME_OUT
                        );
                }

                return this.currentValue;
            }
        }

        public SpeedometerGauge(Window knownWindow)
            : base(knownWindow)
        {
        }

        public virtual void WaitForReady()
        {
            this.ScreenElement.WaitForReady();
        }
    }
}
