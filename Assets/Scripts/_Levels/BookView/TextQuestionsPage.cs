using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.Scripts._Levels.BookView
{

    public class TextQuestionsPage : PageView
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private Text question;
        [SerializeField]
        private Toggle[] toggles;

        public override void OnClickTic()
        {
            BookView.GetBookView().SetTicButtonEnabled(false);
            if (CheckAnswer())
            {
                // todo -> right sound
                BookView.GetBookView().SaveStateOfCurrentPage();
                BookView.GetBookView().SetTicButtonInteractable(false);
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].interactable = false;
                }
                BookView.GetBookView().SetForwardArrowInteractable(true);
            }
            else
            {
                // todo -> wrong sound
            }
            BookView.GetBookView().SetTicButtonEnabled(true);
        }

        private bool CheckAnswer()
        {
            string optionSelected = "";
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    optionSelected = toggles[i].GetComponentInChildren<Text>().text;
                    break;
                } 
            }
            return BookView.GetBookView().CheckAnswer(optionSelected);
        }

        public override void OnPrevPage()
        {
        }

        public override void SetGeneralButtonsState()
        {
            BookView.GetBookView().SetTicButtonVisible(true);
            BookView.GetBookView().SetTicButtonInteractable(false);
            BookView.GetBookView().SetForwardArrowInteractable(false);
            BookView.GetBookView().SetBackwardArrowInteractable(true);
        }

        public override void ShowPage(Page page)
        {
            text.text = page.text;
            question.text = page.question;

            List<int> indexes = new List<int>(page.options.Length);
            int randIndex;
            for (int i = 0; i < page.options.Length; i++)
            {
                do
                {
                    randIndex = Random.Range(0, page.options.Length);

                } while (indexes.Contains(randIndex));

                toggles[randIndex].GetComponentInChildren<Text>().text = page.options[i].text;
                indexes.Add(randIndex);
                
            }

            if (BookView.GetBookView().IsCurrentPageResolved())
            {
                string correctAnswer = page.GetCorrectAnswer();
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].isOn = toggles[i].GetComponentInChildren<Text>().text == correctAnswer;
                    toggles[i].interactable = false;
                }
                BookView.GetBookView().SetForwardArrowInteractable(false);
            }
        }

    }
}