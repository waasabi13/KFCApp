﻿
namespace KFCFront
{
    partial class FrontForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.всёМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бургерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снекиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.напиткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специальныеПредложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(405, 580);
            this.listBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всёМенюToolStripMenuItem,
            this.бургерыToolStripMenuItem,
            this.курицаToolStripMenuItem,
            this.снекиToolStripMenuItem,
            this.напиткиToolStripMenuItem,
            this.специальныеПредложенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1133, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // всёМенюToolStripMenuItem
            // 
            this.всёМенюToolStripMenuItem.Name = "всёМенюToolStripMenuItem";
            this.всёМенюToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.всёМенюToolStripMenuItem.Text = "Всё меню";
            // 
            // бургерыToolStripMenuItem
            // 
            this.бургерыToolStripMenuItem.Name = "бургерыToolStripMenuItem";
            this.бургерыToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.бургерыToolStripMenuItem.Text = "Бургеры";
            // 
            // курицаToolStripMenuItem
            // 
            this.курицаToolStripMenuItem.Name = "курицаToolStripMenuItem";
            this.курицаToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.курицаToolStripMenuItem.Text = "Курица";
            // 
            // снекиToolStripMenuItem
            // 
            this.снекиToolStripMenuItem.Name = "снекиToolStripMenuItem";
            this.снекиToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.снекиToolStripMenuItem.Text = "Снеки";
            // 
            // напиткиToolStripMenuItem
            // 
            this.напиткиToolStripMenuItem.Name = "напиткиToolStripMenuItem";
            this.напиткиToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.напиткиToolStripMenuItem.Text = "Напитки";
            // 
            // специальныеПредложенияToolStripMenuItem
            // 
            this.специальныеПредложенияToolStripMenuItem.Name = "специальныеПредложенияToolStripMenuItem";
            this.специальныеПредложенияToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.специальныеПредложенияToolStripMenuItem.Text = "Специальные предложения";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(411, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 324);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(412, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(709, 253);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(764, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 324);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 624);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrontForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrontForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem всёМенюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бургерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снекиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem напиткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальныеПредложенияToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
