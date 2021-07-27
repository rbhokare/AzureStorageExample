namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtOrderText = new System.Windows.Forms.TextBox();
            this.lblOrderText = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblErrorText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(388, 349);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(145, 50);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(233, 349);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(145, 50);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtOrderText
            // 
            this.txtOrderText.Location = new System.Drawing.Point(233, 125);
            this.txtOrderText.Name = "txtOrderText";
            this.txtOrderText.Size = new System.Drawing.Size(316, 27);
            this.txtOrderText.TabIndex = 1;
            // 
            // lblOrderText
            // 
            this.lblOrderText.AutoSize = true;
            this.lblOrderText.Location = new System.Drawing.Point(132, 128);
            this.lblOrderText.Name = "lblOrderText";
            this.lblOrderText.Size = new System.Drawing.Size(78, 20);
            this.lblOrderText.TabIndex = 2;
            this.lblOrderText.Text = "Order Text";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.Location = new System.Drawing.Point(233, 82);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(316, 27);
            this.txtOrderDate.TabIndex = 1;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(132, 85);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Order Date";
            // 
            // lblErrorText
            // 
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.ForeColor = System.Drawing.Color.Red;
            this.lblErrorText.Location = new System.Drawing.Point(132, 175);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(85, 20);
            this.lblErrorText.TabIndex = 3;
            this.lblErrorText.Text = "lblErrorText";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblErrorText);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.lblOrderText);
            this.Controls.Add(this.txtOrderText);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtOrderText;
        private System.Windows.Forms.Label lblOrderText;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblErrorText;
    }
}

