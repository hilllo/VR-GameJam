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


    public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.position = point;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }

    public void StopClip()
    {

    }
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void OnFloorPlay()
    {
        efxSource.clip = krabssound;
        Play(krabssound, Vector3.zero, .4F, 1F);
    }
    public void StopOnFloorPlay()
    {
        efxSource.clip = krabssound;
        efxSource.Stop();
    }

    public void IsCookingPlay()
    {
       // efxSource.clip = sizzlesound;
        //efxSource.loop = true;
        Play(sizzlesound, Vector3.zero, .4F, 1F);
    }
    
    public void StopIsCookingPlay()
    {
        efxSource.clip = sizzlesound;
        efxSource.loop = false;
        efxSource.Stop();
    }

    public void PlanktonLaughPlay()
    {
        if (index == 1)
        {
            //efxSource.clip = Plankton1;
            //efxSource.PlayOneShot(Plankton1, 1F);
            Play(Plankton1, Vector3.zero, .4F, 1F);
            index = 0;
        }
        else
        {
            ///efxSource.clip = Plankton2;
            //efxSource.PlayOneShot(Plankton2,1F);
            Play(Plankton2, Vector3.zero, .4F, 1F);
            index = 1;
        }
    }
    public void StopPlaying()
    {
        efxSource.Stop();
    }

    public void PlayBeam()
    {
        efxSource.clip = BeamSound;
       // Play(BeamSound, Vector3.zero, .4F, 1F);
        efxSource.Play();
    }
    public void StopBeam()
    {
    }

    public void PlayShipSound()
    {
        //efxSource.clip = PropellerSound;
        efxSource.loop = true;
        //efxSource.Play();
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
