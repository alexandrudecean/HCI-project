using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject warningPanel; // Panel pentru warning

    public void StartGame()
    {
        warningPanel.SetActive(true); // Activează warning-ul
        gameObject.SetActive(false); // Ascunde meniul principal
    }

    public void QuitGame()
    {
        Application.Quit(); // Închide aplicația
        Debug.Log("Aplicația s-a închis.");
    }
}
