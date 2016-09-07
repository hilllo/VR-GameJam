using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookingCubesManager : Singleton<CookingCubesManager> {

    [SerializeField]
    private GameObject CookingCubePrefab;

    private List<CookingCube> _CookingCubeList;
    private List<CookingCube> _BurnedCubeList;

    private float _Timer = 0.0f;
    [SerializeField]
    private float _Interval = 5.0f;
    private int _SpawnZoneLoop = 1;
    private int _SpawnAmount = 1;
    private bool _InStage2 = false;
    private bool _InStage3 = false;

    // TODO: UI - Move to UI Manager
    public int TotalCubeCount { get; private set; }
    public int BurnedCubeCount { get; private set; }

    void Start () {
        this._CookingCubeList = new List<CookingCube>();
        this._BurnedCubeList = new List<CookingCube>();

        this._Timer = 0.0f;
        this.TotalCubeCount = this._CookingCubeList.Count;
        this.BurnedCubeCount = 0;

        this.Spawn(this._SpawnZoneLoop);
        this.Spawn(this._SpawnZoneLoop);

        this._SpawnZoneLoop++;

        //this.Spawn(2);
        //this.Spawn(3);
        //this.Spawn(4);

    }
	
	void Update () {
        if (GameManager.Instance.Stage == GameManager.GameStage.GameOver)
            return;

        if(GameManager.Instance.TimeLeft < 30.0f && !this._InStage2)
        {
            this._SpawnAmount = 2;
            this._Interval -= 1.0f;
            this._InStage2 = true;
        }

        if (GameManager.Instance.TimeLeft < 10.0f && !this._InStage3)
        {
            this._SpawnAmount = 4;
            this._Interval -= 2.0f;
            this._InStage3 = true;
        }

        this._Timer += Time.deltaTime;
        if(this._Timer > this._Interval)
        {
            for(int i = 0; i< this._SpawnAmount; i++)
            {
                this.Spawn(this._SpawnZoneLoop);
            }
            
            if (this._SpawnZoneLoop > 4)
                this._SpawnZoneLoop = 1;
            else
                this._SpawnZoneLoop++;

            this._Timer = 0.0f;
        }
	}

    private void Spawn(int zone)
    {
        Vector3 cubePos = this.GetSpawnPos(zone);
        GameObject cookingCubeGO = (GameObject)Instantiate(this.CookingCubePrefab, cubePos, Quaternion.identity,this.transform);
        CookingCube cookingCube = cookingCubeGO.GetComponent<CookingCube>();
        this._CookingCubeList.Add(cookingCube);

        this.TotalCubeCount = this._CookingCubeList.Count;
    }

    private Vector3 GetSpawnPos(int zone)
    {
        switch (zone)
        {
            case 1:
                return new Vector3(Random.Range(-1.5f, 2.5f), Random.Range(1.0f, 5.0f), Random.Range(0.5f, 2.0f));                
            case 2:
                return new Vector3(Random.Range(1.5f, 2.5f), Random.Range(1.0f, 5.0f), Random.Range(-3.0f, 2.0f));
            case 3:
                return new Vector3(Random.Range(-1.5f, 2.5f), Random.Range(1.0f, 5.0f), Random.Range(-2.5f, -1.0f));
            case 4:
                return new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(1.0f, 5.0f), Random.Range(-3.0f, 2.0f));
            default:
                return new Vector3(0f, 0f, 0f);                 
        }
    }

    public void AddBurnedCube(CookingCube burnedCube)
    {
        this._BurnedCubeList.Add(burnedCube);

        this.BurnedCubeCount = this._BurnedCubeList.Count;
    }

}
