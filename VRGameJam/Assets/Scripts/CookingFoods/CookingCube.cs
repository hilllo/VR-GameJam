using UnityEngine;
using System.Collections;

public class CookingCube : CookingFoods {

    private float _ColorLerpT = 0.0f;

    protected override void OnStart()
    {
        this._CookingTimer = 0.0f;
    }

    protected override void OnUpdate()
    {
        if (this.IsCooking && !this._GazeReceiver.IsBeingGazed)
        {
            if (this._CookingTimer < this._PerfectlyCookDuration)
            {
                this._Renderer.material.color = Color.Lerp(Color.white, Color.red, this._ColorLerpT);
                if (this._ColorLerpT < 1)
                    this._ColorLerpT += Time.deltaTime / this._PerfectlyCookDuration;
            }
            else if (this._CookingTimer < this._PerfectlyCookDuration + this._BadlyCookDuration)
            {

                this._Renderer.material.color = Color.Lerp(Color.red, Color.black, this._ColorLerpT - 1.0f);
                if (this._ColorLerpT < 2)
                    this._ColorLerpT += Time.deltaTime / this._BadlyCookDuration;
            }

            Debug.Log(_CookingTimer.ToString());
            this._CookingTimer += Time.deltaTime;
        }
    }

}
