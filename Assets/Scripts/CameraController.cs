using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    private Vector2 moveInput;
    public Vector2 MoveInput
    {
        get { return moveInput; }
        set { moveInput = value; }
    }

    private float rotationInput;
    public float RotationInput
    {
        get { return rotationInput; }
        set { rotationInput = value; }
    }

    private void LateUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    private void MoveCamera()
    {
        transform.position += transform.forward * moveInput.y * moveSpeed * Time.deltaTime;
        transform.position += transform.right * moveInput.x * moveSpeed * Time.deltaTime;
    }

    private void RotateCamera()
    {
        transform.Rotate(transform.up * rotationInput * rotateSpeed * Time.deltaTime);
    }
}
