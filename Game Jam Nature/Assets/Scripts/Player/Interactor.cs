using UnityEngine;
interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionSrc;
    [SerializeField] float interactionRange;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactionSrc.position, interactionSrc.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, interactionRange)) { 
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
        }
    }
}
