using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    public static NPCStats Instance;

    //tavern island
    public bool tavernBadge;
    public int tavernCompletion;
    public int tavernLimit;

    //reef island
    public bool reefBadge;
    public int reefCompletion;
 
    //cave island
    public bool caveBadge;
    public int caveCompletion;

    //deep island
    public bool deepBadge;
    public bool deepCompletion;



    void Start()
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

    void Update()
    {
        
    }



    public void setNPCStats()
    {

    }
}
