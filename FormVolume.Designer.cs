﻿namespace LTIOpenstackProject
{
    partial class FormVolume
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateVolume = new System.Windows.Forms.Button();
            this.buttonRemoveVol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(22, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 292);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Volumes:";
            // 
            // buttonCreateVolume
            // 
            this.buttonCreateVolume.Location = new System.Drawing.Point(344, 44);
            this.buttonCreateVolume.Name = "buttonCreateVolume";
            this.buttonCreateVolume.Size = new System.Drawing.Size(106, 31);
            this.buttonCreateVolume.TabIndex = 2;
            this.buttonCreateVolume.Text = "Criar Volume";
            this.buttonCreateVolume.UseVisualStyleBackColor = true;
            this.buttonCreateVolume.Click += new System.EventHandler(this.buttonCreateVolume_Click);
            // 
            // buttonRemoveVol
            // 
            this.buttonRemoveVol.Location = new System.Drawing.Point(344, 118);
            this.buttonRemoveVol.Name = "buttonRemoveVol";
            this.buttonRemoveVol.Size = new System.Drawing.Size(106, 31);
            this.buttonRemoveVol.TabIndex = 3;
            this.buttonRemoveVol.Text = "Remover Volume";
            this.buttonRemoveVol.UseVisualStyleBackColor = true;
            this.buttonRemoveVol.Click += new System.EventHandler(this.buttonRemoveVol_Click);
            // 
            // FormVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRemoveVol);
            this.Controls.Add(this.buttonCreateVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "FormVolume";
            this.Text = "FormVolume";
            this.Load += new System.EventHandler(this.FormVolume_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateVolume;
        private System.Windows.Forms.Button buttonRemoveVol;
    }
}