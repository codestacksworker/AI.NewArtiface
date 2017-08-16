using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.VideoControl
{
    public class VideoManager : ICollection<IVideoBase>, IVideoManager
    {
        public VideoManager()
        {
            _AssistItem = new AxDZVideoControl();
            (_AssistItem as AxDZVideoControl).Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private IVideoBase _AssistItem;

        private ICollection<IVideoBase> _Items;
        private bool isDisposed = false;

        public ICollection<IVideoBase> Items
        {
            get
            {
                return _Items;
            }
        }

        public int Count
        {
            get
            {
                return _Items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _Items.IsReadOnly;
            }
        }

        private VideoParameter _para;
        public VideoParameter Para
        {
            get
            {
                return _para;
            }

            set
            {
                _para = value;
            }
        }

        public void Initialize(VideoParameter paras, string controlName)
        {
            //$"{"'OcxID':'{axVideoOCX1.Name}'"}"; 实时流--控件Name "realtime_axVideoOCX1"
            var ocxid = "{\"OcxID\":\"realtime_" + (_AssistItem as AxDZVideoControl).Name.ToLower() + "\"}";
            _AssistItem.Initialize(paras, ocxid);
            _Items = new List<IVideoBase>();
        }

        public byte Login()
        {
            return _AssistItem.Login();
        }

        public byte LogOut()
        {
            return _AssistItem.LogOut();
        }

        public void Add(IVideoBase item)
        {
            _Items.Add(item);
        }

        public void Clear()
        {
            _Items.Clear();
        }

        public bool Contains(IVideoBase item)
        {
            return _Items.Contains(item);
        }

        public void CopyTo(IVideoBase[] array, int arrayIndex)
        {
            _Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(IVideoBase item)
        {
            return _Items.Remove(item);
        }

        public IEnumerator<IVideoBase> GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    //释放托管资源 
                    try
                    {
                        _Items.ToList().ForEach((_) =>
                        {
                            _.Stop();
                            _.DisPose();
                        });

                        _AssistItem.DisPose();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err);
                    }
                }
                //释放非托管资源 

            }
            isDisposed = true;
        }

        ~VideoManager()
        {
            Dispose(false);
        }
    }
}
