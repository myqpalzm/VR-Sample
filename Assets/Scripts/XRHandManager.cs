using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHandManager : MonoBehaviour
{
    [SerializeField] private InputActionProperty rightTeleportActivate;
    
    private XRRayInteractor _leftRayInteractor;
    private LineRenderer _leftLineRenderer;
    private XRInteractorLineVisual _leftInteractorLineVisual;
    
    private XRRayInteractor _rightRayInteractor;
    private LineRenderer _rightLineRenderer;
    private XRInteractorLineVisual _rightInteractorLineVisual;

    private void Awake()
    {
        GameObject leftHand = GameObject.Find("LeftHand Controller");
        GameObject rightHand = GameObject.Find("RightHand Controller");

        _leftRayInteractor = leftHand.GetComponent<XRRayInteractor>();
        _leftLineRenderer = leftHand.GetComponent<LineRenderer>();
        _leftInteractorLineVisual = leftHand.GetComponent<XRInteractorLineVisual>();
        
        _rightRayInteractor = rightHand.GetComponent<XRRayInteractor>();
        _rightLineRenderer = rightHand.GetComponent<LineRenderer>();
        _rightInteractorLineVisual = rightHand.GetComponent<XRInteractorLineVisual>();

        _leftRayInteractor.enabled = false;
        _leftLineRenderer.enabled = false;
        _leftInteractorLineVisual.enabled = false;
    }

    private void Update()
    {
        if (rightTeleportActivate.action.ReadValue<float>() > 0.1f)
        {
            ToggleRightTeleportationRay(true);
        }
        else
        {
            ToggleRightTeleportationRay(false);
        }
    }
    
    public void ToggleRightTeleportationRay(bool toggle)
    {
        _rightRayInteractor.enabled = toggle;
        _rightLineRenderer.enabled = toggle;
        _rightInteractorLineVisual.enabled = toggle;
    }
}
