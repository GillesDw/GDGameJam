using UnityEditor.Sprites;
using UnityEngine;

public class EndGameInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.instance.EndOfTheGame();
    }
}
