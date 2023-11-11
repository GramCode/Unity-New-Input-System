using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();

        _input.Player.ColorChange.performed += ColorChange_performed;
        _input.Player.Drive.performed += Drive_performed;
        _input.Driving.Swap.performed += Swap_performed;
    }

    private void Swap_performed(InputAction.CallbackContext context)
    {
        _input.Driving.Disable();
        _input.Player.Enable();
    }

    private void Drive_performed(InputAction.CallbackContext context)
    {
        _input.Player.Disable();
        _input.Driving.Enable();
    }

    private void ColorChange_performed(InputAction.CallbackContext context)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void Update()
    {
        CalculateRotation();
        CalculateDriving();
    }

    private void CalculateRotation()
    {
        var rotate = _input.Player.Rotate.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * 30f * rotate);
    }

    private void CalculateDriving()
    {
        var drive = _input.Driving.DriveAround.ReadValue<Vector2>();
        transform.Translate(new Vector3(drive.x, 0, drive.y) * Time.deltaTime * 5f);
    }
}
