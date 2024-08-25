using UnityEngine;
using UnityEngine.Audio;

public class MusicMenu : MonoBehaviour
{
    private readonly string _masterVolumeCommand = "MasterVolume";
    private readonly string _musicVolumeCommand = "MusicVolume";
    private readonly string _effectsVolumeCommand = "EffectsVolume";

    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;
    [SerializeField] private AudioMixerGroup _effectsMixer;

    private float _fullVolume = 0f;
    private float _zeroVolume = -80f;
    private float _volumeScaler = 20f;

    public void ToggleMusic(bool enabled) //used in toggle music
    {
        if (enabled)
            _masterMixer.audioMixer.SetFloat(_masterVolumeCommand, _zeroVolume);
        else
            _masterMixer.audioMixer.SetFloat(_masterVolumeCommand, _fullVolume);
    }

    public void ChangeMasterVolume(float volume) //used in master volume slider
    {
        ChangeVolume(volume, _masterMixer, _masterVolumeCommand);
    }

    public void ChangeMusicVolume(float volume) //used in music volume slider
    {
        ChangeVolume(volume, _musicMixer, _musicVolumeCommand);
    }

    public void ChangeEffectsVolume(float volume) //used in effects volume slider
    {
        ChangeVolume(volume, _effectsMixer, _effectsVolumeCommand);
    }

    private void ChangeVolume(float volume, AudioMixerGroup mixer, string volumeCommand)
    {
        mixer.audioMixer.SetFloat(volumeCommand, Mathf.Log10(volume) * _volumeScaler);
    }
}
