using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public GameObject baseControllerGameobject;
    public GameObject uiControllerGameObject;

    public InputActionReference uiActivationReference;

    [Space]
    public UnityEvent onUIActivate;
    public UnityEvent onUICancel;

    private void OnEnable()
    {
        uiActivationReference.action.performed += UIModeActivate;
        uiActivationReference.action.canceled += UIModeCancel;
    }

    private void UIModeCancel(UnityEngine.InputSystem.InputAction.CallbackContext obj) => Invoke("DeactivateUIController", .1f);

    void DeactivateUIController() => onUICancel.Invoke();

    private void UIModeActivate(UnityEngine.InputSystem.InputAction.CallbackContext obj) => onUIActivate.Invoke();

    private void OnDisable()
    {
        uiActivationReference.action.performed -= UIModeActivate;
        uiActivationReference.action.canceled -= UIModeCancel;
    }
}