using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Shell.ViewModels;
using SING.Data;
using SING.Data.BaseTools;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;
using SING.Infrastructure.Events;

namespace Shell.Views
{
    public partial class LogoutView : UserControl
    {

        private readonly IEventAggregator _eventAggregator;

        public LogoutView()
        {
            InitializeComponent();

            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            txtUserName.Text = AppConfig.Instance.LoginName;
        }

        private void LogoutControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = (bool)e.NewValue;

            this.btnLogin.IsEnabled = isVisible;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            AfterLoginClick();

            bool isAuth = false;
            string userInfo = string.Empty;
            string Uid = string.Empty;
            string UType = string.Empty;
            string divIndex = string.Empty;
            string divOrder = string.Empty;

            try
            {
                isAuth = IsAuth(out userInfo);
            }
            catch (Exception ex)
            {
                Logger.Error("获取用户出错", ex);

                RecoverFromLoginClick();
            }

            if (AppConfig.Instance.VersionType == VersionType.Net)
            {
                if (userInfo == string.Empty)
                {
                    MessageBoxHelper.Show("用户登录错误！", "登录失败");

                    RecoverFromLoginClick();

                    return;
                }
            }

            try
            {
                isAuth = IsAuth(out userInfo);
                if (AppConfig.Instance.VersionType == VersionType.Net)
                {
                    if (userInfo == string.Empty)
                        throw new Exception("用户登录错误!");
                  
                }
                else if (isAuth == false)
                {
                    AfterLoginClick();
                    MessageBoxHelper.Show("服务器连接错误！", "登录失败");
                    RecoverFromLoginClick();
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取用户出错", ex);

                RecoverFromLoginClick();
            }

            FACEIdentity identity = new FACEIdentity(txtUserName.Text, txtPassword.Password, isAuth);

            if (identity.IsAuthenticated == false)
            {
                MessageBoxHelper.Show("用户或密码错误，请重新输入！", "登录失败");
                RecoverFromLoginClick();
            }
            else
            {
                //记录登录用户名
                AppConfig.Instance.LoginName = txtUserName.Text;
                AppConfig.Instance.LoginPwd = txtPassword.Password;

                //UserCfgData curLoginUsers = AppConfig.Instance.UserInfo.UserInfo;
                //if (curLoginUsers.Uid != AppConfig.Instance.UserInfo.UserInfo.Uid) // 登录用户与注销用户不是同一用户时，进行页面内容刷新
                //{
                //    AppConfig.Instance.Save(true);
                //    AppConfig.Instance.UserInfo = identity;

                //    #region 分离用户信息

                //    try
                //    {
                //        if (AppConfig.Instance.VersionType == VersionType.Net)
                //        {
                //            string[] infos = userInfo.Split('=', ';');

                //            for (int i = 0; i < infos.Length; i++)
                //            {
                //                string info = infos[i];
                //                if (info == "UID")
                //                {
                //                    Uid = infos[i + 1];
                //                    continue;
                //                }
                //                if (info == "UTYPE")
                //                {
                //                    UType = infos[i + 1];
                //                    continue;
                //                }
                //                if (info == "DIVINDEX")
                //                {
                //                    divIndex = infos[i + 1];
                //                    continue;
                //                }

                //                if (info == "DIVORDER")
                //                {
                //                    divOrder = infos[i + 1];
                //                    continue;
                //                }
                //            }
                //            userInfo = string.Empty;
                //            if (Uid == VerifyUserLogin.One)
                //            {
                //                userInfo = "设备信息有误!";
                //                Logger.Error(userInfo);
                //            }
                //            else if (Uid == VerifyUserLogin.Two)
                //            {
                //                userInfo = "用户非法!";
                //                Logger.Error(userInfo);
                //            }
                //            else if (Uid == VerifyUserLogin.Three)
                //            {
                //                userInfo = "用户状态更新出错!";
                //                Logger.Error(userInfo);
                //            }
                //            else if (int.Parse(UType) <= 0)
                //            {
                //                userInfo = "用户类型错误!";
                //                Logger.Error(userInfo);
                //            }
                //            if (userInfo == string.Empty)
                //            {
                //                AfterLoginClick();
                //                MessageBoxHelper.Show(userInfo, "登录失败");
                //                RecoverFromLoginClick();
                //                return;
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Logger.Error("分离用户信息错误", ex);
                //        RecoverFromLoginClick();
                //    }

                //    #endregion

                //    Thread.CurrentPrincipal = new GenericPrincipal(identity, new string[] { Uid, UType, divIndex, divOrder });
                //}
                
                try
                {
                    //ReloadMainWindow(curLoginUsers);

                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {

                    MessageBoxHelper.Show("FACE", ex.ToString());
                    Environment.Exit(0);
                }
            }
        }
        //private void ReloadMainWindow(UserCfgData curLoginUsers)
        //{
        //    #region 发布事件用于关闭所有以打开的窗口

        //    _eventAggregator.GetEvent<CloseCurrentAllComponentsEvent>().Publish(null);

        //    #endregion

        //    #region 更新页面信息

        //    FACEIdentity identity = Thread.CurrentPrincipal.Identity as FACEIdentity;

        //    if (identity != null)
        //    {
        //        UserCfgData userses = curLoginUsers;

        //        try
        //        {
        //            FACEIdentity.CurrentUser = identity;

        //            ShellViewModel svm = Application.Current.MainWindow.DataContext as ShellViewModel;

        //            if (svm != null)
        //            {


        //                #region 设置登录用户信息

        //                svm.CurrentUserUnit = "管理员A";

        //                AppConfig.Instance.UserInfo.UserInfo = userses;

        //                #endregion

        //                #region 设置菜单信息

                   

        //                svm.ApplicationMenus = svm.IniApplicationMenu();

        //                AppConfig.Instance.ApplicationMenus = svm.ApplicationMenus;

        //                #endregion
        //            }
        //        }
        //        catch (Exception)
        //        {

        //        }
        //        if (userses != null)
        //        {
        //            identity.UserInfo = userses;
        //        }
        //    }

        //    #endregion
        //}
        private bool IsAuth(out string userInfo)
        {
            try
            {
                // 验证用户信息
                if (AppConfig.Instance.VersionType == VersionType.Net)
                {
                    userInfo = string.Empty;
                    return ScheduleGet.Login(txtUserName.Text, txtPassword.Password);
                }
                else
                {
                    userInfo = string.Empty;
                    return ScheduleGet.Login(txtUserName.Text, txtPassword.Password);
                }

            }
            catch (Exception ex)
            {
                Logger.Error("连接服务器错误", ex);
            }
            userInfo = string.Empty;
            return false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void AfterLoginClick()
        {
            this.btnLogin.IsEnabled = false;
        }

        private void RecoverFromLoginClick()
        {
            this.btnLogin.IsEnabled = true;
        }
    }
}
