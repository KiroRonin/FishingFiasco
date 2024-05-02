using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WaterSource
{
    Tavern,
    Coral,
    Cave,
    Deep
}

public class FishingSystem : MonoBehaviour
{
    public static FishingSystem Instance { get; set; }

    public List<FishObject> TavernFishList;
    public List<FishObject> CoralFishList;
    public List<FishObject> CaveFishList;
    public List<FishObject> DeepFishList;

    
    public GameObject FishingMinigame;


    public bool IsBiting;

    public int Id;
    public FishObject fish;
    public FishingRod fishingRod;

    private string scenename;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;


    }
    public void StartFishing(WaterSource watersource)
    {
        StartCoroutine(FishingCoroutine(watersource));
    }

    IEnumerator FishingCoroutine(WaterSource watersource)
    {
        yield return new WaitForEndOfFrame();


        fish = CalculateBite(watersource);
        Id = fish.Id;
        Debug.Log(Id);

        Debug.Log(fish.fishName + " IS BITING");
        fishingRod.PullRod();
        fishingRod.animator.SetBool("IsPulling", true);
        fishingRod.animator.SetBool("IsMinigame", true);
        FishingMinigame.SetActive(true);
        


    }



    public FishObject CalculateBite(WaterSource watersource)
    {
        List<FishObject> availableFish = GetAvailableFish(watersource);

        float totalprobability = 0f;
        foreach (FishObject fish in availableFish)
        {
            totalprobability += fish.probability;
        }

        int randomvalue = UnityEngine.Random.Range(0, Mathf.FloorToInt(totalprobability + 1));
        Debug.Log("Random Value is" + randomvalue);

        float cumProbability = 0f;
        foreach (FishObject fish in availableFish)
        {
            cumProbability += fish.probability;
            if (randomvalue <= cumProbability)
            {
                return fish;
            }
        }

        return null;

    }

    private List<FishObject> GetAvailableFish(WaterSource watersource)
    {
        switch (watersource)
        {
            case WaterSource.Tavern:
                return TavernFishList;
            case WaterSource.Coral:
                return CoralFishList;
            case WaterSource.Cave:
                return CaveFishList;
            case WaterSource.Deep:
                return DeepFishList;
            default:
                return null;

        }
    }
}
