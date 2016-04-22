using UnityEngine;
using Assets.Scripts.Sound;
using Assets.Scripts._Levels;
using SimpleJSON;

namespace Assets.Scripts.App
{
    public class AppController : MonoBehaviour
    {
        private static AppController appController;
        private Book currentBook;
        private Book[] books;


        void Awake(){
            if (appController == null) appController = this;
            else if (appController != this) Destroy(gameObject);     
            DontDestroyOnLoad(gameObject);
        }         

        public void LoadBooks(int level = 1) 
        {
            TextAsset JSONstring = Resources.Load(level+1 + "_grade") as TextAsset;
            JSONNode data = JSON.Parse(JSONstring.text);
            books = new Book[data["books"].Count];
            for (int i = 0; i < data["books"].Count; i++)
            {
                books[i] = JsonUtility.FromJson<Book>(data["books"][i].ToString());       
            }
        }

        internal string[] GetBookTitles()
        {
            string[] toReturn = new string[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                toReturn[i] = books[i].title;
            }
            return toReturn;
        }

        internal void ShowBook(int book){
            SoundController.GetController().StopMusic();
            ViewController.GetController().ShowBook(books[book]);
        }

        internal void ShowInGameMenu(){
            ViewController.GetController().ShowInGameMenu();
        }    

        public static AppController GetController()
        {
            return appController;
        }
    }
}
