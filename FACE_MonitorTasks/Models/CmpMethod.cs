using Microsoft.Practices.Prism.ViewModel;
using SING.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_MonitorTasks.Models
{
   public class CmpMethod: ModelBase
    {
       
        private Guid _uuid;
        private int _methodType;
        private Guid _strategyID;
       
       

        private double _thresholdScore;
        private double _calculateScore;
        private int _calculateInterval;
        private int __calculateTotal;
        
        public Guid Uuid
        {
            get
            {
                return _uuid;
            }

            set
            {
                this._uuid = value;
                this.RaisePropertyChanged(() => this.Uuid);
            }
        }

        public int MethodType
        {
            get
            {
                return _methodType;
            }

            set
            {
                this._methodType = value;
                this.RaisePropertyChanged(() => this.MethodType);
            }
        }

        public Guid StrategyID
        {
            get
            {
                return _strategyID;
            }

            set
            {
                this._strategyID = value;
                this.RaisePropertyChanged(() => this.StrategyID);
            }
        }
        
        
        [Range(0.0,100.0,ErrorMessage ="超过相似度允许范围")]
        public double ThresholdScore
        {
            get
            {
                return _thresholdScore;
            }

            set
            {
                this._thresholdScore = value;
                this.RaisePropertyChanged(() => this.ThresholdScore);
            }
        }

        public double CalculateScore
        {
            get
            {
                return _calculateScore;
            }

            set
            {
                this._calculateScore = value;
                this.RaisePropertyChanged(() => this.CalculateScore);
            }
        }

        public int CalculateInterval
        {
            get
            {
                return _calculateInterval;
            }

            set
            {
                this._calculateInterval = value;
                this.RaisePropertyChanged(() => this.CalculateInterval);
            }
        }

        public int CalculateTotal
        {
            get
            {
                return __calculateTotal;
            }

            set
            {
                this.__calculateTotal = value;
                this.RaisePropertyChanged(() => this.CalculateTotal);
            }
        }

      


        public static List<CmpMethod> AllCmpMethod { get; private set; }
     
        static CmpMethod()
        {
            AllCmpMethod = new List<CmpMethod>();
            var id = Guid.NewGuid();
            AllCmpMethod.Add(GetMethod(id, 0, 1));
            AllCmpMethod.Add(GetMethod(id, 1, 2));
        }

        public static CmpMethod GetMethod(Guid strategyid, int typeid, int index)
        {
            CmpMethod m1 = new CmpMethod();
            m1.Uuid = Guid.NewGuid();
            m1.MethodType = 0;
            m1.ThresholdScore = 80.00;
            m1.IsChecked = true;
            if (typeid == 1)
            {
                m1.MethodType = 1;
                m1.CalculateScore = 70.00;
                m1.CalculateInterval = 10;
                m1.CalculateTotal = 3;
                m1.IsChecked = true;
            }
            m1.StrategyID = strategyid;
            m1.Index = index;
            return m1;
        }
    }
}
