using UnityEngine;
using Assets.Scripts.App;
using System;

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

        internal void GoBack() {
            ViewController.GetController().LoadCover();
        }

        public static LoginController GetController(){
            return loginController;
        }

        internal void OnClickTic()
        {
            AppController.GetController().LoadBooks(loginView.GetSelectedLevel());
            ViewController.GetController().LoadMainMenu();
        }
    }
}
