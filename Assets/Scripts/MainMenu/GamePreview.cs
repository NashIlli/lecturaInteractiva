using UnityEngine;
using Assets.Scripts.Sound;

namespace Assets.Scripts.MainMenu
{

    public class GamePreview : MonoBehaviour
    {
        public void OnClickBackBtn()
        {
            ClickSound();
            MainMenuController.GetController().ShowMenu();
            gameObject.SetActive(false);
        }     

        internal void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }

    }
}
