using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public InventoryObject npcInventory;

    public GameObject inventoryBackground;

    public FishObject currentFish;
    public int currentFishID;

    public GameObject currentButton;

    public itemslot itemslot;


    // Update is called once per frame
    void Update()
    {
        clickCurrentFish();
        //npcInventory = DiaManager.instance.currentNPC.npcInventory; 
        Debug.Log("current fish id: "+ currentFishID);
        checkEmpty();
    }

    void tradeFish(){
        
    }

    public void clickCurrentFish()
    {
        //currentFishID = GetComponent<fishDataGather>().sendFishId();
        currentButton = EventSystem.current.currentSelectedGameObject;

        currentFish = currentButton.GetComponent<fishDataGather>().sendFishId();

        currentFishID = currentFish.Id;
    }

    void checkEmpty()
    {
        for (int i = 0; i < playerInventory.Container.Count; i++)
        {
            if (playerInventory.Container[i].amount == 0)
            {
                playerInventory.Container.RemoveAt(i);
                var slot = inventoryBackground.transform.GetChild(i).gameObject;
                var display = slot.transform.GetChild(0).gameObject;

                Destroy(display);

            }
        }
    }

    public void trashFish()
    {
        print("trash clicked");
        for (int i = 0; i < playerInventory.Container.Count; i++)
        {
            print(playerInventory.Container[i].fish);
            print(this.currentFish);
            if (playerInventory.Container[i].fish == this.currentFish)
            {
               print("current fish: "+currentFish);
               print("inventory fish: "+playerInventory.Container[i].fish);
               playerInventory.Container[i].amount = 0;
            }
        }
    }
}
