using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts._Levels.BookView
{
    public class ImagePage : PageView
    {
        [SerializeField]
        private Image image;

        public override void OnClickTic() {}
        public override void OnPrevPage(){}

        public override void ShowPage(Page page)
        {
            image.sprite = BookView.LoadSprite("Images/" + page.img);
        }

        internal override void ShowHint(string pista)
        {
            
        }

        public override void SetGeneralButtonsState()
        {
            BookView.GetBookView().SetTicButtonVisible(false);
            BookView.GetBookView().SetForwardArrowInteractable(true);
            BookView.GetBookView().SetBackwardArrowInteractable(true);
        }
    }

}
