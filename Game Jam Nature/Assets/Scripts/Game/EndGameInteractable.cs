using UnityEditor.Sprites;
using UnityEngine;

public class EndGameInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collision collision)
    {
        if(DNAManager.currentDnaCount < 1)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.EndOfTheGame();
            }
        }
    }
}
