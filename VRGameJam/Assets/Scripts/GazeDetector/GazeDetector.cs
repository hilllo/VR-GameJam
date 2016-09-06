using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GazeDetector : MonoBehaviour {

    [SerializeField]
    private Camera _MainCamera;

    [SerializeField]
    private LayerMask _DetectLayerMask;

    private List<RaycastHit> _RaycastHitList;

    void Start()
    {
        this._RaycastHitList = new List<RaycastHit>();
    }

    void Update()
    {
        // Clear previous list
        foreach(RaycastHit hit in this._RaycastHitList)
        {
            GazeReceiver gazeReceiver =  hit.collider.GetComponent<GazeReceiver>();
            if(gazeReceiver!=null)
                gazeReceiver.IsBeingGazed = false;
        }
        this._RaycastHitList.Clear();

        // Get new list
        this._RaycastHitList = (Physics.RaycastAll(this._MainCamera.transform.position, this._MainCamera.transform.forward, 10f, this._DetectLayerMask)).ToList();

        foreach (RaycastHit hit in this._RaycastHitList)
        {
            GazeReceiver currentGR = hit.collider.gameObject.GetComponent<GazeReceiver>();
            if (currentGR != null)
                currentGR.IsBeingGazed = true;
        }
    }
}
