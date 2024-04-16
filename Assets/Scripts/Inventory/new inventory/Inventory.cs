using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public List<Slot> InventorySlots = new List<Slot>();

    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Slot uiSlot in InventorySlots)
        {
            uiSlot.inistializeSlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
