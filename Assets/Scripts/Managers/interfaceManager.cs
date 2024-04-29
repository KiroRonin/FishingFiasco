using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class interfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject bucketImage;
    [SerializeField] private GameObject indexImage;

    [SerializeField] private Sprite emptyInv;
    [SerializeField] private Sprite containedInv;
    [SerializeField] private Sprite fullInv;

    // Start is called before the first frame update
    void Start()
    {
        print("current inv: " +FishStats.Instance.currentFishAmount);
    }

    // Update is called once per frame
    void Update()
    {
        inventoryUI.GetComponentInChildren<TextMeshProUGUI>().text = FishStats.Instance.currentFishAmount + "/" +FishStats.Instance.maxInventory;
        invDisplay();
    }

    private void invDisplay(){
        if (FishStats.Instance.currentFishAmount == 0){
            bucketImage.GetComponent<UnityEngine.UI.Image>().sprite = emptyInv;
        }
        if(FishStats.Instance.currentFishAmount > 0){
            bucketImage.GetComponent<UnityEngine.UI.Image>().sprite = containedInv;
        }
        if(FishStats.Instance.currentFishAmount == FishStats.Instance.maxInventory){
            bucketImage.GetComponent<UnityEngine.UI.Image>().sprite = fullInv;
        }
    }

    public void hideUI(){
        indexImage.transform.Rotate(0f, 0f,10f, Space.Self);

    }
}
