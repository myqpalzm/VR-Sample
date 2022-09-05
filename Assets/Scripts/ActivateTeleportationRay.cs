using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject rightTeleportation;

    public InputActionProperty rightActivate;

    public InputActionProperty rightCancel;

    private XRRayInteractor _xrRayInteractor;
    private LineRenderer _lineRenderer;
    private XRInteractorLineVisual _xrInteractorLineVisual;
    private GameObject _reticle;

    private void Awake()
    {
        _xrRayInteractor = rightTeleportation.GetComponent<XRRayInteractor>();
        _lineRenderer = rightTeleportation.GetComponent<LineRenderer>();
        _xrInteractorLineVisual = rightTeleportation.GetComponent<XRInteractorLineVisual>();
        _reticle = rightTeleportation.transform.Find("Reticle").gameObject;
    }

    private void Update()
    {
        bool toggle = rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f;

        _xrRayInteractor.enabled = toggle;
        _lineRenderer.enabled = toggle;
        _xrInteractorLineVisual.enabled = toggle;
        _reticle.SetActive(toggle);
    }
}
