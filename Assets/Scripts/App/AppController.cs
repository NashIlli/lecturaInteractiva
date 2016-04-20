using UnityEngine;
using Assets.Scripts.Sound;
using System;

namespace Assets.Scripts.App
{
    public class AppController : MonoBehaviour
    {
        private static AppController appController;
        private AppModel appModel;

        void Awake(){
            if (appController == null) appController = this;
            else if (appController != this) Destroy(gameObject);     
            DontDestroyOnLoad(gameObject);
            appModel = new AppModel();
        }         

        internal void PlayCurrentGame()
        {
            SoundController.GetController().StopMusic();
            ViewController.GetController().StartGame(appModel.GetCurrentGame());
        }

        internal void SetUsername(string username)
        {
            appModel.SetUsername(username);
        }

        internal void SetCurrentGame(int currentGame){
            appModel.SetCurrentGame(currentGame);
        }

        internal int GetCurrentGame(){
            return appModel.GetCurrentGame();
        }

        internal void ShowInGameMenu(){
            ViewController.GetController().ShowInGameMenu();
        }    

        public static AppController GetController()
        {
            return appController;
        }

        internal string GetActivityName(int game)
        {
            return appModel.GetDescriptionOf(game);
        }

        internal void SetLevel(int level) {
            appModel.SetLevel(level);
        }
    }
}
