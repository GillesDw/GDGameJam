using UnityEngine;

public class InteractableObj : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("pick");
    }

}
