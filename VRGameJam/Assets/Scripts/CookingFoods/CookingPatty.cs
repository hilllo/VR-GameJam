using UnityEngine;
using System.Collections;

public class CookingPatty : CookingFoods
{

    private bool _HasBurn = false;

    private float _ColorLerpT = 0.0f;
    [SerializeField]
    protected Renderer _Renderer;

    private Color _OriginalColor;

    public bool HasBurn
    {
        get
        {
            return this._HasBurn;
        }

        set
        {
            if (this._HasBurn == value)
                return;

            if (value)
            {

            }

            this._HasBurn = value;
        }
    }

    protected override void OnStart()
    {
        base.OnStart();
        this._OriginalColor = this._Renderer.material.color;
        this.IsCooking = false;
    }

    protected override void OnUpdate()
    {
        if (this.HasBurn)
            return;

        if (this.IsCooking && !this._GazeReceiver.IsBeingGazed)
        {
            //Debug.Log("Cooking");

            if (this._CookingTimer < this._PerfectlyCookDuration)
            {
                this._Renderer.material.color = Color.Lerp(this._OriginalColor, Color.red, this._ColorLerpT);
                if (this._ColorLerpT < 1)
                    this._ColorLerpT += Time.deltaTime / this._PerfectlyCookDuration;
            }
            else if (this._CookingTimer < this._PerfectlyCookDuration + this._BadlyCookDuration)
            {

                this._Renderer.material.color = Color.Lerp(Color.red, Color.black, this._ColorLerpT - 1.0f);
                if (this._ColorLerpT < 2)
                    this._ColorLerpT += Time.deltaTime / this._BadlyCookDuration;
            }

            //    Debug.Log(_CookingTimer.ToString());
            this._CookingTimer += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grill")
        {
            this.IsCooking = true;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grill")
        {
            this.IsCooking = false;
        }
    }
}
