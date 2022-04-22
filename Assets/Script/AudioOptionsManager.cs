using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume); //(?)

        musicSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value;
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsVolume); //(?)

        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }
}
