using UnityEngine;
using System.Collections;

public class hBurgerDetectingZone : MonoBehaviour {

    [SerializeField]
    private Transform _Identity;

    [SerializeField]
    private Collider _Collider;

    [SerializeField]
    private hBurgerComponent _BurgerComponent;

    [SerializeField]
    private bool AutoAdjustment = true;	

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BurgerComponent")
        {
            hBurgerComponent burgerComponent = other.GetComponent<hBurgerComponent>();
            if(burgerComponent && !burgerComponent.HasBeenAttached)
            {
                if (AutoAdjustment)
                {
                    Vector3 newPos = this.gameObject.transform.position;
                    newPos.y += ( other.transform.localScale.y / 2.0f );
                    other.gameObject.transform.position = newPos;

                    Quaternion newQuat = Quaternion.Euler(this.gameObject.transform.rotation.eulerAngles.x, other.gameObject.transform.rotation.eulerAngles.y, this.gameObject.transform.rotation.eulerAngles.z);

                    other.gameObject.transform.rotation = newQuat;
                }
                other.gameObject.transform.SetParent(this._Identity);
                burgerComponent.AttachToBurger();

                // Register all burger components above in this (current) gameObject's hBurgerComponent._AboveBurgerComponents
                hBurgerComponent currentBaseBurgerComponent = this._BurgerComponent.CurrentBase.GetComponent<hBurgerComponent>();
                currentBaseBurgerComponent._AboveBurgerComponents.AddRange(burgerComponent.CurrentBase.GetComponent<hBurgerComponent>()._AboveBurgerComponents);

                // Change every bases of components above to this (current) gameObject
                foreach(GameObject childrenBurgerComponent in burgerComponent._AboveBurgerComponents)
                {
                    childrenBurgerComponent.GetComponent<hBurgerComponent>().CurrentBase = this._BurgerComponent.CurrentBase;
                }

                // Remove Detecting Zone
                Destroy(this.gameObject);
            }
        }
    }
}
