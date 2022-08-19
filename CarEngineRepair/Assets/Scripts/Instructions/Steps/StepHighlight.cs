using System;
using System.Collections.Generic;
using UnityEngine;

namespace Instructions.Steps
{
    public class StepHighlight : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] objectsToHighlight;
        [SerializeField] private Material highlightMaterial;
        [SerializeField] private List<Material> cachedMaterial = new();

        private void OnEnable()
        {
            foreach (var meshRenderer in objectsToHighlight)
            {
                cachedMaterial.Add(meshRenderer.materials[0]);
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
                objectsToHighlight[i].material = cachedMaterial[i];
                
            }
        }
    }
}
