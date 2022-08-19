using System;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Instructions.Steps
{
    public class StepButtonClick : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private WorkflowController workflowController;

        private void OnEnable()
        {
            button.onClick.AddListener(Complete);
        }

        private void Complete()
        {
            workflowController.NextStep();
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Complete);
        }
    }
}
