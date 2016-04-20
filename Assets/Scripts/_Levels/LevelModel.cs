
namespace Assets.Scripts._Levels
{
    public abstract class LevelModel
    {
        protected int minSeconds;
        protected int pointsPerSecond;
        protected int pointsPerError;

        public abstract void StartGame();
        public abstract void NextChallenge();
        public abstract void RestartGame();

        public LevelModel() { }

        public int GetPointsPerError(){
             return pointsPerError;
        }

        public int GetPointsPerSecond(){
            return pointsPerSecond;
        }

        public int GetMinSeconds()
        {
            return minSeconds;
        }

    }
}
