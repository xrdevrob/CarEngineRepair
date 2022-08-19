using System;
using UnityEngine;

namespace Instructions.Steps
{
    public class StepSocketMaster : MonoBehaviour
    {
        [SerializeField] private GameObject[] totalSockets;
        [SerializeField] private WorkflowController workflowController;
        private int _socketsAttached;

        private void OnEnable()
        {
            _socketsAttached = 0;
        }

        public void Complete()
        {
            _socketsAttached++;
            if (_socketsAttached != totalSockets.Length) return;
            workflowController.NextStep();
        }
    }
}
