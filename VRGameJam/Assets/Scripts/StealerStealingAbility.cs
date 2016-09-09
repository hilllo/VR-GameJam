using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StealerStealingAbility : MonoBehaviour {

    [SerializeField]
    private Transform _StealerTrans;

    [SerializeField]
    private float _ForceValue;

    private List<GameObject> _StolenBurgers;

    public bool IsStealing;

	void Start () {
        this._StolenBurgers = new List<GameObject>();
        this.IsStealing = false;
	}	

    void OnTriggerStay(Collider other)
    {
        if (!this.IsStealing)
            return;

        Debug.Log(other.gameObject.name);
        //other.transform.Translate(this._StealerTrans.position * Time.deltaTime);
        if (other.gameObject.tag == "Food" || other.gameObject.tag == "BurgerComponent")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * this._ForceValue);
        }            
    }

    public void StealABurger(GameObject burger)
    {
        this._StolenBurgers.Add(burger);
        burger.SetActive(false);
    }

    public void DropStolenBurgers()
    {
        foreach(GameObject stolenBurger in this._StolenBurgers)
        {
            stolenBurger.transform.position = this.transform.parent.position;
            stolenBurger.SetActive(true);
        }
    }

    public int GetStolenBurgerCount()
    {
        int count =  this._StolenBurgers.Count;
        foreach(GameObject stolenBurger in this._StolenBurgers)
        {
            Destroy(stolenBurger);
        }
        return count;
    }
}
