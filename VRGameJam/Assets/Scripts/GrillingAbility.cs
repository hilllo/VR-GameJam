using UnityEngine;
using System.Collections;

public class GrillingAbility : MonoBehaviour {

    [SerializeField]
    private AudioSource _AudioSource;

    private int _Count = 0;

    void Update()
    {
        if (this._Count > 0)
        {
            if (!this._AudioSource.isPlaying)
            {
                this._AudioSource.Play();
                //Debug.Log("Play");
            }
                
        }
        else
        {
            if (this._AudioSource.isPlaying)
            {
                this._AudioSource.Stop();
                //Debug.Log("Stop");
            }                
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("Patty"))
            this._Count++;       
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("Patty"))
            this._Count--;
    }
}
