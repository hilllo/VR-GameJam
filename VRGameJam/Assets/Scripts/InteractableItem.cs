using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{

    public Rigidbody rigidbody;
    private bool interacting;
    public static bool playflipsound;
    public static bool playkrabssound;
    private string ControllerName;
    public static bool iscooking;
    public static bool onFloor;
    public string ItemName;
    public static bool onBun;
    public Transform StickToPoint;
    private Transform SnapToBurger;
    public Transform FirstItem;
    public Transform SecondItem;
    public Transform ThirdItem;
    public Transform FourthItem;
    public Transform FifthItem;
    public Transform SixthItem;
    public Transform SeventhItem;
    public Transform EigthItem;
    public static int pattyadded;
    public static int topbunadded;
    public static int cheeseadded;
    public static int tomatoadded;
    public static int onionadded;
    public static int lettuceadded;
    public static int picklesadded;

    public bool addon;
    public static bool done;



    protected Transform burger;
    public static int ItemCount;

    Vector3 posDelta;
    Quaternion rotDelta;
    private Vector3 axis;
    Vector3 snapto;
    private float angle;
    private WandController attachedWand;
    protected Transform PickupTransform;
    public Transform InteractionPoint;
    public static bool enabled;


    private Vector3 veloc;

    void Awake()
    {
        //initialize component
        rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.maxAngularVelocity = 100f;
    }

    public void FixedUpdate()
    {
        BurgerContent.BurgerOrder = "PLT";
        if (gameObject.name == "bottombun")
        {
           // Debug.Log("The first level is filled :====: " + gameObject.transform.GetChild(1).transform.childCount);
            /*if (gameObject.transform.GetChild(2).transform.childCount > 0)
            {
                ItemCount = 2;
            }
            else if (gameObject.transform.GetChild(1).transform.childCount > 0)
            {
                ItemCount = 1;
            }
            else if (gameObject.transform.GetChild(1).transform.childCount == 0)
            {
                ItemCount = 0;
            }*/
            //Debug.Log("The second level is filled :====: " + gameObject.transform.GetChild(2).transform.childCount);


        }

        if (attachedWand && interacting)
        {

            if (InteractionPoint != null)
            {
                posDelta = (StickToPoint.transform.position - InteractionPoint.position);//Adjust positioning of item in hand
                rotDelta = StickToPoint.transform.rotation * Quaternion.Inverse(InteractionPoint.rotation);//Adjust positioning of item in hand
            }
            else
            {
                posDelta = (PickupTransform.transform.position - this.transform.position);
                rotDelta = PickupTransform.transform.rotation * Quaternion.Inverse(this.transform.rotation);
            }



            rotDelta.ToAngleAxis(out angle, out axis);

            if (rigidbody != null)
            {
                if (angle > 180)
                    angle -= 360;

                if (angle != 0)
                {

                    Vector3 AngularTarget = angle * axis;
                    this.rigidbody.angularVelocity = Vector3.MoveTowards(this.rigidbody.angularVelocity, AngularTarget, 110f);
                }
                Vector3 VelocityTarget = posDelta / Time.fixedDeltaTime;
                this.rigidbody.velocity = Vector3.MoveTowards(this.rigidbody.velocity, VelocityTarget, 10f);
            }
        }
    }


    public void BeginInteraction(WandController wand)
    {
        if (((ItemName == "patty") && wand.transform.GetChild(0).name == "spatula") || ((ItemName != "patty") && wand.transform.GetChild(0).name == "hand")){

            attachedWand = wand;
            PickupTransform = new GameObject(string.Format("[{0}] PickupTransform", this.gameObject.name)).transform;
            PickupTransform.parent = wand.transform;
            PickupTransform.position = this.transform.position;
            PickupTransform.rotation = this.transform.rotation;
            interacting = true;
        }
    }
    public void EndInteraction(WandController wand)
    {

        if (wand == attachedWand)
        {
            attachedWand = null;
            interacting = false;

        }
    }
    public bool IsInteracting()
    {
        return interacting;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (ItemName == "patty")
        {
            if (collision.gameObject.name == "grill")
            {
                iscooking = true;

                Debug.Log("It is cooking now");
            }
            else if (collision.gameObject.name == "floor")
            {
                Debug.Log("You dropped it on the floor");
                onFloor = true;
                //Mr. Krabs comes in and yells at spongebob for dropping it on the floor $$$ yer spending all me money !
            }
            else if (collision.gameObject.name == "bottombun")
            {
                Debug.Log("Touching the bun");
                Debug.Log("Item count is ===== " + ItemCount);
                pattyadded = 1;
                addon = true;
            }
        }
        else if (ItemName == "topbun")
        {
            if (collision.gameObject.name == "floor")
            {
  
                Debug.Log("You dropped it on the floor");
                onFloor = true;
                //Mr. Krabs comes in and yells at spongebob for dropping it on the floor $$$ yer spending all me money !
            }
            else if (collision.gameObject.name == "bottombun")
            {
                topbunadded = 1;
                addon = true;
                done = true;
            }

        }
        else if (ItemName == "cheese")
        {
            if (collision.gameObject.name == "floor")
            {

                Debug.Log("You dropped it on the floor");
                onFloor = true;
                //Mr. Krabs comes in and yells at spongebob for dropping it on the floor $$$ yer spending all me money !
            }
            else if (collision.gameObject.name == "bottombun")
            {
                cheeseadded = 1;
                addon = true;

            }

        }
        else if (ItemName == "tomato")
        {
            if (collision.gameObject.name == "floor")
            {
                Debug.Log("You dropped it on the floor");
                onFloor = true;
            }
            else if (collision.gameObject.name == "bottombun")
            {
                tomatoadded = 1;
                addon = true;

            }

        }
        else if (ItemName == "onion")
        {
            if (collision.gameObject.name == "floor")
            {
                Debug.Log("You dropped it on the floor");
                onFloor = true;
            }
            else if (collision.gameObject.name == "bottombun")
            {
                onionadded = 1;
                addon = true;

            }

        }
        else if (ItemName == "lettuce")
        {
            if (collision.gameObject.name == "floor")
            {
                Debug.Log("You dropped it on the floor");
                onFloor = true;
            }
            else if (collision.gameObject.name == "bottombun")
            {
                lettuceadded = 1;
                addon = true;

            }

        }
        else if (ItemName == "pickle")
        {
            if (collision.gameObject.name == "floor")
            {
                Debug.Log("You dropped it on the floor");
                onFloor = true;
            }
            else if (collision.gameObject.name == "bottombun")
            {
                picklesadded = 1;
                addon = true;

            }

        }
        if (onFloor)
        {
            playkrabssound = true;
        }
        if (addon)
        {
            switch (ItemCount) {
                case 0:
                    SnapToBurger = FirstItem;
                    Debug.Log("Snapping to firstitem");
                    break;
                case 1:
                    SnapToBurger = SecondItem;
                    Debug.Log("Snapping to seconditem");

                    break;
                case 2:
                    SnapToBurger = ThirdItem;
                    Debug.Log("Snapping to thirditem");

                    break;
                case 3:
                    SnapToBurger = FourthItem;
                    Debug.Log("Snapping to firstitem");
                    break;
                case 4:
                    SnapToBurger = FifthItem;
                    Debug.Log("Snapping to seconditem");

                    break;
                case 5:
                    SnapToBurger = SixthItem;
                    Debug.Log("Snapping to thirditem");

                    break;
                case 6:
                    SnapToBurger = SeventhItem;
                    Debug.Log("Snapping to seconditem");

                    break;
                case 7:
                    SnapToBurger = EigthItem;
                    Debug.Log("Snapping to thirditem");

                    break;
            }

            gameObject.transform.SetParent(SnapToBurger.transform, true);
            gameObject.transform.localPosition = SnapToBurger.transform.localPosition;

            gameObject.transform.localRotation = Quaternion.identity;


            Destroy(gameObject.GetComponent<Rigidbody>());
            attachedWand = null;
            interacting = false;
            addon = false;
            
            if (done == true)
            {
                
                //Destroy(gameObject.transform.parent);
            }
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        onFloor = false;
        iscooking = false;
        enabled = false;
        playkrabssound = false;
        addon = false;
        done = false;
        

    }

}
