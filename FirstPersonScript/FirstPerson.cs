using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float speed = 5f;
    public float speedRotation = 180f;
    public Vector3 _input;
    public Vector2 yLimit = new Vector2(-20, 20);
    public Camera _mainCamera;
    public float _targetRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _targetRotation -= Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;
        _targetRotation = Mathf.Clamp(_targetRotation, yLimit.x, yLimit.y);
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += transform.rotation * _input * speed * Time.deltaTime;
        transform.Rotate(0, Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime, 0);
        _mainCamera.transform.rotation = Quaternion.Euler(_targetRotation,
            _mainCamera.transform.rotation.eulerAngles.y, _mainCamera.transform.rotation.eulerAngles.z);

    }
}
