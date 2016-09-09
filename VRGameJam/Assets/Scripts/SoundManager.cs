using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource BackgroundSong;
    public AudioSource efxSource;
    public AudioClip krabssound;
    public AudioClip sizzlesound;

    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void OnFloorPlay()
    {
        efxSource.clip = krabssound;
        efxSource.Play();
    }
    public void StopOnFloorPlay()
    {
        efxSource.clip = krabssound;
        efxSource.Stop();
    }

    public void IsCookingPlay()
    {
        efxSource.clip = sizzlesound;
        efxSource.loop = true;
        efxSource.PlayOneShot(sizzlesound, .5F);
    }
    
    public void StopIsCookingPlay()
    {
        efxSource.clip = sizzlesound;
        efxSource.loop = false;
        efxSource.Stop();
    }


}
