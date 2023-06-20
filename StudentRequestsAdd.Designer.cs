namespace APU_Programming_Café_Management_System.StudentForm
{
    partial class StudentRequestsAdd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxModule = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(69, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 25);
            this.lblTitle.TabIndex = 54;
            this.lblTitle.Text = "Write a Request to Lecturer";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(566, 326);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 53;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite.ForeColor = System.Drawing.SystemColors.Control;
            this.btnWrite.Location = new System.Drawing.Point(656, 326);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 31);
            this.btnWrite.TabIndex = 52;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(412, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Level :";
            // 
            // cmbBoxLevel
            // 
            this.cmbBoxLevel.FormattingEnabled = true;
            this.cmbBoxLevel.Location = new System.Drawing.Point(415, 181);
            this.cmbBoxLevel.Name = "cmbBoxLevel";
            this.cmbBoxLevel.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxLevel.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(248, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Module :";
            // 
            // cmbBoxModule
            // 
            this.cmbBoxModule.FormattingEnabled = true;
            this.cmbBoxModule.Location = new System.Drawing.Point(251, 181);
            this.cmbBoxModule.Name = "cmbBoxModule";
            this.cmbBoxModule.Size = new System.Drawing.Size(121, 24);
            this.cmbBoxModule.TabIndex = 48;
            // 
            // StudentRequestsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBoxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxModule);
            this.Name = "StudentRequestsAdd";
            this.Size = new System.Drawing.Size(800, 406);
            this.Load += new System.EventHandler(this.StudentRequestsAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxModule;
    }
}
