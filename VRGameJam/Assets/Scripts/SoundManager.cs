using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {

    public AudioSource BackgroundSong;
    public AudioSource efxSource;
    public AudioClip krabssound;
    public AudioClip sizzlesound;
    public AudioClip Plankton1;
    public AudioClip Plankton2;
    public AudioClip BeamSound;
    public AudioClip CorrectSound;
    public AudioClip ExplosionSound;

    public int index;

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

    public void PlanktonLaughPlay()
    {
        index = Random.Range(0,1);
        if (index == 1)
        {
            efxSource.clip = Plankton1;
            efxSource.PlayOneShot(Plankton1, 1F);
        }
        else
        {
            efxSource.clip = Plankton2;
            efxSource.PlayOneShot(Plankton2,1F);
        }
    }
    public void StopPlaying()
    {
        efxSource.Stop();
    }

    public void PlayBeam()
    {
        efxSource.clip = BeamSound;

        efxSource.Play();
    }
    public void PlayShipSound()
    {
        //efxSource.clip = PropellerSound;
        efxSource.loop = true;
        efxSource.Play();
    }
    public void EndShipSound()
    {
        //efxSource.clip = PropellerSound;
        efxSource.loop = false;
        efxSource.Stop();
    }
    public void CorrectBurgerCompleted()
    {
        efxSource.clip = CorrectSound;
        efxSource.PlayOneShot(CorrectSound, 1F);
    }

    public void PlayExplosion()
    {
        efxSource.clip = ExplosionSound;
        efxSource.PlayOneShot(ExplosionSound, 2F);
    }
}
