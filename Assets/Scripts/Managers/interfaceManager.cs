using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        print("current inv: " +FishStats.Instance.currentFishAmount);
    }

    // Update is called once per frame
    void Update()
    {
        inventoryUI.GetComponentInChildren<TextMeshProUGUI>().text = (FishStats.Instance.currentFishAmount + "/" +FishStats.Instance.maxInventory);
    }
}
