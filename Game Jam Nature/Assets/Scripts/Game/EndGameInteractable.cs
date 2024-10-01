using UnityEngine;

public class EndGameInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(DNAManager.currentDnaCount > 0)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.EndOfTheGame();
            }
        }
    }
}
