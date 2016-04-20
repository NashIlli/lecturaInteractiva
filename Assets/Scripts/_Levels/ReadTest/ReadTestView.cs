using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System;
using System.Collections.Generic;

namespace Assets.Scripts._Levels.ReadTest
{

	public class ReadTestView : LevelView
    {
        public Text readingText,questionText;
		public Toggle[] answerButtons;
		public ToggleGroup toggleGroup;
		public Button submitButton;
		public GameObject endGamePanel;

		void Awake()
		{
			readingText.supportRichText = true;
		}

		internal void NextChallenge(Question question)
        {
			submitButton.interactable = false;
			readingText.text = question.Paragraph;
			questionText.text = question.QuestionText;
			for (int i = 0; i < 3; i++) {
				answerButtons [i].GetComponentInChildren<Text>().text = question.AnswersTexts [i];
			}  
        }



        public void OnClickSubmit()
        {
			
			IEnumerator<Toggle> toggleEnum = toggleGroup.ActiveToggles().GetEnumerator();
			toggleEnum.MoveNext();
			Toggle toggle = toggleEnum.Current;
			toggle.isOn = false;
            PlaySoundClick();
			ReadTestController.GetController().CheckAnswer(toggle.GetComponentInChildren<Text>().text);
        }

        public void OnClickHintButton()
        {
            PlaySoundClick();
			ShowHint ();

        }

		void ShowHint(){
			string[] hintTexts = ReadTestController.GetController ().GetHints ();
			string oldString = readingText.text;
			string newString ="";


			for (int i = 0; i < hintTexts.Length; i++) {
				
				int hintIndex = readingText.text.IndexOf(hintTexts[i]);
				int hintLength = hintTexts[i].Length;

				string start = oldString.Substring (0, hintIndex);
				string middle = oldString.Substring (hintIndex, hintLength);
				string end = oldString.Substring (hintIndex+hintLength, oldString.Length-(hintIndex+hintLength));

				newString = start+"<color=white>" +middle + "</color>"+end;

				oldString = newString;
			}

			readingText.text = newString;

			ReadTestController.GetController ().LogHint ();
		}


		public void OnToggleSelected(){
			submitButton.interactable = true;
		}

//        internal void CorrectAnswer()
//        {
//			//PlayRightSound();
//        }
//
//        internal void WrongAnswer()
//        {
//			//PlayWrongSound();
//        }

        public override void RestartGame()
        {
//            answer.text = "";
        }

		public void EndGame(){
			endGamePanel.SetActive(true);
		}



    }
}