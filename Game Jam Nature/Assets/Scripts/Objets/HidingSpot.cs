using UnityEngine;

public class HidingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] Transform player;
    Vector3 exitPos;
    bool currentlyHiding = false;
    public void Interact()
    {
        if (currentlyHiding != true)
        {
            Hide();
        }
        else
        {
            Exit();
        }
    }

    public void Hide()
    {
        exitPos = player.position;
        player.position = transform.position;
        PlayerMovement.playerMovementEnabled = false;
        currentlyHiding = true;
    }

    public void Exit()
    {
        player.position= exitPos;
        PlayerMovement.playerMovementEnabled = true;
        currentlyHiding = false;
    }
}
