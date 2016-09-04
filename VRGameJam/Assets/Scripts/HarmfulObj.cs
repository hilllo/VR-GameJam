using UnityEngine;
using System.Collections;

public class HarmfulObj : MonoBehaviour {

    [SerializeField]
    private Renderer _Renderer;

    private bool _HasAddedToGM = false;
	
	void Update () {

        if (!this._HasAddedToGM && this._Renderer.isVisible)
        {
            //Debug.Log(string.Format("Detected HarmfulObj! {0}", Time.time.ToString()));
            GameManager.Instance.AddHarmfulObj(this.GetInstanceID(), this);
            this._HasAddedToGM = true;

        }
        else if (this._HasAddedToGM && !this._Renderer.isVisible)
        {
            //Debug.Log(string.Format("Removed HarmfulObj! {0}", Time.time.ToString()));
            GameManager.Instance.RemoveHarmfulObj(this.GetInstanceID());
            this._HasAddedToGM = false;
        }
            
	}
}
