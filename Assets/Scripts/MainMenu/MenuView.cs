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
            int maxCountChars = stories[0].Length;
            for (int i = 1; i < stories.Length; i++)
            {
                if (stories[i].Length > maxCountChars) maxCountChars = stories[i].Length;
            }

            int maxFontSize = SetMaxFontSize(maxCountChars);

            for (int i = 0; i < stories.Length; i++)
            {
                GameObject button = Instantiate(prefabStoryButton);
                button.GetComponent<StoryButton>().SetIndexBook(i);
                button.GetComponent<StoryButton>().SetTitleText(stories[i], maxFontSize);
                ViewController.FitObjectTo(button, panel.transform);
            }
        }

        private int SetMaxFontSize(int maxCountChars)
        {
            if (maxCountChars <= 16) return 77;
            if (maxCountChars <= 18) return 72;
            if (maxCountChars <= 23) return 61;
            return 55;
        }

        public void OnClickBack()
        {
            ClickSound();
            ViewController.GetController().LoadLogin();
        }
    }
}
