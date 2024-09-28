using UnityEngine;

public class FlashlightAnimation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 60;
    private void Update()
    {
        this.transform.Rotate(rotationSpeed, 0, 0);
    }
}
