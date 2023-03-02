using Globals.Entities;

namespace PresentationLayer
{
    partial class WorkoutEdit
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
            Globals.Entities.Workout workout2 = new Globals.Entities.Workout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkoutEdit));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBoxSwimmers = new System.Windows.Forms.ListBox();
            this.buttonAddSwimmerToWorkout = new System.Windows.Forms.Button();
            this.comboBoxCoaches = new System.Windows.Forms.ComboBox();
            this.comboBoxSwimmingPools = new System.Windows.Forms.ComboBox();
            this.labelCoach = new System.Windows.Forms.Label();
            this.labelSwimmingPool = new System.Windows.Forms.Label();
            this.buttonRemoveSwimmerFromWorkout = new System.Windows.Forms.Button();
            this.propertyGridWorkout = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(131, 404);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 34);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.CancelEditWorkout);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(232, 404);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 34);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Ok";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveEditWorkout);
            // 
            // listBoxSwimmers
            // 
            this.listBoxSwimmers.FormattingEnabled = true;
            this.listBoxSwimmers.ItemHeight = 20;
            this.listBoxSwimmers.Location = new System.Drawing.Point(349, 45);
            this.listBoxSwimmers.Name = "listBoxSwimmers";
            this.listBoxSwimmers.Size = new System.Drawing.Size(404, 384);
            this.listBoxSwimmers.TabIndex = 4;
            // 
            // buttonAddSwimmerToWorkout
            // 
            this.buttonAddSwimmerToWorkout.Location = new System.Drawing.Point(759, 45);
            this.buttonAddSwimmerToWorkout.Name = "buttonAddSwimmerToWorkout";
            this.buttonAddSwimmerToWorkout.Size = new System.Drawing.Size(31, 28);
            this.buttonAddSwimmerToWorkout.TabIndex = 5;
            this.buttonAddSwimmerToWorkout.Text = "+";
            this.buttonAddSwimmerToWorkout.UseVisualStyleBackColor = true;
            this.buttonAddSwimmerToWorkout.Click += new System.EventHandler(this.AddSwimmerToWorkout);
            // 
            // comboBoxCoaches
            // 
            this.comboBoxCoaches.FormattingEnabled = true;
            this.comboBoxCoaches.Location = new System.Drawing.Point(36, 311);
            this.comboBoxCoaches.Name = "comboBoxCoaches";
            this.comboBoxCoaches.Size = new System.Drawing.Size(287, 28);
            this.comboBoxCoaches.TabIndex = 6;
            this.comboBoxCoaches.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCoachesSelectedIndexChanged);
            // 
            // comboBoxSwimmingPools
            // 
            this.comboBoxSwimmingPools.FormattingEnabled = true;
            this.comboBoxSwimmingPools.Location = new System.Drawing.Point(37, 370);
            this.comboBoxSwimmingPools.Name = "comboBoxSwimmingPools";
            this.comboBoxSwimmingPools.Size = new System.Drawing.Size(287, 28);
            this.comboBoxSwimmingPools.TabIndex = 7;
            this.comboBoxSwimmingPools.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSwimmingPoolsSelectedIndexChanged);
            // 
            // labelCoach
            // 
            this.labelCoach.AutoSize = true;
            this.labelCoach.Location = new System.Drawing.Point(35, 288);
            this.labelCoach.Name = "labelCoach";
            this.labelCoach.Size = new System.Drawing.Size(53, 20);
            this.labelCoach.TabIndex = 8;
            this.labelCoach.Text = "Coach:";
            // 
            // labelSwimmingPool
            // 
            this.labelSwimmingPool.AutoSize = true;
            this.labelSwimmingPool.Location = new System.Drawing.Point(37, 347);
            this.labelSwimmingPool.Name = "labelSwimmingPool";
            this.labelSwimmingPool.Size = new System.Drawing.Size(111, 20);
            this.labelSwimmingPool.TabIndex = 9;
            this.labelSwimmingPool.Text = "SwimmingPool:";
            // 
            // buttonRemoveSwimmerFromWorkout
            // 
            this.buttonRemoveSwimmerFromWorkout.Location = new System.Drawing.Point(759, 79);
            this.buttonRemoveSwimmerFromWorkout.Name = "buttonRemoveSwimmerFromWorkout";
            this.buttonRemoveSwimmerFromWorkout.Size = new System.Drawing.Size(31, 28);
            this.buttonRemoveSwimmerFromWorkout.TabIndex = 10;
            this.buttonRemoveSwimmerFromWorkout.Text = "-";
            this.buttonRemoveSwimmerFromWorkout.UseVisualStyleBackColor = true;
            this.buttonRemoveSwimmerFromWorkout.Click += new System.EventHandler(this.RemoveSwimmerFromWorkout);
            // 
            // propertyGridWorkout
            // 
            this.propertyGridWorkout.AllowDrop = true;
            this.propertyGridWorkout.Location = new System.Drawing.Point(37, 12);
            this.propertyGridWorkout.Name = "propertyGridWorkout";
            this.propertyGridWorkout.SelectedObject = new Workout();
            this.propertyGridWorkout.Size = new System.Drawing.Size(286, 273);
            this.propertyGridWorkout.TabIndex = 11;
            this.propertyGridWorkout.SelectedObject = Workout;
            // 
            // WorkoutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.propertyGridWorkout);
            this.Controls.Add(this.buttonRemoveSwimmerFromWorkout);
            this.Controls.Add(this.labelSwimmingPool);
            this.Controls.Add(this.labelCoach);
            this.Controls.Add(this.comboBoxSwimmingPools);
            this.Controls.Add(this.comboBoxCoaches);
            this.Controls.Add(this.buttonAddSwimmerToWorkout);
            this.Controls.Add(this.listBoxSwimmers);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "WorkoutEdit";
            this.Text = "SwimmerEdit";
            this.Load += new System.EventHandler(this.WorkoutEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonCancel;
        private Button buttonSave;
        private ListBox listBoxSwimmers;
        private Button buttonAddSwimmerToWorkout;
        private ComboBox comboBoxCoaches;
        private ComboBox comboBoxSwimmingPools;
        private Label labelCoach;
        private Label labelSwimmingPool;
        private Button buttonRemoveSwimmerFromWorkout;
        private PropertyGrid propertyGridWorkout;
    }
}