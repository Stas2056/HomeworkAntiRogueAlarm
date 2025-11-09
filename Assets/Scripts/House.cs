using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private InvasionTrigger _invasionTtrigger;

    private void OnEnable()
    {
        _invasionTtrigger.Invasion += _alarm.Activate;
        _invasionTtrigger.Leave += _alarm.Deactivate;
    }

    private void OnDisable()
    {
        _invasionTtrigger.Invasion -= _alarm.Activate;
        _invasionTtrigger.Leave -= _alarm.Deactivate;
    }
}