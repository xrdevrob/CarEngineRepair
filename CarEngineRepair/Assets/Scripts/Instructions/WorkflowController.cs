using UnityEngine;

namespace Instructions
{
    public class WorkflowController : MonoBehaviour
    {
        [SerializeField] private GameObject[] steps;
        [SerializeField] private int currentStep = 0;
        [SerializeField] private int maxSteps;

        private void OnEnable()
        {
            maxSteps = steps.Length;
        }

        public void NextStep()
        {
            if (currentStep+1 >= maxSteps) return;
            steps[currentStep].SetActive(false);
            currentStep++;
            steps[currentStep].SetActive(true);
        }

        public void RestartInstructions()
        {
            steps[maxSteps].SetActive(false);
            steps[0].SetActive(true);
        }
    }
}
