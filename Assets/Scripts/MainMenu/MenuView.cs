using UnityEngine;
using Assets.Scripts.Sound;
using System;
using Assets.Scripts.App;

namespace Assets.Scripts.MainMenu {
    public class MenuView : MonoBehaviour {

        [SerializeField]
        private GameObject prefabStoryButton;

        [SerializeField]
        private GameObject panel;


        public void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }

        internal void AddStoryButtonsOf(string[] stories)
        {
            for (int i = 0; i < stories.Length; i++)
            {
                GameObject button = Instantiate(prefabStoryButton);
                button.GetComponent<StoryButton>().SetIndexBook(i);
                button.GetComponent<StoryButton>().SetTitleText(stories[i]);
                ViewController.FitObjectTo(button, panel.transform);
            }
        }

        public void OnClickBack()
        {
            ClickSound();
            ViewController.GetController().LoadLogin();
        }
    }
}
