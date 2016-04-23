using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Sound;

namespace Assets.Scripts.MainMenu
{

    public class StoryButton : MonoBehaviour {

        private int indexBook;
        [SerializeField]
        private Text titleText;


        public void ShowBook()
        {
            SoundController.GetController().PlayClickSound();
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