using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Public
{
   public class PublicMethod
    {
        /// <summary>
        /// 设置GridView行号
        /// </summary>
        /// <param name="e"></param>
        public static void SetGridViewRowNo(DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (1 == 1)
            {
                //if (e.RowHandle >= 0)
                //{
                //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                //}
                //else if (e.RowHandle < 0 && e.RowHandle > -1000)
                //{
                //    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                //    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                //}
            }
        }

    }
}
