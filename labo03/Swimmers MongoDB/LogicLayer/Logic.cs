using Globals.Entities;
using Globals.Interfaces;

namespace LogicLayer
{
    public class Logic : ILogic
    {
        private readonly IData _data;

        public Logic(IData data)
        {
            _data = data;
        }

        public List<Coach> GetCoaches()
        {
            return this._data.GetCoaches();
        }

        public List<SwimmingPool> GetSwimmingPools()
        {
            return _data.GetSwimmingPools();
        }

        public List<Swimmer> GetSwimmers()
        {
            return this._data.GetSwimmers();
        }

        public List<Swimmer> GetSwimmers(Workout workout)
        {
            return this._data.GetSwimmers(workout);
        }

        public List<Workout> GetWorkouts()
        {
            return this._data.GetWorkouts();
        }

        public List<Workout> GetWorkouts(Swimmer swimmer) 
        { 
            return this._data.GetWorkouts(swimmer);
        }

        public void UpdateSwimmer(Swimmer swimmer)
        {
            this._data.UpdateSwimmer(swimmer);
        }

        public void UpdateWorkout(Workout workout)
        {
            this._data.UpdateWorkout(workout);
        }
        public Workout GetWorkout(int id) 
        { 
            return this._data.GetWorkout(id);
        }

        public bool CheckIfWorkoutExist(Workout workout)
        {
            return this._data.CheckIfWorkoutExist(workout);
        }

        public bool CheckIfSwimmerExist(Swimmer swimmer)
        {
            return this._data.CheckIfSwimmerExist(swimmer);
        }

        public void AddSwimmer(Swimmer swimmer)
        {
            this._data.AddSwimmer(swimmer);
        }

        public void AddWorkout(Workout workout)
        {
            this._data.AddWorkout(workout);
        }
    }
}