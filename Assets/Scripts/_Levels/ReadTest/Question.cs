using System;

namespace Assets.Scripts._Levels.ReadTest
{

	public class Question
	{

		private string paragraphText,questionText;
		private string[] hintTexts,answersTexts;
		private int questionType;
		private int id;



		public Question (string paragraph,string question,string[] hints,string[] answers,int type,int id)
		{
			paragraphText = paragraph;
			questionText = question;
			hintTexts = hints;
			answersTexts = answers;
			questionType = type;
			this.id = id;
		}

		public string[] HintTexts {
			get {
				return hintTexts;
			}
		}

		public string[] AnswersTexts {
			get {
				return answersTexts;
			}
		}

		public string Paragraph {
			get {
				return paragraphText;
			}
		}

		public string QuestionText {
			get {
				return questionText;
			}
		}



		public int QuestionType {
			get {
				return questionType;
			}
		}

		public int Id {
			get {
				return id;
			}
		}


	}
}

