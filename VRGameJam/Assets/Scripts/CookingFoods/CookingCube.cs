using UnityEngine;
using System.Collections;

public class CookingCube : CookingFoods {

    //private float _ColorLerpT = 0.0f;

    private float _ColorLerpTP = 0.0f;
    private float _ColorLerpTB = 0.0f;
    private float _RecoverDuration = 6.0f;
    private bool _HasBurn = false;

    protected override void OnStart()
    {
        this._CookingTimer = 0.0f;
    }

    protected override void OnUpdate()
    {
        //if (this.IsCooking && !this._GazeReceiver.IsBeingGazed)
        //{
        //    if (this._CookingTimer < this._PerfectlyCookDuration)
        //    {
        //        this._Renderer.material.color = Color.Lerp(Color.white, Color.red, this._ColorLerpT);
        //        if (this._ColorLerpT < 1)
        //            this._ColorLerpT += Time.deltaTime / this._PerfectlyCookDuration;
        //    }
        //    else if (this._CookingTimer < this._PerfectlyCookDuration + this._BadlyCookDuration)
        //    {

        //        this._Renderer.material.color = Color.Lerp(Color.red, Color.black, this._ColorLerpT - 1.0f);
        //        if (this._ColorLerpT < 2)
        //            this._ColorLerpT += Time.deltaTime / this._BadlyCookDuration;
        //    }

        ////    Debug.Log(_CookingTimer.ToString());
        //    this._CookingTimer += Time.deltaTime;
        //}

        if (this.IsCooking && !this._GazeReceiver.IsBeingGazed)
        {
            if (this._ColorLerpTP < 1.0f)
            {
                this._Renderer.material.color = Color.Lerp(Color.white, Color.red, this._ColorLerpTP);
                this._ColorLerpTP += Time.deltaTime / this._PerfectlyCookDuration;
            }
            else if (this._ColorLerpTB < 1.0f)
            {

                this._Renderer.material.color = Color.Lerp(Color.red, Color.black, this._ColorLerpTB);
                this._ColorLerpTB += Time.deltaTime / this._BadlyCookDuration;
            }
            else
            {
                this._HasBurn = true;
            }
        }
        else if(this.IsCooking && this._GazeReceiver.IsBeingGazed)
        {
            if (!this._HasBurn)
            {
                if (this._ColorLerpTB > 0.0f)
                {
                    this._Renderer.material.color = Color.Lerp(Color.red, Color.black, this._ColorLerpTB);
                    this._ColorLerpTB -= Time.deltaTime / (this._RecoverDuration / 2.0f);                    
                }
                else if (this._ColorLerpTP > 0.0f)
                {
                    this._Renderer.material.color = Color.Lerp(Color.white, Color.red, this._ColorLerpTP);
                    this._ColorLerpTP -= Time.deltaTime / (this._RecoverDuration / 2.0f);
                }
            }
        }

    }

}
