using UnityEngine;
using System.Collections;

public class GazeReceiver : MonoBehaviour {

    [SerializeField]
    private Transform _MainCameraTrans;

    [SerializeField]
    private bool _IsBeingGazed;

    void Update()
    {
        this.transform.LookAt(this._MainCameraTrans.position);
    }

    public bool IsBeingGazed
    {
        get
        {
            return this._IsBeingGazed;
        }
        set
        {
            if (this.IsBeingGazed == value)
                return;

            if (value)
            {
                // TODO: If is being gazed
            }
            else
            {
                // TODO: If is not being gazed
            }

            this._IsBeingGazed = value;
        }
    }
}
