using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Instructions.Steps
{
    public class StepScrewdriver : MonoBehaviour
    {
        [SerializeField] private Animator screwdriverAnimator;

        private static int _unscrewAnimation = Animator.StringToHash("Unscrew");
        private static int _screwAnimation = Animator.StringToHash("Screw");
        private static int _idleAnimation = Animator.StringToHash("Idle");

        [Space, SerializeField] private AudioSource audioSource;

        private int _currentAnimation;

        private void OnEnable() => WorkflowController.OnStepChange += UpdateAnimation;

        private void UpdateAnimation(int currentStep)
        {
            if (currentStep == 6) _currentAnimation = _unscrewAnimation;
            else
            {
                _currentAnimation = _screwAnimation;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Screws")) screwdriverAnimator.Play("RotateLeftOpen");
        }

        public void OnActivate()
        {
            screwdriverAnimator.SetBool(_currentAnimation, true);
            screwdriverAnimator.SetBool(_idleAnimation, false);
            var random = Random.Range(0.8f, 1.2f);
            audioSource.pitch = random;
            audioSource.Play();
        }

        public void OnDeactivate()
        {
            screwdriverAnimator.SetBool(_idleAnimation, true);
            screwdriverAnimator.SetBool(_currentAnimation, false);
        }

        private void OnDisable() => WorkflowController.OnStepChange -= UpdateAnimation;
    }
}