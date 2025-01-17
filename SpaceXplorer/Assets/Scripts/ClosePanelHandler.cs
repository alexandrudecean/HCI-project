using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public void CloseParentPanel()
    {
        if (transform.parent != null)
        {
            transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
        }
    }
}
