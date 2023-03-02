using Globals.Entities;
using Globals.Interfaces;
using System;
using System.Collections;
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
    public partial class WorkoutEdit : Form
    {
        private readonly ILogic _logic;
        public Workout Workout { get; set; }
        public MainForm MainForm { get; set; }
        public WorkoutEdit(ILogic logic, Workout workout, MainForm mainform)
        {
            _logic = logic;
            Workout = workout;
            MainForm = mainform;
            InitializeComponent();
            FillListBoxSwimmers();
            FillComboBoxCoaches();
            FillComboBoxSwimmingPools();
        }

        private void CancelEditWorkout(object Sender, EventArgs e)
        {
            //Swimmer.Workouts = _logic.GetWorkouts(Swimmer);
            Workout.Swimmers = _logic.GetSwimmers(Workout);
            //Workout = _logic.GetWorkout(Workout.Id);
            MainForm.Show();
            this.Close();
        }

        private void SaveEditWorkout(object Sender, EventArgs e)
        {
            if (!_logic.CheckIfWorkoutExist(Workout))
            {
                Workout newWorkout = new Workout(Workout.Duration, Workout.Schedule, Workout.SwimmingPool, Workout.Type);
                _logic.AddWorkout(newWorkout, Workout.Coach);
            }
            else
            {
                _logic.UpdateWorkout(Workout);
            }
            MainForm mainForm = new MainForm(_logic);
            mainForm.Show();
            this.Close();
        }

        public void FillListBoxSwimmers()
        {

            listBoxSwimmers.Items.Clear();
            var swimmers = Workout.Swimmers;
            foreach (Swimmer swimmer in swimmers)
            {
                listBoxSwimmers.Items.Add(swimmer.ToString());
            }
        }

        public void FillComboBoxCoaches()
        {
            var coaches = _logic.GetCoaches();
            foreach (Coach coach in coaches)
            {
                comboBoxCoaches.Items.Add(coach.ToString());
            }
            if (_logic.CheckIfWorkoutExist(Workout))
            {
                comboBoxCoaches.SelectedIndex = comboBoxCoaches.FindStringExact(Workout.Coach.ToString());
            }
        }

        public void FillComboBoxSwimmingPools()
        {
            var swimmingPools = _logic.GetSwimmingPools();
            foreach (SwimmingPool swimmingPool  in swimmingPools)
            {
                comboBoxSwimmingPools.Items.Add(swimmingPool.ToString());
            }
            if (_logic.CheckIfWorkoutExist(Workout))
            {
                comboBoxSwimmingPools.SelectedIndex = comboBoxSwimmingPools.FindStringExact(Workout.SwimmingPool.ToString());
            }
        }

        private void ComboBoxCoachesSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBoxCoaches.SelectedIndex;
            Workout.Coach = _logic.GetCoaches()[id];
            propertyGridWorkout.Refresh();
        }

        private void ComboBoxSwimmingPoolsSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBoxSwimmingPools.SelectedIndex;
            Workout.SwimmingPool = _logic.GetSwimmingPools()[id];
            propertyGridWorkout.Refresh();
        }

        private void AddSwimmerToWorkout(object Sender, EventArgs e)
        {
            AddSwimmer addSwimmer = new AddSwimmer(_logic, Workout, this, MainForm);
            addSwimmer.ShowDialog();
        }

        private void RemoveSwimmerFromWorkout(object Sender, EventArgs e)
        {
            int index = listBoxSwimmers.SelectedIndex;
            //var swimmer = Workout.Swimmers[index];
            Workout.Swimmers.RemoveAt(index);
            FillListBoxSwimmers();
            
        }

        private void WorkoutEdit_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
