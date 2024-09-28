using UnityEngine;

public class Ambience : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
                GameManager.instance.AmbienceCave();
        }
    }
}
