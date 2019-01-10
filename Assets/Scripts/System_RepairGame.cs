using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_RepairGame : Object_Interact_Parent {

    public GameObject miniGamePanel;

    public override void Awake()
    {
        //base.Awake();
    }
    public override void Start()
    {
        //base.Start();
    }

    public override void Update()
    {
        //base.Update();
    }

    public override void Interact()
    {
        base.Interact();

        GameObject tempObj;
        tempObj = Instantiate(miniGamePanel);
    }
}
