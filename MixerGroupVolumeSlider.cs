using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MixerGroupVolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private readonly string _volumeParameterName = "Volume";

    private Slider _slider;
    private float _volumeScaler = 20f;
    private float _minValue = 0.0001f;
    private float _startValue = 0.5f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = _minValue;
        _slider.value = _startValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(GetVolumeParameterName(), Mathf.Log10(volume) * _volumeScaler);
    }

    private string GetVolumeParameterName()
    {
        return _mixerGroup.name + _volumeParameterName;
    }
}
