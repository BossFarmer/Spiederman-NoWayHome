using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundScript[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play ( string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
