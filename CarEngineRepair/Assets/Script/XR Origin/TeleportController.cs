using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameobject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void OnEnable()
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(UnityEngine.InputSystem.InputAction.CallbackContext obj) => Invoke("DeactivateTeleporter", .1f);

    void DeactivateTeleporter() => onTeleportCancel.Invoke();

    private void TeleportModeActivate(UnityEngine.InputSystem.InputAction.CallbackContext obj) => onTeleportActivate.Invoke();

    private void OnDisable()
    {
        teleportActivationReference.action.performed -= TeleportModeActivate;
        teleportActivationReference.action.canceled -= TeleportModeCancel;
    }
}