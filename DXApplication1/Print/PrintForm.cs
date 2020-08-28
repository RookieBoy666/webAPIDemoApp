using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;
using webApiDemoApp.DataDA;

namespace webApiDemoApp.Print
{
    public partial class PrintForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public PrintForm()
        {
            InitializeComponent();
        }
        public PrintForm(string moduleid, string id, DataSet ds, bool chkPrint = false)
        {
            InitializeComponent();
            switch (moduleid)
            {
                case "达利面料检验信息表"://达利面料检验信息表
                    //Fill_FabricInspectionInformation(ds);
                    break;
                case "杭州嘉濠印花染整有限公司生产指定书"://杭州嘉濠印花染整有限公司生产指定书
                    //Selectsalesorder_jiahao(id);
                    break;
                case "student"://新立成订单打印
                            StudentPrint(id);
                    break;
                case "莱美染色生产计划单"://莱美染色生产计划单
                  //  SalesorderPrint_laimei(id);
                    break;

            }
        }

        private void StudentPrint(String id)
        {
            IWorkbook workbook = spreadsheetControl1.Document;
            //string printsuffixs = CRMPublicDA.GetGlobalPrintSuffixs();
            //if (printsuffixs == "xinlicheng")
            //{
                DataTable dt = StudentDA.getStudents(id);
                workbook.LoadDocument("Resources/PrintTemplate/student.xlsx");
                int maxcolornum = 28;//每页最大行数
                int pagnum = ((dt.Rows.Count - 1) / maxcolornum) + 1;
                for (int p = 0; p < pagnum; p++)//遍历页
                {
                    Worksheet sheet = workbook.Worksheets["Sheet" + (p + 1)];

                    if (pagnum > p + 1)//打完本页之后，还有其他页需要打印,先把本页模板拷贝到下一页
                    {
                        workbook.Worksheets.Add("Sheet" + (p + 2));

                        workbook.Worksheets["Sheet" + (p + 2)].CopyFrom(sheet);
                    }
                    sheet.Cells["b3"].Value = dt.Rows[0]["name"].ToString();
                    sheet.Cells["e3"].Value = dt.Rows[0]["id"].ToString();

                    //sheet.Cells["h3"].Value = dt.Rows[0]["pbly"].ToString();
                    //sheet.Cells["e4"].Value = dt.Rows[0]["ht"].ToString();
                    //sheet.Cells["h4"].Value = dt.Rows[0]["cler"].ToString();
                    //sheet.Cells["A24"].Value = dt.Rows[0]["dre"].ToString();
                    //sheet.Cells["e6"].Value = dt.Rows[0]["tpzl"].ToString();
                    //sheet.Cells["B28"].Value = dt.Rows[0]["FullName"].ToString();
                    //sheet.Cells["e5"].Value = Convert.ToDateTime(dt.Rows[0]["cjrq"]).ToString("yyyy-MM-dd");
                    //sheet.Cells["b4"].Value = Convert.ToDateTime(dt.Rows[0]["jhrq"]).ToString("yyyy-MM-dd");
                    int startno = 8;
                    string saleorderno = "a";
                    string cellcardno = "b";
                    string cellpinming = "c";
                    string cellsehao = "d";
                    string cellseming = "e";
                    string cellpishu = "f";
                    string cellnewpro = "g";
                    string cellrmk = "h";
                    int k = 0;
                    int sumjs = 0;
                    //decimal summs = 0;
                    //decimal sumjz = 0;
                    //decimal summz = 0;
                    for (int j = 0; j < maxcolornum; j++)
                    {
                        int a = p * maxcolornum + j;
                        if (a < dt.Rows.Count)
                        {
                            sheet.Cells[saleorderno + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["name"].ToString();
                            sheet.Cells[cellcardno + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["id"].ToString();
                            sheet.Cells[cellpinming + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["sex"].ToString();
                            //sheet.Cells[cellsehao + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["ep_ColorOrColorway"].ToString();
                            //sheet.Cells[cellseming + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["ep_quantity"].ToString();
                            //sheet.Cells[cellpishu + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["unit"].ToString();
                            //sheet.Cells[cellnewpro + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["fsize"].ToString();
                            //sheet.Cells[cellrmk + (startno + k)].Value = dt.Rows[(p * maxcolornum) + j]["clre"].ToString();
                            k++;
                          //  sumjs += Convert.ToInt32(dt.Rows[(p * maxcolornum) + j]["ep_quantity"]);
                            //summs += Convert.ToDecimal(dt.Rows[(p * maxcolornum) + j]["ms"]);
                            //// summz += Convert.ToDecimal(dt.Rows[(p * maxcolornum) + j]["mzh"]);
                            //sumjz += Convert.ToDecimal(dt.Rows[(p * maxcolornum) + j]["zl"]);
                         //   sheet.Cells["e23"].Value = sumjs.ToString();
                            //sheet.Cells["d18"].Value = summs.ToString();
                            ////sheet.Cells["f18"].Value = summz.ToString();
                            //sheet.Cells["h18"].Value = sumjz.ToString();
                        }
                    }
                //}
            }
        }

    }
}