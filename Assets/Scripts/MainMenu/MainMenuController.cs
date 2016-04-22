using Assets.Scripts.App;
using System;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{

    public class MainMenuController : MonoBehaviour
    {
        private static MainMenuController mainMenuController;
        public MenuView menuView;

        void Awake()
        {
            if (mainMenuController == null) mainMenuController = this;
            else if (mainMenuController != this) Destroy(gameObject);
        }

        void Start()
        {

            menuView.AddStoryButtonsOf(AppController.GetController().GetBookTitles());
        }

        internal void ShowBook(int indexBook)
        {
            AppController.GetController().ShowBook(indexBook);
        }

        public static MainMenuController GetController()
        {
            return mainMenuController;
        }
    }
}