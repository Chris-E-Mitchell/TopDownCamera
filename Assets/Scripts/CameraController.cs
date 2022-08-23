using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float edgeDetectionSize = 10f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float scrollZoomSpeed = 5f;
    [SerializeField] private bool simpleFOVZoom = true;
    [SerializeField] private float simpleFOVMax = 60f;
    [SerializeField] private float simpleFOVMin = 20f;

    private float targetFOV;

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

    private float zoomInput;
    public float ZoomInput
    {
        get { return zoomInput; }
        set { zoomInput = value; }
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

    private Vector2 moveInputMousePosition;
    public Vector2 MoveInputMousePosition
    {
        get { return moveInputMousePosition; }
        set { moveInputMousePosition = value; }
    }

    private Vector2 zoomInputMouse;
    public Vector2 ZoomInputMouse
    {
        get { return zoomInputMouse; }
        set { zoomInputMouse = value; }
    }

    private void Start()
    {
        if (virtualCamera == null)
        {
            Debug.LogWarning("Virtual Camera not assigned in " + name);
        }

        if (simpleFOVZoom)
        {
            targetFOV = Mathf.Clamp(virtualCamera.m_Lens.FieldOfView, simpleFOVMin, simpleFOVMax);
            virtualCamera.m_Lens.FieldOfView = targetFOV;
        }
    }

    private void LateUpdate()
    {
        MoveCamera();
        MoveCameraMouse();
        RotateCamera();
        ZoomCameraKeys();
        RotateCameraMouse();
        //EdgeDetectMove();
        ZoomCameraMouse();
    }

    private void MoveCamera()
    {
        transform.position += moveInput.y * moveSpeed * Time.deltaTime * transform.forward;
        transform.position += moveInput.x * moveSpeed * Time.deltaTime * transform.right;
    }

    private void RotateCamera()
    {
        transform.Rotate(rotateSpeed * rotationInput * Time.deltaTime * transform.up);
    }

    private void ZoomCameraKeys()
    {
        if (simpleFOVZoom)
        {
            if (zoomInput != 0)
            {
                targetFOV = virtualCamera.m_Lens.FieldOfView + (zoomInput * zoomSpeed * Time.deltaTime);
                targetFOV = Mathf.Clamp(targetFOV, simpleFOVMin, simpleFOVMax);
                virtualCamera.m_Lens.FieldOfView = targetFOV;
            }
        }
    }

    private void RotateCameraMouse()
    {
        transform.Rotate(rotateSpeed * rotationInputMouse.x * Time.deltaTime * transform.up);
    }

    private void MoveCameraMouse()
    {
        transform.position += -moveInputMouse.y * moveSpeed * Time.deltaTime * transform.forward;
        transform.position += -moveInputMouse.x * moveSpeed * Time.deltaTime * transform.right;
    }

    private void EdgeDetectMove()
    {
        if (moveInputMousePosition.y >= (Camera.main.pixelHeight - edgeDetectionSize))
        {
            transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }
        if (moveInputMousePosition.y <= edgeDetectionSize)
        {
            transform.position -= moveSpeed * Time.deltaTime * transform.forward;
        }
        if (moveInputMousePosition.x >= (Camera.main.pixelWidth - edgeDetectionSize))
        {
            transform.position += moveSpeed * Time.deltaTime * transform.right;
        }
        if (moveInputMousePosition.x <= edgeDetectionSize)
        {
            transform.position -= moveSpeed * Time.deltaTime * transform.right;
        }
    }

    private void ZoomCameraMouse()
    {
        if (simpleFOVZoom)
        {
            if (zoomInputMouse.y > 0)
            {
                targetFOV -= scrollZoomSpeed;
            }
            if (zoomInputMouse.y < 0)
            {
                targetFOV += scrollZoomSpeed;
            }

            targetFOV = Mathf.Clamp(targetFOV, simpleFOVMin, simpleFOVMax);

            float lerpSpeed = 10f;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, targetFOV, lerpSpeed * Time.deltaTime);
        }
    }
}
