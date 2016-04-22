using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts._Levels.BookView
{

    public class TextPage : PageView
    {
        [SerializeField]
        private Text text;

        public override void OnClickTic(){}

        public override void OnPrevPage(){}

        public override void SetGeneralButtonsState()
        {
            BookView.GetBookView().SetTicButtonVisible(false);
            BookView.GetBookView().SetForwardArrowInteractable(true);
            BookView.GetBookView().SetBackwardArrowInteractable(true);
        }

        public override void ShowPage(Page page)
        {
            text.text = page.text;
        }
    }
}
