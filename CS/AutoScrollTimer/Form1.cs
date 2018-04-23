using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AutoScrollTimer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        AutoScrollHelper autoScrollHelper;
        private void Form1_Load(object sender, EventArgs e) {
            gridControl1.DataSource = GetDataTable();
            autoScrollHelper = new AutoScrollHelper(gridView1);
        }

        private DataTable GetDataTable() {
            const int ColCount = 40;
            const int RowCount = 100;
            DataTable table = new DataTable();
            for(int i = 0; i < ColCount; i++)
                table.Columns.Add();
            for(int j = 0; j < RowCount; j++) {
                DataRow row = table.NewRow();
                for(int i = 0; i < ColCount; i++)
                    row[i] = string.Format("row {0} / col {1}", j, i);
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            return table;
        }

        private void simpleButton1_MouseMove(object sender, MouseEventArgs e) {
            simpleButton1.DoDragDrop("test", DragDropEffects.Move);
        }

        private void gridControl1_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
            autoScrollHelper.ScrollIfNeeded();
        }

        private void gridControl1_DragLeave(object sender, EventArgs e) {
            
        }
    }
}