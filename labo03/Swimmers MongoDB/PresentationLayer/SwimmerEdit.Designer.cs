﻿using Globals.Entities;
using Globals.Interfaces;
namespace PresentationLayer
{
    partial class SwimmerEdit
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
            Globals.Entities.Swimmer swimmer1 = new Globals.Entities.Swimmer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwimmerEdit));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBoxWorkouts = new System.Windows.Forms.ListBox();
            this.buttonAddWorkoutToSwimmer = new System.Windows.Forms.Button();
            this.propertyGridSwimmer = new System.Windows.Forms.PropertyGrid();
            this.labelSwimmerName = new System.Windows.Forms.Label();
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
            this.buttonCancel.Click += new System.EventHandler(this.CancelEditSwimmer);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(232, 404);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 34);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveEditSwimmer);
            // 
            // listBoxWorkouts
            // 
            this.listBoxWorkouts.FormattingEnabled = true;
            this.listBoxWorkouts.ItemHeight = 20;
            this.listBoxWorkouts.Location = new System.Drawing.Point(349, 45);
            this.listBoxWorkouts.Name = "listBoxWorkouts";
            this.listBoxWorkouts.Size = new System.Drawing.Size(404, 384);
            this.listBoxWorkouts.TabIndex = 4;
            // 
            // buttonAddWorkoutToSwimmer
            // 
            this.buttonAddWorkoutToSwimmer.Location = new System.Drawing.Point(759, 45);
            this.buttonAddWorkoutToSwimmer.Name = "buttonAddWorkoutToSwimmer";
            this.buttonAddWorkoutToSwimmer.Size = new System.Drawing.Size(31, 28);
            this.buttonAddWorkoutToSwimmer.TabIndex = 5;
            this.buttonAddWorkoutToSwimmer.Text = "+";
            this.buttonAddWorkoutToSwimmer.UseVisualStyleBackColor = true;
            this.buttonAddWorkoutToSwimmer.Click += new System.EventHandler(this.AddWorkoutToSwimmer);
            // 
            // propertyGridSwimmer
            // 
            this.propertyGridSwimmer.AllowDrop = true;
            this.propertyGridSwimmer.Location = new System.Drawing.Point(23, 95);
            this.propertyGridSwimmer.Name = "propertyGridSwimmer";
            swimmer1.DateOfBirth = new System.DateTime(((long)(0)));
            swimmer1.FinaPoints = 0;
            swimmer1.FirstName = null;
            swimmer1.Gender = '\0';
            swimmer1.Id = null;
            swimmer1.LastName = null;
            this.propertyGridSwimmer.SelectedObject = swimmer1;
            this.propertyGridSwimmer.Size = new System.Drawing.Size(299, 302);
            this.propertyGridSwimmer.TabIndex = 7;
            // 
            // labelSwimmerName
            // 
            this.labelSwimmerName.AutoSize = true;
            this.labelSwimmerName.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSwimmerName.Location = new System.Drawing.Point(24, 42);
            this.labelSwimmerName.Name = "labelSwimmerName";
            this.labelSwimmerName.Size = new System.Drawing.Size(311, 57);
            this.labelSwimmerName.TabIndex = 8;
            this.labelSwimmerName.Text = "New Swimmer";
            // 
            // SwimmerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSwimmerName);
            this.Controls.Add(this.propertyGridSwimmer);
            this.Controls.Add(this.buttonAddWorkoutToSwimmer);
            this.Controls.Add(this.listBoxWorkouts);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "SwimmerEdit";
            this.Load += new System.EventHandler(this.SwimmerEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelSwimmerName;
        private Button buttonCancel;
        private Button buttonSave;
        private ListBox listBoxWorkouts;
        private Button buttonAddWorkoutToSwimmer;
        private PropertyGrid propertyGridSwimmer;
        private Label label1;
    }
}