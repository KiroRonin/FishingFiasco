using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public TradeInventoryObject npcInventory;

    public GameObject inventoryBackground;

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



    public void clickCurrentFish()
    {
        checkFish();
        if (DiaManager.instance.tradeActive == true){
            tradeFish();
        }
        
    }


    void checkFish()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        var buttonFish = currentButton.GetComponent<fishDataGather>().sendFishId();

        var slot = currentButton.transform.parent.gameObject;
        var menu = slot.transform.parent.gameObject;

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
        var slot = currentButton.transform.parent.gameObject;
        var menu = slot.transform.parent.gameObject;

        print("checking trade");

        if (menu.GetComponent<DisplayTradeInventory>() != null)
        {
            print("clicked on trade fish");
            if (currentFishID == currentTradeFishID)
            {
                var difference = currentTradeFishAmount - currentFishAmount;
                
                npcInventory.AddFish(currentTradeFish, currentFishAmount, 0);
                playerInventory.AddFish(currentFish, -currentFishAmount);

                
                displayTradeInventory.UpdateDisplay();
                displayInventory.UpdateDisplay();
                print("trade success");
            }
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
                    playerInventory.Container[i].amount = 0;
                    checkEmpty(i);
                    displayInventory.UpdateDisplay();
                }
            }
            
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
