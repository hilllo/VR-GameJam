﻿using UnityEngine;
using System.Collections;

public class GazeReceiver : MonoBehaviour {

    [SerializeField]
    private Transform _MainCameraTrans;

    [SerializeField]
    private bool _IsBeingGazed;

    void Start()
    {
        this._MainCameraTrans = Camera.main.transform;
    }

    void Update()
    {
        if(this._MainCameraTrans != null)
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
