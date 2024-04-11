using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTpickupFish : MonoBehaviour
{
    


    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Fish")){
            
            FishStats.Instance.increaseFishValue(other.gameObject.GetComponent<Fish>().fish.Id);
            print("fish id:" + other.gameObject.GetComponent<Fish>().fish.Id);

            FishStats.Instance.currentFishAmount = PlayerInventory.Instance.inventoryCount;
            GameManager.Instance.SaveData();
            Destroy(other.gameObject);

        }
    }
}
