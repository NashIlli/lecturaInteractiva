using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System.Collections.Generic;

namespace Assets.Scripts.Login{

    public class LoginView : MonoBehaviour{

        //todo -> get var from Settings
        public InputField inputText;
        public Text incorrectInput;
        public Button ticBtn;   
		public ToggleGroup toggleGroup;
		public List<Toggle> levelToggles;

		private int selectedLevel;

        // Use this for initialization
        void OnEnable(){
            incorrectInput.gameObject.SetActive(false);
        }

        void Update(){
			if (Input.anyKeyDown) {
					ticBtn.interactable = inputText.text.Length > 2;
			}
			if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)) { UpdateLevel ();CheckEnteredUsername(); }
        }  

        public void OnClickTicBtn(){
            PlayClickSound();
			UpdateLevel ();
            CheckEnteredUsername();
        }

		void UpdateLevel(){
			IEnumerator<Toggle> toggleEnum = toggleGroup.ActiveToggles().GetEnumerator();
			toggleEnum.MoveNext();
			Toggle toggle = toggleEnum.Current;
			selectedLevel = levelToggles.IndexOf (toggle);
		}

        void CheckEnteredUsername(){
            inputText.text = inputText.text.Trim();
			LoginController.GetController().SaveUsername(inputText.text.ToLower(),selectedLevel);
        }

        internal void ShowIncorrectInputAnimation(){
            ticBtn.interactable = false;
            ticBtn.enabled = false;
            incorrectInput.GetComponent<IncorrectUserAnimation>().ShowIncorrecrUserAnimation();
        }

        public void OnIncorrectInputAnimationEnd(){          
            ticBtn.interactable = true;
            ticBtn.enabled = true;
        }

        public void OnClickBack(){
            PlayClickSound();
            LoginController.GetController().GoBack();
        }

        public void PlayClickSound(){
            SoundController.GetController().PlayClickSound();
        }




    }
}