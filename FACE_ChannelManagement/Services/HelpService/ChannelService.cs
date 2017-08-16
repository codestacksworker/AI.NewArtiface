using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dev_SING.Data.BaseTools;
using FACE_ChannelManagement.ViewModels;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.DAL;
using SING.Data.DAL.Data;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Data.BaseTools;
using newcode = SING.Data.DAL.NewCode;
using newcodedata = SING.Data.DAL.NewCode.Data;
using SING.Data.DAL.NewCode.Condition;

namespace FACE_ChannelManagement.Services.HelpService
{
    public class ChannelService
    {
        private ViewModel _viewmodel;
        private BackgroundWorker _work;
        public void DoWork(ViewModel viewmodel)
        {
            try
            {
                this._viewmodel = viewmodel;
                this._work = new BackgroundWorker();
                _work.WorkerReportsProgress = true;
                _work.WorkerSupportsCancellation = true;
                _work.DoWork += Do;
                _work.RunWorkerCompleted += RunWorkerCompleted;
                _work.ProgressChanged += ProgressChanged;
                _work.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error("ChannelService:通道启动查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Do(object sender, DoWorkEventArgs e)
        {
            Search();
        }

        void Search()
        {
            for (int i = 1; i < 21; i++)
            {
                _viewmodel.VideoList.Add(new SING.Data.Controls.TreeControl.Models.DataItem()
                {
                    Parent = new SING.Data.Controls.TreeControl.Models.DataItem() { Text = "北京" },
                    Channel = new ChannelData()
                    {
                        ChannelAddr = "192.168.1." + i.ToString(),
                        Uuid = AssistTools.GuidN,
                        //RegionName = "北京" + i.ToString(),
                        ChannelDirect = i % 2 == 0
                                        ? 1 : i % 3 == 0
                                        ? 2 : i % 5 == 0
                                        ? 3 : 4,
                        ChannelName = "海淀",
                        IsConnected = i % 2 == 0
                    },
                });
            }
        }

        public Result AddChannel(DataItem item)
        {
            Channel channel = ChannelData.Convert(item.Channel);
            var result = Channel.AddChannel(channel);
            return result;
        }

        public Result EditChannel(DataItem item)
        {
            Channel channel = ChannelData.Convert(item.Channel);
            var result = Channel.ModChannel(channel);
            return result;
        }

        public Result DeleteChannel(DataItem item)
        {
            Channel channel = ChannelData.Convert(item.Channel);
            var result = Channel.DelChannel(channel.Uuid);
            return result;
        }

        public static Result DeleteChannel(int regionId)
        {
            Result result = null;
            try
            {
                if (regionId == 0)
                {
                    MessageBoxHelper.Show("请您选择要删除的区域，【删除】", "提示");
                }
                result = Channel.DelChannel(regionId);

                if (result.ErrorCode == StatusCode.Success)
                {
                    //MessageBoxHelper.Show("删除成功！", "提示", MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxHelper.Show("删除失败！", "提示", MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：删除模板异常！【ChannelService】-->【函数名】：DeleteChannel", ex);
                MessageBoxHelper.Show("删除失败！", "提示", MessageBoxImage.Warning);
            }

            return result;
        }

        public static bool ChannelIsExist(string channelNo)
        {
            bool isExist = false;

            try
            {
                if (string.IsNullOrEmpty(channelNo))
                {
                    MessageBoxHelper.Show("请您填写通道号，通道号不能为空，【校验】", "提示");
                }

                Result result = Channel.ChannelIsExist(channelNo);

                if (result.ErrorCode == StatusCode.True)
                {
                    isExist = true;
                    MessageBoxHelper.Show("通道号已存在，不能重复添加！", "提示", MessageBoxImage.Information);
                }
                else if (result.ErrorCode == StatusCode.Success)
                {
                    isExist = false;
                }
                else
                {
                    isExist = true;
                    MessageBoxHelper.Show("通道号校验失败，请重新校验！", "提示", MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：校验通道号是否存在异常！【ChannelService】-->【函数名】：ChannelIsExist", ex);
                MessageBoxHelper.Show("校验通道号是否存在失败！", "提示", MessageBoxImage.Warning);
            }

            return isExist;
        }

        public static ChannelData QueryChannel(string uuid)
        {
            ChannelData data = null;
            try
            {
                if (string.IsNullOrEmpty(uuid))
                {
                    MessageBoxHelper.Show("请选择要查询的通道！", "提示");

                    return data;
                }

                Channel channel = Channel.QueryChannel(uuid);

                if (channel != null)
                {
                    data = ChannelData.ConvertToData(channel);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("【Error】：查询通道异常！【ChannelService】-->【函数名】：QueryChannel", ex);
                MessageBoxHelper.Show("查询通道失败！", "提示", MessageBoxImage.Warning);
            }

            return data;
        }

        #region  新数据接口
        public List<newcodedata.ChannelData> Query()
        {
            newcode.Pager<ChannelCondition> pager = new newcode.Pager<ChannelCondition> {
                PageNo = 1,
                PageRows = 20,
                Condition = new ChannelCondition {
                    RegionId=10,
                    ChannelName=""
                }
                //Condition = new System.Collections.Hashtable()
            };
            //pager.Condition.Add("regionId","");
            //pager.Condition.Add("channelName", "");
            newcode.Channel channel = new newcode.Channel();
            newcode.Pager<ChannelCondition,newcode.Channel> p= channel.Query(pager);
            List<newcodedata.ChannelData> result = new List<newcodedata.ChannelData>();
            List<newcode.Channel> list= p.ResultList;
            list.ForEach(c=> { result.Add(c.ToUIData<newcodedata.ChannelData>()); });
            return result;
        }

        public newcodedata.ChannelData Insert()
        {
            newcodedata.ChannelData data = new newcodedata.ChannelData
            {
                ChannelVerid="2.0.0.1",
                ChannelName="通道1",
                ChannelDescription="通道",
                ChannelType=2,
                ChannelAddr="海淀定福皇庄",
                ChannelUid="admin",
                ChannelPsw="123@456",
                MinFaceWidth=20,
                MinImgQuality=20,
                MinCapDistance=20,
                MaxSaveDistance=20,
                MaxYaw=20,
                MaxRoll=20,
                MaxPitch=20,
                ChannelLongitude=39,
                ChannelLatitude=39,
                ChannelArea="定福皇庄",
                ChannelDirect=1,
                ChannelThreshold=80,
                CapStat=1,
                RegionId=10,
                SdkVer="2.0.0.1",
                Important=30
            };
            newcode.Channel obj = data.ToData<newcode.Channel>();
            var result = obj.Insert().ToUIData<newcodedata.ChannelData>();
            return result;
        }

        public newcodedata.ChannelData Update()
        {
            newcodedata.ChannelData data = new newcodedata.ChannelData
            {
                ChannelVerid = "2.0.0.1",
                ChannelName = "通道1",
                ChannelDescription = "通道",
                ChannelType = 2,
                ChannelAddr = "海淀定福皇庄",
                ChannelUid = "admin",
                ChannelPsw = "123@456",
                MinFaceWidth = 20,
                MinImgQuality = 20,
                MinCapDistance = 20,
                MaxSaveDistance = 20,
                MaxYaw = 20,
                MaxRoll = 20,
                MaxPitch = 20,
                ChannelLongitude = 39,
                ChannelLatitude = 39,
                ChannelArea = "定福皇庄",
                ChannelDirect = 1,
                ChannelThreshold = 80,
                CapStat = 1,
                RegionId = 10,
                SdkVer = "2.0.0.1",
                Important = 30
            };
            newcode.Channel obj = data.ToData<newcode.Channel>();
            return obj.Update().ToUIData<newcodedata.ChannelData>();
        }

        public bool Delete()
        {
            string[] idarr = { "110108196608166316", "120101193010291546" };
            newcode.Channel obj = new newcode.Channel();
            var result = obj.Delete(idarr);
            return result;
        }
        #endregion
    }
}
