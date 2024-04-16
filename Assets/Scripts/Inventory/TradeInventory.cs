using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeInventory : MonoBehaviour
{
    public static TradeInventory Instance;
    
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


    // Update is called once per frame
    void Update()
    {
        
    }

}
