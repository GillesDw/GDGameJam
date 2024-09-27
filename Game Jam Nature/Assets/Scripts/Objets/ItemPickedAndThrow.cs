using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickedAndThrow : MonoBehaviour, IInteractable
{
    [SerializeField] Transform hand;
    [SerializeField] Camera cam;
    float moveSpeed = 20;
    bool picked = false;
    Rigidbody rb;
    public void Interact()
    {
        picked = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Pick()
    {
        rb.isKinematic = true;
        transform.position = hand.position;
    }

    public void Update()
    {
        if(picked)
        {
            Pick();
            if (Input.GetMouseButtonDown(1))
            {
                rb.isKinematic = false;
                rb.AddForce(cam.transform.forward * moveSpeed * 50f, ForceMode.Force);
                picked = false;
            }
        }
    }
}
