using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayTradeInventory : MonoBehaviour
{
    public InventoryObject tradeInventory;
    public GameObject tradeInventoryDisplay;

    public GameObject inventorySlotHolder;

    /*
    public int numbSlots;

    public int x_start;
    public int y_start;

    public int x_space;
    public int y_space;
    */

    Dictionary<InventorySlot, GameObject> fishDisplay = new Dictionary<InventorySlot, GameObject>();
    
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay(){

        for (int i = 0; i < tradeInventory.Container.Count; i++)
        {
            var slot = tradeInventoryDisplay.transform.GetChild(i);



            if(fishDisplay.ContainsKey(tradeInventory.Container[i])){

                slot.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.Container[i].amount.ToString("n0");

            }
            else
            {
                var display = Instantiate(tradeInventory.Container[i].fish.prefabDisplay, slot.transform.position, Quaternion.identity, transform);

                display.transform.SetParent(slot, true);

                slot.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.Container[i].amount.ToString("n0");

                fishDisplay.Add(tradeInventory.Container[i], display);
                
            }
        }
    }


}
