using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryDisplay;

    Dictionary<InventorySlot, GameObject> fishDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    void Update()
    {
        UpdateDisplay();
    }


    public void UpdateDisplay(){

        for (int i = 0; i < inventory.Container.Count; i++){
            
            var slot = inventoryDisplay.transform.GetChild(i);

            if(fishDisplayed.ContainsKey(inventory.Container[i])){

                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            }
            else{
                
                var display = Instantiate(inventory.Container[i].fish.prefabDisplay, slot.transform.position, Quaternion.identity, transform);

                display.transform.SetParent(slot, true);
                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                fishDisplayed.Add(inventory.Container[i], display);

                if (DiaManager.instance.tradeActive == true){
                    //print("trade inventory active");
                    display.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
    
            }
            
        }
    }

}
