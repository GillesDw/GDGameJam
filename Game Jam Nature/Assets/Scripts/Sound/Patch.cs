using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/Patch")]
public class Patch : ScriptableObject
{
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] [Range(0, 1)] private float _minVolume = 1;
    [SerializeField] [Range(0, 1)] private float _maxVolume = 1;
    [SerializeField] [Range(-3, 3)] private float _minPitch = 1;
    [SerializeField] [Range(-3, 3)] private float _maxPitch = 1;
    [SerializeField] private AudioMixerGroup _group;

    private void OnValidate()
    {
        if (_minVolume > _maxVolume)
        {
            _minVolume = _maxVolume;
        }

        if (_minPitch > _maxPitch)
        {
            _minPitch = _maxPitch;
        }
    }

    public void Play(AudioSource source)
    {
        source.volume = Random.Range(_minVolume, _maxVolume);
        source.pitch = Random.Range(_minPitch, _maxPitch);
        source.outputAudioMixerGroup = _group;
        source.clip = _clips[Random.Range(0, _clips.Count)];
        source.Play();
    }
}
