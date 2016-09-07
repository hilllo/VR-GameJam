using UnityEngine;
using System.Collections;

public class Sizzle : MonoBehaviour {

    public AudioClip sizzleStart;
    public AudioClip sizzleLoop;

    private bool started;

    [SerializeField]
    private AudioSource audio;

    private float lowrange = .75F;
    private float highrange = 1F;

    void Update()
    {
        if (PattyToFlip.iscooking == true)
        {
            audio.pitch = Random.Range(lowrange, highrange);
            audio.loop = true;
            if (started == false)
            {
                started = true;
                audio.PlayOneShot(sizzleStart, .5F);
            }

            audio.clip = sizzleLoop;
            audio.PlayOneShot(sizzleStart, 1F);

        }
        else
        {
            audio.clip = sizzleLoop;

            audio.loop = false;
            started = false;
            audio.Stop();
        }

    }

}
