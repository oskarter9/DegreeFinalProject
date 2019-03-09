using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float MouseSensitivity;
    public Interactable focus;

    [SerializeField] private Transform _playerBody;

    private float _xAxisClamp;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = GetComponentInChildren<TwinCameraController>()._activeCamera;
        LockCursor();
        _xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();

        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SetFocus(interactable);
                }
            }
            else
            {
                RemoveFocus();
            }
        }
        
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

        _xAxisClamp += mouseY;

        if (_xAxisClamp > 90.0f)
        {
            _xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (_xAxisClamp < -90.0f)
        {
            _xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.localEulerAngles;
        eulerRotation.x = value;
        transform.localEulerAngles = eulerRotation;
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus!= null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}
