using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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
        private GameObject[] pages;

        private int currentPage;
        private Book book;
        private bool[] pagesResolved;



        void Awake()
        {
            if (bookView == null) bookView = this;
            else if (bookView != this) Destroy(this);
            
        }

        public void StartBook(Book book)
        {
            pagesResolved = new bool[book.pages.Length];
            currentPage = 0;
            this.book = book;
            ShowPage(0);
        }

        private void ShowPage(int indexPage)
        {
            pages[book.pages[currentPage].tipo - 1].SetActive(false);
            currentPage = indexPage;
            pages[book.pages[indexPage].tipo - 1].SetActive(true);
            pages[book.pages[indexPage].tipo - 1].GetComponentInChildren<PageView>().ShowPage(book.pages[currentPage]);
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
            return Resources.Load<Sprite>(path);
            
        }

        internal bool CheckAnswer(string optionSelected)
        {
            return book.pages[currentPage].GetCorrectAnswer() == optionSelected;
        }

        internal bool IsCurrentPageResolved()
        {
            return pagesResolved[currentPage];
        }
    }
}
