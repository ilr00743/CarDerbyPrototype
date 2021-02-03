using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorModeCamera : MonoBehaviour
{
    [Header("Look Sensitivity")]
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;

    [Header("Clamping")]
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    [Header("Spectator")]
    [SerializeField] private float _moveSpeed;

    private float _rotationX;
    private float _rotationY;

    public void Start() 
    {   
        Cursor.lockState = CursorLockMode.None;   
    }

    public void LateUpdate() 
    {
        _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;
        _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;

        _rotationY = Mathf.Clamp(_rotationY, _minY, _maxY);

        transform.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0);

        float x = Input.GetAxis("Horizontal");
        float y = 0;
        float z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.E))
        {
            y = 1;
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            y = -1;
        }

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}