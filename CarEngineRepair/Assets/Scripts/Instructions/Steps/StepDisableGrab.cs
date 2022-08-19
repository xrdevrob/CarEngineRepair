using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Instructions.Steps
{
    public class StepDisableGrab : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable xrGrabInteractable;

        private void Awake()
        {
            xrGrabInteractable.enabled = false;
        }
    }
}
