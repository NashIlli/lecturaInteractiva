using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Sound;
using Random = UnityEngine.Random;

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
                SoundController.GetController().PlayRightAnswerSound();
                BookView.GetBookView().SaveStateOfCurrentPage();
                BookView.GetBookView().SetTicButtonInteractable(false);
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].GetComponentsInChildren<Image>()[1].color = toggles[i].isOn
                        ? new Color32(0, 255, 65, 115)
                        : new Color32(255, 152, 0, 115);
                    toggles[i].interactable = false;
                    
                }
                BookView.GetBookView().SetForwardArrowInteractable(true);
                BookView.GetBookView().SetHintButtonInteractble(false);
            }
            else
            {
                foreach (var toggle in toggles)
                {
                    toggle.GetComponentsInChildren<Image>()[1].color = toggle.isOn
                        ? new Color32(255, 0, 0, 121)
                        : new Color32(255, 152, 0, 115);
                }
                SoundController.GetController().PlayWrongSound();
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

            bool resolved = BookView.GetBookView().IsCurrentPageResolved();
            {
                string correctAnswer = page.GetCorrectAnswer();
                for (int i = 0; i < toggles.Length; i++)
                {
                   
                    toggles[i].isOn = resolved && toggles[i].GetComponentInChildren<Text>().text == correctAnswer;
                    
                    toggles[i].interactable = !resolved;
                }
                BookView.GetBookView().SetForwardArrowInteractable(resolved);
                //BookView.GetBookView().SetTicButtonInteractable(!resolved);
            }
            if (resolved)
            {
                
            
                BookView.GetBookView().SetTicButtonInteractable(false);
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].GetComponentsInChildren<Image>()[1].color = toggles[i].isOn
                        ? new Color32(0, 255, 65, 115)
                        : new Color32(255, 152, 0, 115);
                }

            }

        }

        internal override void ShowHint(string pista)
        {
            int hintIndex = text.text.IndexOf(pista, StringComparison.Ordinal);
            int hintLength = pista.Length;

            string start = text.text.Substring(0, hintIndex);
            string middle = text.text.Substring(hintIndex, hintLength);
            string end = text.text.Substring(hintIndex + hintLength, text.text.Length - (hintIndex + hintLength));

            text.text = start + "<color=#FF812CFF>" + middle + "</color>" + end;

        }

        public void OnToggleClick()
        {
            SoundController.GetController().PlayClickSound();
            foreach (var toggle in toggles)
            {
                toggle.GetComponentsInChildren<Image>()[1].color = new Color32(255, 152, 0, 115);
            }
            for (int i = 0; i < toggles.Length; i++)
            {
                
                if (toggles[i].isOn)
                {
                    BookView.GetBookView().SetTicButtonInteractable(true);
                    return;
                }
            }
            BookView.GetBookView().SetTicButtonInteractable(false);
        }

    }
}