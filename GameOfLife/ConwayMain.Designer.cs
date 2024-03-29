﻿namespace GameOfLife
{
    partial class ConwayMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConwayMain));
            label1 = new Label();
            resetButton = new Button();
            goButton = new Button();
            advanceButton = new Button();
            pbGrid = new PictureBox();
            numsSize = new NumericUpDown();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numsSize).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // resetButton
            // 
            resources.ApplyResources(resetButton, "resetButton");
            resetButton.Name = "resetButton";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // goButton
            // 
            resources.ApplyResources(goButton, "goButton");
            goButton.Name = "goButton";
            goButton.UseVisualStyleBackColor = true;
            goButton.Click += goButton_Click;
            // 
            // advanceButton
            // 
            resources.ApplyResources(advanceButton, "advanceButton");
            advanceButton.Name = "advanceButton";
            advanceButton.UseVisualStyleBackColor = true;
            advanceButton.Click += advanceButton_Click;
            // 
            // pbGrid
            // 
            resources.ApplyResources(pbGrid, "pbGrid");
            pbGrid.Name = "pbGrid";
            pbGrid.TabStop = false;
            // 
            // numsSize
            // 
            resources.ApplyResources(numsSize, "numsSize");
            numsSize.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numsSize.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numsSize.Name = "numsSize";
            numsSize.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.Name = "comboBox1";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            resources.ApplyResources(comboBox2, "comboBox2");
            comboBox2.Name = "comboBox2";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // ConwayMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(numsSize);
            Controls.Add(pbGrid);
            Controls.Add(advanceButton);
            Controls.Add(goButton);
            Controls.Add(resetButton);
            Controls.Add(label1);
            Name = "ConwayMain";
            FormClosing += ConwayMain_FormClosing;
            Load += ConWayMain_Load;
            ((System.ComponentModel.ISupportInitialize)pbGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numsSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button resetButton;
        private Button goButton;
        private Button advanceButton;
        private PictureBox pbGrid;
        private NumericUpDown numsSize;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}
