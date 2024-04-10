using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTpickupFish : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Fish")){
            FishStats.Instance.increaseFishValue(0);
            Debug.Log("carp value: " + FishStats.Instance.carp);
            GameManager.Instance.SaveData();
            Destroy(other.gameObject);


        }
    }
}
