using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts._Levels.BookView
{

    public class ImageTextPage : PageView
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Text text;

        public override void OnClickTic() {}

        public override void OnPrevPage(){}

        public override void SetGeneralButtonsState()
        {
            BookView.GetBookView().SetTicButtonVisible(false);
            BookView.GetBookView().SetForwardArrowInteractable(true);
            BookView.GetBookView().SetBackwardArrowInteractable(true);
        }

        public override void ShowPage(Page page)
        {
            image.sprite = BookView.LoadSprite("Images/" + page.img);
            text.text = page.text;
        }

        internal override void ShowHint(string pista)
        {
            
        }
    }
}
