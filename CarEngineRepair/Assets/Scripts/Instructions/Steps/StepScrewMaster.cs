using UnityEngine;

namespace Instructions.Steps
{
    public class StepScrewMaster : MonoBehaviour
    {
        [SerializeField] private GameObject[] totalScrews;
        [SerializeField] private WorkflowController workflowController;
        private int _screwsDone;

        private void OnEnable()
        {
            _screwsDone = 0;
        }

        public void Complete()
        {
            _screwsDone++;
            if (_screwsDone != totalScrews.Length) return;
            workflowController.NextStep();
        }
    }
}
