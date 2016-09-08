using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandController : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    HashSet<InteractableItem> objects = new HashSet<InteractableItem>();
    private InteractableItem closestItem;
    private InteractableItem inHandItem;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        return;
    }

    void Update()
    {
        if (controller.GetPressDown(triggerButton))
        {
            float min = float.MaxValue;
            float distance;

            foreach (InteractableItem obj in objects)
            {
                distance = (obj.transform.position - transform.position).sqrMagnitude;

                if (distance < min)
                {
                    min = distance;
                    closestItem = obj;
                }

                inHandItem = closestItem;

                if (inHandItem)
                {
                    if (inHandItem.IsInteracting())
                    {
                        inHandItem.EndInteraction(this);
                    }

                    inHandItem.BeginInteraction(this);
                }
            }
        }
        if (controller.GetPressUp(triggerButton) && inHandItem != null)
        {
            inHandItem.EndInteraction(this);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objects.Add(collidedItem);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objects.Remove(collidedItem);

        }
    }

}
