using Globals.Entities;
using Globals.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SharpRepository.MongoDbRepository;
using SharpRepository.Repository.Caching;

namespace DataAccessLayer
{
    public class Data : IData
    {
        //private SwimmingContext _context;
        /*MongoClient client;
        IMongoCollection<Swimmer> SwimmerCollection;
        IMongoCollection<Coach> CoachCollection;
        IMongoCollection<SwimmingPool> SwimmingPoolCollection;
        IMongoCollection<Workout> WorkoutCollection;*/
        private MongoDbRepository<Swimmer> repoSwimmers;
        private MongoDbRepository<Coach> repoCoaches;
        private MongoDbRepository<SwimmingPool> repoSwimmingPools;
        private MongoDbRepository<Workout> repoWorkouts;

        private IMongoDatabase _db;
        private MongoClient _client;

        public Data()
        {
            string conn = "mongodb://localhost:27017";
            string dbName = "swimmerMongoDB";

            BsonClassMap.RegisterClassMap<Coach>(cm => {
                cm.AutoMap();
                cm.SetDiscriminator("coachClass");
            });
            BsonClassMap.RegisterClassMap<SwimmingPool>(cm => {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Workout>(cm => {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Swimmer>(cm => {
                cm.AutoMap();
                cm.SetDiscriminator("swimmerClass");
            });

            //this._context = new SwimmingContext();

            _client = new MongoClient(conn);
            _db = _client.GetDatabase(dbName);

            //var CoachCollection = _db.GetCollection<Coach>("coaches");
            //var Coachesrepo = new MongoDbRepository<Coach>(conn);

            /*CoachCollection = _db.GetCollection<Coach>("coaches");
            SwimmingPoolCollection = _db.GetCollection<SwimmingPool>("swimmingpools");
            WorkoutCollection = _db.GetCollection<Workout>("workouts");
            SwimmerCollection = _db.GetCollection<Swimmer>("swimmers");*/
            
            
            repoCoaches = new MongoDbRepository<Coach>();
            repoSwimmers = new MongoDbRepository<Swimmer>();
            repoWorkouts = new MongoDbRepository<Workout>();
            repoSwimmingPools = new MongoDbRepository<SwimmingPool>();

            CreateSwimmingPool();
            CreateCoaches();
            CreateWorkouts();
            CreateSwimmers();
        }

        public void CreateCoaches()
        {
            var coaches = new List<Coach> {
                new Coach(DateTime.Parse("1998-01-23 12:45:56"), "Jos", "De Steen", 'M', (CoachLevel)Enum.Parse(typeof(CoachLevel), "INITIATOR")),
                new Coach(DateTime.Parse("1998-01-23 12:45:56"), "Peter", "Demeester", 'M', (CoachLevel)Enum.Parse(typeof(CoachLevel), "INSTRUCTOR")),
                new Coach(DateTime.Parse("1998-01-23 12:45:56"), "Nel", "De Snel", 'F', (CoachLevel)Enum.Parse(typeof(CoachLevel), "TRAINER_A")),
                new Coach(DateTime.Parse("1998-01-23 12:45:56"), "Piet", "De Miet", 'X', (CoachLevel)Enum.Parse(typeof(CoachLevel), "TRAINER_B")),
            };
            foreach (Coach coach in coaches)
            {
                //coach.Discriminator = "coachClass";
                repoCoaches.Add(coach);
            }
        }

        public void CreateSwimmers()
        {
            var swimmers = new List<Swimmer>
            {
                new Swimmer(DateTime.Parse("1998-01-23 12:45:56"), "Klaas", "De Steen", 'M', 8),
                new Swimmer(DateTime.Parse("1998-01-23 12:45:56"), "Brent", "De Bakker", 'M', 9),
                new Swimmer(DateTime.Parse("1998-01-23 12:45:56"), "Arthur", "Cleays", 'M', 7),
                new Swimmer(DateTime.Parse("1998-01-23 12:45:56"), "John", "Doe", 'M', 6),
            };

            var workouts = GetWorkouts();
            swimmers[0].Workouts.Add(workouts[0]);
            swimmers[0].Workouts.Add(workouts[1]);
            swimmers[1].Workouts.Add(workouts[0]);
            swimmers[1].Workouts.Add(workouts[2]);
            swimmers[2].Workouts.Add(workouts[3]);

            foreach (Swimmer swimmer in swimmers)
            {
                //swimmer.Discriminator = "swimmerClass";
                repoSwimmers.Add(swimmer);
            }
        }

        public void CreateWorkouts()
        {
            var coaches = GetCoaches();
            var workouts = new List<Workout>
            {
                new Workout(coaches[0], 90, DateTime.Parse("2023-01-23 12:45:56"), GetSwimmingPools()[0], (WorkoutType)Enum.Parse(typeof(WorkoutType), "ENDURANCE")),
                new Workout(coaches[0], 60, DateTime.Parse("2022-01-23 12:45:56"), GetSwimmingPools()[0], (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(coaches[1], 75, DateTime.Parse("2024-01-23 12:45:56"), GetSwimmingPools()[1], (WorkoutType)Enum.Parse(typeof(WorkoutType), "INTERVAL")),
                new Workout(coaches[1], 55, DateTime.Parse("2025-01-23 12:45:56"), GetSwimmingPools()[1], (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(coaches[1], 50, DateTime.Parse("2021-01-23 12:45:56"), GetSwimmingPools()[2], (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(coaches[2], 65, DateTime.Parse("2020-01-23 12:45:56"), GetSwimmingPools()[2], (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
            }.ToList();


            repoWorkouts.Add(workouts);
        }

        public void CreateSwimmingPool()
        {
            var swimmingPools = new List<SwimmingPool>
            {
                new SwimmingPool("Gent", (PoolLaneLength)Enum.Parse(typeof(PoolLaneLength), "_25"), "Rooiegem", "rooiegemlaan", 9000),
                new SwimmingPool("Gent", (PoolLaneLength)Enum.Parse(typeof(PoolLaneLength), "_50"), "Strop", "stropstraat", 9000),
                new SwimmingPool("Gent", (PoolLaneLength)Enum.Parse(typeof(PoolLaneLength), "_25"), "Rozenbroeke", "rozenbroekstraat", 9000),
            };
            foreach (SwimmingPool swimmingPool in swimmingPools)
            {
                repoSwimmingPools.Add(swimmingPool);
            }
        }

        public List<Coach> GetCoaches()
        {
            return (List<Coach>)repoCoaches.GetAll();
        }
        public Coach GetCoach(int id)
        {
            return repoCoaches.Get(id.ToString());
        }

        public List<SwimmingPool> GetSwimmingPools()
        {
            return (List<SwimmingPool>)repoSwimmingPools.GetAll();
        }

        public List<Swimmer> GetSwimmers()
        {
            return (List<Swimmer>)repoSwimmers.GetAll();
        }

        public List<Swimmer> GetSwimmers(Workout workout)
        {
            return (List<Swimmer>)repoSwimmers.FindAll(s => s.Workouts.Contains(workout));
        }

        public bool CheckIfSwimmerExist(Swimmer swimmer)
        {
            if(swimmer.Id == null)
            {
                return false;
            }
            return repoSwimmers.Exists(s => s.Id == swimmer.Id);
        }

        public List<Workout> GetWorkouts()
        {
            return (List<Workout>)repoWorkouts.GetAll();
        }

        public List<Workout> GetWorkouts(Swimmer swimmer)
        {
            return (List<Workout>)repoSwimmers.Find(s => s.Id == swimmer.Id).Workouts.ToList();
        }

        public bool CheckIfWorkoutExist(Workout workout)
        {
            if (workout.Id == null)
            {
                return false;
            }
            return repoWorkouts.Exists(w => w.Id == workout.Id);
        }

        public void UpdateSwimmer(Swimmer swimmer)
        {
            repoSwimmers.Update(swimmer);
        }

        public void UpdateWorkout(Workout workout)
        {
            repoWorkouts.Update(workout);
        }

        public Workout GetWorkout(int id)
        {
            return repoWorkouts.Get(id.ToString());
        }
        public Workout GetWorkout(string id)
        {
            return repoWorkouts.Find(w => w.Id == id);
        }

        public SwimmingPool GetSwimmingPool(int id)
        {
            return repoSwimmingPools.Get(id.ToString());
        }
        public SwimmingPool GetSwimmingPool(string id)
        {
            return repoSwimmingPools.Get(id);
        }

        public void AddSwimmer(Swimmer swimmer)
         {
             repoSwimmers.Add(swimmer);
         }

        public void AddWorkout(Workout workout, Coach coach)
        {
            repoWorkouts.Add(workout);
        }

        public void AddWorkout(Workout workout)
        {
            repoWorkouts.Add(workout);
        }

    }
}
