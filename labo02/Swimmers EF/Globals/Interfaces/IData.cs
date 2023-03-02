using Globals.Entities;

namespace Globals.Interfaces
{
    public interface IData
    {
        List<Coach> GetCoaches();
        List<SwimmingPool> GetSwimmingPools();
        List<Swimmer> GetSwimmers();
        List<Swimmer> GetSwimmers(Workout workout);
        List<Workout> GetWorkouts();
        List<Workout> GetWorkouts(Swimmer swimmer);
        void UpdateSwimmer(Swimmer swimmer);
        void UpdateWorkout(Workout workout);
        Workout GetWorkout(int id);
        bool CheckIfWorkoutExist(Workout workout);
        bool CheckIfSwimmerExist(Swimmer swimmer);
        void AddSwimmer(Swimmer swimmer);
        void AddWorkout(Workout workout, Coach coach);
    }
}