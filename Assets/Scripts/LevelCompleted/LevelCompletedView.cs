using Assets.Scripts.App;
using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LevelCompleted
{
    public class LevelCompletedView : MonoBehaviour
    {

        [SerializeField] private Text correctAsnwersText;
        [SerializeField] private Text wrongAsnwersText;

        void OnEnable()
        {
            SoundController.GetController().PlayLevelCompleteSound();
        }

        public void OnClickAnotherBook()
        {
            SoundController.GetController().PlayClickSound();
            ViewController.GetController().LoadMainMenu();
        }


        public void SetAnswers(int correctAnswers, int wrongAnswers)
        {
            correctAsnwersText.text = " " + correctAnswers;
            wrongAsnwersText.text = " " + wrongAnswers;
        }
    }
}
