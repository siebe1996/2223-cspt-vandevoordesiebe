using Globals.Entities;
using Globals.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AddWorkout : Form
    {
        private ILogic _logic;
        public SwimmerEdit SwimmerEdit { get; set; }
        public MainForm MainForm { get; set; }
        public Swimmer Swimmer { get; set; }
        public AddWorkout(ILogic logic, Swimmer swimmer, SwimmerEdit swimmerEdit, MainForm mainForm)
        {
            _logic = logic;
            SwimmerEdit = swimmerEdit;
            MainForm = mainForm;
            Swimmer = swimmer;
            InitializeComponent();
            FillComboBoxWorkouts();
        }

        private void CancelWorkout(object Sender, EventArgs e)
        {
            //Swimmer.Workouts = _logic.GetWorkouts();
            this.Close();
        }

        private void SaveWorkout(object Sender, EventArgs e)
        {
            var workouts = _logic.GetWorkouts();
            int workoutId = comboBoxWorkouts.SelectedIndex;
            Swimmer.Workouts.Add(workouts[workoutId]);
            //_logic.AddWorkoutToSwimmerDb(Swimmer);
            SwimmerEdit.RefillListBoxWorkouts();
            //SwimmerEdit swimmerEdit = new SwimmerEdit(_logic, Swimmer, MainForm);
            this.Close();
        }

        public void FillComboBoxWorkouts()
        {
            var workouts = _logic.GetWorkouts();
            foreach (Workout workout in workouts)
            {
                comboBoxWorkouts.Items.Add(workout.ToString());
            }
        }
    }
}
