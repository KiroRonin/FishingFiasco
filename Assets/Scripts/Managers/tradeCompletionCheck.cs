using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tradeCompletionCheck : MonoBehaviour
{
    public static tradeCompletionCheck Instance { get; set; }

    public List<NPC> npcList;

    public bool allTradeDone;

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
    
    public void checkCompletion()
    {
        var totalNPC = npcList.Count;
        var completeNPC = 0;
        for (int i = 0; i < npcList.Count; i++)
        {
            if (npcList[i].GetComponent<NPC>().isComplete == true)
            {
                completeNPC++;
            }
        }
        if (completeNPC == totalNPC)
        {
            allTradeDone = true;
        }
    }
}
