using UnityEngine;

namespace Instructions.Steps
{
    public class StepMoveTrigger : MonoBehaviour
    {
        [SerializeField] private string triggerTag;
        [SerializeField] private WorkflowController workflowController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(triggerTag)) workflowController.NextStep();
        }
    }
}
