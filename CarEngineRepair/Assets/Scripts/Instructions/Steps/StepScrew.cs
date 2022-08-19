using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Instructions.Steps
{
    public class StepScrew : MonoBehaviour
    {
        [SerializeField] private StepScrewMaster stepScrewMaster;
        [SerializeField] private string compareTag = "Screwdriver";
        [SerializeField] private XRGrabInteractable xrGrabInteractable;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material cashedMaterial;
        [SerializeField] private float delay = 2f;

        private bool _objectTriggered;
        private bool _coroutineRunning;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(compareTag)) return;
            _objectTriggered = true;
            StartCoroutine(CompleteStep());
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(compareTag)) return;
            if (_objectTriggered && _coroutineRunning) StopCoroutine(CompleteStep());

            _objectTriggered = false;
        }

        public IEnumerator CompleteStep()
        {
            _coroutineRunning = true;
            yield return new WaitForSeconds(delay);
            xrGrabInteractable.enabled = true;
            meshRenderer.material = cashedMaterial;
            stepScrewMaster.Complete();
            _coroutineRunning = false;
        }
    }
}