using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private string n;
    private string k;
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

        if(name == "NPC")
        {
            knot = "SandboxTest";
        }
        else
        {
            knot = "";
        }

        k = knot;
    }

    public string GetKnot()
    {
        return k;
    }
}

