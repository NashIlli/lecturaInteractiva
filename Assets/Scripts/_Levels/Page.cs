using UnityEngine;
using System;

namespace Assets.Scripts._Levels
{

    [Serializable]
    public class Page
    {

        public int tipo;
        public string img;
        public string text;
        public string pista;
        public string question;

        public Option[] options;


        internal string GetCorrectAnswer()
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].isCorrect) return options[i].text;
            }
            return "error";
        }

        public bool HasClue()
        {
            return text != null && pista != null && text.Contains(pista);
        }
    }
}
