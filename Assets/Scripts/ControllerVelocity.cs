using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVelocity : MonoBehaviour
{
    [SerializeField] InputActionProperty m_velocityProperty;

    public Vector3 Velocity {get; private set;} = Vector3.zero;

    void Update()
    {
        Velocity = m_velocityProperty.action.ReadValue<Vector3>();
    }
}
