using System;
using UnityEngine;

namespace Instructions.Steps
{
    public class StepHighlight : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] objectsToHighlight;
        [SerializeField] private Material highlightMaterial;
        [SerializeField] private Material[] previousMaterial;

        private void OnEnable()
        {
            for (int i = 0; i < objectsToHighlight.Length; i++)
            {
                previousMaterial[i] = objectsToHighlight[i].material;
            }
            
            for (int i = 0; i < objectsToHighlight.Length; i++)
            {
                objectsToHighlight[i].material = highlightMaterial;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < objectsToHighlight.Length; i++)
            {
                objectsToHighlight[i].material = previousMaterial[i];
            }
        }
    }
}
