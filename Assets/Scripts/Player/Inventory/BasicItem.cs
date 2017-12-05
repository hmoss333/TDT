using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicItem {

    #region properties
    private string name; // the name of the item
    public UnityEvent OnNameChange = new UnityEvent(); // the event invoked when the property changes
    public string Name // getters and setters of the property which trigger the event
    {
        get { return name; }
        set { name = value; OnNameChange.Invoke(); }
    }
    private string graphic; // a string that holds the name of the graphical representation of the item: Sprite in the UI or the model in game-world
    public UnityEvent OnGraphicChange = new UnityEvent();
    public string Graphic
    {
        get { return graphic; }
        set { graphic = value; OnGraphicChange.Invoke(); }
    }
    private ushort maxAmount; // number that represents the maximum amount of an item in one stack (like in Minecraft)
    public UnityEvent OnMaxAmountChange = new UnityEvent();
    public ushort MaxAmount
    {
        get { return maxAmount; }
        set { maxAmount = value; OnMaxAmountChange.Invoke(); }
    }
    private ushort amount; // number that represents amount of an item in one stack
    public UnityEvent OnAmountChange = new UnityEvent();
    public ushort Amount
    {
        get { return amount; }
        set { amount = value; OnAmountChange.Invoke(); }
    }
    private float durability; // number 0-1 that represents the durability
    public UnityEvent OnDurabilityChange = new UnityEvent();
    public float Durability
    {
        get { return durability; }
        set { durability = value; OnDurabilityChange.Invoke(); }
    }
    #endregion
    #region constructors 

    // Basic constructor without parameters
    public BasicItem()
    {
        Amount = 1;
        MaxAmount = 64;
        Name = "Unnamed Item";
        Graphic = "Unknown";
        Durability = 1.0f;
    }
    // Main constructor with basic parameters
    public BasicItem(string itemName, string itemGraphic)
    {
        Amount = 1;
        MaxAmount = 64;
        Name = itemName;
        Graphic = itemGraphic;
    }
    #endregion


}
