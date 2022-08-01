using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Animator handAnimator;
        [SerializeField] private InputActionReference triggerActionReference;
        [SerializeField] private InputActionReference gripActionReference;
        private static readonly int Trigger = Animator.StringToHash("Trigger");
        private static readonly int Grab = Animator.StringToHash("Grab");

        private void OnEnable()
        {
            triggerActionReference.action.performed += Trigger_Performed;
            triggerActionReference.action.canceled += Trigger_Canceled;

            gripActionReference.action.performed += Grip_Performed;
            gripActionReference.action.canceled += Grip_Canceled;
        }

        private void OnDisable()
        {
            triggerActionReference.action.performed -= Trigger_Performed;
            triggerActionReference.action.canceled -= Trigger_Canceled;
            
            gripActionReference.action.performed -= Grip_Performed;
            gripActionReference.action.canceled -= Grip_Canceled;
        }

        private void Trigger_Performed(InputAction.CallbackContext obj) => handAnimator.SetBool(Trigger, true);

        private void Trigger_Canceled(InputAction.CallbackContext obj) => handAnimator.SetBool(Trigger, false);

        private void Grip_Performed(InputAction.CallbackContext obj) => handAnimator.SetBool(Grab, true);

        private void Grip_Canceled(InputAction.CallbackContext obj) => handAnimator.SetBool(Grab, false);
    }
}
