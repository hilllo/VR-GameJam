using UnityEngine;
using System.Collections;

public class HarmfulObjsManager : Singleton<HarmfulObjsManager> {

    [SerializeField]
    private GameObject _HarmfulObj;

    [SerializeField]
    private Transform _HarmfulObjsTrans;

    [SerializeField]
    private float _SpawningInterval = 2.0f;

    [SerializeField]
    private Vector3 _Border; // TODO: Symmetrical 

    [SerializeField]
    private float _BorderOffset = 0.5f;

    private float _Timer = 0.0f;

    void Start () {
	
	}
	
	void Update () {

        this._Timer += Time.deltaTime;
        if(this._Timer > this._SpawningInterval)
        {
            this.SpawnObj();
            this._Timer = 0.0f;
        }
	}

    private void SpawnObj()
    {
        Vector3 pos = new Vector3(Random.Range(-this._Border.x + this._BorderOffset, this._Border.x - this._BorderOffset), 
                                  Random.Range(this._BorderOffset, this._Border.y - this._BorderOffset), 
                                  Random.Range(-this._Border.z + this._BorderOffset, this._Border.z - this._BorderOffset));

        GameObject newHarmfulObj = (GameObject) Instantiate(this._HarmfulObj, pos, this._HarmfulObj.transform.rotation);
        newHarmfulObj.transform.SetParent(this._HarmfulObjsTrans);
    }
}
