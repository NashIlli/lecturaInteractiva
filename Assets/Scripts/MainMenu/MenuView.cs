using UnityEngine;
using Assets.Scripts.Sound;

namespace Assets.Scripts.MainMenu {
    public class MenuView : MonoBehaviour {    

//        public void OnClickSettings()
//        {
//            ClickSound();
//            MainMenuController.GetController().ShowSettings();
//        }
//
//        public void OnClickMetrics()
//        {
//            ClickSound();
//            MainMenuController.GetController().ShowMetrics();
//        }

        public void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }
    }
}
