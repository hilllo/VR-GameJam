using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StealerAI : MonoBehaviour {

    public enum StealerStage
    {
        STARTENTERING,
        ENTERING,
        STARTSTEALING,
        STEALING,
        STARTEXITING,
        EXITING,
        DONE,
        STARTDYING,
        DIE,
        NONE
    }

    #region Fields

    [SerializeField]
    private GameObject _AiPathGO;

    [SerializeField]
    private List<Transform> _AiSpots;

    [SerializeField]
    private StealerStealingAbility _StealerStealingAbility;

    [SerializeField]
    private MeshRenderer _MeshRenderer;

    [SerializeField]
    private Collider _Collider;

    [SerializeField]
    private GameObject _ExplosionParticleGO;

    [SerializeField]
    private float _EnteringDuration;

    [SerializeField]
    private float _StealingDuration;

    [SerializeField]
    private float _ExitingDuration;    

    private float _PosLerpT;
    private int _CurrentSpotIndex = 0;

    #endregion Fields

    #region Properties

    public StealerStage Stage { get; private set; }
    public int StoleBurgerCount { get; private set; }

    #endregion Properties

    #region MonoBehaviour

    void Start () {
        this._AiPathGO = GameObject.FindGameObjectWithTag("AIPath");

        this._AiSpots = new List<Transform>();
        this._AiPathGO.transform.GetComponentsInChildren<Transform>(this._AiSpots);

        // _AiSpots[0] == _AiPathGO, Remove the parent from the list
        this._AiSpots.RemoveAt(0); 

        // Move the the start spot
        this.transform.position = this._AiSpots[this._CurrentSpotIndex].position;
        if (this._CurrentSpotIndex < this._AiSpots.Count - 1)
            this.transform.LookAt(this._AiSpots[this._CurrentSpotIndex + 1]);

        this.Stage = StealerStage.STARTENTERING;
    }

    void Update () {

        // If the stealer was hitted, do nothing
        if (this.Stage == StealerStage.DIE)
            return;
        
        switch(this.Stage)
        {
            case StealerStage.STARTENTERING:
                StartCoroutine(this.CoEntering());
                this.Stage = StealerStage.ENTERING;
                break;
            case StealerStage.STARTSTEALING:
                StartCoroutine(this.CoStealing());
                this.Stage = StealerStage.STEALING;
                break;
            case StealerStage.STARTEXITING:
                StartCoroutine(this.CoExiting());
                this.Stage = StealerStage.EXITING;
                break;
            case StealerStage.DONE:
                StartCoroutine(this.CoDone());
                break;
            case StealerStage.STARTDYING:
                StartCoroutine(this.CoExplodeAndDie());
                this.Stage = StealerStage.DIE;
                break;
            default:
                break;
        }                    
	}

    #endregion MonoBehaviours

    // Steal a burger anytime it reaches a burger
    void OnCollisionEnter(Collision collision)
    {
        // TODO: Merge here
        if (this.Stage == StealerStage.DIE)
            return;
        if (this.Stage == StealerStage.STARTDYING)
            return;

        if (collision.gameObject.tag == "Player")
        {
            this.Stage = StealerStage.STARTDYING;            
        }
        if(collision.gameObject.tag == "Food" || collision.gameObject.tag == "BurgerComponent")
        {
            this._StealerStealingAbility.StealABurger(collision.gameObject);
        }
    }

    private IEnumerator CoEntering()
    {
        while (this._CurrentSpotIndex < this._AiSpots.Count - 1)
        {
            this._PosLerpT += Time.deltaTime / (this._EnteringDuration / this._AiSpots.Count);
            this.transform.position = Vector3.Lerp(this._AiSpots[this._CurrentSpotIndex].position, this._AiSpots[_CurrentSpotIndex + 1].position, this._PosLerpT);
            if (this._PosLerpT >= 1.0f)
            {
                this._CurrentSpotIndex++;
                if (this._CurrentSpotIndex < this._AiSpots.Count - 1)
                {
                    this._PosLerpT = 0.0f;
                    this.transform.LookAt(this._AiSpots[this._CurrentSpotIndex + 1]);
                }
            }
            yield return null;
        }

        this._PosLerpT = 0.0f;

        this.Stage = StealerStage.STARTSTEALING;
    }

    private IEnumerator CoStealing()
    {
        this._StealerStealingAbility.IsStealing = true;
        yield return new WaitForSeconds(this._StealingDuration);
        this._StealerStealingAbility.IsStealing = false;
        this.Stage = StealerStage.STARTEXITING;
    }

    private IEnumerator CoExiting()
    {
        //Debug.Log("Start Exiting");
        while(this._PosLerpT < 1.0f)
        {
            this._PosLerpT += Time.deltaTime / this._ExitingDuration;
            this.transform.position = Vector3.Lerp(this.transform.position, this._AiSpots[0].position, this._PosLerpT);
            yield return null;
        }

        this.Stage = StealerStage.DONE;
    }

    private IEnumerator CoDone()
    {
        this.StoleBurgerCount = this._StealerStealingAbility.GetStolenBurgerCount();

        // TODO: GM - Change score here
        GameManager.Instance.LoseScore(this.StoleBurgerCount * 8);

        this.Stage = StealerStage.NONE;
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }

    private IEnumerator CoExplodeAndDie()
    {
        this._ExplosionParticleGO.SetActive(true);
        this._Collider.isTrigger = true;
        this._StealerStealingAbility.IsStealing = false;
        this._StealerStealingAbility.DropStolenBurgers();

        yield return new WaitForSeconds(0.1f);
        this._MeshRenderer.enabled = false;

        yield return new WaitForSeconds(2.9f);
        Destroy(this.gameObject);
    }
}
