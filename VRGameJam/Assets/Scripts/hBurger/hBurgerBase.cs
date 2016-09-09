using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hBurgerBase : MonoBehaviour {

    [SerializeField]
    private hBurgerComponent _BurgerComponent;

    [SerializeField]
    private List<string> _Ingredient;

    [SerializeField]
    private Vector2[] _CustomizedOrder;

    [SerializeField]
    private int _CurrentOrder = 0;

    private bool _HasFinished = false;

    void Update () {
        if (!this._HasFinished && this._BurgerComponent.HasTop)
        {
            // Calculate order
            List<GameObject> aboveBurgerComponents = this._BurgerComponent.AboveBurgerComponents;
            for (int i = 1; i < this._BurgerComponent.AboveBurgerComponents.Count - 1; i++)
            {
                for(int j = 0; j < this._Ingredient.Count; j++)
                {
                    if (this._BurgerComponent.AboveBurgerComponents[i].name.Contains(this._Ingredient[j]))
                    {
                        this._CurrentOrder = this._CurrentOrder * 10 + j + 1;
                        break;
                    }                        
                }
            }

            // Calculate Score
            for(int i = 0; i < this._CustomizedOrder.Length; i++)
            {
                if(this._CurrentOrder == this._CustomizedOrder[i].x)
                {
                    GameManager.Instance.GainScore((int)this._CustomizedOrder[i].y);
                    break;
                }
            }

            this._HasFinished = true;
        }
	}
}
