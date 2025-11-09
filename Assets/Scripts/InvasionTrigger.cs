using System;
using UnityEngine;

public class InvasionTrigger : MonoBehaviour
{
    public event Action Invasion;
    public event Action Leave;

    private void OnTriggerEnter(Collider other)
    {
        Invasion?.Invoke(); 
    }

    private void OnTriggerExit(Collider other)
    {
        Leave?.Invoke();
    }
}