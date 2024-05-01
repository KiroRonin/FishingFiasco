using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayTradeInventory : MonoBehaviour
{
    public TradeInventoryObject tradeInventory;
    public GameObject tradeInventoryDisplay;

    public GameObject inventorySlotHolder;

    Dictionary<TradeInventorySlot, GameObject> fishDisplay = new Dictionary<TradeInventorySlot, GameObject>();
    
    void OnEnable()
    {
        UpdateDisplay();
    }

    void OnDisable() 
    {
        clearTradeDisplay();
    }

    public void UpdateDisplay(){
        for (int i = 0; i < tradeInventory.tradeContainer.Count; i++)
        {
            var container = Instantiate(inventorySlotHolder, transform.position, Quaternion.identity, transform);
            
            container.transform.SetParent(tradeInventoryDisplay.transform, true);
            print(container);

            var slot = tradeInventoryDisplay.transform.GetChild(i);

            if(fishDisplay.ContainsKey(tradeInventory.tradeContainer[i])){
                print("key thing " + tradeInventory.tradeContainer[i]);
                slot.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.tradeContainer[i].currentAmount.ToString("n0") +"/"+tradeInventory.tradeContainer[i].fullAmount.ToString("n0");

            }
            else
            {
                var display = Instantiate(tradeInventory.tradeContainer[i].fish.prefabDisplay, slot.transform.position, Quaternion.identity, transform);

                display.transform.SetParent(slot, true);
                display.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

                slot.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.tradeContainer[i].currentAmount.ToString("n0") +"/"+tradeInventory.tradeContainer[i].fullAmount.ToString("n0");

                fishDisplay.Add(tradeInventory.tradeContainer[i], display);
                
            }
        }
    }

    public void clearTradeDisplay()
    {
        for (int i = 0; i < tradeInventory.tradeContainer.Count; i++)
        {
            var changeSlot = tradeInventoryDisplay.transform.GetChild(i).gameObject;
            Destroy(changeSlot);
            fishDisplay.Clear();
        }
    }


}
