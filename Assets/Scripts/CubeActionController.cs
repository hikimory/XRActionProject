using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeActionController : MonoBehaviour
{
    [SerializeField] InputActionReference m_toggleAction = null;
    [SerializeField] InputActionReference m_changeColorAction = null;

    private MeshRenderer _meshRenderer;

    private void Awake() 
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        m_toggleAction.action.performed += Toggle;
    }

    private void OnDestroy() 
    {
        m_toggleAction.action.performed -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext obj)
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_toggleAction.name + " " + m_toggleAction.action.phase);
        float value = m_changeColorAction.action.ReadValue<float>();
        UpdateColor(value);
    }

    private void UpdateColor(float value)
    {
        _meshRenderer.material.color = new Color(value, value, value);
    }
}
