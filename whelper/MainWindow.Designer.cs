namespace whelper
{
    partial class MainWindow
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
            this.X = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LocalPlayerSection = new System.Windows.Forms.GroupBox();
            this.PBase = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EPBase = new System.Windows.Forms.Label();
            this.eX = new System.Windows.Forms.Label();
            this.eZ = new System.Windows.Forms.Label();
            this.eY = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LocalPlayerSection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(6, 59);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(54, 13);
            this.X.TabIndex = 0;
            this.X.Text = "Current X:";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Location = new System.Drawing.Point(6, 114);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(54, 13);
            this.Z.TabIndex = 2;
            this.Z.Text = "Current Z:";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Location = new System.Drawing.Point(6, 86);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(54, 13);
            this.Y.TabIndex = 3;
            this.Y.Text = "Current Y:";
            // 
            // LocalPlayerSection
            // 
            this.LocalPlayerSection.Controls.Add(this.PBase);
            this.LocalPlayerSection.Controls.Add(this.X);
            this.LocalPlayerSection.Controls.Add(this.Z);
            this.LocalPlayerSection.Controls.Add(this.Y);
            this.LocalPlayerSection.Location = new System.Drawing.Point(12, 22);
            this.LocalPlayerSection.Name = "LocalPlayerSection";
            this.LocalPlayerSection.Size = new System.Drawing.Size(243, 142);
            this.LocalPlayerSection.TabIndex = 4;
            this.LocalPlayerSection.TabStop = false;
            this.LocalPlayerSection.Text = "Local Player Stuff";
            // 
            // PBase
            // 
            this.PBase.AutoSize = true;
            this.PBase.Location = new System.Drawing.Point(6, 32);
            this.PBase.Name = "PBase";
            this.PBase.Size = new System.Drawing.Size(95, 13);
            this.PBase.TabIndex = 4;
            this.PBase.Text = "Local Player Base:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EPBase);
            this.groupBox1.Controls.Add(this.eX);
            this.groupBox1.Controls.Add(this.eZ);
            this.groupBox1.Controls.Add(this.eY);
            this.groupBox1.Location = new System.Drawing.Point(12, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 142);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Closest Entity";
            // 
            // EPBase
            // 
            this.EPBase.AutoSize = true;
            this.EPBase.Location = new System.Drawing.Point(6, 30);
            this.EPBase.Name = "EPBase";
            this.EPBase.Size = new System.Drawing.Size(95, 13);
            this.EPBase.TabIndex = 4;
            this.EPBase.Text = "Entity Player Base:";
            // 
            // eX
            // 
            this.eX.AutoSize = true;
            this.eX.Location = new System.Drawing.Point(6, 59);
            this.eX.Name = "eX";
            this.eX.Size = new System.Drawing.Size(54, 13);
            this.eX.TabIndex = 0;
            this.eX.Text = "Current X:";
            // 
            // eZ
            // 
            this.eZ.AutoSize = true;
            this.eZ.Location = new System.Drawing.Point(6, 114);
            this.eZ.Name = "eZ";
            this.eZ.Size = new System.Drawing.Size(54, 13);
            this.eZ.TabIndex = 2;
            this.eZ.Text = "Current Z:";
            // 
            // eY
            // 
            this.eY.AutoSize = true;
            this.eY.Location = new System.Drawing.Point(6, 86);
            this.eY.Name = "eY";
            this.eY.Size = new System.Drawing.Size(54, 13);
            this.eY.TabIndex = 3;
            this.eY.Text = "Current Y:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 142);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 101);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(68, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "No Flash";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Triggerbot";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LocalPlayerSection);
            this.Name = "MainWindow";
            this.Text = "aPf ~ ? Main_Window";
            this.LocalPlayerSection.ResumeLayout(false);
            this.LocalPlayerSection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label Y;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox LocalPlayerSection;
        private System.Windows.Forms.Label PBase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label EPBase;
        private System.Windows.Forms.Label eX;
        private System.Windows.Forms.Label eZ;
        private System.Windows.Forms.Label eY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}