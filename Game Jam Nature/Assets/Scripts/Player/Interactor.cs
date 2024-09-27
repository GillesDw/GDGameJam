using UnityEngine;
interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionSrc;
    [SerializeField] float interactionRange;
    [SerializeField] Camera camera;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(camera.transform.position, camera.transform.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, interactionRange)) { 
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
        }
    }
}
