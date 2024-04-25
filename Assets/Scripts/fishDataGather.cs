using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishDataGather : MonoBehaviour
{
    public SellManager sellManager;
    //[SerializeField] private int indexID;
    [SerializeField] private FishObject fish;

    public void currentFish(){
        sellManager.currentFish = fish;
        
        Debug.Log(sellManager.currentFish.Id);
    
    }
}

