using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
//using Microsoft.Xrm.Sdk;

namespace DC.Client.SystemLib
{
    public class PrdConst
    {
        /// <summary>
        /// 连接数据库配置文件
        /// </summary>
        public static string DBConnFile = Directory.GetCurrentDirectory() + "\\Resources\\XML\\SystemSet.xml";
        /// <summary>
        /// Cookies文件
        /// </summary>
        public static string CookiesFile = Directory.GetCurrentDirectory() + "\\Resources\\XML\\Cookies.xml";
        /// <summary>
        /// update文件
        /// </summary>
        public static string UpdateFile = Directory.GetCurrentDirectory() + "\\Resources\\XML\\Update.xml";
        /// <summary>
        /// 上次登录用户
        /// </summary>
        public static string LastUser = "";
        /// <summary>
        /// 上次登录用户密码
        /// </summary>
        public static string LastPwd = "";
        /// <summary>
        /// 上次登录样式
        /// </summary>
        public static string LastStyle = "";
        /// <summary>
        /// 登录系统用户id
        /// </summary>
        public static string SystemUserId = "";
        /// <summary>
        /// 登录系统部门
        /// </summary>
        public static string OwningBusinessUnit = "";
        /// <summary>
        /// 负责人类型
        /// </summary>
        public static string OwnerIdType = "";
        /// <summary>
        /// 登录员工部门id
        /// </summary>
        public static string PartId = "";
        /// <summary>
        /// 登录员工部门名称
        /// </summary>
        public static string PartName = "";
        /// <summary>
        /// 当前登录人名称,用于制单人界面显示。
        /// </summary>
        public static string UserName = "";
        /// <summary>
        /// 登录员工岗位id
        /// </summary>
        public static string PostId = "";
        /// <summary>
        /// 登录员工岗位名称
        /// </summary>
        public static string PostName = "";
        /// <summary>
        /// 登录用户的微信用户组
        /// </summary>
        public static string Clerk = "";
        /// <summary>
        /// 上次登录机台
        /// </summary>
        public static string LastMcn = "";
        /// <summary>
        /// 100:生产作业4.0  200:能源监控
        /// </summary>
        public static int intShow = 100;
        /// <summary>
        /// 机台模式
        /// </summary>
        public static string MachineMode = "正常模式";
        /// <summary>
        /// 是否允许最小化
        /// </summary>
        public static bool MinEnable = false;
        /// <summary>
        /// ERP组织名称
        /// </summary>
        public static string ERPServerName = "";
        /// <summary>
        /// ERP域名
        /// </summary>
        public static string ERPDomain = "";
        /// <summary>
        /// 域端口
        /// </summary>
        public static string ERPDomainCom = "";
        /// <summary>
        /// ERP链接组织服务
        /// </summary>
     //   public static IOrganizationService CRMService;
        /// <summary>
        /// 服务器名称
        /// </summary>
        public static string ServerName = "127.0.0.1";
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBName = "Jetpoint";
        /// <summary>
        /// 数据库登录用户
        /// </summary>
        public static string UserID = "sa";
        /// <summary>
        /// 数据库登录用户密码
        /// </summary>
        public static string Password = "";
        /// <summary>
        /// ERP服务器名称
        /// </summary>
        public static string ERPDBServerName = "127.0.0.1";
        /// <summary>
        /// ERP数据库名称
        /// </summary>
        public static string ERPDBName = "Jetpoint";
        /// <summary>
        /// ERP数据库登录用户
        /// </summary>
        public static string ERPDBUser = "sa";
        /// <summary>
        /// ERP数据库登录用户密码
        /// </summary>
        public static string ERPDBPassword = "";
        /// <summary>
        /// 数据库登录用户
        /// </summary>
        public static string ERPUserID = "";
        /// <summary>
        /// 数据库登录用户密码
        /// </summary>
        public static string ERPPassword = "";
        /// <summary>
        /// 主界面是否显示最小化按钮  默认1:显示 0:不显示
        /// </summary>
        public static int ShowMinBtn = 1;
        /// <summary>
        /// 登录界面与主界面标题
        /// </summary>
        public static string ShowTitle = "杭州开源 爱普（Enterpoint）生产管控.机台作业";

        /// <summary>
        /// 哪个地区的项目
        /// </summary>
        public static string ProjectArea = string.Empty;
        /// <summary>
        /// 屏幕高度
        /// </summary>
        public static int screenHeigth = 0;
        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public static int screenWidth = 0;
        /// <summary>
        /// 多机台编号
        /// </summary>
        public static string[] logmchs = null;//多机台编号
        /// <summary>
        /// 机台编号
        /// </summary>
        public static string logmch = string.Empty;//机台编号
        /// <summary>
        /// 登录机台名称
        /// </summary>
        public static string logmchtxt = string.Empty;//机台名称
        /// <summary>
        /// 登录机台id
        /// </summary>
        public static string intmcnid = string.Empty;//机台id;
        /// <summary>
        /// 班组名称
        /// </summary>
        public static string bantxt = "";
        /// <summary>
        /// 班组人员允许多机台登录 默认为0  0:允许 1:不允许
        /// </summary>
        public static int McnEnvPsnFlg = 0;
        /// <summary>
        /// 本机台对应IP地址
        /// </summary>
        public static string LocalIp = "";
        /// <summary>
        /// 机台相关登录信息
        /// Hashtable列表:
        /// LogUserID(用户ID),LogUserSht(用户名),LogUserPwd(密码),LogPsnID(登录人ID),LogPsnSht(登录人),LogPsnTxt(登录人名称),banTxt(班组),
        /// ftnum(按钮个数),zhflg,
        /// cdat(产量日期),sqty(上布米数),eqty(下布米数),svo(上布车速),evo(下布车速)
        /// </summary>
        public static IDictionary<string, Hashtable> McnMessList;
        /// <summary>
        /// 0 --摆布制卡,1 -- 半成品.
        /// </summary>
        public static int startwhich = 0;
        /// <summary>
        /// 记录回修制卡中最后一个卡号.
        /// </summary>
        public static string cardrepaino = "";
        /// <summary>
        /// 778170000-按摆布数量拆分,778170001-按实际投坯数量拆分,778170002-按当前数量拆分
        /// </summary>
        public static string GSetsplitqty = "778170000";
        /// <summary>
        /// 核心工序已报工的前提下进行卡转单操作权限
        /// </summary>
        public static bool CardCoreProcess = false;

        /// <summary>
        /// 一个工序对应多个工序检测项。
        /// </summary>
        public static Dictionary<string, Dictionary<string, int>> osdic = new Dictionary<string, Dictionary<string, int>>();

        /// <summary>
        /// 存储成品工艺库id或者其他生产单工艺流程id.
        /// fgstandrouting -- 成品工艺库标准流程，fgreviewrouting --成品工艺库评审流程，proid --引入其他生产单工艺流程。
        /// </summary>
        public static Dictionary<string,string> routingiddic = new Dictionary<string, string>();

        /// <summary>
        /// 引入的生产单单号
        /// </summary>
        public static string prostrfrom = "";

        /// <summary>
        /// CS打印后缀
        /// </summary>
        public static string PrintSuffixs = "";

        /// <summary>
        /// KYCSWebApi基地址
        /// </summary>
        public static string CSWebApiBaseUrl = "";

        /// <summary>
        /// 主题皮肤
        /// </summary>
        public static string Skin = "VS2010";

        /// <summary>
        /// 存储方法对应的当前当前工序
        /// </summary>
        public static string metseqid = "";

        /// <summary>
        /// 存储三级工艺工序id
        /// </summary>
        public static string threeseqid = "";
    }
}
