using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryDisplay;
    public GameObject trashButton;

    public SellManager sellManager;

    Dictionary<InventorySlot, GameObject> fishDisplayed = new Dictionary<InventorySlot, GameObject>();
    

     void OnEnable() {
        sellManager = GameObject.Find("SellManager").GetComponent<SellManager>();
        UpdateDisplay();
        print(fishDisplayed.Count);
        trashButton.GetComponent<Button>().onClick.AddListener(()=>sellManager.trashFish());
    
    }

    void OnDisable() 
    {
        clearInvDisplay();
    }


    public void UpdateDisplay(){

        for (int i = 0; i < inventory.Container.Count; i++){
            
            var slot = inventoryDisplay.transform.GetChild(i);

            if(fishDisplayed.ContainsKey(inventory.Container[i])){

                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            }
            else{
                print("creating inventory slot");
                var display = Instantiate(inventory.Container[i].fish.prefabDisplay, slot.transform.position, Quaternion.identity, transform);

                display.transform.SetParent(slot, true);

                display.GetComponent<Button>().onClick.AddListener(()=>sellManager.clickCurrentFish());

                display.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                fishDisplayed.Add(inventory.Container[i], display);

                if (DiaManager.instance.tradeActive == true){
                    print("trade inventory active");
                    display.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
    
            }
            
        }
    }

    public void clearInvDisplay()
    {
         for (int i = 0; i < inventory.Container.Count; i++)
        {
            var changeSlot = inventoryDisplay.transform.GetChild(i).gameObject;
            var display = changeSlot.transform.GetChild(0).gameObject;
            Destroy(display);
            fishDisplayed.Clear();
        }
    }

    public void clearDictionary()
    {
        fishDisplayed.Clear();
    }


}
