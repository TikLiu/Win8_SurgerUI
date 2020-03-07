using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Controls.Layout.Toolkit
{
    [TemplateVisualState(Name = HubTileItem.StateFlipFront, GroupName = HubTileItem.GroupFlip)]
    [TemplateVisualState(Name=HubTileItem.StateFlipBack, GroupName = HubTileItem.GroupFlip)]
    [TemplatePart(Name = HubTileItem.ElementFrontItem, Type = typeof(object))]
    [TemplatePart(Name = HubTileItem.ElementBackItem, Type = typeof(object))]
    public class HubTileItem :Control
    {
        private const string ElementFrontItem = "FrontItem";
        private const string ElementBackItem = "BackItem";
        private const string GroupFlip = "FlipStates";
        private const string StateFlipFront = "FlipFront";
        private const string StateFlipBack = "FlipBack";

        private DispatcherTimer flipTimer = null;

        private bool _isFrontStoryboardPlay = false;

        /// <summary>
        /// Indicates that the control is currently executing an action.
        /// </summary>
        private bool _isBusyWithAction;

        private Storyboard _flipFrontStoryboard;
        public Storyboard FlipFrontStoryboard 
        {
            get 
            {
                return _flipFrontStoryboard;
            }
            set
            {
                if (_flipFrontStoryboard != null)
                {
                    _flipFrontStoryboard.Completed -= FlipFrontStoryboard_Completed;
                }
                _flipFrontStoryboard = value;
                if (_flipFrontStoryboard != null)
                {
                    _flipFrontStoryboard.Completed -= FlipFrontStoryboard_Completed;
                }
            }
        }

        private void FlipFrontStoryboard_Completed(object sender, object e)
        {
            _isBusyWithAction = false;

            //if (ParentAccordion != null)
            //{
            //    ParentAccordion.OnActionFinish(this);
            //}
        }

        private Storyboard _flipBackStoryboard;
        public Storyboard FlipBackStoryboard
        {
            get { return _flipBackStoryboard; }
            set 
            {
                if (_flipBackStoryboard != null)
                {
                    _flipBackStoryboard.Completed -= FlipBackStoryboard_Completed;
                }
                _flipBackStoryboard = value;
                if (_flipBackStoryboard != null)
                {
                    _flipBackStoryboard.Completed += FlipBackStoryboard_Completed;
                }
            }
        }

        private void FlipBackStoryboard_Completed(object sender, object e)
        {
            _isBusyWithAction = false;
        }

        public object FrontItem { get; set; }

        public object BackItem { get; set; }
        

        public HubTileItem()
        { 
            this.DefaultStyleKey = typeof(HubTileItem);

            flipTimer = new DispatcherTimer()
            {
                 Interval=new TimeSpan(0,0,1)
            };
            flipTimer.Tick += flipTimer_Tick;

            flipTimer.Start();
        }

        private void flipTimer_Tick(object sender, object e)
        {
            this.StartAction();
        }

        internal virtual void StartAction()
        {
            Action layoutAction;

            if (_isFrontStoryboardPlay)
            {
                layoutAction = () =>
                    {
                        VisualStateManager.GoToState(this, StateFlipBack, true);
                    };
            }
            else
            {
                layoutAction = () =>
                    {
                        VisualStateManager.GoToState(this, StateFlipFront, true);
                    };
            }
            _isBusyWithAction = true;
            layoutAction();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //FrameworkElement root = VisualTreeHelper.GetChild(this, 0) as FrameworkElement;

            //if (root != null)
            //{
            //    FlipFrontStoryboard = (from stategroup in
            //                          (VisualStateManager.GetVisualStateGroups(root) as Collection<VisualStateGroup>)
            //                      where stategroup.Name == GroupFlip
            //                      from state in (stategroup.States as IList<VisualState>)
            //                      where state.Name == StateFlipFront
            //                      select state.Storyboard).FirstOrDefault();

            //    FlipBackStoryboard = (from stategroup in
            //                              (VisualStateManager.GetVisualStateGroups(root) as Collection<VisualStateGroup>)
            //                          where stategroup.Name == GroupFlip
            //                          from state in (stategroup.States as IList<VisualState>)
            //                          where state.Name == StateFlipBack
            //                          select state.Storyboard).FirstOrDefault();
            //}
            //else
            //{
            //    FlipFrontStoryboard = null;
            //    FlipBackStoryboard = null;
            //}
        }
        
    }
}
