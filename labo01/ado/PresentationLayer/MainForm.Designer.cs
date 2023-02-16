namespace PresentationLayer
{
    partial class MainFormSwimmers
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
            this.groupBoxCoaches = new System.Windows.Forms.GroupBox();
            this.comboBoxCoaches = new System.Windows.Forms.ComboBox();
            this.labelCoaches = new System.Windows.Forms.Label();
            this.listBoxCoaches = new System.Windows.Forms.ListBox();
            this.groupBoxSwimmers = new System.Windows.Forms.GroupBox();
            this.listBoxSwimmers = new System.Windows.Forms.ListBox();
            this.labelSwimmers = new System.Windows.Forms.Label();
            this.comboBoxSwimmers = new System.Windows.Forms.ComboBox();
            this.groupBoxCoaches.SuspendLayout();
            this.groupBoxSwimmers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCoaches
            // 
            this.groupBoxCoaches.Controls.Add(this.listBoxCoaches);
            this.groupBoxCoaches.Controls.Add(this.labelCoaches);
            this.groupBoxCoaches.Controls.Add(this.comboBoxCoaches);
            this.groupBoxCoaches.Location = new System.Drawing.Point(23, 47);
            this.groupBoxCoaches.Name = "groupBoxCoaches";
            this.groupBoxCoaches.Size = new System.Drawing.Size(346, 349);
            this.groupBoxCoaches.TabIndex = 0;
            this.groupBoxCoaches.TabStop = false;
            this.groupBoxCoaches.Text = "Coaches";
            //this.groupBoxCoaches.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // comboBoxCoaches
            // 
            this.comboBoxCoaches.FormattingEnabled = true;
            this.comboBoxCoaches.Location = new System.Drawing.Point(21, 59);
            this.comboBoxCoaches.Name = "comboBoxCoaches";
            this.comboBoxCoaches.Size = new System.Drawing.Size(297, 28);
            this.comboBoxCoaches.TabIndex = 0;
            this.comboBoxCoaches.SelectedIndexChanged += new System.EventHandler(this.comboBoxCoachesSelectedIndexChanged);
            // 
            // labelCoaches
            // 
            this.labelCoaches.AutoSize = true;
            this.labelCoaches.Location = new System.Drawing.Point(21, 136);
            this.labelCoaches.Name = "labelCoaches";
            this.labelCoaches.Size = new System.Drawing.Size(74, 20);
            this.labelCoaches.TabIndex = 1;
            this.labelCoaches.Text = "Workouts:";
            //this.labelCoaches.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxCoaches
            // 
            this.listBoxCoaches.FormattingEnabled = true;
            this.listBoxCoaches.ItemHeight = 20;
            this.listBoxCoaches.Location = new System.Drawing.Point(21, 182);
            this.listBoxCoaches.Name = "listBoxCoaches";
            this.listBoxCoaches.Size = new System.Drawing.Size(297, 104);
            this.listBoxCoaches.TabIndex = 2;
            // 
            // groupBoxSwimmers
            // 
            this.groupBoxSwimmers.Controls.Add(this.listBoxSwimmers);
            this.groupBoxSwimmers.Controls.Add(this.labelSwimmers);
            this.groupBoxSwimmers.Controls.Add(this.comboBoxSwimmers);
            this.groupBoxSwimmers.Location = new System.Drawing.Point(424, 47);
            this.groupBoxSwimmers.Name = "groupBoxSwimmers";
            this.groupBoxSwimmers.Size = new System.Drawing.Size(346, 349);
            this.groupBoxSwimmers.TabIndex = 1;
            this.groupBoxSwimmers.TabStop = false;
            this.groupBoxSwimmers.Text = "Swimmers";
            // 
            // listBoxSwimmers
            // 
            this.listBoxSwimmers.FormattingEnabled = true;
            this.listBoxSwimmers.ItemHeight = 20;
            this.listBoxSwimmers.Location = new System.Drawing.Point(21, 182);
            this.listBoxSwimmers.Name = "listBoxSwimmers";
            this.listBoxSwimmers.Size = new System.Drawing.Size(297, 104);
            this.listBoxSwimmers.TabIndex = 2;
            // 
            // labelSwimmers
            // 
            this.labelSwimmers.AutoSize = true;
            this.labelSwimmers.Location = new System.Drawing.Point(21, 136);
            this.labelSwimmers.Name = "labelSwimmers";
            this.labelSwimmers.Size = new System.Drawing.Size(74, 20);
            this.labelSwimmers.TabIndex = 1;
            this.labelSwimmers.Text = "Workouts:";
            // 
            // comboBoxSwimmers
            // 
            this.comboBoxSwimmers.FormattingEnabled = true;
            this.comboBoxSwimmers.Location = new System.Drawing.Point(21, 59);
            this.comboBoxSwimmers.Name = "comboBoxSwimmers";
            this.comboBoxSwimmers.Size = new System.Drawing.Size(297, 28);
            this.comboBoxSwimmers.TabIndex = 0;
            this.comboBoxSwimmers.SelectedIndexChanged += new System.EventHandler(this.comboBoxSwimmersSelectedIndexChanged);

            // 
            // MainFormSwimmers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxSwimmers);
            this.Controls.Add(this.groupBoxCoaches);
            this.Name = "MainFormSwimmers";
            this.Text = "Swimmers";
            this.groupBoxCoaches.ResumeLayout(false);
            this.groupBoxCoaches.PerformLayout();
            this.groupBoxSwimmers.ResumeLayout(false);
            this.groupBoxSwimmers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxCoaches;
        private ComboBox comboBoxCoaches;
        private Label labelCoaches;
        private ListBox listBoxCoaches;
        private GroupBox groupBoxSwimmers;
        private ListBox listBoxSwimmers;
        private Label labelSwimmers;
        private ComboBox comboBoxSwimmers;
    }
}