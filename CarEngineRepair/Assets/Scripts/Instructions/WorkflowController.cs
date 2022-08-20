using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Instructions
{
    public class WorkflowController : MonoBehaviour
    {
        [SerializeField] private GameObject[] steps;
        [SerializeField] private int currentStep = 0;
        [SerializeField] private int maxSteps;

        public static Action<int> OnStepChange;

            private void Awake()
        {
            steps[0].SetActive(true);
        }

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
            OnStepChange?.Invoke(currentStep);
        }

        public void RestartInstructions()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
