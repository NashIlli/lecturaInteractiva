using UnityEngine;
using Assets.Scripts.App;

namespace Assets.Scripts.Login
{

    public class LoginController : MonoBehaviour
    {
        private static LoginController loginController;
        public LoginView loginView;
	

        void Awake(){
            if (loginController == null){
                loginController = this;
            }else if (loginController != this){
                Destroy(gameObject);
            }
        }

		public void SaveUsername(string username,int level){
            if(username != "" && username.Length > 2){

                AppController.GetController().SetUsername(username);
				ViewController.GetController ().StartGame(level);
            } else{
                loginView.ShowIncorrectInputAnimation();
            }

        }

        internal void GoBack() {
            ViewController.GetController().LoadCover();
        }

        public static LoginController GetController(){
            return loginController;
        }
    }
}
