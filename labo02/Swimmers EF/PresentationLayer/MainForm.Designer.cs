namespace PresentationLayer
{
    partial class MainForm
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
            this.groupBoxSwimmers = new System.Windows.Forms.GroupBox();
            this.dataGridViewWorkoutsSwimmer = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCoach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddSwimmer = new System.Windows.Forms.Button();
            this.buttonEditSwimmer = new System.Windows.Forms.Button();
            this.comboBoxSwimmers = new System.Windows.Forms.ComboBox();
            this.groupBoxWorkouts = new System.Windows.Forms.GroupBox();
            this.buttonEditWorkout = new System.Windows.Forms.Button();
            this.buttonAddWorkout = new System.Windows.Forms.Button();
            this.listBoxWorkouts = new System.Windows.Forms.ListBox();
            this.buttonAddWorkoutToSwimmer = new System.Windows.Forms.Button();
            this.groupBoxSwimmers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkoutsSwimmer)).BeginInit();
            this.groupBoxWorkouts.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSwimmers
            // 
            this.groupBoxSwimmers.Controls.Add(this.dataGridViewWorkoutsSwimmer);
            this.groupBoxSwimmers.Controls.Add(this.label1);
            this.groupBoxSwimmers.Controls.Add(this.buttonAddSwimmer);
            this.groupBoxSwimmers.Controls.Add(this.buttonEditSwimmer);
            this.groupBoxSwimmers.Controls.Add(this.comboBoxSwimmers);
            this.groupBoxSwimmers.Location = new System.Drawing.Point(13, 18);
            this.groupBoxSwimmers.Name = "groupBoxSwimmers";
            this.groupBoxSwimmers.Size = new System.Drawing.Size(468, 464);
            this.groupBoxSwimmers.TabIndex = 0;
            this.groupBoxSwimmers.TabStop = false;
            this.groupBoxSwimmers.Text = "Manage Swimmers";
            this.groupBoxSwimmers.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridViewWorkoutsSwimmer
            // 
            this.dataGridViewWorkoutsSwimmer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkoutsSwimmer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnType,
            this.ColumnCoach,
            this.ColumnSchedule});
            this.dataGridViewWorkoutsSwimmer.Location = new System.Drawing.Point(14, 130);
            this.dataGridViewWorkoutsSwimmer.Name = "dataGridViewWorkoutsSwimmer";
            this.dataGridViewWorkoutsSwimmer.RowHeadersVisible = false;
            this.dataGridViewWorkoutsSwimmer.RowHeadersWidth = 51;
            this.dataGridViewWorkoutsSwimmer.RowTemplate.Height = 29;
            this.dataGridViewWorkoutsSwimmer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewWorkoutsSwimmer.Size = new System.Drawing.Size(433, 316);
            this.dataGridViewWorkoutsSwimmer.TabIndex = 4;
            this.dataGridViewWorkoutsSwimmer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.MinimumWidth = 6;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Width = 35;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.MinimumWidth = 6;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Width = 140;
            // 
            // ColumnCoach
            // 
            this.ColumnCoach.HeaderText = "Coach";
            this.ColumnCoach.MinimumWidth = 6;
            this.ColumnCoach.Name = "ColumnCoach";
            this.ColumnCoach.Width = 140;
            // 
            // ColumnSchedule
            // 
            this.ColumnSchedule.HeaderText = "Schedule";
            this.ColumnSchedule.MinimumWidth = 6;
            this.ColumnSchedule.Name = "ColumnSchedule";
            this.ColumnSchedule.Width = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // buttonAddSwimmer
            // 
            this.buttonAddSwimmer.Location = new System.Drawing.Point(322, 39);
            this.buttonAddSwimmer.Name = "buttonAddSwimmer";
            this.buttonAddSwimmer.Size = new System.Drawing.Size(31, 28);
            this.buttonAddSwimmer.TabIndex = 2;
            this.buttonAddSwimmer.Text = "+";
            this.buttonAddSwimmer.UseVisualStyleBackColor = true;
            this.buttonAddSwimmer.Click += new System.EventHandler(this.AddSwimmer);
            // 
            // buttonEditSwimmer
            // 
            this.buttonEditSwimmer.Location = new System.Drawing.Point(285, 39);
            this.buttonEditSwimmer.Name = "buttonEditSwimmer";
            this.buttonEditSwimmer.Size = new System.Drawing.Size(31, 28);
            this.buttonEditSwimmer.TabIndex = 1;
            this.buttonEditSwimmer.Text = "e";
            this.buttonEditSwimmer.UseVisualStyleBackColor = true;
            this.buttonEditSwimmer.Click += new System.EventHandler(this.EditSwimmer);
            // 
            // comboBoxSwimmers
            // 
            this.comboBoxSwimmers.FormattingEnabled = true;
            this.comboBoxSwimmers.Location = new System.Drawing.Point(15, 40);
            this.comboBoxSwimmers.Name = "comboBoxSwimmers";
            this.comboBoxSwimmers.Size = new System.Drawing.Size(264, 28);
            this.comboBoxSwimmers.TabIndex = 0;
            this.comboBoxSwimmers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSwimmersSelectedIndexChanged);
            // 
            // groupBoxWorkouts
            // 
            this.groupBoxWorkouts.Controls.Add(this.buttonEditWorkout);
            this.groupBoxWorkouts.Controls.Add(this.buttonAddWorkout);
            this.groupBoxWorkouts.Controls.Add(this.listBoxWorkouts);
            this.groupBoxWorkouts.Location = new System.Drawing.Point(549, 18);
            this.groupBoxWorkouts.Name = "groupBoxWorkouts";
            this.groupBoxWorkouts.Size = new System.Drawing.Size(416, 464);
            this.groupBoxWorkouts.TabIndex = 1;
            this.groupBoxWorkouts.TabStop = false;
            this.groupBoxWorkouts.Text = "Manage Workouts";
            // 
            // buttonEditWorkout
            // 
            this.buttonEditWorkout.Location = new System.Drawing.Point(379, 74);
            this.buttonEditWorkout.Name = "buttonEditWorkout";
            this.buttonEditWorkout.Size = new System.Drawing.Size(31, 28);
            this.buttonEditWorkout.TabIndex = 4;
            this.buttonEditWorkout.Text = "e";
            this.buttonEditWorkout.UseVisualStyleBackColor = true;
            this.buttonEditWorkout.Click += new System.EventHandler(this.EditWorkout);
            // 
            // buttonAddWorkout
            // 
            this.buttonAddWorkout.Location = new System.Drawing.Point(379, 40);
            this.buttonAddWorkout.Name = "buttonAddWorkout";
            this.buttonAddWorkout.Size = new System.Drawing.Size(31, 28);
            this.buttonAddWorkout.TabIndex = 3;
            this.buttonAddWorkout.Text = "+";
            this.buttonAddWorkout.UseVisualStyleBackColor = true;
            this.buttonAddWorkout.Click += new System.EventHandler(this.AddWorkout);
            // 
            // listBoxWorkouts
            // 
            this.listBoxWorkouts.FormattingEnabled = true;
            this.listBoxWorkouts.ItemHeight = 20;
            this.listBoxWorkouts.Location = new System.Drawing.Point(17, 39);
            this.listBoxWorkouts.Name = "listBoxWorkouts";
            this.listBoxWorkouts.Size = new System.Drawing.Size(357, 404);
            this.listBoxWorkouts.TabIndex = 0;
            // 
            // buttonAddWorkoutToSwimmer
            // 
            this.buttonAddWorkoutToSwimmer.Location = new System.Drawing.Point(501, 204);
            this.buttonAddWorkoutToSwimmer.Name = "buttonAddWorkoutToSwimmer";
            this.buttonAddWorkoutToSwimmer.Size = new System.Drawing.Size(31, 28);
            this.buttonAddWorkoutToSwimmer.TabIndex = 3;
            this.buttonAddWorkoutToSwimmer.Text = "<";
            this.buttonAddWorkoutToSwimmer.UseVisualStyleBackColor = true;
            this.buttonAddWorkoutToSwimmer.Click += new System.EventHandler(this.AddWorkoutToSwimmer);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 494);
            this.Controls.Add(this.buttonAddWorkoutToSwimmer);
            this.Controls.Add(this.groupBoxWorkouts);
            this.Controls.Add(this.groupBoxSwimmers);
            this.Name = "MainForm";
            this.Text = "Swimmers gui EF";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxSwimmers.ResumeLayout(false);
            this.groupBoxSwimmers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkoutsSwimmer)).EndInit();
            this.groupBoxWorkouts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxSwimmers;
        private GroupBox groupBoxWorkouts;
        private ComboBox comboBoxSwimmers;
        private Button buttonAddSwimmer;
        private Button buttonEditSwimmer;
        private Label label1;
        private DataGridView dataGridViewWorkoutsSwimmer;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnType;
        private DataGridViewTextBoxColumn ColumnCoach;
        private DataGridViewTextBoxColumn ColumnSchedule;
        private ListBox listBoxWorkouts;
        private Button buttonAddWorkoutToSwimmer;
        private Button buttonAddWorkout;
        private Button buttonEditWorkout;
    }
}