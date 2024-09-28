using UnityEngine;

public class InteractableObj : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject obj;
    public void Interact()
    {
        obj.SetActive(true);

        Debug.Log("pick");
    }

}
