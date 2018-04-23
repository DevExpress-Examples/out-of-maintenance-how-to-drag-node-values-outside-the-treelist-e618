using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraTreeList;

namespace WindowsApplication1 {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form {
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.TextBox textBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(498, 375);
            this.treeList1.TabIndex = 0;
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseMove);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox1.Location = new System.Drawing.Point(498, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 375);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Drag-and-drop TreeList cells here";
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(652, 375);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            new DevExpress.XtraTreeList.Design.XViews(treeList1);
        }

        TreeListHitInfo dragStartHitInfo;

        private void treeList1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if(e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
                dragStartHitInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
        }
        private void treeList1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            if(e.Button == MouseButtons.Left
                && dragStartHitInfo != null && dragStartHitInfo.HitInfoType == HitInfoType.Cell) {

                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(dragStartHitInfo.MousePoint.X - dragSize.Width / 2,
                    dragStartHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);

                if(!dragRect.Contains(new Point(e.X, e.Y))) {
                    string dragObject = dragStartHitInfo.Node.GetDisplayText(dragStartHitInfo.Column);
                    (sender as TreeList).DoDragDrop(dragObject, DragDropEffects.Copy);
                }
            }
        }
        private void textBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }
        private void textBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
            string data = e.Data.GetData("System.String", true) as string;
            if(data != null)
                (sender as TextBox).Text = data;
        }
    }
}
