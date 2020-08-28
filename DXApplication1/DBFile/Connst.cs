using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webApiDemoApp.DBFile
{
    public enum LanguageEnum
    {
        LanguageCN,
        LanguageEN,
    }
    //放置所以产品统一的常量，比如登录信息，系统相关信息等。具体的产品常量可以从此类继承
    public class Const
    {
        /// <summary>
        /// 配置文件中的版本号
        /// </summary>
        public static string Version = "";

        public static bool updateflag = false;

        /// <summary>
        /// 新立成染化料生产领料单更新标志位
        /// </summary>
        public static bool updateflag_xlc = false;

        /// <summary>
        /// 云中马坯布领坯单更新标志位
        /// </summary>
        public static bool apyupdateflag_yzm = false;

        public static string selectcrd = "";//选中的缸号
        /// <summary>
        /// 当前活动窗体
        /// </summary>
        public static Form ActivatForm;
        public static LanguageEnum languageName = LanguageEnum.LanguageCN;
        /// <summary>
        /// 网络断开数据保存到本地标志 true代表断网
        /// </summary>
        public static bool EnableLocalSave = false;
        /// <summary>
        /// 登陆界面启动是传入的参数
        /// </summary>
        public static string password = "";

        /// <summary>
        /// 机台编号 M_模块 通道 地址,ip_mcn_modu_chanl,exps
        /// </summary>
        public static DataTable moduleadr = new DataTable();

        /// <summary>
        /// 系统应用路径
        /// </summary>
      
        /// <summary>
        /// 为kaiyuan时 管理版现场监控调用
        /// </summary>
        public static string tydl = string.Empty;//统一登录判断是现场监控   为kaiyuan时
        /// <summary>
        /// 连接数据库配置文件
        /// </summary>
     
        /// <summary>
        /// 服务器数据库连接串
        /// </summary>
        public static string SqlConnentionString = "";
        /// <summary>
        /// ERP服务器数据库连接串
        /// </summary>
        public static string ERPDBSqlConnentionString = "";
        /// <summary>
        /// 服务器数据库连接串
        /// </summary>
        public static string CRMSqlConnentionString = "";
        public static string SqlConnentionString2 = "";
        /// <summary>
        /// 服务器IP
        /// </summary>
        public static string ServerIP = "";
        /// <summary>
        /// 0:成品 1:坯布
        /// </summary>
        public static int SystemType = 0;
        /// <summary>
        /// 删除成功标志
        /// </summary>
        public static bool GPlanDelFlg = false;
        #region Login常数
        /// <summary>
        /// 当前登陆用户GUID
        /// </summary>
        public static Guid LogUserId = new Guid();
        /// <summary>
        /// 当前登陆用户对应员工GUID
        /// </summary>
        public static Guid LogPsnId = new Guid();
        /// <summary>
        /// 登陆用户编号
        /// </summary>
        public static string LogUserSht = string.Empty;//登陆用户编号
        /// <summary>
        /// 登入人编号
        /// </summary>
        public static string LogPsnSht = string.Empty;//登入人编号
        /// <summary>
        /// 登入用户密码
        /// </summary>
        public static string LogUserPwd = string.Empty; //登入用户密码
        /// <summary>
        /// 登入人姓名
        /// </summary>
        public static string LogPsnTxt = string.Empty;//登入人姓名
        /// <summary>
        /// 机台编号
        /// </summary>
        public static string LogMcnSht = string.Empty;//机台编号
        /// <summary>
        /// 机台名称
        /// </summary>
        public static string LogMcnTxt = string.Empty;//机台名称

        /// <summary>
        /// 班组名称
        /// </summary>
        public static string banTxt = "";
        /// <summary>
        /// 登录人所在班组人员
        /// </summary>
        public static string[] banPsnsSht = null;//登录人所在班组人员    
        public static string[] banPsnsTxt = null;//登录人所在班组人员  
        public static string[] banPsnsPosid = null;//登录人所在班组人员  
        public static string[] banPsnsPos = null;//登录人所在班组人员  
        public static string[] banPsnsLevel = null;//登录人所在班组人员  
        /// <summary>
        /// 系统单位
        /// </summary>
        public static string SysUnt = "米";
        #endregion
        #region 设置颜色
        /// <summary>
        /// 生产中生产单颜色
        /// </summary>
        public static Color PrjProduct = Color.FromArgb(196, 255, 225);
        //public static Color PrjProduct = Color.Green;
        /// <summary>
        /// 挂起生产单颜色
        /// </summary>
        public static Color PrjHang = Color.FromArgb(255, 255, 225);
        /// <summary>
        /// 完工以及结束生产单颜色
        /// </summary>
        public static Color PrjStop = Color.FromArgb(223, 223, 223);
        //public static Color PrjStop = Color.Gray;
        /// <summary>
        /// 异常颜色
        /// </summary>
        public static Color PrjExp = Color.FromArgb(255, 236, 237);
        #endregion

        public static bool ExitFlg = false;
        /// <summary>
        /// 登陆时间，用于存每次连接CRM服务器后当前时间
        /// </summary>
        public static DateTime CRMConnTime = DateTime.Now;
        /// <summary>
        /// 首次连接标志位，判断是否进行第一次连接 true表示为已连接
        /// </summary>
        public static bool FirstCRMConnFlag = false;
        /// <summary>
        /// 设置超时时间
        /// </summary>
        public static int CRMConnSettimeout = 120;
        /// <summary>
        /// 是否打开跳转窗体
        /// </summary>
        public static bool MessShowFlg = false;
        public static string MessFormName = "";//窗体名称
        public static string MessParamShtNo = "";//页面传参编号
        public static string MessParamShtId = "";//页面传参GOID
        public static string MessParamFromPath = "";//窗体路径
        public static string MessParamFromText = "";//窗体名称
        public static string MessFromFormPageFlag = "";//窗体来源
        public static string MessReturnPageFlag = "";//返回信息

        public static string[] pageparam;



        public static string HomepageFlag = "";//判断是否为流程菜单页面进入

        /// <summary>
        /// 二级报表窗体参数
        /// </summary>
        public static string[] param;

        /// <summary>
        /// 工艺配置刷新dt
        /// </summary>
        public static DataTable dtMain;

    }
}
