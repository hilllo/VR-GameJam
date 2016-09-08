using UnityEngine;
using System.Collections;

public class h_InteractableObject : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The Ojbect that is interacting.
    /// </summary>
    private bool _IsInteracting = false;

    /// <summary>
    /// The Ojbect that is picked up.
    /// </summary>
    private h_WandController _AttachedWand;

    /// <summary>
    /// The _InteractionPoint of the object
    /// </summary>
    private GameObject _InteractionPoint;

    #endregion Fields

    #region Properties

    /// <summary>
    /// The index of the current controller
    /// </summary>
    public bool IsInteracting
    {
        get
        {
            return this._IsInteracting;
        }
    }

    /// <summary>
    /// The current controller
    /// </summary>
    public h_WandController AttachedWand
    {
        get
        {
            return this._AttachedWand;
        }
    }

    /// <summary>
    /// The _InteractionPoint of the object
    /// </summary>
    protected GameObject InteractionPoint
    {
        get
        {
            return this._InteractionPoint;
        }
    }

    #endregion Properties

    #region MonoBehaviour

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        this.OnStart();
    }

    /// <summary>
    /// OnStart
    /// </summary>
    protected virtual void OnStart()
    {
        this._InteractionPoint = new GameObject("InteractionPoint");
        this._InteractionPoint.transform.SetParent(this.transform,true);
    }

    #endregion MonoBehaviour

    /// <summary>
    /// StartInteraction
    /// </summary>
    public void StartInteraction(h_WandController wand)
    {
        this._AttachedWand = wand;
        this._InteractionPoint.transform.position = wand.transform.position;
        this._InteractionPoint.transform.rotation = wand.transform.rotation;

        this._IsInteracting = true;
    }

    /// <summary>
    /// EndInteraction
    /// </summary>
    public void EndInteration(h_WandController wand)
    {
        if(this._AttachedWand == wand)
        {
            this._AttachedWand = null;
            this._IsInteracting = false;
        }
    }

}
