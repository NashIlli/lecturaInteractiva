using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts.App;
using Assets.Scripts.Sound;

namespace Assets.Scripts._Levels.BookView
{

    public class BookView : MonoBehaviour
    {
        private static BookView bookView;

        [SerializeField]
        private Button forwardArrow;
        [SerializeField]
        private Button backwardArrow;
        [SerializeField]
        private Button ticButton;
        [SerializeField]
        private Button hintButton;
        [SerializeField]
        private PageView[] pages;

        private int currentPage;
        private Book book;
        private bool[] pagesResolved;
        private bool[] hintShowed;

        private int wrongAnswers;
        private int correctAnswers;



        void Awake()
        {
            if (bookView == null) bookView = this;
            else if (bookView != this) Destroy(this);
            
        }

        public void StartBook(Book book)
        {
            pagesResolved = new bool[book.pages.Length];
            hintShowed = new bool[book.pages.Length];
            currentPage = 0;
            this.book = book;
            ShowPage(0);
        }

        private void ShowPage(int indexPage)
        {
            pages[book.pages[currentPage].tipo - 1].gameObject.SetActive(false);
            currentPage = indexPage;
            pages[book.pages[indexPage].tipo - 1].gameObject.SetActive(true);
            pages[book.pages[indexPage].tipo - 1].GetComponentInChildren<PageView>().ShowPage(book.pages[currentPage]);
            backwardArrow.gameObject.SetActive(currentPage > 0);
            hintButton.interactable = book.pages[currentPage].HasClue() && !hintShowed[currentPage] && !IsCurrentPageResolved();
            if(hintShowed[currentPage]) pages[book.pages[currentPage].tipo - 1].ShowHint(book.pages[currentPage].pista);;
        }

        internal void SetHintButtonInteractble(bool v)
        {
            hintButton.interactable = v;
        }

        internal void SetForwardArrowInteractable(bool v)
        {
            forwardArrow.interactable = v;
        }

        internal void SaveStateOfCurrentPage()
        {
            pagesResolved[currentPage] = true;
        }


        internal void SetBackwardArrowInteractable(bool v)
        {
            backwardArrow.interactable = v;
        }

        internal void SetTicButtonVisible(bool v)
        {
            ticButton.gameObject.SetActive(v);
        }

        internal void SetTicButtonInteractable(bool v)
        {
            ticButton.interactable = v;
        }

        public static BookView GetBookView()
        {
            return bookView;
        }

        internal void SetTicButtonEnabled(bool v)
        {
            ticButton.enabled = v;
        }

        public static Sprite LoadSprite(string path)
        {
            Debug.Log(path);

            return Resources.Load<Sprite>(path.Substring(0, path.Length - 4));
            
        }

        internal bool CheckAnswer(string optionSelected)
        {
            if (book.pages[currentPage].GetCorrectAnswer() == optionSelected)
            {
                correctAnswers++;
                return true;
            }
            else
            {
                wrongAnswers++;
                return false;
            }
        }

        internal bool IsCurrentPageResolved()
        {
            return pagesResolved[currentPage];
        }

        public void OnClickBackwardArrow()
        {
            SoundController.GetController().PlayClickSound();
            ShowPage(currentPage-1);
        }

        public void OnClickForwardArrow()
        {
            SoundController.GetController().PlayClickSound();
            if (book.pages.Length - 1 > currentPage) ShowPage(currentPage+1);
            else ViewController.GetController().LoadLevelCompleted(correctAnswers, wrongAnswers);
        }

        public void OnClickTicButton()
        {
            SoundController.GetController().PlayClickSound();
            pages[book.pages[currentPage].tipo - 1].OnClickTic();
        }

        public void OnClickHintButton()
        {
            SoundController.GetController().PlayClickSound();
            hintButton.interactable = false;
            hintShowed[currentPage] = true;
            pages[book.pages[currentPage].tipo - 1].ShowHint(book.pages[currentPage].pista);
        }

        public void OnClickMenuBtn()
        {
            SoundController.GetController().PlayClickSound();
            ViewController.GetController().ShowInGameMenu();
        }
    }
}
