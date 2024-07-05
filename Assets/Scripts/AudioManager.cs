using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{ 
    PLAYERFOOTSTEP,
    PLAYERJUMP,
    PLAYERHURT,
    PLAYERATTACK,
    SKELETONHURT
        //add more here
}

public class AudioManager : Singleton <AudioManager>
{
    [SerializeField] private AudioClip[] audioList;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.audioList[(int)sound], volume);
    }
}
