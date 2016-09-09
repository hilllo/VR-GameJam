using UnityEngine;
using System.Collections;

public class StealerManager : MonoBehaviour {
    [SerializeField]
    private GameObject _Stealer;

    [SerializeField]
    private int _SentStealerTimes = 2;

    void Update()
    {
        if (this._SentStealerTimes == 2 && GameManager.Instance.TimeLeft < 45.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 1 && GameManager.Instance.TimeLeft < 20.0f) 
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
    }
}
