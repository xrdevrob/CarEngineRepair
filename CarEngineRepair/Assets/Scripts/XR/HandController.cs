using UnityEngine;
using UnityEngine.InputSystem;

namespace XR
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Animator handAnimator;
        [SerializeField] private InputActionReference triggerActionRef;
        [SerializeField] private InputActionReference gripActionRef;

        private static int _triggerAnimation = Animator.StringToHash("Trigger");
        private static int _gripAnimation = Animator.StringToHash("Grip");

        private void Update()
        {
            float triggerValue = triggerActionRef.action.ReadValue<float>();
            handAnimator.SetFloat(_triggerAnimation, triggerValue);

            float gripValue = gripActionRef.action.ReadValue<float>();
            handAnimator.SetFloat(_gripAnimation, gripValue);
        }
    }
}
