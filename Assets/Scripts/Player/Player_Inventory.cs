using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour {

    #region public
    public BasicContainer mainContainer = new BasicContainer();
    #endregion

    void OnGUI()
{
    if (GUI.Button(new Rect(10, 10, 150, 100), "Add item"))
    {
        BasicItem item = new BasicItem("Test Item", "BasicIcon");
        item.Amount = (ushort)Random.Range(1, 10);
        item.Durability = Random.Range(0.1f, 1.0f);
        mainContainer.AddItemAsASingleStack(item);
    }
}
private void Start()
{
     mainContainer.OnInventoryChange.AddListener(delegate { Debug.Log("Inventory changed!"); });
}
}
