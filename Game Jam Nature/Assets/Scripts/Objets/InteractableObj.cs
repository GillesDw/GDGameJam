using UnityEngine;

public class InteractableObj : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject obj;
    public void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        obj.SetActive(true);

        Debug.Log("pick");
    }

    public void ReturnButton()
    {
        obj.SetActive(false);
    }
}
