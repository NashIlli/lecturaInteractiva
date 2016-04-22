using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Sound;
using Assets.Scripts._Levels;
using Assets.Scripts._Levels.BookView;
using System;

namespace Assets.Scripts.App
{
    public class ViewController : MonoBehaviour
    {
        private static ViewController viewController;
        public GameObject cover;
        public GameObject login;
        public GameObject mainMenu;
//        public GameObject settings;
        public GameObject inGameMenu;
        public GameObject instructions;
        public GameObject levelCompleted;
		public GameObject readTest;
		public GameObject viewPanel;
        public GameObject bookView;
        public List<GameObject> levels;
        private GameObject currentGameObject;

        // these objects are pop, the current object isn't destroyed when they are showed
        private GameObject inGameMenuScreen;
        private GameObject instructionsScreen;

        void Awake()
        {
            if (viewController == null) viewController = this;
            else if (viewController != this) Destroy(gameObject);      
            DontDestroyOnLoad(this);
        }  

		void Start(){
			LoadCover ();
		}

        internal void LoadMainMenu()
        {
            ChangeCurrentObject(mainMenu);
            SoundController.GetController().StopMusic();
        }    

        internal void LoadCover()
        {
            ChangeCurrentObject(cover);		
        }

        internal void ShowBook(Book book)
        {
            ChangeCurrentObject(bookView);
            currentGameObject.GetComponentInChildren<BookView>().StartBook(book);


        }

        private void ChangeCurrentObject(GameObject newObject)
        {
            GameObject child = Instantiate(newObject);
            FitObjectTo(child, viewPanel.transform);
            Destroy(currentGameObject);
            currentGameObject = child;            
        }

        internal void ShowInGameMenu()
        {
            inGameMenuScreen = Instantiate(inGameMenu);
            FitObjectTo(inGameMenuScreen, viewPanel.transform);
        }

        public static void FitObjectTo(GameObject child, Transform transform)
        {
            child.transform.SetParent(transform, true);
            child.transform.localPosition = Vector3.zero;
            child.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            child.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            child.transform.localScale = Vector3.one;
        }

        internal void LoadLogin()
        {
            ChangeCurrentObject(login);
        }

        internal void StartGame(int currentLevel)
        {
			AppController.GetController ().ShowBook (currentLevel);
			ChangeCurrentObject(readTest);         
        }    

        internal void ShowInstructions()
        {
            instructionsScreen = Instantiate(instructions);
            FitObjectTo(instructionsScreen, viewPanel.transform);
        }

        internal void HideInGameMenu(){
            Destroy(inGameMenuScreen);
        }

        internal void HideInstructions()
        {
            Destroy(instructionsScreen);
        }

        internal void LoadLevelCompleted()
        {
            ChangeCurrentObject(levelCompleted);
        }

        public static ViewController GetController()
        {
            return viewController;
        }
    }
}
