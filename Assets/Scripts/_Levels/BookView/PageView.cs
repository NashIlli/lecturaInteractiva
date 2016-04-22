using UnityEngine;
using System.Collections;
using Assets.Scripts._Levels;

namespace Assets.Scripts._Levels.BookView
{

    public abstract class PageView : MonoBehaviour
    {

        public abstract void OnClickTic();
        public abstract void OnPrevPage();
        public abstract void SetGeneralButtonsState();
        public abstract void ShowPage(Page page);

        void OnEnable()
        {
            SetGeneralButtonsState();
        }

        public void ShowBeginLeft()
        {

        }

        public void ShowBeginRight()
        {

        }
    }
}
