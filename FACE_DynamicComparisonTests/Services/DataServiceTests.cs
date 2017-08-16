using Xunit;
using FACE_DynamicComparison.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_DynamicComparison.Services.HelpService;
using Moq;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;

namespace FACE_DynamicComparison.Services.Tests
{
    public class DataServiceTests
    {
        //CORE_WS_ZP_001 按开始、截至日期统计抓拍次数，返回统计结果
        //CORE_WS_XT_005 根据布控任务ID进行告警信息订阅，返回订阅操作结果
        //CORE_WS_XT_006 根据布控任务ID取消告警信息订阅，返回取消操作结果
        //CORE_WS_XT_007 根据布控任务ID进行报警信息订阅，返回订阅操作结果
        //CORE_WS_XT_008 根据布控任务ID取消报警信息订阅，返回取消操作结果

        //CORE_WS_XT_001 根据用户名、密码认证用户登录信息，返回认证结果：成功、用户名或密码错误、用户账号不存在，若登录成功同时返回用户信息，如姓名等
        //CORE_WS_RW_005 查询所有布控任务列表，返回列表（布控通道数、目标人数、告警次数、当前用户订阅状态、任务状态）
        //CORE_WS_RW_006 根据布控任务ID，查询返回布控任务详情信息(任务类型、布控计划、布控人、描述、布控区域、布控目标、目标库、比对策略、创建时间)
        //CORE_WS_GJ_018  按开始、截至日期统计告警推送次数，返回统计结果
        //CORE_WS_GJ_019  按开始、截至日期统计告警次数，返回统计结果
        //CORE_WS_GJ_020  按开始、截至日期统计未复合的告警次数，返回统计结果
        //CORE_WS_GJ_021  按开始、截至时间，统计每小时的告警、报警、人次数据，返回统计数据列表
        //CORE_WS_GJ_002  根据告警ID，查询返回告警详情信息、抓拍信息、目标人信息
        

        [Fact()]
        public void HttpServiceTest()
        {
            // Arrange
            Mock<IDataService> mockService = new Mock<IDataService>();
            ViewModels.ViewModel vm = new ViewModels.ViewModel(mockService.Object);

            //Act
            var resultPublishCount = vm._dataService.GetPublishCount();
            var resultAlertCount =  vm._dataService.GetAlertCount();
            var resultUncheckedCount = vm._dataService.GetUncheckedCount();
            var resultStatisticalCount = vm._dataService.FindStatisticalCount();
            var resultCapState = vm._dataService.QueryCapState();
            var resultComState = vm._dataService.QueryComState();
            var resultMethodeState = vm._dataService.QueryMethodeState();

            var resultSubscribeSec = vm._dataService.SubscribeSec();
            var resultUnSubscribeSec = vm._dataService.UnSubscribeSec();
            var resultSubscribeOriginal = vm._dataService.SubscribeOriginal();
            var resultUnSubscribeOriginal = vm._dataService.UnSubscribeOriginal();

            var resultAlertDetail = vm._dataService.GetAlertDetail();
            var resultNewestAlerts = vm._dataService.QueryNewestAlerts();
            var resultCheckAlert = vm._dataService.ReCheckAlert();
            var resultStatistics = vm._dataService.CheckedStatistics();
            var resultJobs = vm._dataService.QueryJobs();
            var resultUser = vm._dataService.Login();

            // Assert
            Assert.NotNull(resultPublishCount);
            Assert.NotNull(resultAlertCount);
            Assert.NotNull(resultUncheckedCount);
            Assert.NotNull(resultStatisticalCount);
            Assert.NotNull(resultCapState);
            Assert.NotNull(resultComState);
            Assert.NotNull(resultMethodeState);

            Assert.NotNull(resultSubscribeSec);
            Assert.NotNull(resultUnSubscribeSec);
            Assert.NotNull(resultSubscribeOriginal);
            Assert.NotNull(resultUnSubscribeOriginal);
            
            Assert.NotNull(resultAlertDetail);
            Assert.NotNull(resultNewestAlerts);
            Assert.NotNull(resultCheckAlert);
            Assert.NotNull(resultStatistics);
            Assert.NotNull(resultJobs);
            Assert.NotNull(resultUser);


            Assert.True(resultAlertCount >= 0, "获取告警数不通过");
        }

        [Fact()]
        public void CommandTest()
        {

            Assert.True(true, "命令未执行");
        }



        }
}