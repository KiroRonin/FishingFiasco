using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    
    public InventoryObject inventory;

    public int inventorySize = 5;
    public int inventoryCount = 0; 

      public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) {
        var fish = other.GetComponent<Fish>();
        print("picked up");
        if (fish){
            if(inventoryCount < inventorySize){
                inventory.AddFish(fish.fish, 1);
                Destroy(other.gameObject);
                inventoryCount++;
                print(inventoryCount);
            }
            
        }
    }
    /*
    private void OnApplicationQuit() {
        inventory.Container.Clear();
    }
    */
}
