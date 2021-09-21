using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity _controllerVelocity = null;
    private MeshRenderer _meshRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _controllerVelocity = args.interactor.GetComponent<ControllerVelocity>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        _controllerVelocity = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if(isSelected)
        {
            if(updatePhase ==  XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                UpdateColorWithVelocity();
        }
    }

    private void UpdateColorWithVelocity()
    {
        Vector3 velocity = _controllerVelocity ? _controllerVelocity.Velocity : Vector3.zero;
        Color color = new Color(velocity.x, velocity.y, velocity.z);
        _meshRenderer.material.color = color;
    }
}
