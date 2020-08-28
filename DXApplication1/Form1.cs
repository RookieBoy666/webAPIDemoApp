using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    dic.Clear();
        //    dic.Add("Id", "id");
        //    string ret = HttpUtils.HttpGet("home/ApplyById", dic);
        //    if (!string.IsNullOrEmpty(ret) && !ret.Contains("failed"))
        //    {
        //        DataTable dt = JsonConvert.DeserializeObject<DataTable>(ret);
        //        gridControl1.DataSource = dt;

        //        #region 合计
        //        #endregion
        //    }
        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.ToString();
            if(!string.IsNullOrEmpty(id))
            {
                Search(id);
            }
        }

        private void Search(string id)
        {
            dic.Clear();
            dic.Add("id", id);
            string ret = HttpUtils.HttpGet("home/ApplyById", dic);
            if (!string.IsNullOrEmpty(ret) && !ret.Contains("failed"))
            {
                DataTable dt = new DataTable();
                dt= JsonConvert.DeserializeObject<DataTable>(ret);
         
                // ds = dt.Tables[0];
                gridControl1.DataSource = dt;

                #region 合计
                #endregion
            }
        }

      
    }
}
