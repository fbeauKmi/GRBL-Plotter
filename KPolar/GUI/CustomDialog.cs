using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using GrblPlotter.GUI;
using GrblPlotter;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrblPlotter.GUI
{
    public partial class CustomDialog : Form
    {
        private object sender;

        public enum DialogResult
        {
            Upload,
            UploadAndPrint,
            Cancel
        }
        public DialogResult Result { get; private set; }

        public CustomDialog(string message, string caption, object sender, Form owner)
        {
            this.sender = sender;
            this.Owner = owner;
            InitializeComponent();
            this.Text = caption;
            this.labelMessage.Text = message;
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Upload;
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonUploadAndPrint_Click(object sender, EventArgs e)
        {
            Result = DialogResult.UploadAndPrint;
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
namespace GrblPlotter.GUI
{
    partial class CustomDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonUploadAndPrint;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            

            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonUploadAndPrint = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(50, 13);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Message";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(15, 50);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 1;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonUploadAndPrint
            // 
            this.buttonUploadAndPrint.Location = new System.Drawing.Point(96, 50);
            this.buttonUploadAndPrint.Name = "buttonUploadAndPrint";
            this.buttonUploadAndPrint.Size = new System.Drawing.Size(100, 23);
            this.buttonUploadAndPrint.TabIndex = 2;
            this.buttonUploadAndPrint.Text = "Upload and Print";
            this.buttonUploadAndPrint.UseVisualStyleBackColor = true;
            this.buttonUploadAndPrint.Click += new System.EventHandler(this.buttonUploadAndPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(202, 50);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            // Add this line in the InitializeComponent method to disable size change by user
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUploadAndPrint);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.labelMessage);
            this.Name = "CustomDialog";
            this.Text = "CustomDialog";

            this.StartPosition = FormStartPosition.Manual;
            if (this.sender is Control control)
            {
                Point point = control.PointToScreen(new Point(0, 0));
                this.Location = new Point(point.X + (control.Width - this.Width)/2,
                                           point.Y + (control.Width - this.Width) / 2);
            }
            else if (this.sender is GroupBox groupBox)
            {
                Point point = groupBox.PointToClient(new Point(0, 0));
                this.Location = new Point(point.X + (groupBox.Width - this.Width) / 2,
                                           point.Y - (groupBox.Height - this.Height) / 2);
            }
            else
            {
                this.Location = new Point(this.Owner.Location.X + 25,
                                          this.Owner.Location.Y + 25);
            }

            this.Icon = Properties.Resources.Icon;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

