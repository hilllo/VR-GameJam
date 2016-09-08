using UnityEngine;
using System.Collections;

public class AngryKrabs : MonoBehaviour {

    public AudioClip spongebob;

    private bool started;

    [SerializeField]
    private AudioSource audio;

    private float lowrange = .75F;
    private float highrange = 1F;

    void Awake()
    {
        started = false;
    }

    void Update()
    {
        if (InteractableItem.onFloor)
        {
            audio.pitch = 1F;
            audio.loop = true;
            if (started == false)
            {
                audio.clip = spongebob;
                Debug.Log("Play Spongebob SOUND NOW");

                audio.PlayOneShot(spongebob, 1F);
                started = true;
            }

        }
        else
        {
            audio.loop = false;
            started = false;
            audio.Stop();
        }

    }

}
