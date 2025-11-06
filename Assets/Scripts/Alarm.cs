using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float _volumeChangeSpeedModificator = 0.1f;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        _coroutine = StartCoroutine(SmoothSoundChange(_maxVolume));
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SmoothSoundChange(_minVolume));
    }

    private IEnumerator SmoothSoundChange(float targetVolume)
    {
        bool isWork = true;

        while (isWork)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume,
                                                    _volumeChangeSpeedModificator * Time.deltaTime);

            if (_audioSource.volume == targetVolume)
            {
                isWork = false;
            }

            yield return null;
        }
    }
}