using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cover {

    public class CoverScreen : MonoBehaviour {

        public CoverView coverView;

        public Text startText;
        public Text aboutText;

        public void OnClickStartBtn()
        {
            coverView.ClickSound();
            CoverController.GetController().StartGame();
        }

        public void OnClickOxBtn(){
            coverView.ClickSound();
            coverView.ShowOx();
            gameObject.SetActive(false);
        }   

        public void OnClickAboutBtn(){
            coverView.ClickSound();
            coverView.ShowAbout();
            gameObject.SetActive(false);
        }       

        public void OnClickArgentineBtn()
        {
            
           coverView.ClickSound();
        }    

        public void OnClickBritishBtn()
        {
            
            coverView.ClickSound();
        }

        public void ClickSound()
        {
            coverView.ClickSound();
        }


    }
}
