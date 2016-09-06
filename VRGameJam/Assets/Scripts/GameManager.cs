using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

    #region Fields

    [SerializeField]
    private Camera _MainCamera;

    [SerializeField]
    private float _LimitedTime = 2.0f;

    private Dictionary<int, HarmfulObj> _DetectedHarmfulObjs;
    private float _Timer = 0.0f;
    private float _TimeToBeDisplayed = 1.0f;

    #endregion Fields

    #region Properties

    public Camera MainCamera
    {
        get
        {
            return this._MainCamera;
        }
    }

    public float LimitedTime
    {
        get
        {
            return this._LimitedTime;
        }
    }

    #endregion Properties

    #region MonoBehaviour

    void Start () {
        this._DetectedHarmfulObjs = new Dictionary<int, HarmfulObj>();
    }

    void Update()
    {

        if (this._DetectedHarmfulObjs.Count > 0)
        {
            this._Timer += Time.deltaTime;
            if(this._Timer > this._TimeToBeDisplayed)
            {
                //Debug.Log(string.Format("Timer: {0}", this._TimeToBeDisplayed.ToString()));
                UIManager.Instance.UpdateHarmfulTimeTxt(this._TimeToBeDisplayed);
                this._TimeToBeDisplayed += 1.0f;
            }
        }
        else if (this._Timer > 0.0f)
        {
            //Debug.Log(string.Format("Timer: Clear"));
            this._Timer = 0.0f;
            this._TimeToBeDisplayed = 1.0f;

            UIManager.Instance.ClearHarmfulObjCountTxt();
            UIManager.Instance.ClearHarmfulTimeTxt();
        }
    }

    #endregion MonoBehaviour

    #region Detected HarmfulObj

    public void AddHarmfulObj(int id, HarmfulObj harmfulObj)
    {
        HarmfulObj tempHarmfulObj;
        if (this._DetectedHarmfulObjs.TryGetValue(id, out tempHarmfulObj))
        {
            // TODO: Throw expectation here
            this._DetectedHarmfulObjs.Remove(id);
            this._DetectedHarmfulObjs.Add(id, harmfulObj);
            return;
        }

        this._DetectedHarmfulObjs.Add(id, harmfulObj);
        //Debug.Log(string.Format("GM: Added {0} in _DetectedHarmfulObjs (Count = {1})", id.ToString(), this._DetectedHarmfulObjs.Count.ToString()));
        UIManager.Instance.UpdateHarmfulObjCountTxt(this._DetectedHarmfulObjs.Count);
    }

    public void RemoveHarmfulObj(int id)
    {
        HarmfulObj harmfulObj;
        if(!this._DetectedHarmfulObjs.TryGetValue(id,out harmfulObj))
        {
            // TODO: Throw expectation here
            Debug.Log(string.Format("GM: Expected {0} existed in _DetectedHarmfulObjs",id.ToString()));
            return;
        }

        this._DetectedHarmfulObjs.Remove(id);
        //Debug.Log(string.Format("GM: Removed {0} in _DetectedHarmfulObjs (Count = {1})", id.ToString(), this._DetectedHarmfulObjs.Count.ToString()));
        UIManager.Instance.UpdateHarmfulObjCountTxt(this._DetectedHarmfulObjs.Count);
    }

    #endregion Detected HarmfulObj

}
