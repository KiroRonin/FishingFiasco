using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    
    public InventoryObject inventory;

    public int inventorySize;
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

    //ADDS FISH TO INV WHEN COLLIDING; CHANGE LATER TO ALLIGN WITH THE FISHING MINIGAME!!
    public void OnTriggerEnter(Collider other) {
        var fish = other.GetComponent<Fish>();

        if (fish){
            if(inventoryCount < inventorySize){
                inventory.AddFish(fish.fish, 1);
                inventoryCount++;

                FishStats.Instance.increaseFishValue(other.gameObject.GetComponent<Fish>().fish.Id);
                FishStats.Instance.currentFishAmount = inventoryCount;
            
                Destroy(other.gameObject);

                GameManager.Instance.SaveData();
                print("ADDING TO INVENTORY:" + inventoryCount + "/" + inventorySize);
            }
            
        }
    }
    /*
    private void OnApplicationQuit() {
        inventory.Container.Clear();
    }
    */
}
