using Globals.Entities;
using Globals.Interfaces;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        private readonly ILogic _logic;
        private List<Swimmer> swimmers;
        private List<Workout> workouts;
        public MainForm(ILogic logic)
        {
            _logic = logic;
            InitializeComponent();
            swimmers = _logic.GetSwimmers();
            swimmers.Sort();
            FillComboBoxSwimmers(swimmers);
            workouts= _logic.GetWorkouts();
            workouts.Sort();
            FillListBoxWorkouts(workouts);
        }

        public void FillComboBoxSwimmers(List<Swimmer> swimmers)
        {
            foreach (Swimmer swimmer in swimmers)
            {
                comboBoxSwimmers.Items.Add(swimmer.ToString());
            }
        }

        private void ComboBoxSwimmersSelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewWorkoutsSwimmer.Rows.Clear();
            int id = comboBoxSwimmers.SelectedIndex;
            List<Workout> workoutsSwimmer = _logic.GetWorkouts(swimmers[id]);
            workoutsSwimmer.Sort();
            foreach(Workout workout in workoutsSwimmer)
            {
                string[] row = new string[] { workout.Id.ToString(), workout.Type.ToString(), workout.Coach.ToString(), workout.Schedule.ToString() };
                dataGridViewWorkoutsSwimmer.Rows.Add(row);
            }
        }

        private void FillListBoxWorkouts(List<Workout> workouts)
        {
            listBoxWorkouts.Items.Clear();
            foreach (Workout workout in workouts)
            {
                listBoxWorkouts.Items.Add(workout.ToString());
            }
        }

        private void AddWorkoutToSwimmer(object sender, EventArgs e)
        {
            dataGridViewWorkoutsSwimmer.Rows.Clear();
            int newWorkoutId = listBoxWorkouts.SelectedIndex;
            int swimmerId = comboBoxSwimmers.SelectedIndex;
            swimmers[swimmerId].Workouts.Add(workouts[newWorkoutId]);
            _logic.UpdateSwimmer(swimmers[swimmerId]);
            List<Workout> workoutsSwimmer = _logic.GetWorkouts(swimmers[swimmerId]);
            workoutsSwimmer.Sort();
            foreach (Workout workout in workoutsSwimmer)
            {
                string[] row = new string[] { workout.Id.ToString(), workout.Type.ToString(), workout.Coach.ToString(), workout.Schedule.ToString() };
                dataGridViewWorkoutsSwimmer.Rows.Add(row);
            }

        }

        private void AddSwimmer(object Sender, EventArgs e) 
        {
            SwimmerEdit swimmerEdit = new SwimmerEdit(_logic, new Swimmer(), this);
            swimmerEdit.Show();
            this.Hide();
        }

        private void EditSwimmer(object Sender, EventArgs e)
        {

            int swimmerId = comboBoxSwimmers.SelectedIndex;
            var swimmer = swimmers[swimmerId];
            SwimmerEdit swimmerEdit = new SwimmerEdit(_logic, swimmer, this);
            swimmerEdit.Show();
            this.Hide();
        }

        private void AddWorkout(object Sender, EventArgs e)
        {
            WorkoutEdit workout = new WorkoutEdit(_logic, new Workout(), this);
            workout.Show();
            this.Hide();
        }

        private void EditWorkout(object Sender, EventArgs e)
        {
            int index = listBoxWorkouts.SelectedIndex;
            var workoutFromList = workouts[index];
            WorkoutEdit workoutEdit = new WorkoutEdit(_logic, workoutFromList, this);
            workoutEdit.Show();
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}