using UnityEngine;

public class PositionHood : MonoBehaviour
{
    [SerializeField] private Rigidbody hoodRigidbody;

    public void FreezePosition()
    {
        hoodRigidbody.freezeRotation = true;
    }    
    
    public void ReleasePosition()
    {
        hoodRigidbody.freezeRotation = false;
    }
}
