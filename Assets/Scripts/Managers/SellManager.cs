using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public TradeInventoryObject npcInventory;

    public GameObject inventoryBackground;
    public GameObject tradeInventoryBackground;

    public GameObject currentButton;

    public FishObject currentFish;
    public int currentFishID;
    public int currentFishAmount;

    public FishObject currentTradeFish;
    public int currentTradeFishAmount;
    public int currentTradeFishMax;
    public int currentTradeFishID;
    
    public DisplayInventory displayInventory;
    public DisplayTradeInventory displayTradeInventory;

    public itemslot itemslot;

    public GameObject slot;
    public GameObject menu;

    public int currentBucket;


    public void clickCurrentFish()
    {
        checkFish();
        if (DiaManager.instance.tradeActive == true && menu.GetComponent<DisplayTradeInventory>() != null){
            tradeFish();
        }
        
    }


    void checkFish()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        var buttonFish = currentButton.GetComponent<fishDataGather>().sendFish();

        slot = currentButton.transform.parent.gameObject;
        menu = slot.transform.parent.gameObject;

        //CHECKS TRADE INVENTORY
        if (menu.GetComponent<DisplayTradeInventory>() != null)
        {
            currentTradeFish = buttonFish;
            currentTradeFishID = buttonFish.Id;
            for (int i = 0; i < npcInventory.tradeContainer.Count; i++)
            {
                if (npcInventory.tradeContainer[i].fish.Id == currentTradeFishID)
                {
                    print("same id");
                    currentTradeFishAmount = npcInventory.tradeContainer[i].currentAmount;
                    currentTradeFishMax = npcInventory.tradeContainer[i].fullAmount;
                    print("current #: "+currentTradeFishAmount);
                    print("max: "+currentTradeFishMax);
                }
         
            }
        }
        //CHECKS PLAYER INVENTORY
        else if (menu.GetComponent<DisplayInventory>() != null)
        {
            currentFish = buttonFish;
            currentFishID = buttonFish.Id;
            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].fish.Id == currentFishID)
                {
                    currentFishAmount = playerInventory.Container[i].amount;
                }
            }
        }
    }

    void tradeFish()
    {
            print("clicked on trade fish");
            if (currentFishID == currentTradeFishID)
            {
                var empty = currentTradeFishMax - currentTradeFishAmount;
                var leftover = empty - currentFishAmount;
                
                if (leftover <1)
                {
                    npcInventory.AddFish(currentTradeFish, empty, 0);
                }
                else
                {
                    npcInventory.AddFish(currentTradeFish, currentFishAmount, 0);
                }
                playerInventory.AddFish(currentFish, -empty);
                FishStats.Instance.currentFishAmount -= currentFishAmount-empty;

                displayInventory.clearInvDisplayTrade();
                
                for (int i = 0; i < playerInventory.Container.Count; i++)
                {
                    checkEmpty(i);
                }

                displayTradeInventory.UpdateDisplay();
                displayInventory.UpdateDisplayTrade();
                print("trade success");
                checkTradeFinished();
            }
        
    }

    public void trashFish()
    {
        print("trash clicked");

        if (currentButton.GetComponent<fishDataGather>().fish.Id == currentFishID)
        {
            Destroy(currentButton);
            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].fish.Id == currentFishID)
                {
                    print(currentFish);
                    FishStats.Instance.currentFishAmount -= playerInventory.Container[i].amount;
                    playerInventory.Container[i].amount = 0;
                    displayInventory.clearInvDisplay();
                    checkEmpty(i);
                    displayInventory.UpdateDisplay();
                }
            }
            
        }
        
    }

    void checkEmpty(int i)
    {
        if (playerInventory.Container[i].amount <= 0)
        {
            playerInventory.Container.RemoveAt(i);
        }
    }

    void checkTradeFinished()
    {
        var openSlot = 0;
        var finishedSlot = 0;

        for (int i = 0; i < npcInventory.tradeContainer.Count; i++)
        {
            if (npcInventory.tradeContainer[i].currentAmount == npcInventory.tradeContainer[i].fullAmount)
            {
                finishedSlot++;
            }
            openSlot++;
        }
        if (finishedSlot == openSlot)
        {
            DiaManager.instance.currentNPC.isComplete = true;
        }
        
    }

}
