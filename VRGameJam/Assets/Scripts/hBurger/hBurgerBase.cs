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
            int test;
            for(test = 0; test < this._CustomizedOrder.Length; test++)
            {
                if(this._CurrentOrder == this._CustomizedOrder[test].x)
                {
                    GameManager.Instance.GainScore((int)this._CustomizedOrder[test].y);
                    SoundManager.Instance.CorrectBurgerCompleted();
                    break;
                }
            }
            if(test == this._CustomizedOrder.Length)
            {
                GameManager.Instance.GainScore(1);
                SoundManager.Instance.OnFloorPlay();
            }

            this._HasFinished = true;
        }
	}
}
