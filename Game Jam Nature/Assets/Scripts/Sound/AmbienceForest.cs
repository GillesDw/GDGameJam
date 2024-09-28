using UnityEngine;

public class AmbienceForest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
                GameManager.instance.AmbienceForest();
        }
    }
}
