using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine _coroutine;

    public void Activate()
    {
        CheckAndStopCoroutine();

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _coroutine = StartCoroutine(SmoothSoundChange(_maxVolume));
    }

    public void Deactivate()
    {
        CheckAndStopCoroutine();
        _coroutine = StartCoroutine(SmoothSoundChange(_minVolume));
    }

    private void CheckAndStopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator SmoothSoundChange(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume,
                                                    _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}