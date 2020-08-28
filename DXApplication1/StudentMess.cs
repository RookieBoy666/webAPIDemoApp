using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
 
namespace DXApplication1
{
    public partial class StudentMess : DevExpress.XtraEditors.XtraForm
    {
        string fileName = "";//xml存储地址
        string id = "";//主单id
        Dictionary<string, string> dic = new Dictionary<string, string>();
        bool closeflag = false;//关闭标志: true:需要关闭本窗体

        public StudentMess()
        {
            InitializeComponent();
        }
        public StudentMess(string inid)
        {
            InitializeComponent();
            id = inid;
        } //用于记忆

        private void StudentMess_Load(object sender, EventArgs e)
        {
            fileName = Directory.GetCurrentDirectory() + "\\Resources\\XML\\" + this.Name + ".xml";

            gridControl1.ForceInitialize();
            if (System.IO.File.Exists(fileName))
                gridView1.RestoreLayoutFromXml(fileName);



            if (!GetData(id))
            {
                closeflag = true;
                return;
            }
        }
        //获取数据
        public bool GetData(string inid)
        {
   
            dic.Clear();
            dic.Add("id", inid);
            string retmain = HttpUtils.HttpGet("home/GetMainMess", dic);//主单信息
            if (!string.IsNullOrEmpty(retmain) && !retmain.Contains("failed"))
            {
                DataTable dtmain = JsonConvert.DeserializeObject<DataTable>(retmain);
                if (dtmain != null && dtmain.Rows.Count > 0)
                {
                    name.Text = dtmain.Rows[0]["name"].ToString();
                    sex.Text = dtmain.Rows[0]["sex"].ToString();
                 

               
                }
            }
            else
            {
                return false;
            }
 

            #region 获取明细信息
            dic.Clear();
            dic.Add("id", inid);
            string retdetail = HttpUtils.HttpGet("Home/GetDetailById", dic);//明细信息
            if (!string.IsNullOrEmpty(retdetail) && !retdetail.Contains("failed"))
            {
                DataTable dtdetail = JsonConvert.DeserializeObject<DataTable>(retdetail);
                if (dtdetail != null && dtdetail.Rows.Count > 0)
                {
                    gridControl1.DataSource = dtdetail;

                    #region 合计
                    //if (dtdetail != null)
                    //{
                    //    //根据单位分别合计
                    //    DataTable dtsum = new DataTable();
                    //    dtsum.Columns.Add("unit", typeof(string));
                    //    dtsum.Columns.Add("sumqty", typeof(decimal));

                    //    for (int i = 0; i < dtdetail.Rows.Count; i++)
                    //    {
                    //        decimal qty = string.IsNullOrEmpty(dtdetail.Rows[i]["qty"].ToString()) ? 0 : Convert.ToDecimal(dtdetail.Rows[i]["qty"]);
                    //        string unit = dtdetail.Rows[i]["unit"].ToString();//当前行单位
                    //        DataRow[] dr = dtsum.Select("unit='" + unit + "'");
                    //        if (dr != null && dr.Length > 0)
                    //        {
                    //            dr[0]["sumqty"] = Convert.ToDecimal(dr[0]["sumqty"]) + qty;
                    //        }
                    //        else
                    //        {
                    //            dtsum.Rows.Add(unit, qty);
                    //        }
                    //    }
                    //    string sumtext = "";
                    //    for (int j = 0; j < dtsum.Rows.Count; j++)
                    //    {
                    //        sumtext += dtsum.Rows[j]["sumqty"].ToString() + " (" + dtsum.Rows[j]["unit"].ToString() + "),";
                    //    }
                    //    if (!string.IsNullOrEmpty(sumtext))
                    //    {
                    //        sumtext = sumtext.Substring(0, sumtext.Length - 1);
                    //    }

                    //    lblsum.Text = "合计: 本次到货数量: " + sumtext + ";";
                    //}
                    //else
                    //{
                    //    lblsum.Text = "合计: 本次到货数量: 0;";
                    //}
                    #endregion
                }
            }
            else
            {
                return false;
            }
            #endregion
            return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageReport ir = new ImageReport();
            //   ir.Report = report;

            //查询数据
            dic.Clear();
            string ret = HttpUtils.HttpGet("home/studentList", dic);
            if (!string.IsNullOrEmpty(ret) && !ret.Contains("failed"))
            {
                DataTable datatable = new DataTable();
                datatable = JsonConvert.DeserializeObject<DataTable>(ret);
                //  gridControl1.DataSource = datatable;
                ir.DataSource = datatable;  // 为报表设置数据列表
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

        }
    }
}