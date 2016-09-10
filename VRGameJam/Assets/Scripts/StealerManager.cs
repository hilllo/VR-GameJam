using UnityEngine;
using System.Collections;

public class StealerManager : MonoBehaviour {
    [SerializeField]
    private GameObject _Stealer;

    [SerializeField]
    private int _SentStealerTimes = 2;


    void Update()
    {
        if (this._SentStealerTimes == 7 && GameManager.Instance.TimeLeft < 60.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 6 && GameManager.Instance.TimeLeft < 40.0f) 
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 5 && GameManager.Instance.TimeLeft < 30.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 4&& GameManager.Instance.TimeLeft < 22.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 3 && GameManager.Instance.TimeLeft < 15.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 2 && GameManager.Instance.TimeLeft < 10.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
        else if (this._SentStealerTimes == 1 && GameManager.Instance.TimeLeft < 6.0f)
        {
            Instantiate(this._Stealer);
            this._SentStealerTimes--;
        }
    }
}
