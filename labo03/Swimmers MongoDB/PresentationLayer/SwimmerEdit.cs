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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class SwimmerEdit : Form
    {
        private readonly ILogic _logic;
        public Swimmer Swimmer {get; set;}
        public MainForm MainForm { get; set;}
        List<Workout> Workouts;
        public SwimmerEdit(ILogic logic, Swimmer swimmer, MainForm mainform)
        {
            _logic = logic;
            Swimmer = swimmer;
            MainForm = mainform;
            InitializeComponent();
            if (_logic.CheckIfSwimmerExist(Swimmer))
            {
                this.Text = "Swimmer " + Swimmer.ToString();
                this.labelSwimmerName.Text = Swimmer.ToString();
                Workouts = _logic.GetWorkouts(Swimmer);
            }
            else
            {
                this.Text = "New Swimmer";
                this.labelSwimmerName.Text = "New Swimmer";
                Workouts = new List<Workout>();
            }
            FillListBoxWorkouts();
            this.propertyGridSwimmer.SelectedObject = Swimmer;
        }

        private void CancelEditSwimmer(object Sender, EventArgs e)
        {
            if (_logic.CheckIfSwimmerExist(Swimmer))
            {
                Swimmer.Workouts = _logic.GetWorkouts(Swimmer);
            }
            MainForm.Show();
            this.Close();
        }

        private void SaveEditSwimmer(object Sender, EventArgs e)
        {
            if (!_logic.CheckIfSwimmerExist(Swimmer))
            {
                Swimmer newSwimmer = new Swimmer(Swimmer.DateOfBirth, Swimmer.FirstName, Swimmer.LastName, Swimmer.Gender, Swimmer.FinaPoints);
                newSwimmer.Workouts = Swimmer.Workouts;
                _logic.AddSwimmer(newSwimmer);
            }
            else
            {
                _logic.UpdateSwimmer(Swimmer);
            }
            MainForm mainForm = new MainForm(_logic);
            mainForm.Show();
            this.Close();
        }

        public void FillListBoxWorkouts()
        {
            
            listBoxWorkouts.Items.Clear();
            foreach (Workout workout in Workouts)
            {
                listBoxWorkouts.Items.Add(workout.ToString());
            }
        }

        public void RefillListBoxWorkouts()
        {

            listBoxWorkouts.Items.Clear();
            var workouts = Swimmer.Workouts;
            foreach (Workout workout in workouts)
            {
                listBoxWorkouts.Items.Add(workout.ToString());
            }
        }

        private void AddWorkoutToSwimmer(object sender, EventArgs e)
        {

            AddWorkout addWorkout = new AddWorkout(_logic, Swimmer, this, MainForm);
            addWorkout.ShowDialog();
        }

        private void SwimmerEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
