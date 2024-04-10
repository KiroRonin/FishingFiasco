using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int inventorySize = 5;
    public int inventoryCount; 

    public void OnTriggerEnter(Collider other) {
        var fish = other.GetComponent<Fish>();
        print("picked up");
        if (fish){
            if(inventoryCount <= inventorySize){
                inventory.AddFish(fish.fish, 1);
                Destroy(other.gameObject);
                inventoryCount++;
            }
            
        }
    }
    /*
    private void OnApplicationQuit() {
        inventory.Container.Clear();
    }
    */
}
