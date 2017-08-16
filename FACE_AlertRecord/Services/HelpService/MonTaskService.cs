using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_AlertRecord.Models;
using FACE_AlertRecord.ViewModels;

namespace FACE_AlertRecord.Services.HelpService
{
    public class MonTaskService
    {
        public void MonTaskData(ViewModel viewModel)
        {
            for (int i = 0; i < 5; i++)
            {
                MonitorTaskData task = new MonitorTaskData
                {
                    TaskName = "任务" + i.ToString(),
                    Description = i.ToString(),
                    CreateUser = "测试" + i.ToString(),
                    TaskStatus = i,
                };
                viewModel.MonitorTaskList.Add(task);
            }
        }
    }
}
