namespace XmlTxt
{
    partial class Form1
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
            this.txtXmlLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBkp = new System.Windows.Forms.TextBox();
            this.btnSelectTxtPath = new System.Windows.Forms.Button();
            this.txtTxt = new System.Windows.Forms.TextBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtXmlLocation
            // 
            this.txtXmlLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtXmlLocation.Enabled = false;
            this.txtXmlLocation.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXmlLocation.Location = new System.Drawing.Point(12, 97);
            this.txtXmlLocation.Name = "txtXmlLocation";
            this.txtXmlLocation.Size = new System.Drawing.Size(462, 47);
            this.txtXmlLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conversor Xml para Txt";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::XmlTxt.Properties.Resources.documents_158461_960_720;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(490, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 47);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::XmlTxt.Properties.Resources.documents_158461_960_720;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(490, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 47);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBkp
            // 
            this.txtBkp.BackColor = System.Drawing.SystemColors.Window;
            this.txtBkp.Enabled = false;
            this.txtBkp.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBkp.Location = new System.Drawing.Point(12, 186);
            this.txtBkp.Name = "txtBkp";
            this.txtBkp.Size = new System.Drawing.Size(462, 47);
            this.txtBkp.TabIndex = 3;
            // 
            // btnSelectTxtPath
            // 
            this.btnSelectTxtPath.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectTxtPath.BackgroundImage = global::XmlTxt.Properties.Resources.documents_158461_960_720;
            this.btnSelectTxtPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectTxtPath.Location = new System.Drawing.Point(490, 279);
            this.btnSelectTxtPath.Name = "btnSelectTxtPath";
            this.btnSelectTxtPath.Size = new System.Drawing.Size(53, 47);
            this.btnSelectTxtPath.TabIndex = 6;
            this.btnSelectTxtPath.UseVisualStyleBackColor = false;
            this.btnSelectTxtPath.Click += new System.EventHandler(this.btnSelectTxtPath_Click);
            // 
            // txtTxt
            // 
            this.txtTxt.BackColor = System.Drawing.SystemColors.Window;
            this.txtTxt.Enabled = false;
            this.txtTxt.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxt.Location = new System.Drawing.Point(12, 279);
            this.txtTxt.Name = "txtTxt";
            this.txtTxt.Size = new System.Drawing.Size(462, 47);
            this.txtTxt.TabIndex = 5;
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.LightGreen;
            this.btnGerar.FlatAppearance.BorderSize = 0;
            this.btnGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerar.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.Location = new System.Drawing.Point(12, 357);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(531, 47);
            this.btnGerar.TabIndex = 8;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Selecione a pasta dos Xml";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selecione a pasta de backup dos Xml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Selecione a pasta onde o txt sera gerado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 416);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.btnSelectTxtPath);
            this.Controls.Add(this.txtTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtBkp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXmlLocation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXmlLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBkp;
        private System.Windows.Forms.Button btnSelectTxtPath;
        private System.Windows.Forms.TextBox txtTxt;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

