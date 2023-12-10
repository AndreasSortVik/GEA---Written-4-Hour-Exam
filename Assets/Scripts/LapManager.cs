using UnityEngine;
using UnityEngine.Serialization;

public class LapManager : MonoBehaviour
{
    [SerializeField] private AICubeMovement aiCubeMovementScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "AI Cube")
        {
            aiCubeMovementScript.UpdateLapInfo();
        }
    }
}
