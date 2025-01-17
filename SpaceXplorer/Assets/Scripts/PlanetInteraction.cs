using UnityEngine;
using UnityEngine.InputSystem; 

public class PlanetInteraction : MonoBehaviour
{
    [SerializeField] private GameObject quizUI;
    [SerializeField] private static GameObject currentQuizUI;

    private void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            HandleInput(Touchscreen.current.primaryTouch.position.ReadValue());
        }
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            HandleInput(Mouse.current.position.ReadValue());
        }
    }

    private void HandleInput(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject) 
            {
                if (currentQuizUI != null && currentQuizUI.activeSelf)
                {
                    return;
                }

                quizUI.SetActive(true);
                currentQuizUI = quizUI;
            }
        }
    }

    public void CloseQuiz()
    {
        if (quizUI != null)
        {
            quizUI.SetActive(false);
        }
    }
}
