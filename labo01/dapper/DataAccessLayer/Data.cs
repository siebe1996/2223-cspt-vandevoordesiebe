using Globals.Interfaces;
using MySql.Data.MySqlClient;
using DataAccessLayer.Models;
using Dapper;
using Org.BouncyCastle.Crypto.Macs;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System;

namespace DataAccessLayer
{
    public class Data : IData
    {
        private MySqlConnection _conn;

        public Data()
        {
            string connection1 = "SERVER=localhost; DATABASE=mydb; UID=root; PASSWORD=Azerty123;";
            string connection2 = "Server = db-host.mysql.database.azure.com; Port = 3306; Database = mydb; Uid = svdv; Pwd = Azerty123; SslMode = Preferred;";
            _conn = new MySqlConnection(connection2);
        }

        public List<MemberModel> DataMembersKind(string kind)
        {
            string cmdCoaches = "SELECT m.id Id, m.date_of_birth DateOfBirth, m.first_name FirstName, m.last_name LastName, m.gender Gender, c.level Level,w.id Id, w.duration Duration, w.schedule Schedule, w.type Type,sp.id Id, sp.city City, sp.lane_length LaneLength, sp.name Name, sp.street Street, sp.zip_code ZipCode FROM coaches AS c JOIN members AS m ON c.id = m.id LEFT JOIN workouts AS w on c.id = w.coach_id LEFT JOIN swimming_pool AS sp on w.swimming_pool_id = sp.id";
            string cmdSwimmers = "SELECT m.id Id, m.date_of_birth DateOfBirth, m.first_name FirstName, m.last_name LastName, m.gender Gender, s.fina_points FinaPoints,w.id Id, w.duration Duration, w.schedule Schedule, w.type Type,sp.id Id, sp.city City, sp.lane_length LaneLength, sp.name Name, sp.street Street, sp.zip_code ZipCode FROM swimmers AS s JOIN members AS m ON s.id = m.id RIGHT JOIN swimmers_workouts AS sw ON s.id = sw.swimmer_id LEFT JOIN workouts AS w ON sw.workout_id = w.id LEFT JOIN swimming_pool AS sp ON w.swimming_pool_id = sp.id";
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    List<MemberModel> membersModelList = new List<MemberModel>();
                    if (kind.Equals("Coaches"))
                    {
                        var coachDict = new Dictionary<int, CoachModel>();
                        List<CoachModel> coachModelList = _conn.Query<CoachModel, WorkoutModel, SwimmingPoolModel, CoachModel>(cmdCoaches, (CoachModel coachModel, WorkoutModel workoutModel, SwimmingPoolModel swimmingPoolModel) =>
                        {
                            CoachModel coachEntry;
                            if (!coachDict.TryGetValue(coachModel.Id, out coachEntry))
                            {
                                coachEntry = coachModel;
                                coachEntry.Workouts = new List<WorkoutModel>();
                                coachDict.Add(coachEntry.Id, coachEntry);
                            }
                            workoutModel.SwimmingPool = swimmingPoolModel;
                            coachEntry.Workouts.Add(workoutModel);
                            return coachEntry;
                        },
                        splitOn: "Id"
                        ).Distinct().ToList();
                        membersModelList = new List<MemberModel>(coachModelList.Select(m => (CoachModel)m));
                    }
                    else if (kind.Equals("Swimmers"))
                    {
                        var swimmerDict = new Dictionary<int, SwimmerModel>();
                        List<SwimmerModel> swimmerModelList = _conn.Query<SwimmerModel, WorkoutModel, SwimmingPoolModel, SwimmerModel>(cmdSwimmers, (SwimmerModel swimmerModel, WorkoutModel workoutModel, SwimmingPoolModel swimmingPoolModel) =>
                        {
                            SwimmerModel swimmerEntry;
                            if (!swimmerDict.TryGetValue(swimmerModel.Id, out swimmerEntry))
                            {
                                swimmerEntry = swimmerModel;
                                swimmerEntry.Workouts = new List<WorkoutModel>();
                                swimmerDict.Add(swimmerEntry.Id, swimmerEntry);
                            }
                            workoutModel.SwimmingPool = swimmingPoolModel;
                            swimmerEntry.Workouts.Add(workoutModel);
                            return swimmerEntry;
                        },
                        splitOn: "Id"
                        ).Distinct().ToList();
                        membersModelList = new List<MemberModel>(swimmerModelList.Select(m => (SwimmerModel)m));
                    }
                    return membersModelList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally { _conn.Close(); }
            }
        }
    }
}