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

    private Vector2 rotationInputMouse;
    public Vector2 RotationInputMouse
    {
        get { return rotationInputMouse; }
        set { rotationInputMouse = value; }
    }

    private Vector2 moveInputMouse;
    public Vector2 MoveInputMouse
    {
        get { return moveInputMouse; }
        set { moveInputMouse = value; }
    }

    private void LateUpdate()
    {
        MoveCamera();
        MoveCameraMouse();
        RotateCamera();
        RotateCameraMouse();
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

    private void RotateCameraMouse()
    {
        transform.Rotate(transform.up * rotationInputMouse.x * rotateSpeed * Time.deltaTime);
    }

    private void MoveCameraMouse()
    {
        transform.position += transform.forward * -moveInputMouse.y * moveSpeed * Time.deltaTime;
        transform.position += transform.right * -moveInputMouse.x * moveSpeed * Time.deltaTime;
    }
}
