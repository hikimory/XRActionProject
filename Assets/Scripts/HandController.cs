using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{

    [SerializeField] private InputActionAsset m_actionAsset;
    [SerializeField] private string m_controllerName;
    [SerializeField] private string m_actionNameTrigger;
    [SerializeField] private string m_actionNameGrip;
    public InputActionReference actionReference;
    private InputActionMap _actionMap;
    private InputAction _inputActionTrigger;
    private InputAction _inputActionGrip;

    private Animator _handAnimator;

    private void Awake() 
    {
        _actionMap = m_actionAsset.FindActionMap(m_controllerName);
        _inputActionGrip = _actionMap.FindAction(m_actionNameGrip);
        _inputActionTrigger = _actionMap.FindAction(m_actionNameTrigger);

        _handAnimator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        _inputActionGrip.Enable();
        _inputActionTrigger.Enable();
    }

    private void OnDisable() 
    {
        _inputActionGrip.Disable();
        _inputActionTrigger.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        var gripValue = _inputActionGrip.ReadValue<float>();
        var triggerValue = _inputActionTrigger.ReadValue<float>();

        _handAnimator.SetFloat("Grip", gripValue);
        _handAnimator.SetFloat("Trigger", triggerValue);
    }
}
