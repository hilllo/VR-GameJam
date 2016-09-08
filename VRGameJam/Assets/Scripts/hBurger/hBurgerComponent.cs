using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hBurgerComponent : MonoBehaviour {

    [SerializeField]
    private Rigidbody _Rigidbody;

    [SerializeField]
    private h_PickableObject _h_PickableObject;
    
    private GameObject _InteractionPoint;

    [SerializeField]
    public List<GameObject> _AboveBurgerComponents;

    public bool HasBeenAttached = false;

    [SerializeField]
    public hBurgerComponent CurrentBase;

    void Start()
    {
        this._AboveBurgerComponents.Add(this.gameObject);
        this.CurrentBase = this;
    }

    void Update()
    {
        if(!this._InteractionPoint && this.transform.FindChild("InteractionPoint"))
            this._InteractionPoint = this.transform.FindChild("InteractionPoint").gameObject;

    }

    public void AttachToBurger(bool hasTop = false)
    {
        this.HasBeenAttached = true;
        Destroy(this._Rigidbody);
        Destroy(this._h_PickableObject);
        Destroy(this._InteractionPoint);
        //Destroy(this);
    }
}
