using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookingCubesManager : Singleton<CookingCubesManager> {

    [SerializeField]
    private GameObject _CookingCubePrefab;

    private List<CookingCube> _CookingCubeList;

	// Use this for initialization
	void Start () {
        this._CookingCubeList = new List<CookingCube>();

        this.Spawn(1);
        this.Spawn(1);

        this.Spawn(2);
        this.Spawn(3);
        this.Spawn(4);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Spawn(int zone)
    {
        Vector3 cubePos = this.GetSpawnPos(zone);
        GameObject cookingCubeGO = (GameObject)Instantiate(this._CookingCubePrefab, cubePos, new Quaternion(0f, 0f, 0f, 0f), this.transform);
        cookingCubeGO.transform.SetParent(this.transform);
        CookingCube cookingCube = cookingCubeGO.GetComponent<CookingCube>();
        this._CookingCubeList.Add(cookingCube);
    }

    private Vector3 GetSpawnPos(int zone)
    {
        switch (zone)
        {
            case 1:
                return new Vector3(Random.Range(-1.5f, 2.5f), Random.Range(0.4f, 1.0f), Random.Range(0.5f, 2.0f));                
            case 2:
                return new Vector3(Random.Range(1.5f, 2.5f), Random.Range(0.4f, 1.0f), Random.Range(-3.0f, 2.0f));
            case 3:
                return new Vector3(Random.Range(-1.5f, 2.5f), Random.Range(0.4f, 1.0f), Random.Range(-2.5f, -1.0f));
            case 4:
                return new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(0.4f, 1.0f), Random.Range(-3.0f, 2.0f));
            default:
                return new Vector3(0f, 0f, 0f);                 
        }
    }
}
