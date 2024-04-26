using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private string n;
    private string k;
    public bool isTrade;

    public InventoryObject npcInventory;
    void Start()
    {
        n = gameObject.name;
        SetKnot(n);
    }

    public void SetKnot(string name)
    {
        string knot;
        knot = name;

        k = knot;
    }

    public string GetKnot()
    {
        return k;
    }

}


