using FACE_MonitorTasks.ViewModels;
using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FACE_MonitorTasks.Services.HelpService
{
    public class BasicDataSource
    {
        /// <summary>
        /// Get Job Type
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetJobType(ViewModel viewModel)
        {
            ObservableCollection<SysTypecodeData> res = new ObservableCollection<SysTypecodeData>();

            SysTypecode taskTypeItems = new SysTypecode();
            Pager<SysTypecodeDataCondition, SysTypecode> result = taskTypeItems.Query(new Pager<SysTypecodeDataCondition>
            {
                Condition = new SysTypecodeDataCondition() { TypeCode = "JOB_TYPE" }
            });

            result.ResultList.ForEach(x => res.Add(x.ToUIData<SysTypecodeData>()));

            List<string> _taskType = new List<string>();
            foreach (var item in res)
            {
                _taskType.Add(item.ItemValue);
            }

            viewModel.TaskType = _taskType.ToArray();
        }

        /// <summary>
        /// Get JobMethod DataSource 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetStrategyName(ViewModel viewModel)
        {
            ObservableCollection<SysTypecodeData> res = new ObservableCollection<SysTypecodeData>();

            SysTypecode jobMethodItems = new SysTypecode();
            Pager<SysTypecodeDataCondition, SysTypecode> result = jobMethodItems.Query(new Pager<SysTypecodeDataCondition>
            {
                Condition = new SysTypecodeDataCondition() { TypeCode = "METHOD_TYPE" }
            });

            result.ResultList.ForEach(x => viewModel.CmpMethodTypeItemsSource.Add(x.ToUIData<SysTypecodeData>()));
        }

        /// <summary>
        /// Get FaceObject DataSource 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void GetFaceObjectData(ViewModel viewModel)
        {
            ObservableCollection<FaceObjectData> res = new ObservableCollection<FaceObjectData>();

            FaceObject faceObject = new FaceObject();
            Pager<FaceObjectCondition, FaceObject> result = faceObject.Query(new Pager<FaceObjectCondition>
            {

            });
            result.ResultList.ForEach(x => viewModel.FtdbList.Add(x.ToUIData<FaceObjectData>()));
        }

    }
}
