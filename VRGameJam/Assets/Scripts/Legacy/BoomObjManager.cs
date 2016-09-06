using UnityEngine;
using System.Collections;

public class BoomObjManager : Singleton<BoomObj> {

    private RaycastHit _RaycastHit;
    private BoomObj _CurrentBoomObj;

    [SerializeField]
    private float _FocusTime = 1.0f;

    private float _Timer = 0.0f;

    // Use this for initialization
    void Start () {
        this._Timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(GameManager.Instance.MainCamera.transform.position, GameManager.Instance.MainCamera.transform.forward, out this._RaycastHit, 10f))
        {
            if (this._RaycastHit.collider.gameObject.tag == "BoomObj")
            {
                if (this._CurrentBoomObj == this._RaycastHit.collider.gameObject.GetComponent<BoomObj>())
                    this._Timer += Time.deltaTime;
                else
                {
                    if(this._CurrentBoomObj != null)
                        this._CurrentBoomObj.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                    this._Timer = 0.0f;

                    this._CurrentBoomObj = this._RaycastHit.collider.gameObject.GetComponent<BoomObj>();
                    this._CurrentBoomObj.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                }               

                if(this._Timer > this._FocusTime)
                    this._CurrentBoomObj.Boom();
            }
            else
            {
                if (this._CurrentBoomObj != null)
                    this._CurrentBoomObj.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                this._Timer = 0.0f;
                this._CurrentBoomObj = null;
            }
        }
    }
}
