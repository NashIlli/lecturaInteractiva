using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.MainMenu
{

    public class StoryButton : MonoBehaviour {

        private int indexBook;
        [SerializeField]
        private Text titleText;


        public void ShowBook()
        {
            MainMenuController.GetController().ShowBook(indexBook);
        }

        public void SetIndexBook(int index)
        {
            indexBook = index;
        }

        public void SetTitleText(string title)
        {
            titleText.text = title;
        }
    }
}