using System;
using UnityEngine;

namespace Instructions.Steps
{
    public class StepHighlight : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] objectsToHighlight;

        private void OnEnable()
        {
            for (int i = 0; i < objectsToHighlight.Length; i++)
            {
                //objectsToHighlight[i].material
            }
        }

        private void OnDisable()
        {
            throw new NotImplementedException();
        }
    }
}
