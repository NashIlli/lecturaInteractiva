using System;
using System.Collections.Generic;

namespace Assets.Scripts.App
{
    internal class AppModel
    {
        private int currentGame;
        private int currentLevel;
        private string username;

        private List<string> descriptions;

        public AppModel(){
            InitDescriptions();
            currentGame = -1;
        }

        private void InitDescriptions()
        {
            descriptions = new List<string>();   
            // todo -> fill the list   
        }

        internal int GetCurrentGame(){
            return currentGame;
        }

        internal void SetCurrentGame(int currentGame){
            this.currentGame = currentGame;
        }      

        internal string GetDescriptionOf(int game)
        {
            return descriptions[game];
        }

        internal void SetUsername(string username)
        {
            this.username = username;
        }

        internal void SetLevel(int level)
        {
            currentLevel = level;
        }
    }
}