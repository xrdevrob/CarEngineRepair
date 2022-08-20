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

        private bool _coroutineRunning;
        private Coroutine _routine;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(compareTag)) return;
            
            _routine = StartCoroutine(CompleteStep());
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(compareTag)) return;

            Debug.Log($"TriggerExit: {other.gameObject.name}");
            if (_coroutineRunning)
            {
                StopCoroutine(_routine);
                _coroutineRunning = false;
                Debug.Log("Coroutine Stopped");
            }
        }

        public IEnumerator CompleteStep()
        {
            Debug.Log("Coroutine Start");
            _coroutineRunning = true;
            yield return new WaitForSeconds(delay);
            Debug.Log("After Delay");
            xrGrabInteractable.enabled = true;
            meshRenderer.material = cashedMaterial;
            stepScrewMaster.Complete();
            _coroutineRunning = false;
            Debug.Log("Coroutine End");
            _routine = null;
        }
    }
}