using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public TradeInventoryObject npcInventory;

    public GameObject inventoryBackground;

    public FishObject currentFish;
    public int currentFishID;
    public GameObject currentButton;

    public FishObject currentTradeFish;
    public int currentTradeFishID;

    public DisplayInventory displayInventory;

    public itemslot itemslot;


    

    public void clickCurrentFish()
    {
        checkFish();
    }


    public void trashFish()
    {
        print("trash clicked");

        if (currentButton.GetComponent<fishDataGather>().fish.Id == currentFishID)
        {
            print("clicked");
            Destroy(currentButton);

            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].fish.Id == currentFishID)
                {
                    print(currentFish);
                    playerInventory.Container[i].amount = 0;
                    checkEmpty(i);
                    displayInventory.UpdateDisplay();
                }
            }
            
        }
        
    }

    void checkFish()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        var buttonFish = currentButton.GetComponent<fishDataGather>().sendFishId();

        var slot = currentButton.transform.parent.gameObject;
        var menu = slot.transform.parent.gameObject;

        if (menu.GetComponent<DisplayTradeInventory>() != null)
        {
            print("trade UI");
            currentTradeFish = buttonFish;
            currentTradeFishID = buttonFish.Id;
        }
        else if (menu.GetComponent<DisplayInventory>() != null)
        {
            print("inventory UI");
            currentFish = buttonFish;
            currentFishID = buttonFish.Id;
        }
    }


     void checkEmpty(int i)
    {
        print(playerInventory.Container[i].fish);
        print(playerInventory.Container[i].amount);

        if (playerInventory.Container[i].amount == 0)
        {
            playerInventory.Container.RemoveAt(i);
            var slot = inventoryBackground.transform.GetChild(i).gameObject;
            var display = slot.transform.GetChild(0).gameObject;
            print("destroying slot "+i);
            Destroy(display);
        }
    }
}
