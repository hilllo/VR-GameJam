using UnityEngine;
using System.Collections;

public class BurgerContent : MonoBehaviour {
    public static string BurgerOrder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        InteractableItem.ItemCount = InteractableItem.pattyadded + InteractableItem.topbunadded + InteractableItem.picklesadded + InteractableItem.onionadded + InteractableItem.lettuceadded + InteractableItem.tomatoadded + InteractableItem.cheeseadded;



        Debug.Log("Count is === " + InteractableItem.ItemCount);
        if (BurgerOrder == "PLT")
        {
            if (InteractableItem.done == true && ((InteractableItem.ItemCount == 4) && (InteractableItem.topbunadded + InteractableItem.pattyadded + InteractableItem.picklesadded + InteractableItem.tomatoadded) == 4))
            {
                //Add To Score
                Debug.Log("You got a PLT RIGHT!");
            }
        }
        else if (BurgerOrder == "CheesePatty")
        {
            if (InteractableItem.done && ((InteractableItem.ItemCount) == (InteractableItem.topbunadded + InteractableItem.pattyadded + InteractableItem.cheeseadded)))
            {
                //Add To Score
                Debug.Log("You got a CheesePatty RIGHT!");

            }
        }
        else if (BurgerOrder == "Pickley")
        {
            if (InteractableItem.done && ((InteractableItem.ItemCount) == (InteractableItem.topbunadded + InteractableItem.pattyadded + InteractableItem.tomatoadded + InteractableItem.picklesadded + InteractableItem.lettuceadded)))
            {
                Debug.Log("You got a Pickley RIGHT!");

                //Add To Score
            }
        }
        else if (BurgerOrder == "Loaded")
        {
            if (InteractableItem.done && ((InteractableItem.ItemCount) == 7))
            {
                Debug.Log("You got a Loaded RIGHT!");

                //Add To Score
            }
        }
    }
}
