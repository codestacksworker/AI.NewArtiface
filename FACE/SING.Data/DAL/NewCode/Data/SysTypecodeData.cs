namespace SING.Data.DAL.NewCode.Data
{
    public class SysTypecodeData : UIDataBase
    {
        private string uuid;
        private string typeCode;
        private int itemId;
        private string itemCode;
        private string itemValue;
        private string parentId;
        private string searchCode;
        private string memo;

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value; OnPropertyChanged("Uuid");
            }
        }

        public string TypeCode
        {
            get
            {
                return typeCode;
            }

            set
            {
                typeCode = value; OnPropertyChanged("TypeCode");
            }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; OnPropertyChanged("ItemId"); }
        }

        public string ItemCode
        {
            get
            {
                return itemCode;
            }

            set
            {
                itemCode = value; OnPropertyChanged("ItemCode");
            }
        }

        public string ItemValue
        {
            get
            {
                return itemValue;
            }

            set
            {
                itemValue = value; OnPropertyChanged("ItemValue");
            }
        }

        public string ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value; OnPropertyChanged("ParentId");
            }
        }

        public string SearchCode
        {
            get
            {
                return searchCode;
            }

            set
            {
                searchCode = value; OnPropertyChanged("SearchCode");
            }
        }

        public string Memo
        {
            get
            {
                return memo;
            }

            set
            {
                memo = value; OnPropertyChanged("Memo");
            }
        }
    }
}
