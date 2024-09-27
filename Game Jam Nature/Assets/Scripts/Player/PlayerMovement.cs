using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float speedRotation = 180f;
    [SerializeField] Vector3 _input;
    [SerializeField] Vector2 yLimit = new Vector2(-90, 90);
    [SerializeField] Camera _mainCamera;
    [SerializeField] float _targetRotation = 0;

    public static bool playerMovementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementEnabled)
        {
            _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.position += transform.rotation * _input * speed * Time.deltaTime;
        }
        else
        {
        }
        _targetRotation -= Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;
        _targetRotation = Mathf.Clamp(_targetRotation, yLimit.x, yLimit.y);
        transform.Rotate(0, Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime, 0);
        _mainCamera.transform.rotation = Quaternion.Euler(_targetRotation,
        _mainCamera.transform.rotation.eulerAngles.y, _mainCamera.transform.rotation.eulerAngles.z);
    }
}
