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
    private float _Border = 5.0f; // TODO: Symmetrical 

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
        float spawnBorder = this._Border - this._BorderOffset;
        Vector3 pos = new Vector3(Random.Range(-spawnBorder, spawnBorder), Random.Range(0.5f, spawnBorder + 5.0f), Random.Range(-spawnBorder, spawnBorder));
        GameObject newHarmfulObj = (GameObject) Instantiate(this._HarmfulObj, pos, this._HarmfulObj.transform.rotation);
        newHarmfulObj.transform.SetParent(this._HarmfulObjsTrans);
    }
}
