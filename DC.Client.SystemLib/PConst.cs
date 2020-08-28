using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace DC.Client.SystemLib
{
    //成品检验项目常量
    public class PConst : Const
    {

        /// <summary>
        /// 布卷打印查询语句
        /// </summary>

        public static string ColSqlStr = @"select fg_rol.prj as '生产单',sd_prj.clr as '色号',sd_prj.P_mtrtxt AS '产品',sd_cod.p_con as '产品规格',
    fg_rol.wth AS '门幅',fg_rol.sht as '卷号',fg_rol.qty as '数量',fg_rol.mqty as '米数',fg_rol.yqty as '码数',
    fg_rol.wqty as '重量',sd_cod.p_unt as '单位',case when sd_cod.p_unt='米' then 'M' else 'Y' end as '英文单位',fg_rol.cty as '等级',isnull(qm_env.ptxt,'') as '打印等级',fg_rol.usetxt AS '款号',fg_rol.mov as '缸号',
    fg_rol.lot as 'LOT号',fg_rol.psntxt as '检验员',fg_rol.cdat AS '检验日期','生产单:'+fg_rol.prj+'色号:'+sd_prj.clr+'产品:'+sd_prj.P_mtrtxt+'产品规格:'+sd_cod.p_con+'门幅:'+fg_rol.wth+'卷号:'+fg_rol.sht+'米数:'+convert(varchar(50),fg_rol.mqty) as '二维码',  isnull(fg_rol.barcode1,'0000000000') as '条码1'
    from fg_rol
    join sd_prj on sd_prj.prjsht=fg_rol.prj
    join sd_cod on sd_cod.sht=sd_prj.sht
    left join qm_env on qm_env.typ=3 and qm_env.txt=fg_rol.cty
    where 1=1";
        /// <summary>
        /// 布匹检验类型：0布匹检验 1布匹打卷 2布匹检验打卷 3布匹称重 4布匹打包 5贸易版
        /// </summary>
        public static int ColType = 0;
        /// <summary>
        /// 打印配置文件名
        /// </summary>
        public static string PrintXMLName = "默认标签";
        /// <summary>
        /// 是否默认直接打卷 0:不默认 1:默认
        /// </summary>
        public static int PackColFlg = 0;
        /// <summary>
        /// 是否默认打印 0:不默认 1:默认
        /// </summary>
        public static int PrintFlg = 0;
        /// <summary>
        /// 码表偏移值
        /// </summary>
        public static decimal WarpNum = 0;
        /// <summary>
        /// 打印条码长度(>)
        /// </summary>
        public static decimal PrintColQty = 10;
        /// <summary>
        /// 零布长度
        /// </summary>
        public static decimal Lingbu = 10;
        /// <summary>
        /// 默认剪布类型(根据qm_env读取剪布类型的txt)
        /// </summary>
        public static string CutType = "不剪";
        /// <summary>
        /// 0:刷卡 1:刷单
        /// </summary>
        public static int BrushCardOrPrj = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        public static int ColDecimalNum = 2;
        /// <summary>
        /// 进位方式(0:四舍五入,1:直接舍弃,2:直接进位)
        /// </summary>
        public static int ColRoundNum = 0;
        /// <summary>
        /// 卷号取法 0:不自动补号 1:自动补号
        /// </summary>
        public static int ColNoAddType = 0;
        /// <summary>
        /// 打印份数
        /// </summary>
        public static int PrintNum = 0;
        /// <summary>
        /// 当前活动窗体
        /// </summary>
        public static Form ActivatForm;
        /// <summary>
        /// 是否定义键
        /// </summary>
        public static bool EnterKeys = false;
        /// <summary>
        /// 零布等级名称
        /// </summary>
        public static string lingbutxt = "";
        /// <summary>
        /// 正品等级名称
        /// </summary>
        public static string zptxt = "";
        /// <summary>
        /// 另次等级名称
        /// </summary>
        public static string lctxt = "";
        /// <summary>
        /// 正品小于分数
        /// </summary>
        public static int ColCtyQty = 20;
        /// <summary>
        /// 码表com口
        /// </summary>
        public static string MComStr = "";
        /// <summary>
        /// 车速com口
        /// </summary>
        public static string VoComStr = "";
        /// <summary>
        /// 电子称com口
        /// </summary>
        public static string KComStr = "";
        /// <summary>
        /// 码表地址
        /// </summary>
        public static string MAddr = "";
        /// <summary>
        /// 车速地址
        /// </summary>
        public static string VoAddr = "";
        /// <summary>
        /// 电子称地址
        /// </summary>
        public static string KAddr = "";
        /// <summary>
        /// 断网标志  true为断网
        /// </summary>
        public static bool NoInterNet = false;
        /// <summary>
        /// 称重标志 0:不计重 1:取电子称 2:根据长度算
        /// </summary>
        public static int WeightFlg = 0;
        /// <summary>
        /// 界面单位 0:不取生产单单位 1:取生产单单位
        /// </summary>
        public static int PrjUntSelect = 1;
        /// <summary>
        /// 码表取数端口
        /// </summary>
        public static System.IO.Ports.SerialPort serport;
        /// <summary>
        /// 码表取车速端口
        /// </summary>
        public static System.IO.Ports.SerialPort voserport;
        /// <summary>
        /// 秤端口
        /// </summary>
        public static System.IO.Ports.SerialPort kgserport;
        /// <summary>
        /// 机台的模块 例子：YXME01_0
        /// </summary>
        public static string McnModu = string.Empty;
        /// <summary>
        /// 机台的模块 例子：YXME01_0
        /// </summary>
        public static string McnVoModu = string.Empty;
        /// <summary>
        /// 机台的模块 例子：YXME01_0
        /// </summary>
        public static string McnKgModu = string.Empty;
        /// <summary>
        /// 临时保存文件
        /// </summary>
        public static string xmlSave = Const.StartupPath + "\\Resources\\SaveFile.xml";
        /// <summary>
        /// 程序关闭标志
        /// </summary>
        public static bool ExitFlg = false;
        /// <summary>
        /// 自定义Label显示文字
        /// </summary>
        public static DataTable dtLabelText = new DataTable();
        /// <summary>
        /// 自定义控件位置
        /// </summary>
        public static DataTable dtControl = new DataTable();
        /// <summary>
        /// Control位置
        /// </summary>
        public static string xmlColControl = Const.StartupPath + "\\Resources\\ColControlSetSizeFile.xml";
        /// <summary>
        /// Control位置
        /// </summary>
        public static string xmlCheckControl = Const.StartupPath + "\\Resources\\CheckControlSetSizeFile.xml";
        /// <summary>
        /// Label显示XML文件
        /// </summary>
        public static string xmlColLabel = Const.StartupPath + "\\Resources\\ColLabelTextFile.xml";
        /// <summary>
        /// Label显示XML文件
        /// </summary>
        public static string xmlCheckLabel = Const.StartupPath + "\\Resources\\CheckLabelTextFile.xml";
        /// <summary>
        /// 箱单打印打印机名称设置
        /// </summary>
        public static string xmlBoxPrint = Const.StartupPath + "\\Resources\\BoxPrintSet.xml";
        public static string BoxPrint = "";
        public static string BoxDetailPrint = "";
        /// <summary>
        /// 合计处生产单总数
        /// </summary>
        public static string TotalPrjText = "生产单投坯/总数";
        /// <summary>
        /// 合计处已打卷数/卷数
        /// </summary>
        public static string TotalCheckPackQtyText = "已打卷数/卷数";
        /// <summary>
        /// 合计处未打卷数
        /// </summary>
        public static string TotalNoCheckPackQtyText = "未打卷数";
        /// <summary>
        /// 打卷疵点类型
        /// </summary>
        public static string ColCidTypSht = "60101";
        /// <summary>
        /// 打卷疵点类型
        /// </summary>
        public static string ColCidTypTxt = "成检";
        /// <summary>
        /// 成品布卷卷号是否自动生成:0:自动 1:不自动
        /// </summary>
        public static int ColEnterSht = 0;
        /// <summary>
        /// 等级变化类型 0:手动选择 1:根据fg_pct设置等级码分范围变化等级
        /// </summary>
        public static int CtyChangeTyp = 0;
        /// <summary>
        /// 布匹检验/打卷是否需要卡完工后才能进行 0:不需要 1:需要
        /// </summary>
        public static int StartCheckFlg = 0;
        /// <summary>
        /// 车速的纠正系数
        /// </summary>
        public static decimal VoNum = 1;
        /// <summary>
        /// 保存后是否清除加减码 0:是 1:否
        /// </summary>
        public static int ClearSendQty = 0;
        /// <summary>
        /// 不校验 检验打卷可超出比例 0:校验 1:不校验
        /// </summary>
        public static int NoColCheckPackLen = 0;
        /// <summary>
        /// 是否支持多机台刷同卡 0:不允许 1:允许
        /// </summary>
        public static int OnlyMcnPackCard = 0;
        /// <summary>
        /// 校验门幅是否必输 0:校验 1:不校验
        /// </summary>
        public static int CheckColWthEnter = 0;
        /// <summary>
        /// 打卷长度是否保留整数 0:不保留 1:保留
        /// </summary>
        public static int ColQtyRounding = 0;
        /// <summary>
        /// 检验保存间隔时间:单位为秒
        /// </summary>
        public static decimal CheckSaveTime = 3;
        /// <summary>
        /// 卷号根据生产单/卡号/柜号取 0:生产单 1:卡号 2:柜号
        /// </summary>
        public static int ColNoForYunOrPrj = 0;
        public static string BarcodeSetXml = Const.StartupPath + "\\Resources\\BarcodeSet.xml";
        public static string BarcodeSetSql = "";
        /// <summary>
        /// 布匹检验系统打印模式 0：旧版模式（xml和Excel） 1:FastReport
        /// </summary>
        public static int ColPrintType = 0;
        /// <summary>
        /// 布匹检验系统自动带出门幅 0：不自动带出 1：带出
        /// </summary>
        public static int ColSetWth = 0;
    }
}
