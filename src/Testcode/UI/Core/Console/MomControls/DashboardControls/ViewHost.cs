namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    //using Dump;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

    /// <summary>
    /// This interface defines the list of controls that are available in a generic view host
    /// </summary>
    public interface IViewHostControls
    {
        /// <summary>
        /// Title of the View
        /// </summary>
        StaticControl Title
        {
            get;
        }

        /// <summary>
        /// Task stack panel of the view
        /// </summary>
        Window TaskStackPanel
        {
            get;
        }

        /// <summary>
        /// The link that is shown when there is an error in the view
        /// </summary>
        Button ErrorLink
        {
            get;
        }

        /// <summary>
        /// The progress bar that is shown when the view is busy
        /// </summary>
        ProgressBar ProgressIndicator
        {
            get;
        }

        /// <summary>
        /// The content that is shown in the view
        /// </summary>
        Window Content
        {
            get;
        }

    }

    /// <summary>
    /// The class the represents the generic view host
    /// </summary>
    public class ViewHost : Control, IViewHostControls
    {
        #region ControlQIDs

        /// <summary>
        /// This contains the default QIDs for the controls
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// Default QID for the Title
            /// </summary>
            public static QID TitleQID = new QID(";[UIA]ClassName='TextBlock'");

            /// <summary>
            /// Default QID for the Task stack panel
            /// </summary>
            public static QID TaskStackPanelQID = new QID(";[UIA]ClassName='ComposedRegionTaskHost'");//new QID(";[UIA]ClassName='StackPanel'");

            /// <summary>
            /// Default QID for the ErrorLink
            /// </summary>
            public static QID ErrorLinkQID = new QID(";[UIA]ClassName='Button'");

            /// <summary>
            /// Default QID for the progress indicator
            /// </summary>
            public static QID ProgressBarQID = new QID(";[UIA]ClassName => 'ProgressBar'");
        }

        /// <summary>
        /// Gets the QID for the Title
        /// </summary>
        /// <returns>QID for the control</returns>
        protected virtual QID GetTitleQID()
        {
            return ControlQIDs.TitleQID;
        }

        /// <summary>
        /// Gets the QID for the Task stack panel
        /// </summary>
        /// <returns>QID for the control</returns>
        protected virtual QID GetTaskStackQID()
        {
            return ControlQIDs.TaskStackPanelQID;
        }

        /// <summary>
        /// Gets the QID for the Content. By default this throws an exception.
        /// </summary>
        /// <returns>QID for the control</returns>
        protected virtual QID GetContentQID()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the QID for the ErrorLink
        /// </summary>
        /// <returns>QID for the control</returns>
        protected virtual QID GetErrorLinkQID()
        {
            return ControlQIDs.ErrorLinkQID;
        }

        /// <summary>
        /// Gets the QID for the Progress indicator
        /// </summary>
        /// <returns>QID for the control</returns>
        protected virtual QID GetProgressIndicatorQID()
        {
            return ControlQIDs.ProgressBarQID;
        }

        /// <summary>
        /// The progrss indicator is checked 12 times
        /// </summary>
        protected virtual int IterationCount
        {
            get
            {
                return 12;
            }
        }

        /// <summary>
        /// Between each progress indicator checks, wait time is 5 seconds
        /// </summary>
        protected virtual int WaitTimeBetweenProgressCheck
        {
            get
            {
                return 5 * MomCommon.Constants.OneSecond;
            }
        }

        #endregion

        #region private variables

        /// <summary>
        /// Used in latching on to the inner controls
        /// </summary>
        private const int TIME_OUT = MomCommon.Constants.OneMinute;

        /// <summary>
        /// Title of the view
        /// </summary>
        private StaticControl title;

        /// <summary>
        /// Task stack panel of the view
        /// </summary>
        private Window taskStackPanel;

        /// <summary>
        /// Error link seen when there is an error in the view
        /// </summary>
        private Button errorLink;

        /// <summary>
        /// Progress bar shown when the view is busy
        /// </summary>
        private ProgressBar progressIndicator;

        /// <summary>
        /// The content of the view
        /// </summary>
        private Window content;

        #endregion

        #region public properties

        /// <summary>
        /// Gets the value that indicates that there is an error in the view
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return this.errorLink.IsVisible;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ViewHost
        /// </summary>
        /// <param name="knownWindow">Window that is the view</param>
        public ViewHost(Maui.Core.Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IViewHostControls Members

        /// <summary>
        /// Title of the view
        /// </summary>
        public StaticControl Title
        {
            get
            {
                if (this.title == null)
                {
                    this.title = new Maui.Core.WinControls.StaticControl(
                        new Window(
                            this,
                            this.GetTitleQID(),
                            TIME_OUT)
                            );
                }

                return this.title;
            }
        }

        /// <summary>
        /// Task stack panel of the view
        /// </summary>
        public Window TaskStackPanel
        {
            get
            {
                if (this.taskStackPanel == null)
                {
                    this.taskStackPanel = new Window(
                        this,
                        this.GetTaskStackQID(),
                        TIME_OUT);
                }

                return this.taskStackPanel;
            }
        }

        /// <summary>
        /// The error link on the view
        /// </summary>
        public Button ErrorLink
        {
            get
            {
                if (this.errorLink == null)
                {
                    this.errorLink = new Maui.Core.WinControls.Button(
                        new Window(
                            this,
                            this.GetErrorLinkQID(),
                            TIME_OUT)
                            );
                }

                return this.errorLink;
            }
        }

        /// <summary>
        /// Progress indicator
        /// </summary>
        public ProgressBar ProgressIndicator
        {
            get
            {
                if (this.progressIndicator == null)
                {
                    this.progressIndicator = new Maui.Core.WinControls.ProgressBar(
                        new Window(
                            this,
                            this.GetProgressIndicatorQID(),
                            TIME_OUT)
                            );
                }

                return this.progressIndicator;
            }
        }

        /// <summary>
        /// Content of the view
        /// </summary>
        public Window Content
        {
            get
            {
                if (this.content == null)
                {
                    this.content = new Maui.Core.WinControls.Control(
                        new Window(
                            this,
                            this.GetContentQID(),
                            TIME_OUT)
                            );
                }

                return this.content;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// This function waits for the progress indicator to get disabled.
        /// </summary>
        public virtual void WaitForReady()
        {
            this.ScreenElement.WaitForReady();

            //REMOVING the code below as the progress bar is no longer functional
            //Leaving it commented out in case it becomes functional again.
            //int iterations = this.IterationCount;
            //int waitTime = this.WaitTimeBetweenProgressCheck;

            //bool isReady = false;
            //while (iterations > 0)
            //{
            //    if (!this.ProgressIndicator.IsEnabled)
            //    {
            //        return;
            //    }

            //    int currentValue = this.ProgressIndicator.Value;
            //    int maxValue = ProgressIndicator.MaxValue;
            //    if (currentValue != maxValue)
            //    {
            //        System.Threading.Thread.Sleep(waitTime);
            //    }
            //    else
            //    {
            //        isReady = true;
            //        break;
            //    }

            //    iterations--;
            //}

            //if (!isReady)
            //{
            //    throw new Exception("View taking more than a minute to load the data. View name: " + title.Text);
            //}
        }

        #endregion
    }
}