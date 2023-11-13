using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private SphereInputActions _input;
    private bool _jumped = false;

    void Start()
    {
        _input = new SphereInputActions();
        _input.Sphere.Enable();

        _input.Sphere.Jump.performed += Jump_performed;
        _input.Sphere.Jump.canceled += Jump_canceled;
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!_jumped)
        {
            var jumpForce = context.duration;
            GetComponent<Rigidbody>().AddForce(Vector3.up * (15 * (float)jumpForce), ForceMode.Impulse);
        }
        _jumped = false;

        Debug.Log("Duration: " + context.duration);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _jumped = true;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 15f, ForceMode.Impulse);
    }

}
