using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour
{
    public static FishStats Instance;
    
    public int carp;
    public int grouper;
    public int shark;
    public int blindfish;
    public int hyaline;
    public int snakehead;

    public int currentFishAmount;
    public int maxInventory;

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

    public void increaseFishValue(int fish)
    {
        switch(fish)
        {
            case 0:
                carp++;
                break;
            case 1:
                grouper++;
                break;
            case 2:
                shark++;
                break;
            case 3:
                blindfish++;
                break;
            case 4:
                hyaline++;
                break;
            case 5:
                snakehead++;
                break;
        }
    }

    public void setFishStats(int carp, int grouper, int shark, int blindfish, int hyaline, int snakehead, int currentFishAmount, int maxInventory)
    {
        this.carp = carp;
        this.grouper = grouper;
        this.shark = shark;
        this.blindfish = blindfish;
        this.hyaline = hyaline;
        this.snakehead = snakehead;

        this.currentFishAmount = currentFishAmount;
        this.maxInventory = maxInventory;

    }
}
