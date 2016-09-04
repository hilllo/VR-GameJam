using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

    [SerializeField]
    private Text _SustainTimeTxt;

    [SerializeField]
    private Text _HarmfulObjCountTxt;

    [SerializeField]
    private Text _HarmfulTimeTxt;

    void Start () {
        this.ClearHarmfulObjCountTxt();
        this.ClearHarmfulTimeTxt();
    }
	
	void Update () {
        this._SustainTimeTxt.text = Time.time.ToString();
	}

    public void UpdateHarmfulObjCountTxt(int count)
    {
        this._HarmfulObjCountTxt.text = count.ToString();
    }

    public void ClearHarmfulObjCountTxt()
    {
        this._HarmfulObjCountTxt.text = "0";
    }

    public void UpdateHarmfulTimeTxt(float count)
    {
        this._HarmfulTimeTxt.text = count.ToString();
    }

    public void ClearHarmfulTimeTxt()
    {
        this._HarmfulTimeTxt.text = "0";
    }
}
