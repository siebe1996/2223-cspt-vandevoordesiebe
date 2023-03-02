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
    public partial class AddSwimmer : Form
    {
        private ILogic _logic;
        public WorkoutEdit WorkoutEdit { get; set; }
        public MainForm MainForm { get; set; }
        public Workout Workout { get; set; }
        public AddSwimmer(ILogic logic, Workout workout, WorkoutEdit workoutEdit, MainForm mainForm)
        {
            _logic = logic;
            WorkoutEdit = workoutEdit;
            MainForm = mainForm;
            Workout = workout;
            InitializeComponent();
            FillComboBoxSwimmers();
        }

        private void CancelSwimmer(object Sender, EventArgs e)
        {
            //Swimmer.Workouts = _logic.GetWorkouts();
            this.Close();
        }

        private void SaveSwimmer(object Sender, EventArgs e)
        {
            var swimmers = _logic.GetSwimmers();
            int index = comboBoxSwimmers.SelectedIndex;
            Workout.Swimmers.Add(swimmers[index]);
            //_logic.AddWorkoutToSwimmerDb(Swimmer);
            WorkoutEdit.FillListBoxSwimmers();
            //SwimmerEdit swimmerEdit = new SwimmerEdit(_logic, Swimmer, MainForm);
            this.Close();
        }

        public void FillComboBoxSwimmers()
        {
            var swimmers = _logic.GetSwimmers();
            foreach (Swimmer swimmer in swimmers)
            {
                comboBoxSwimmers.Items.Add(swimmer.ToString());
            }
        }
    }
}
