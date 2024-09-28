using UnityEngine;

public class SurfaceDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Material _defaultMaterial;

    [ContextMenu("Test Casting")]
    public Material CastForSurface()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        Vector3 orientation = Vector3.down;
        float lenght = 2f;

        RaycastHit hitInfo;
        bool didHit = Physics.Raycast(position, orientation, out hitInfo, lenght, _layerMask);
        Debug.DrawRay(position, orientation * lenght, Color.green);

        if (didHit)
        {
            Debug.Log("HIT!!");
            MeshRenderer renderer = hitInfo.collider.GetComponent<MeshRenderer>();
            Material result = renderer.sharedMaterial;
            return result;


        }
        else
        {
            Debug.Log("NO HIT");
            return _defaultMaterial;
        }

    }
}
