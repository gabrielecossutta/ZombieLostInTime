using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach ( Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        //Play("Stage1");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        //Debug.LogWarning("Sound: " + name + " started");
        s.source.Play();
    }
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!s.source.isPlaying)
        {
            if (s == null)
            {
                //Debug.LogWarning("Sound: " + name + " not found");
                return;
            }
            //Debug.LogWarning("Sound: " + name + " started");
            s.source.Play();
        }
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            if (s == null)
            {
                //Debug.LogWarning("Sound: " + name + " not found");
                return;
            }
            //Debug.LogWarning("Sound: " + name + " started");
            s.source.Pause();
        }
    }
    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!s.source.isPlaying)
        {
            if (s == null)
            {
                //Debug.LogWarning("Sound: " + name + " not found");
                return;
            }
            //Debug.LogWarning("Sound: " + name + " started");
            s.source.UnPause();
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        //Debug.LogWarning("Sound: " + name + " started");
        s.source.Stop();
    }
    public void StopAll()
    {
        foreach ( Sound s in sounds)
        {
            s.source.Stop();
        }
    }

}
