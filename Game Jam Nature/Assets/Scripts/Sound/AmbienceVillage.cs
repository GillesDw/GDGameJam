using UnityEngine;

public class AmbienceVillage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
                GameManager.instance.AmbienceVillage();
        }
    }
}
