using Assets.Scripts.Sound;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExitButton : MonoBehaviour {

        public void OnClickExitButton()
        {
            SoundController.GetController().PlayClickSound();
            Application.Quit();
        }
    }
}
