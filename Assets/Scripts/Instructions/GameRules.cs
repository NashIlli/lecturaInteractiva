using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using Assets.Scripts.App;

namespace Assets.Scripts.Instructions
{
    public class GameRules : MonoBehaviour
    {
		public Text instructionText;

        void Start(){
			instructionText.text = (AppController.GetController ().GetCurrentGame () == 0) ? "LEE Y CONTESTA LAS PREGUNTAS"
				: "Lee las historias y contesta las preguntas. Elige una respuesta correcta.";

        }

    

        public void OnClickBackToGame()
        {
            ClickSound();
            ViewController.GetController().HideInstructions();
        }

        private void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }
    }
}