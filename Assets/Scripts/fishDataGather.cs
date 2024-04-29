using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishDataGather : MonoBehaviour
{
    [SerializeField] private FishObject fish;
    [SerializeField] private itemslot slotId;

    public FishObject sendFishId()
    {
        return fish;
    }
}

