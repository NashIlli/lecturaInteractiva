using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System.Collections.Generic;

namespace Assets.Scripts.Login{

    public class LoginView : MonoBehaviour{

		public ToggleGroup toggleGroup;
		public List<Toggle> levelToggles;

		private int selectedLevel;


        void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)) OnClickBack();
            else if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)) { UpdateLevel(); }
        }  

        public void OnClickTicBtn(){
            PlayClickSound();
			UpdateLevel ();
            LoginController.GetController().OnClickTic();
        }

		void UpdateLevel(){
			IEnumerator<Toggle> toggleEnum = toggleGroup.ActiveToggles().GetEnumerator();
			toggleEnum.MoveNext();
			selectedLevel = levelToggles.IndexOf (toggleEnum.Current);
		}

        public void OnClickBack(){
            PlayClickSound();
            LoginController.GetController().GoBack();
        }

        public int GetSelectedLevel()
        {
            return selectedLevel;
        }

        public void PlayClickSound(){
            SoundController.GetController().PlayClickSound();
        }





    }
}