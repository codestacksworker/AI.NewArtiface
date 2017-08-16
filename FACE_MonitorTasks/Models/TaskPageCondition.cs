using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Controls.PageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_MonitorTasks.Models
{
  public class PageCondition : NotificationObject,IPageCondition
    {
        private int _startNum;
        private int _count;
        private int _pageNow;

        private bool _previousPageIsEnable;
        private bool _nextPageIsEnable;

        public int StartNum
        {
            get
            {
                return _startNum;
            }

            set
            {
                this._startNum = value;
                this.RaisePropertyChanged(() => this.StartNum);
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                this._count = value;
                this.RaisePropertyChanged(() => this.Count);
            }
        }

        public int PageNow
        {
            get
            {
                return _pageNow;
            }

            set
            {
                this._pageNow = value;
                this.RaisePropertyChanged(() => this.PageNow);
            }
        }

        public bool PreviousPageIsEnable
        {
            get
            {
                return _previousPageIsEnable;
            }

            set
            {
                this._previousPageIsEnable = value;
                this.RaisePropertyChanged(() => this.PreviousPageIsEnable);
            }
        }

        public bool NextPageIsEnable
        {
            get
            {
                return _nextPageIsEnable;
            }

            set
            {
                this._nextPageIsEnable = value;
                this.RaisePropertyChanged(() => this.NextPageIsEnable);
            }
        }
    }
}
