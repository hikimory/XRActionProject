using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImprovedHandController : MonoBehaviour
{
    [SerializeField] InputActionReference m_controllerActionTrigger;
    [SerializeField] InputActionReference m_controllerActionGrip;

    private Animator _handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        m_controllerActionGrip.action.performed += GripPress;
        m_controllerActionTrigger.action.performed += TriggerPress;

        _handAnimator = GetComponent<Animator>();
    }

    private void TriggerPress(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());

    private void GripPress(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Grip", obj.ReadValue<float>());

    // Update is called once per frame
    void Update()
    {
        
    }
}
