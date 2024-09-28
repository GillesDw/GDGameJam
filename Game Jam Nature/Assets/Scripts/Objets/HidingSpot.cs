using UnityEngine;

public class HidingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] Transform player;
    Vector3 exitPos;
    bool currentlyHiding = false;
    [SerializeField] Rigidbody playerRb;
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
        GameManager.instance.DoorSfx();
        exitPos = player.position;
        playerRb.isKinematic = true;
        player.position = transform.position;
        PlayerMovementTutorial.playerMovementEnabled = false;
        currentlyHiding = true;
        PlayerMovementTutorial.IsHiding = true;
    }

    public void Exit()
    {
        GameManager.instance.DoorSfx();
        player.position= exitPos;
        playerRb.isKinematic = false;
        PlayerMovementTutorial.playerMovementEnabled = true;
        currentlyHiding = false;
        PlayerMovementTutorial.IsHiding = false;
    }
}
