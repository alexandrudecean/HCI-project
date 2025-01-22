using UnityEngine;

public class WarningUI : MonoBehaviour
{
    public GameObject gameObjects; 

    public void ContinueToGame()
    {
        gameObjects.SetActive(true); 
        WarningUI.Destroy(gameObject);
    }
}
