using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Create a reference for the input actions
    private PlayerInputActions _input;

    void Start()
    {
        //Instantiate input actions
        _input = new PlayerInputActions();
        //Enable the Dog input action map
        _input.Dog.Enable();
        //Register perform action
        _input.Dog.Bark.performed += Bark_performed;
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Action Performed!");
        Debug.Log("Context: " + context);
    }
}
