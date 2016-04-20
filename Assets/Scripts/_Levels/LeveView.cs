using Assets.Scripts.App;
using Assets.Scripts.Sound;
using UnityEngine;

namespace Assets.Scripts._Levels
{

    public abstract class LevelView : MonoBehaviour
    {
        public abstract void RestartGame();

        public void OnClickMenuBtn(){
            PlaySoundClick();
            AppController.GetController().ShowInGameMenu();
        }  

        internal void PlaySoundClick()
        {
            SoundController.GetController().PlayClickSound();
        }

        internal void PlayRightSound()
        {
            SoundController.GetController().PlayRightAnswerSound();
        }

        internal void PlayWrongSound()
        {
            SoundController.GetController().PlayWrongSound();
        }
    }
}
