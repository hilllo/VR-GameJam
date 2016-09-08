using UnityEngine;
using System.Collections;

public class SpawnIngredients : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private IngredientsBox ingredient;
    private bool generate;
    private bool generated;
    private string ItemtoSpawn;
    private string BoxName;

    private GameObject prefab;

    [SerializeField]
    private GameObject pattyprefab;
    [SerializeField]
    private GameObject cheeseprefab;
    [SerializeField]
    private GameObject lettuceprefab;
    [SerializeField]
    private GameObject tomatoprefab;
    [SerializeField]
    private GameObject pickleprefab;
    [SerializeField]
    private GameObject topbunprefab;
    [SerializeField]
    private GameObject bottombunprefab;
    [SerializeField]
    private GameObject onionprefab;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        return;
    }

    void Update()
    {
        if (controller.GetPressDown(triggerButton) && generate == true)
        {
            switch (BoxName)
            {
                case "PattyBox":
                    prefab = pattyprefab;
                    break;
                case "TopBunBox":
                    prefab = topbunprefab;
                    break;
                case "BottomBunBox":
                    prefab = bottombunprefab;
                    break;
                case "LettuceBox":
                    prefab = lettuceprefab;
                    break;
                case "CheeseBox":
                    prefab = cheeseprefab;
                    break;
                case "PickleBox":
                    prefab = pickleprefab;
                    break;
                case "TomatoBox":
                    prefab = tomatoprefab;
                    break;
                case "OnionBox":
                    prefab = onionprefab;
                    break;
            }
            Instantiate(prefab, this.transform.position, this.transform.rotation);
            Debug.Log("Making new ingredient nowwww");
            generated = true;
        }
        if (controller.GetPressUp(triggerButton) && generated)
        {

            generated = false;
        }

    }

    void OnTriggerStay(Collider collider)
    {
        IngredientsBox collideingredientbox = collider.gameObject.GetComponent<IngredientsBox>();
        if (collideingredientbox)
        {
            BoxName = collider.transform.name;
            generate = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        IngredientsBox collideingredientbox = collider.GetComponent<IngredientsBox>();
        if (collideingredientbox)
        {
            generate = false;
        }
    }
}

