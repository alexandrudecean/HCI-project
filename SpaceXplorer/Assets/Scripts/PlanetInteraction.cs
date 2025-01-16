using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public GameObject quizUI; // Panel-ul pentru această planetă
    private static GameObject currentQuizUI; // Panel-ul activ curent

    private void OnMouseDown()
    {
        // Ascunde Panel-ul anterior dacă există
        if (currentQuizUI != null)
        {
            currentQuizUI.SetActive(false);
        }

        // Activează Panel-ul acestei planete
        quizUI.SetActive(true);
        currentQuizUI = quizUI;

        Debug.Log("Apăsat pe: " + gameObject.name);
    }

    // Funcție pentru a închide panel-ul
    public void CloseQuiz()
    {
        if (quizUI != null)
        {
            quizUI.SetActive(false);
            Debug.Log("Quiz-ul a fost închis!");
        }
    }
}
