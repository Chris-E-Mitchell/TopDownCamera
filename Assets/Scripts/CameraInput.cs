using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInput : MonoBehaviour
{
    private CameraController cameraController;

    private void Start()
    {
        cameraController = GetComponent<CameraController>();
    }

    private void OnMove(InputValue value)
    {
        if (cameraController == null) { return; }

        Vector2 inputValue = value.Get<Vector2>();
        cameraController.MoveInput = inputValue;
    }

    private void OnRotate(InputValue value)
    {
        if (cameraController == null) { return; }

        float inputValue = value.Get<float>();
        cameraController.RotationInput = inputValue;
    }
}
