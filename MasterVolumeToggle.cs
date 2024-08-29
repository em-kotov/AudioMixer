using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MasterVolumeToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Slider _masterVolumeSlider;

    private readonly string _masterVolumeCommand = "MasterVolume";

    private Toggle _toggle;
    private float _fullVolume = 0f;
    private float _zeroVolume = -80f;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        _toggle.isOn = false;
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMusic);
        _masterVolumeSlider.onValueChanged.AddListener(DisableToggle);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
        _masterVolumeSlider.onValueChanged.RemoveListener(DisableToggle);
    }

    private void ToggleMusic(bool enabled)
    {
        if (enabled)
            _mixerGroup.audioMixer.SetFloat(_masterVolumeCommand, _zeroVolume);
        else
            _mixerGroup.audioMixer.SetFloat(_masterVolumeCommand, _fullVolume);
    }

    private void DisableToggle(float volume)
    {
        _toggle.isOn = false;
    }
}
