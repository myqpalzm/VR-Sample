using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterControllerGravity : MonoBehaviour
{
    private CharacterController _characterController;
    private bool _isClimbing = false;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        ClimbProvider.ClimbActive += ClimbActive;
        ClimbProvider.ClimbInactive += ClimbInactive;
    }

    private void OnDestroy()
    {
        ClimbProvider.ClimbActive -= ClimbActive;
        ClimbProvider.ClimbInactive -= ClimbInactive;
    }

    private void FixedUpdate()
    {
        if (!_characterController.isGrounded && !_isClimbing)
            _characterController.SimpleMove(new Vector3());
    }

    private void ClimbActive()
    {
        _isClimbing = true;
    }

    private void ClimbInactive()
    {
        _isClimbing = false;
    }
}
