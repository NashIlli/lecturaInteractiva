﻿using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using Assets.Scripts.App;

namespace Assets.Scripts.Instructions
{
    public class GameRules : MonoBehaviour
    {
		public Text instructionText;

        void Start(){
            instructionText.text = "Lee los textos, observa las imágenes y responde las preguntas";

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