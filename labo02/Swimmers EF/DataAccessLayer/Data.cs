using Globals.Entities;
using Globals.Interfaces;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;
using SharpRepository.EfCoreRepository;
using SharpRepository.Repository.Caching;

namespace DataAccessLayer
{
    public class Data : IData
    {
        private SwimmingContext _context;
        private EfCoreRepository<Member> repoMembers;
        private EfCoreRepository<Coach> repoCoaches;
        private EfCoreRepository<Swimmer> repoSwimmers;
        private EfCoreRepository<SwimmingPool> repoSwimmingPools;
        private EfCoreRepository<Workout> repoWorkouts;

        public Data(DbContext context) 
        { 
            this._context = (SwimmingContext)context;
            _context.Database.EnsureCreated();
            repoMembers = new EfCoreRepository<Member>(_context);
            repoCoaches = new EfCoreRepository<Coach>(_context);
            repoSwimmers = new EfCoreRepository<Swimmer>(_context);
            repoWorkouts = new EfCoreRepository<Workout>(_context);
            repoSwimmingPools = new EfCoreRepository<SwimmingPool>(_context);
            CreateCoaches();
            CreateSwimmingPool();
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
            //coaches.Select(c => repoCoaches.Add(c));
            foreach (Coach coach in coaches)
            {
                repoCoaches.Add(coach);
            }/*
            if (repoCoaches.Find(c => c.Id == 1) == null)
            {
                foreach (Coach coach in coaches)
                {
                    repoCoaches.Add(coach);
                }
            }*/
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
                repoSwimmers.Add(swimmer);
            }

            /*
            if (repoSwimmers.Find(s => s.Id == 1) == null)
            {
                foreach (Swimmer swimmer in swimmers)
                {
                    repoSwimmers.Add(swimmer);
                }
            }*/
        }

        public void CreateWorkouts()
        {
            var workouts = new List<Workout>
            {
                new Workout(90, DateTime.Parse("2023-01-23 12:45:56"), repoSwimmingPools.Get(1), (WorkoutType)Enum.Parse(typeof(WorkoutType), "ENDURANCE")),
                new Workout(60, DateTime.Parse("2022-01-23 12:45:56"), repoSwimmingPools.Get(1), (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(75, DateTime.Parse("2024-01-23 12:45:56"), repoSwimmingPools.Get(2), (WorkoutType)Enum.Parse(typeof(WorkoutType), "INTERVAL")),
                new Workout(55, DateTime.Parse("2025-01-23 12:45:56"), repoSwimmingPools.Get(2), (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(50, DateTime.Parse("2021-01-23 12:45:56"), repoSwimmingPools.Get(3), (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
                new Workout(65, DateTime.Parse("2020-01-23 12:45:56"), repoSwimmingPools.Get(3), (WorkoutType)Enum.Parse(typeof(WorkoutType), "POWER")),
            }.ToList();

            //var coaches = (List<Coach>)repoCoaches.GetAll();
            //var coach = coaches[0];
            //var name = coach.FirstName;
            //coach.Workouts.Add(workouts[0]);
            /*var workout = workouts[0];

            var coaches = GetCoaches();

            coaches[0].Workouts.Add(workout);
            coaches[1].Workouts.Add((Workout)workouts[1]);
            coaches[1].Workouts.Add((Workout)workouts[2]);
            coaches[2].Workouts.Add((Workout)workouts[3]);
            coaches[2].Workouts.Add((Workout)workouts[4]);
            coaches[3].Workouts.Add((Workout)workouts[5]);*/
            /*.Get(1).Workouts.Add((Workout)workouts[0]);
            repoCoaches.Get(2).Workouts.Add((Workout)workouts[1]);
            repoCoaches.Get(2).Workouts.Add((Workout)workouts[2]);
            repoCoaches.Get(3).Workouts.Add((Workout)workouts[3]);
            repoCoaches.Get(3).Workouts.Add((Workout)workouts[4]);
            repoCoaches.Get(4).Workouts.Add((Workout)workouts[5]);*/

            /*foreach (Workout workout in workouts)
            {
                repoWorkouts.Add(workout);
            }*/
            if (true)
            {
                var coaches = GetCoaches();
                coaches[0].Workouts.Add(workouts[0]);
                coaches[1].Workouts.Add(workouts[1]);
                coaches[1].Workouts.Add(workouts[2]);
                coaches[2].Workouts.Add(workouts[3]);
                coaches[2].Workouts.Add(workouts[4]);
                coaches[3].Workouts.Add(workouts[5]);

                repoWorkouts.Add(workouts);
            }
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
            /*if (repoSwimmingPools.Find(sp => sp.Id == 1) == null)
            {
                foreach (SwimmingPool swimmingPool in swimmingPools)
                {
                    repoSwimmingPools.Add(swimmingPool);
                }
            }*/
        }

        public List<Coach> GetCoaches()
        {
            return (List<Coach>)repoCoaches.GetAll();
        }
        public Coach GetCoach(int id)
        {
            return repoCoaches.Get(id);
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
            return repoSwimmers.GetAll().Contains(swimmer);
        }

        public List<Workout> GetWorkouts()
        {
            return (List<Workout>)repoWorkouts.GetAll();
        }

        public List<Workout> GetWorkouts(Swimmer swimmer)
        {
            return (List<Workout>)repoWorkouts.FindAll(w => w.Swimmers.Contains(swimmer));
        }

        public bool CheckIfWorkoutExist(Workout workout)
        {
            return repoWorkouts.GetAll().Contains(workout);
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
            return repoWorkouts.Get(id);
        }

        public void AddSwimmer(Swimmer swimmer)
        {
            repoSwimmers.Add(swimmer);
        }

        public void AddWorkout(Workout workout, Coach coach)
        {
            //var coach = GetCoach(workout.Coach.Id);
            coach.Workouts.Add(workout);
            repoWorkouts.Add(workout);
        }

    }
}