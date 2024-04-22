using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private string n;
    private string k;
    public bool isTrade;

    public InventoryObject npcInventory;
    // Start is called before the first frame update
    void Start()
    {
        n = gameObject.name;
        SetKnot(n);
    }

    // Update is called once per frame
    public void SetKnot(string name)
    {
        string knot;

        if(name == "BillyBass")
        {
            knot = "SandboxTest";
        }
        else if(name == "Oarfish")
        {
            knot = "SecondTest";
        }
        else{
            knot = "";
        }

        //switch()

        k = knot;
    }

    public string GetKnot()
    {
        return k;
    }

}


