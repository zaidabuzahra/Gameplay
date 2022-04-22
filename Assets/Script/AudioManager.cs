using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGroup;
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        Instance = this;

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsMixerGroup;
                    break;

                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }

            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    private void Start()
    {
        UpdateMixerVolume(); //(?)
    }
  

    public void PlayClipByName(string _clipName)
    {
       Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);

        if (soundToPlay != null)
        {
            soundToPlay.source.Play();
        }
     
    }

    public void StopClipByName(string _clipName)
    {
        Sound soundToStop = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);

        if (soundToStop != null)
        {
            soundToStop.source.Stop();
        }

    }

    public void UpdateMixerVolume()
    {
        PlayerPrefs.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20); //(?)
        PlayerPrefs.SetFloat("Sound Effects Volume", Mathf.Log10(AudioOptionsManager.soundEffectsVolume) * 20); //(?)

        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        soundEffectsMixerGroup.audioMixer.SetFloat("Sound Effects Volume", Mathf.Log10(AudioOptionsManager.soundEffectsVolume) * 20);

    }
}
