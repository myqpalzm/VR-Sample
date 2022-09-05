using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbProvider : MonoBehaviour
{
    public static event Action ClimbActive;
    public static event Action ClimbInactive;
    
    public CharacterController characterController;
    public InputActionProperty leftVelocity;
    public InputActionProperty rightVelocity;

    private bool _rightActive = false;
    private bool _leftActive = false;

    private void Start()
    {
        XRDirectClimbInteractor.ClimbHandActivated += HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated += HandDeactivated;
    }

    private void OnDestroy()
    {
        XRDirectClimbInteractor.ClimbHandActivated -= HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated -= HandDeactivated;
    }

    private void HandActivated(string controllerName)
    {
        if (controllerName == "LeftHand Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }

        ClimbActive?.Invoke();
    }

    private void HandDeactivated(string controllerName)
    {
        if (_rightActive && controllerName == "RightHand Controller")
        {
            _rightActive = false;
            ClimbInactive?.Invoke();
        }
        else if (_leftActive && controllerName == "LeftHand Controller")
        {
            _leftActive = false;
            ClimbInactive?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (_rightActive || _leftActive)
            Climb();
    }

    private void Climb()
    {
        Vector3 velocity = _leftActive
            ? leftVelocity.action.ReadValue<Vector3>()
            : rightVelocity.action.ReadValue<Vector3>();

        characterController.Move(characterController.transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
