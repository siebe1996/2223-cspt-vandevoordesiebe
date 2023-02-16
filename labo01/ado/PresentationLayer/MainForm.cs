using DataAccessLayer.Models;
using Globals.Interfaces;
using LogicLayer;

namespace PresentationLayer
{
    public partial class MainFormSwimmers : Form
    {
        private readonly ILogic _logic;
        private List<Coach> coaches = new List<Coach> ();
        private List<Swimmer> swimmers = new List<Swimmer> ();

        public MainFormSwimmers(ILogic logic)
        {
            _logic = logic;
            InitializeComponent();
            var coachMembers = Attendance.GetMembers("Coaches");
            var swimmersMembers = Attendance.GetMembers("Swimmers");
            coaches = coachMembers.Select(m => (Coach)m).ToList();
            coachMembers.Sort();
            swimmers = swimmersMembers.Select(m => (Swimmer)m).ToList();
            swimmersMembers.Sort();
            FillComboBox(comboBoxCoaches, coachMembers);
            FillComboBox(comboBoxSwimmers, swimmersMembers);
        }

        public void FillComboBox(ComboBox comboBox, List<Member> members)
        {
            foreach (Member member in members) 
            {
            comboBox.Items.Add (member.ToString());
            }
        }

        private void comboBoxCoachesSelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxCoaches.Items.Clear ();
            int id = comboBoxCoaches.SelectedIndex;
            List<Workout> workouts = coaches[id].Workouts;
            workouts.Sort();
            foreach (Workout workout in workouts)
            {
                listBoxCoaches.Items.Add(workout.ToString());
            }
        }

        private void comboBoxSwimmersSelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSwimmers.Items.Clear();
            int id = comboBoxSwimmers.SelectedIndex;
            List<Workout> workouts = swimmers[id].Workouts;
            workouts.Sort();
            foreach (Workout workout in workouts)
            {
                listBoxSwimmers.Items.Add(workout.ToString());
            }
        }
    }
}