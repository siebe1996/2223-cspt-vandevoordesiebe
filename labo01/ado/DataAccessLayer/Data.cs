using DataAccessLayer.Models;
using Globals.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class Data : IData
    {
        private MySqlConnection _conn;
        private DataSet _ds = new DataSet();
        private MySqlDataAdapter _da;

        public Data() 
        {
            string connection1 = "SERVER=localhost; DATABASE=mydb; UID=root; PASSWORD=Azerty123;"; ;
            string connection2 = "Server = db-host.mysql.database.azure.com; Port = 3306; Database = mydb; Uid = svdv; Pwd = Azerty123; SslMode = Preferred;";
            _conn = new MySqlConnection(connection2);
        }

        public void MemberKindData(string kind)
        {
            _da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            if (kind.Equals("Coaches"))
            {
                cmd = new MySqlCommand("SELECT * FROM coaches JOIN members ON coaches.id = members.id", _conn);
            }else if (kind.Equals("Swimmers"))
            {
                cmd = new MySqlCommand("SELECT * FROM swimmers JOIN members ON swimmers.id = members.id", _conn);
            }
            _da.SelectCommand = cmd;
            _da.Fill(_ds, kind);
        }

        public void SwimmingPoolData()
        {
            _da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM swimming_pool", _conn);
            _da.SelectCommand = cmd;
            _da.Fill(_ds, "SwimmingPools");
        }

        public void WorkoutCoachData(int coachId)
        {
            _da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM workouts WHERE coach_id = @Id", _conn);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32, 15).Value = coachId;
            _da.SelectCommand = cmd;
            _da.Fill(_ds, "Workout" + coachId);
        }

        public void WorkoutSwimmerData(int swimmerId)
        {
            _da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM swimmers_workouts JOIN workouts ON swimmers_workouts.workout_id = workouts.id WHERE swimmers_workouts.swimmer_id = @Id", _conn);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32, 15).Value = swimmerId;
            _da.SelectCommand = cmd;
            _da.Fill(_ds, "Workout" + swimmerId);
        }

        public int RowCounter(string tableName)
        {
            DataTable tbl = _ds.Tables[tableName];
            int count = tbl.Rows.Count;
            return count;
        }

        public CoachModel DataCoach(int id)
        {
            MemberKindData("Coaches");
            DataTable tblCoach = _ds.Tables["Coaches"];
            DataRow row = tblCoach.Rows[id];
            CoachModel coach = new CoachModel((int)row["id"], DateTime.Parse(row["date_of_birth"].ToString()), (string)row["first_name"], (string)row["last_name"], char.Parse((string)row["gender"]), (CoachLevelModel)Enum.Parse(typeof(CoachLevelModel), (string)row["level"]), new List<WorkoutModel>());
            return coach;
        }

        public SwimmingPoolModel DataSwimmingPool(int id)
        {
            SwimmingPoolData(); //kan eventueel MemberKindData("SwimmingPools")?
            DataTable tblCoach = _ds.Tables["SwimmingPools"];
            DataRow row = tblCoach.Rows[id];
            SwimmingPoolModel swimmingPool = new SwimmingPoolModel((int)row["id"], (string)row["city"], (PoolLaneLengthModel)Enum.Parse(typeof(PoolLaneLengthModel), (string)row["lane_length"]), (string)row["name"], (string)row["street"], (int)row["zip_code"]);
            return swimmingPool;
        }

        public List<MemberModel> DataMembersKind(string kind)
        {
            List<MemberModel>  members= new List<MemberModel>();
            MemberKindData(kind);
            DataTable tblCoach = _ds.Tables[kind];
            int count = tblCoach.Rows.Count;
            for(int i = 0; i < count; i++)
            {
                if (kind.Equals("Coaches"))
                {
                    List<WorkoutModel> workouts = DataCoachWorkouts((int)tblCoach.Rows[i]["id"]);
                    CoachModel member = new CoachModel((int)tblCoach.Rows[i]["id"], DateTime.Parse(tblCoach.Rows[i]["date_of_birth"].ToString()), (string)tblCoach.Rows[i]["first_name"], (string)tblCoach.Rows[i]["last_name"], char.Parse((string)tblCoach.Rows[i]["gender"]), (CoachLevelModel)Enum.Parse(typeof(CoachLevelModel), (string)tblCoach.Rows[i]["level"]), workouts);
                    members.Add(member);
                }
                else if (kind.Equals("Swimmers"))
                {
                    List<WorkoutModel> workouts = DataSwimmerWorkouts((int)tblCoach.Rows[i]["id"]);
                    SwimmerModel member = new SwimmerModel((int)tblCoach.Rows[i]["id"], DateTime.Parse(tblCoach.Rows[i]["date_of_birth"].ToString()), (string)tblCoach.Rows[i]["first_name"], (string)tblCoach.Rows[i]["last_name"], char.Parse((string)tblCoach.Rows[i]["gender"]), (int)tblCoach.Rows[i]["fina_points"], workouts);
                    members.Add(member);
                }
            }
            /*
            foreach (DataRow dr in tblCoach.Rows)
            {
                if (kind.Equals("Coaches"))
                {
                    List<WorkoutModel> workouts = DataCoachWorkouts((int)dr["id"]);
                    CoachModel member = new CoachModel(DateTime.Parse(dr["date_of_birth"].ToString()), (string)dr["first_name"], (string)dr["last_name"], char.Parse((string)dr["gender"]), (int)dr["id"], (CoachLevelModel)Enum.Parse(typeof(CoachLevelModel), (string)dr["level"]), workouts);
                    members.Add(member);
                }
                else if (kind.Equals("Swimmers"))
                {
                    List<WorkoutModel> workouts = DataSwimmerWorkouts((int)dr["id"]);
                    SwimmerModel member = new SwimmerModel(DateTime.Parse((string)dr["date_of_birth"]), (string)dr["first_name"], (string)dr["last_name"], char.Parse((string)dr["gender"]), (int)dr["id"], (int)dr["fina_points"], new List<WorkoutModel>());
                    members.Add(member);
                }
                
            }*/
            return members;
        }

        public List<WorkoutModel> DataCoachWorkouts(int coachId)
        {
            List<WorkoutModel> coachWorkouts = new List<WorkoutModel>();
            WorkoutCoachData(coachId);
            DataTable tblWorkout = _ds.Tables["Workout" + coachId];
            foreach (DataRow dr in tblWorkout.Rows)
            {
                CoachModel coach = DataCoach(coachId);
                SwimmingPoolModel swimmingPool = DataSwimmingPool((int)dr["swimming_pool_id"]);
                WorkoutModel workout = new WorkoutModel((int)dr["id"], coach, (int)dr["duration"], DateTime.Parse(dr["schedule"].ToString()), swimmingPool, (WorkoutTypeModel)Enum.Parse(typeof(WorkoutTypeModel), (string)dr["type"]));
                coachWorkouts.Add(workout);
            }
            return coachWorkouts;
        }

        public List<WorkoutModel> DataSwimmerWorkouts(int swimmerId)
        {
            List<WorkoutModel> swimmerWorkouts = new List<WorkoutModel>();
            WorkoutSwimmerData(swimmerId);
            DataTable tblWorkout = _ds.Tables["Workout" + swimmerId];
            foreach (DataRow dr in tblWorkout.Rows)
            {
                CoachModel coach = DataCoach((int)dr["coach_id"]);
                SwimmingPoolModel swimmingPool = DataSwimmingPool((int)dr["swimming_pool_id"]);
                WorkoutModel workout = new WorkoutModel((int)dr["id"], coach, (int)dr["duration"], DateTime.Parse(dr["schedule"].ToString()), swimmingPool, (WorkoutTypeModel)Enum.Parse(typeof(WorkoutTypeModel), (string)dr["type"]));
                swimmerWorkouts.Add(workout);
            }
            return swimmerWorkouts;
        }
    }
}