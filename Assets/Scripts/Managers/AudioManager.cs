using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource soundFxObject;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audiosource = Instantiate(soundFxObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = audioClip;

        audiosource.volume = volume;

        audiosource.Play();

        float clipLenght = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLenght);
    }
}
