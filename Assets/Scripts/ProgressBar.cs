using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private SliderInputActions _input;

    private bool _startFilling = false;

    private Slider _slider;

    void Start()
    {

        _input = new SliderInputActions();
        _input.ProgressBar.Enable();

        _input.ProgressBar.Fill.started += Fill_started;

        _input.ProgressBar.Fill.canceled += Fill_canceled;

        _slider = GetComponent<Slider>();

        if (_slider == null)
            Debug.LogError("UI Slider is NULL");
    }

    private void Fill_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _startFilling = true;
    }

    private void Fill_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _startFilling = false;
    }

    private void Update()
    {
        if (_startFilling)
        {
            _slider.value += (1.0f * Time.deltaTime) / 3;
        }
        else
        {
            if (_slider.value > 0)
                _slider.value -= (1.0f * Time.deltaTime) / 3;
        }
    }

}
