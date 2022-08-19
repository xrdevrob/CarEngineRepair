using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Instructions.Steps
{
    public class StepSocketEnter : MonoBehaviour
    {
        [Header("Derived")]
        [SerializeField] private XRSocketInteractor xrSocketInteractor;
        [SerializeField] private int interactableValidationLayer;
        [SerializeField] private StepSocketMaster stepSocketMaster;

        private void OnEnable()
        {
            xrSocketInteractor.selectEntered.AddListener(OnSocketSelectEnter);
        }

        private void OnSocketSelectEnter(SelectEnterEventArgs eventArgs)
        {
            if (eventArgs.interactable.gameObject.layer != interactableValidationLayer) return;
            
            stepSocketMaster.Complete();
        }

        private void OnDisable()
        {
            xrSocketInteractor.selectEntered.RemoveListener(OnSocketSelectEnter);
        }
    }
}