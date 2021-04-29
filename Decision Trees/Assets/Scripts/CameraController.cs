using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Text pause;
    [SerializeField] private Image crosshair;

    private float horizontalInput;
    private float verticalInput;
    private float mouseInputX;
    private float mouseInputY;
    private float currentRotationY;
    private float currentRotationX;

    public static bool blocked;

    private void Start()
    {
        currentRotationY = transform.eulerAngles.y;
        currentRotationX = transform.eulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
        blocked = false;
        pause.enabled = false;
        crosshair.enabled = true;
        Time.timeScale = 1;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pause.enabled = true;
                crosshair.enabled = false;
                blocked = true;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pause.enabled = false;
                crosshair.enabled = true;
                blocked = false;
            }
        }

        if (!blocked)
        {
            GetInput();
            HandleTranslation();
            HandleRotation();
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        mouseInputX = Input.GetAxis(MOUSE_X);
        mouseInputY = Input.GetAxis(MOUSE_Y);
    }
    private void HandleTranslation()
    {
        var moveVector = new Vector3(horizontalInput, 0f, verticalInput);
        var worldMoveVector = transform.TransformDirection(moveVector);
        worldMoveVector.y = 0f;
        transform.Translate(worldMoveVector.normalized * Time.deltaTime * moveSpeed, Space.World);
    }
    private void HandleRotation()
    {
        float yaw = mouseInputX * Time.deltaTime * rotationSpeed;
        currentRotationY += yaw;

        float pitch = mouseInputY * Time.deltaTime * rotationSpeed;
        currentRotationX -= pitch;
        currentRotationX = Mathf.Clamp(currentRotationX, -90, 90);
        transform.localRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
    }
}
