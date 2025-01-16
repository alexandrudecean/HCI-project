using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject question1;
    [SerializeField] private GameObject question2;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject fact;
    [SerializeField] private Text responseText;
    [SerializeField] private bool isFirstTrueButtonCorrect;
    [SerializeField] private bool isSecondTrueButtonCorrect;

    public void Start()
    {
        InitializeButtons(question1, 1, isFirstTrueButtonCorrect);
        InitializeButtons(question2, 2, isSecondTrueButtonCorrect);

        question1.SetActive(true);
        question2.SetActive(false);
        responseText.gameObject.SetActive(false);
        closeButton.SetActive(false);
        fact.SetActive(false);
    }

    void InitializeButtons(GameObject questionObject, int questionNumber, bool isTrueButtonCorrect)
    {
        Transform buttonContainer = questionObject.transform.Find("QuestionButtons");

        Button buttonTrue = buttonContainer.Find("ButtonTrue").GetComponent<Button>();
        Button buttonFalse = buttonContainer.Find("ButtonFalse").GetComponent<Button>();

        buttonTrue.onClick.AddListener(() => HandleAnswer(isTrueButtonCorrect, questionNumber));
        buttonFalse.onClick.AddListener(() => HandleAnswer(!isTrueButtonCorrect, questionNumber));
    }

    void HandleAnswer(bool isCorrect, int questionNumber)
    {
        if (isCorrect)
        {
            responseText.text = "Corect!";
            responseText.color = new Color(0, 1, 0, 1);
        }
        else
        {
            responseText.text = "Incorect!";
            responseText.color = new Color(1, 0, 0, 1);
        }

        responseText.gameObject.SetActive(true);

        if (questionNumber == 1)
        {
            question1.SetActive(false);
            StartCoroutine(ProceedToNextQuestion(question2));
        }
        else if (questionNumber == 2)
        {
            question2.SetActive(false);
            StartCoroutine(ShowCloseButton());
        }
    }

    IEnumerator ProceedToNextQuestion(GameObject nextQuestion)
    {
        yield return new WaitForSeconds(2f);

        responseText.gameObject.SetActive(false);

        nextQuestion.SetActive(true);
    }

    IEnumerator ShowCloseButton()
    {
        yield return new WaitForSeconds(2f);

        responseText.gameObject.SetActive(false);

        fact.SetActive(true);

        closeButton.SetActive(true);
    }
}
