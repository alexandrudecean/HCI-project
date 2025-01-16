using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public void CloseParentPanel()
    {
        // Dezactivează obiectul părinte al butonului
        if (transform.parent != null)
        {
            transform.parent.parent.gameObject.SetActive(false);
            Debug.Log("Panel-ul părinte a fost ascuns!");
        }
        else
        {
            Debug.LogWarning("Butonul nu are un părinte!");
        }
    }
}
