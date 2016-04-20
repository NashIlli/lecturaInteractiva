using SimpleJSON;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

namespace Assets.Scripts._Levels.ReadTest
{

	public class ReadTestModel : LevelModel
    {
		private static Random rng = new Random();  

		private int questionCounter,correctAnswers,wrongAnswers,hints;
		private string currentAnswer;
		private List<Question> questions;
		private Question currentQuestion;
		private int[] correctAnswersByType;
		private int[] wrongAnswersByType;

		private string[,] answersByQuestionId;
		private int totalExercises;


		public ReadTestModel(int level){
			StartGame ();
			LoadExercises (level);
			answersByQuestionId = new string[totalExercises,2];
			ShuffleQuestionsByLevel (level);

		}

		public override void StartGame()
		{
			currentAnswer = "";

			questionCounter = -1;
			correctAnswers=0;
			wrongAnswers=0;
			hints=0;
			correctAnswersByType = new int[] {0,0,0,0};
			wrongAnswersByType = new int[] {0,0,0,0};
			questions = new List<Question> ();
		}

		void LoadExercises(int level){
			string exerciseFileName = "LecturaComprensiva"+(level+1).ToString();

			TextAsset JSONstring = Resources.Load(exerciseFileName) as TextAsset;
			JSONNode data = JSON.Parse(JSONstring.text);

			 totalExercises = data ["exercises"].Count;
			string paragraphText, questionText;
			string[] hintTexts,answerTexts;
			int questionType;


			for (int i = 0; i < totalExercises; i++) {
				
				paragraphText = data ["exercises"][i]["paragraph"];
				questionText = data ["exercises"][i]["questions"][0];

				hintTexts = GetStringArray(data ["exercises"][i]["hints"].AsArray);
				answerTexts = GetStringArray(data ["exercises"][i]["answers"].AsArray);
				questionType = data ["exercises"][i]["questionType"].AsInt;

				Question question = new Question (paragraphText, questionText, hintTexts, answerTexts, questionType,i);

				questions.Add (question);
//				Debug.Log (question.Paragraph+question.QuestionText);
			}


		}

		void ShuffleQuestionsByLevel(int level){
			List<Question> tempQuestions;
			switch(level){
			case 0:
			case 1:
			case 2:
				Shuffle (questions);
				break;
			//Randomize all questions except the last 4
			case 3:
				tempQuestions = new List<Question> ();
				for (int i = 0; i < totalExercises - 4; i++) {
					tempQuestions.Add (questions [i]);
				}
				Shuffle (tempQuestions);
				for (int j=totalExercises-4; j<totalExercises; j++) {
					tempQuestions.Add (questions [j]);
				}
				questions = tempQuestions;
				break;
			//Only randomize the first 4 questions
			case 4:
				tempQuestions = new List<Question> ();
				for (int i=0; i < 4; i++) {
					tempQuestions.Add (questions [i]);
				}
				Shuffle (tempQuestions);
				for (int j=4; j < totalExercises; j++) {
					tempQuestions.Add (questions [j]);
				}
				questions = tempQuestions;
				break;

			}


		}

		string[] GetStringArray(JSONArray jsonArray){
			
			string[] array = new string[jsonArray.Count];
			for (int i = 0; i <jsonArray.Count ; i++) {
				array [i] = jsonArray [i];
			}
			return array;
		}


		public override void NextChallenge()
        {
			questionCounter++;
			if (questionCounter < questions.Count) {
				currentQuestion = questions [questionCounter];
				currentAnswer = currentQuestion.AnswersTexts [0];
				Shuffle (currentQuestion.AnswersTexts);
			} else {
				ReadTestController.GetController ().EndGame ();
			}
        }

        public override void RestartGame()
        {
            currentAnswer = "";
        }

       

		public void LogAnswer(bool answer){
			//Data for Question/Answer CSV
			answersByQuestionId [currentQuestion.Id,0] = currentQuestion.QuestionText;
			answersByQuestionId [currentQuestion.Id,1]= (answer) ? "1" : "0";

			//Data for Global Indo CSV
			if (answer) {
				correctAnswers++;
//				correctAnswersByType [currentQuestion.GetType - 1]=correctAnswersByType[currentQuestion.GetType()-1]+1;
			} else {
				wrongAnswers++;
//				wrongAnswersByType [currentQuestion.GetType - 1]=wrongAnswersByType[currentQuestion.GetType()-1]+1;
			}
		}

		public void LogHint(){
			//TODO: Log hints
		}



        internal bool CheckAnswer(string answer)
        {
			return currentAnswer.Equals(answer);
        }

        internal string GetCurrentAnswer()
        {
            return currentAnswer;
        }

		public Question CurrentQuestion {
			get {
				return currentQuestion;
			}
		}


		static void Shuffle(List<Question> array)
		{	
			int n = array.Count;
			for (int i = 0; i < n; i++)
			{
				int r = i + (int)(Random.value * (n - i));
				Question t = array[r];
				array[r] = array[i];
				array[i] = t;
			}
		}

		static void Shuffle<T>(T[] array)
		{	

			int n = array.Length;
			for (int i = 0; i < n; i++)
			{
				int r = i + (int)(Random.value * (n - i));
				T t = array[r];
				array[r] = array[i];
				array[i] = t;
			}
		}

    }
}
