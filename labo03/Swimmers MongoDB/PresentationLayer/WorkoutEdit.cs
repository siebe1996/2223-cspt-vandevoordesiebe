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
            FillComboBoxCoaches();
            FillComboBoxSwimmingPools();
            if (_logic.CheckIfWorkoutExist(Workout))
            {
                this.Text = "Workout " + Workout.ToString();
            }
            else
            {
                this.Text = "New Workout";
            }
            this.propertyGridWorkout.SelectedObject = Workout;
        }

        private void CancelEditWorkout(object Sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }

        private void SaveEditWorkout(object Sender, EventArgs e)
        {
            if (!_logic.CheckIfWorkoutExist(Workout))
            {
                if(Workout.Coach != null && Workout.SwimmingPool != null)
                {
                    Workout newWorkout = new Workout(Workout.Coach, Workout.Duration, Workout.Schedule, Workout.SwimmingPool, Workout.Type);
                    _logic.AddWorkout(newWorkout);
                    MainForm mainForm = new MainForm(_logic);
                    mainForm.Show();
                    this.Close();
                }
            }
            else
            {
                _logic.UpdateWorkout(Workout);
                MainForm mainForm = new MainForm(_logic);
                mainForm.Show();
                this.Close();
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
            else
            {
                comboBoxCoaches.SelectedIndex = 0;
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
            else
            {
                comboBoxSwimmingPools.SelectedIndex = 0;
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

        private void WorkoutEdit_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
