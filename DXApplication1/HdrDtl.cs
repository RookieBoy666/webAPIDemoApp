using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DXApplication1.Public;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using webApiDemoApp.Print;

namespace DXApplication1
{
    public partial class HdrDtl : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        DataSet ds = new DataSet();

        string fileName = "";//xml存储地址
        bool closeflag = false;//关闭标志: true:需要关闭本窗体
        public HdrDtl()
        {
            InitializeComponent();
        }
        private void lookUpEdit1_EditValueChanged(object sender, System.EventArgs e)
        {
            string ret = HttpUtils.HttpGet("home/sexList", dic);
        }
        private void HdrDtl_Load(object sender, System.EventArgs e)
        {
            //用于记忆
            fileName = Directory.GetCurrentDirectory() + "\\Resources\\XML\\" + this.Name + ".xml";

            gridControl1.ForceInitialize();
            if (System.IO.File.Exists(fileName))
                gridView1.RestoreLayoutFromXml(fileName);




            string ret = HttpUtils.HttpGet("home/sexList", dic);

            if (!string.IsNullOrEmpty(ret) && !ret.Contains("failed"))
            {
                DataTable dt = new DataTable();
                using (dt = JsonConvert.DeserializeObject<DataTable>(ret))
                {
                    sex.Properties.DataSource = dt;
                    sex.Properties.ShowDropDown = ShowDropDown.DoubleClick;
                    sex.Properties.ImmediatePopup = true;//显示下拉列表
                    sex.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;//此控件不允许输入
                    sex.Properties.NullText = "";//清空默认值
                    sex.Properties.ValueMember = "value";
                    sex.Properties.DisplayMember = "value";
                  //  this.sex.Properties.NullText = "请选择...";
                }
                //查询数据
                dic.Clear();
                string list = HttpUtils.HttpGet("home/studentList", dic);
                if (!string.IsNullOrEmpty(ret) && !ret.Contains("failed"))
                {
                    DataTable datatable = new DataTable();
                    datatable = JsonConvert.DeserializeObject<DataTable>(list);
                    gridControl1.DataSource = datatable;
                    #region 合计
                    #endregion
                }
            }
        }
        //明细自动编号
        private void GridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            PublicMethod.SetGridViewRowNo(e);
        }

        //双击跳转到信息页面
        private void  GridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = gridView1.FocusedRowHandle;//获取当前行标
            if (rowindex < 0)
                return;

        string mainid = gridView1.GetRowCellValue(rowindex, "Id").ToString();//选择行主单id
            //int statuscode = GetStatusCode(mainid);
            //if (statuscode == -1)
            //{
            //    MessageBox.Show("该单据不存在!", "提示");
            //    return;
            //}
            //else if (statuscode == -10000)//若包含failed,HttpGet方法内已弹出过,不再重复弹出
            //{
            //    return;
            //}
            StudentMess form = new StudentMess(mainid);
          //  form.MdiParent = this.MdiParent;
            form.Text = "学生信息";
            form.Show();
        }
        //重新获取单据状态
        //private int GetStatusCode(string id)
        //{
        //    dic.Clear();
        //    dic.Add("mainid", id);
        //    dic.Add("type", "0");
        //    string retvalue = HttpUtils.HttpGet("Public/EditeOrDeleteCheck", dic);
        //    int retval = -10000;
        //    if (!string.IsNullOrEmpty(retvalue) && !retvalue.Contains("failed"))
        //    {
        //        retval = JsonConvert.DeserializeObject<int>(retvalue);
        //    }
        //    return retval;
        //}
        private static void GridControl_DataSourceChanged(object sender, EventArgs e)
        {
            GridView view = (sender as GridControl).MainView as GridView;
            view.BestFitColumns();
        }
        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            dic.Clear();
            dic.Add("id", id.Text);
            dic.Add("name", name.Text);
            if (this.sex.Properties.NullText != null || this.sex.Properties.NullText != "请选择...")
                dic.Add("sex", sex.Text);
            else
                dic.Add("sex", "");
            string list = HttpUtils.HttpGet("home/GetStudentsList", dic);
            if (!string.IsNullOrEmpty(list) && !list.Contains("failed"))
            {
                DataTable datatable = new DataTable();
                datatable = JsonConvert.DeserializeObject<DataTable>(list);
                gridControl1.DataSource = datatable;
                #region 合计
                #endregion
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            if (index < 0)
            {
                MessageBox.Show("请选中需要操作的数据行！", "提示");
                return;
            }
            string id = "";
            id = gridView1.GetRowCellValue(index, gridView1.Columns["Id"]).ToString();
            PrintForm printForm = new PrintForm("student", id, ds);
        }
    }
}