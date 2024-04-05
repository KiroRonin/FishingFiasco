using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour
{
    public static FishStats Instance;
    
    public int carp;
    public int grouper;
    public int shark;

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
        }
    }

    public void setFishStats(int carp, int grouper, int shark)
    {
        this.carp = carp;
        this.grouper = grouper;
        this.shark = shark;

    }
}
