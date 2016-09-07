using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    
    [SerializeField]
    private TextMesh _TimeLeftNum;

    [SerializeField]
    private TextMesh _TotalCubeNum;

    [SerializeField]
    public TextMesh _BurnedCubeNum;

    [SerializeField]
    private CookingCubesManager _CookingCubeManager;

    void Start () {
        this.ClearTotalCubeNumTxt();
        this.ClearBurnedCubeNumTxt();
    }
	
	void Update () {
        if (GameManager.Instance.Stage == GameManager.GameStage.GameOver)
        {
            this._TimeLeftNum.text = "0";
            return;
        }
            

        this._TimeLeftNum.text = GameManager.Instance.TimeLeft.ToString();

        this._TotalCubeNum.text = this._CookingCubeManager.TotalCubeCount.ToString();
        this._BurnedCubeNum.text = this._CookingCubeManager.BurnedCubeCount.ToString();
    }

    public void ClearTotalCubeNumTxt()
    {
        this._TotalCubeNum.text = "0";
    }

    public void ClearBurnedCubeNumTxt()
    {
        this._BurnedCubeNum.text = "0";
    }
}
