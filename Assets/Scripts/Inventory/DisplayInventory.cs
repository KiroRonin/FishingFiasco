using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryDisplay;
    //public GameObject tradeMenu;

    //public int NUMBER_OF_COLUMN;

    //public int X_START;
    //public int Y_START;

    //public int X_SPACE_BETWEEN_ITEM;
    //public int Y_SPACE_BETWEEN_ITEM;


    Dictionary<InventorySlot, GameObject> fishDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    void Start()
    {
        //CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }


    public void UpdateDisplay(){

        for (int i = 0; i < inventory.Container.Count; i++){
            
            var slot = inventoryDisplay.transform.GetChild(i);

            if(fishDisplayed.ContainsKey(inventory.Container[i])){
                //fishDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                print("already have fish");
            }
            else{
                
                var display = Instantiate(inventory.Container[i].fish.prefabDisplay, slot.transform.position, Quaternion.identity, transform);

                display.transform.SetParent(slot, true);
                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                //display.transform.position = new Vector3(0, 0, 0);

                fishDisplayed.Add(inventory.Container[i], display);


                print("new fish added!");
            }
            
        }
    }

    /*
    public void UpdateDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if(fishDisplayed.ContainsKey(inventory.Container[i])){
                fishDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].fish.prefabDisplay, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                
                fishDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
    */

    /*
    public void CreateDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].fish.prefabDisplay, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            fishDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i/NUMBER_OF_COLUMN)), 0f);
    }
    */

}
