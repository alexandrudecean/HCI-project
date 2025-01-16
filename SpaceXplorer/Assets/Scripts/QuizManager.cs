using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText1;
    public Text questionText2; // Textul pentru informații despre planetă
    public Text planetInfoText;
    private PlanetQuizData currentQuizData;
    private int currentQuestionIndex;
    public GameObject quizPanel;

    public void SetQuizData(PlanetQuizData quizData)
    {
        currentQuizData = quizData;
        currentQuestionIndex = 0;
        planetInfoText.text = quizData.planetInfo; // Afișăm informațiile planetei
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < currentQuizData.questions.Count)
        {
            questionText1.text = currentQuizData.questions[currentQuestionIndex].question;
            questionText2.text = currentQuizData.questions[currentQuestionIndex].question;
        }
        else
        {
            Debug.Log("Quiz finalizat!");
            gameObject.SetActive(false); // Ascunde UI-ul când termină întrebările
        }
    }

    public void AnswerQuestion(bool answer)
    {
        if (currentQuizData.questions[currentQuestionIndex].correctAnswer == answer)
        {
            Debug.Log("Răspuns corect!");
        }
        else
        {
            Debug.Log("Răspuns greșit!");
        }

        currentQuestionIndex++;
        DisplayQuestion();
    }
    // Funcție pentru a închide panel-ul
    public void CloseQuiz()
    {
        if (quizPanel != null)
        {
            quizPanel.SetActive(false);
            Debug.Log("Panel-ul quiz-ului a fost închis!");
        }
    }
}
