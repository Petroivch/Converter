
namespace Converter
{
    partial class ConversionSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFormatFile = new System.Windows.Forms.Label();
            this.rbtnCsv = new System.Windows.Forms.RadioButton();
            this.rbtnJson = new System.Windows.Forms.RadioButton();
            this.rbtnXML = new System.Windows.Forms.RadioButton();
            this.rbtnXLSX = new System.Windows.Forms.RadioButton();
            this.btnSaveExitForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFormatFile
            // 
            this.lblFormatFile.AutoSize = true;
            this.lblFormatFile.Location = new System.Drawing.Point(28, 27);
            this.lblFormatFile.Name = "lblFormatFile";
            this.lblFormatFile.Size = new System.Drawing.Size(201, 20);
            this.lblFormatFile.TabIndex = 0;
            this.lblFormatFile.Text = "Choice a format of result file:";
            // 
            // rbtnCsv
            // 
            this.rbtnCsv.AutoSize = true;
            this.rbtnCsv.Location = new System.Drawing.Point(46, 112);
            this.rbtnCsv.Name = "rbtnCsv";
            this.rbtnCsv.Size = new System.Drawing.Size(56, 24);
            this.rbtnCsv.TabIndex = 2;
            this.rbtnCsv.TabStop = true;
            this.rbtnCsv.Text = "CSV";
            this.rbtnCsv.UseVisualStyleBackColor = true;
            // 
            // rbtnJson
            // 
            this.rbtnJson.AutoSize = true;
            this.rbtnJson.Location = new System.Drawing.Point(46, 69);
            this.rbtnJson.Name = "rbtnJson";
            this.rbtnJson.Size = new System.Drawing.Size(65, 24);
            this.rbtnJson.TabIndex = 3;
            this.rbtnJson.TabStop = true;
            this.rbtnJson.Text = "JSON";
            this.rbtnJson.UseVisualStyleBackColor = true;
            // 
            // rbtnXML
            // 
            this.rbtnXML.AutoSize = true;
            this.rbtnXML.Location = new System.Drawing.Point(46, 160);
            this.rbtnXML.Name = "rbtnXML";
            this.rbtnXML.Size = new System.Drawing.Size(59, 24);
            this.rbtnXML.TabIndex = 4;
            this.rbtnXML.TabStop = true;
            this.rbtnXML.Text = "XML";
            this.rbtnXML.UseVisualStyleBackColor = true;
            // 
            // rbtnXLSX
            // 
            this.rbtnXLSX.AutoSize = true;
            this.rbtnXLSX.Location = new System.Drawing.Point(46, 208);
            this.rbtnXLSX.Name = "rbtnXLSX";
            this.rbtnXLSX.Size = new System.Drawing.Size(63, 24);
            this.rbtnXLSX.TabIndex = 5;
            this.rbtnXLSX.TabStop = true;
            this.rbtnXLSX.Text = "XLSX";
            this.rbtnXLSX.UseVisualStyleBackColor = true;
            // 
            // btnSaveExitForm
            // 
            this.btnSaveExitForm.Location = new System.Drawing.Point(46, 255);
            this.btnSaveExitForm.Name = "btnSaveExitForm";
            this.btnSaveExitForm.Size = new System.Drawing.Size(134, 38);
            this.btnSaveExitForm.TabIndex = 6;
            this.btnSaveExitForm.Text = "Save and Exit";
            this.btnSaveExitForm.UseVisualStyleBackColor = true;
            this.btnSaveExitForm.Click += new System.EventHandler(this.btnExitForm_Click);
            // 
            // ConversionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 325);
            this.ControlBox = false;
            this.Controls.Add(this.btnSaveExitForm);
            this.Controls.Add(this.rbtnXLSX);
            this.Controls.Add(this.rbtnXML);
            this.Controls.Add(this.rbtnJson);
            this.Controls.Add(this.rbtnCsv);
            this.Controls.Add(this.lblFormatFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConversionSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conversion Settings";
            this.Load += new System.EventHandler(this.ConversionSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormatFile;
        private System.Windows.Forms.RadioButton rbtnCsv;
        private System.Windows.Forms.RadioButton rbtnJson;
        private System.Windows.Forms.RadioButton rbtnXML;
        private System.Windows.Forms.RadioButton rbtnXLSX;
        private System.Windows.Forms.Button btnSaveExitForm;
    }
}