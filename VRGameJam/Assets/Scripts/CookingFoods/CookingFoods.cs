using UnityEngine;
using System.Collections;

public class CookingFoods : MonoBehaviour {

    #region Fields

    [SerializeField]
    protected GazeReceiver _GazeReceiver;

    [SerializeField]
    protected float _PerfectlyCookDuration;

    [SerializeField]
    protected float _BadlyCookDuration; //After PerfectlyCook

    protected bool _IsCooking = true;
    protected float _CookingTimer = 0.0f;    

    #endregion Fields

    #region Properties

    public bool IsCooking
    {
        get
        {
            return this._IsCooking;
        }

        set
        {
            if (this._IsCooking == value)
                return;

            // TODO: if ture/false
            this._IsCooking = value;
        }
    }

    #endregion Properties

    #region MonoBehaviour

    void Start()
    {
        this.OnStart();
    }

    void Update()
    {
        this.OnUpdate();
    }

    protected virtual void OnStart()
    {
        // Override for each subclass
    }


    protected virtual void OnUpdate()
    {
        // Override for each subclass
    }

    #endregion MonoBehaviour
}
