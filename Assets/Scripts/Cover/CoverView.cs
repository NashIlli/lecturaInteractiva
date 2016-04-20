using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System;

namespace Assets.Scripts.Cover{

    public class CoverView : MonoBehaviour{      

        public GameObject coverScreen;
        public GameObject oxScreen;
        public GameObject aboutScreen;    

        internal void ShowCoverScreen(){
            coverScreen.SetActive(true);
        }     

        internal void ShowOx()
        {
            oxScreen.SetActive(true);
        }


        internal void ShowAbout()
        {
            aboutScreen.SetActive(true);
        }

        internal void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }
    }
}
