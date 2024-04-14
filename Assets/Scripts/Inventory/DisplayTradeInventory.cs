using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayTradeInventory : MonoBehaviour
{
    public InventoryObject tradeInventory;

    public int numbSlots;

    public int x_start;
    public int y_start;

    public int x_space;
    public int y_space;

    Dictionary<InventorySlot, GameObject> fishDisplay = new Dictionary<InventorySlot, GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay(){
        for (int i = 0; i < tradeInventory.Container.Count; i++)
        {
            if(fishDisplay.ContainsKey(tradeInventory.Container[i])){
                fishDisplay[tradeInventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(tradeInventory.Container[i].fish.prefabDisplay, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.Container[i].amount.ToString("n0");
                
                fishDisplay.Add(tradeInventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay(){
        for (int i = 0; i < tradeInventory.Container.Count; i++)
        {
            var obj = Instantiate(tradeInventory.Container[i].fish.prefabDisplay, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = tradeInventory.Container[i].amount.ToString("n0");

            fishDisplay.Add(tradeInventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(x_start + (x_space * (i % numbSlots)), y_start + (-y_start * (i/numbSlots)), 0f);
    }
}
