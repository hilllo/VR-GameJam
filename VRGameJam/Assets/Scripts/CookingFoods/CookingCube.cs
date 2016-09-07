using UnityEngine;
using System.Collections;

public class CookingCube : CookingFoods {

    private bool _HasBurn = false;

    //private float _ColorLerpT = 0.0f;
    [SerializeField]
    protected Renderer _Renderer;

    private float _ColorLerpTP = 0.0f;
    private float _ColorLerpTB = 0.0f;

    [SerializeField]
    private float _RecoverDuration = 6.0f;

    // TODO: Audio - Move to Audio Manager
    [SerializeField]
    private AudioSource _AudioSource;
    [SerializeField]
    private AudioClip _CookingAudioClip;
    [SerializeField]
    private AudioClip _ExplosionAudioClip;

    [SerializeField]
    private GameObject _ParticleGO;

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
                CookingCubesManager.Instance.AddBurnedCube(this);

                // TODO: Audio - Move to Audio Manager
                if (this._AudioSource.isPlaying)
                    this._AudioSource.Stop();
                this._AudioSource.clip = this._ExplosionAudioClip;
                this._AudioSource.loop = false;
                this._AudioSource.maxDistance = 10;
                this._AudioSource.Play();

                this._ParticleGO.SetActive(true);
            }

            this._HasBurn = value;
        }
    }

    protected override void OnStart()
    {
        base.OnStart();

        // TODO: Audio - Move to Audio Manager
        this._AudioSource.clip = this._CookingAudioClip;
        this._AudioSource.loop = true;
    }

    protected override void OnUpdate()
    {
        if (GameManager.Instance.Stage == GameManager.GameStage.GameOver || this.HasBurn)
            return;

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
            // TODO: Audio - Move to Audio Manager
            if (!this._AudioSource.isPlaying && !this.HasBurn)
                this._AudioSource.Play();

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
                this.HasBurn = true;
            }
            return;
        }
        else if(this.IsCooking && this._GazeReceiver.IsBeingGazed)
        {
            // TODO: Audio - Move to Audio Manager
            if (this._AudioSource.isPlaying)
                this._AudioSource.Stop();

            if (!this.HasBurn)
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
            return;
        }
    }

}
