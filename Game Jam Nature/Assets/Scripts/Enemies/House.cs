using UnityEngine;

public class House : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovementTutorial.IsHiding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovementTutorial.IsHiding = false; 
    }
}
