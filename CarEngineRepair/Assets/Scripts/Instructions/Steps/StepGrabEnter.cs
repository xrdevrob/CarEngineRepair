using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Instructions.Steps
{
    public class StepGrabEnter : MonoBehaviour
    {
        [Header("Derived")] 
        [SerializeField] private XRGrabInteractable xrGrabInteractable;
        [SerializeField] private int interactorValidationLayer;
        [SerializeField] private WorkflowController workflowController;

        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnGrabSelectEnter);
        }

        private void OnGrabSelectEnter(SelectEnterEventArgs eventArgs)
        {
            if (eventArgs.interactor.gameObject.layer != interactorValidationLayer) return;

            workflowController.NextStep();
        }

        private void OnDisable()
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnGrabSelectEnter);
        }
    }
}