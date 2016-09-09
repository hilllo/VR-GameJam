using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : Singleton<UI> {

    [SerializeField]
    private TextMesh _TimeLeftNum;

    [SerializeField]
    private TextMesh _ScoreNum;

	
	void Update () {
        if (GameManager.Instance.Stage == GameManager.GameStage.GameOver)
        {
            this._TimeLeftNum.text = "0";
            return;
        }

        this._TimeLeftNum.text = GameManager.Instance.TimeLeft.ToString();
        this._ScoreNum.text = GameManager.Instance.Score.ToString();
	}
}
