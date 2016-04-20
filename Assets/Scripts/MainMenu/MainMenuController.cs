using Assets.Scripts.App;
using System;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{

    public class MainMenuController : MonoBehaviour
    {
        private static MainMenuController mainMenuController;

        public MenuView menuView;
        public GamePreview gamePreview;

        void Awake()
        {
            if (mainMenuController == null) mainMenuController = this;
            else if (mainMenuController != this) Destroy(gameObject);
        }

        internal void ShowMenu()
        {
            menuView.gameObject.SetActive(true);
        }     

        internal void ShowPreviewGame(int game)
        {
            AppController.GetController().SetCurrentGame(game);
            gamePreview.gameObject.SetActive(true);

        }

//        internal void ShowSettings()
//        {
//            ViewController.GetController().LoadSettings();
//        }
//
//        internal void ShowMetrics()
//        {
//            ViewController.GetController().LoadMetrics();
//        }

        public static MainMenuController GetController()
        {
            return mainMenuController;
        }
    }
}