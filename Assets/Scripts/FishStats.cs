using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour
{
    public static FishStats Instance;
    
        //STARTER ISLAND FISH
    public int carp;
    public int croaker;
    public int crawfish;

        //CORAL REEF FISH
    //empty
    public int grouper;
    public int shark;

        //CAVE FISH
    public int blindfish;
    public int hyaline;
    public int snakehead;

        //UNDERGROUND FISH
    public int seapig;
    public int creature;
    public int squid;

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
                croaker++;
                break;
            case 2:
                crawfish++;
                break;
            case 3:
                //empty++;
                break;
            case 4:
                grouper++;
                break;
            case 5:
                shark++;
                break;
            case 6:
                blindfish++;
                break;
            case 7:
                hyaline++;
                break;
            case 8:
                snakehead++;
                break;
            case 9:
                seapig++;
                break;
            case 10:
                creature++;
                break;
            case 11:
                squid++;
                break;
        }
    }

    public void setFishStats(/*STARTER FISH*/int carp, int croaker, int crawfish, /*CORAL FISH*/ int grouper, int shark,/*CAVE FISH*/int blindfish, int hyaline, int snakehead,/*DEEP FISH*/int seapig, int creature, int squid,/*STATS*/ int currentFishAmount, int maxInventory)
    {
            //STARTER ISLAND REEF FISH UPDATE
        this.carp = carp;
        this.croaker = croaker;
        this.crawfish = crawfish;

            //CORAL REEF FISH UPDATE
        //empty
        this.grouper = grouper;
        this.shark = shark;

            //CAVE FISH UPDATE
        this.blindfish = blindfish;
        this.hyaline = hyaline;
        this.snakehead = snakehead;

            //DEEP FISH UPDATE
        this.seapig = seapig;
        this.creature = creature;
        this.squid = squid;
        
            //STATS UPDATE
        this.currentFishAmount = currentFishAmount;
        this.maxInventory = maxInventory;

    }
}
