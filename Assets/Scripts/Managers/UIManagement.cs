using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Cinemachine;

using StarterAssets;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject FishIndex;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private Camera mainCamera;

    private bool inventoryActivated;
    public bool indexActivated;
    private bool pauseActivated;

    public bool starterActive;
    public bool coralActive;
    public bool caveActive;
    public bool deepActive;
    
    private bool pressedOnceInv;
    private bool pressedOnceInd;
    private bool pressedOncePause;

    private GameObject starterIndex;
    private GameObject coralIndex;
    private GameObject undergroundIndex;
    private GameObject deepIndex;
   

    [SerializeField] private CharacterController Player;
    [SerializeField] private CinemachineVirtualCamera Camera;

    public List<GameObject> indexMenus = new List<GameObject>();
    
    void Start()
    {
        starterIndex = FishIndex.transform.GetChild(0).gameObject;
        coralIndex = FishIndex.transform.GetChild(1).gameObject;
        undergroundIndex = FishIndex.transform.GetChild(2).gameObject;
        deepIndex = FishIndex.transform.GetChild(3).gameObject;

        indexMenus.Add(starterIndex);
        indexMenus.Add(coralIndex);
        indexMenus.Add(undergroundIndex);
        indexMenus.Add(deepIndex);
        
    }

    void Update()
    {
        OnInventory();
        OnIndex();
        OnPause();

        //Debug.Log(starterActive);
    }

    //INVENTORY MENU CODE
    private void OnInventory(){
        if(playerInput.inventory && pressedOnceInv == false){
            if (!inventoryActivated && !indexActivated && !pauseActivated){
                PlayerDisable();

                InventoryMenu.SetActive(true);
                inventoryActivated = true;

            }    
            else if(inventoryActivated){
            
                Debug.Log("inventory open event");
            
                PlayerEnable();

                InventoryMenu.SetActive(false);
                inventoryActivated = false;

                Debug.Log("inventory closed");
            }
            pressedOnceInv = true;
        }
        else if(playerInput.inventory == false){
            pressedOnceInv =false;
        }
    }
    //INDEX MENU CODE
    private void OnIndex(){
        if(playerInput.index && pressedOnceInd == false){
            if (!indexActivated && !inventoryActivated && !pauseActivated){
                PlayerDisable();

                FishIndex.SetActive(true);
                indexActivated = true;


            }    
            else if(indexActivated){
            
                Debug.Log("inventory open event");
            
                PlayerEnable();

                FishIndex.SetActive(false);
                indexActivated = false;

                Debug.Log("inventory closed");
            }
            pressedOnceInd = true;
        }
        else if(playerInput.index == false){
            pressedOnceInd =false;
        }
    } 

    //PAUSE MENU CODE
    private void OnPause(){
        if(playerInput.pause && pressedOncePause == false){
            if (!pauseActivated && !inventoryActivated && !indexActivated){
                PlayerDisable();

                PauseMenu.SetActive(true);
                pauseActivated = true;

                Time.timeScale = 0;

            }    
            else if(pauseActivated){
            
                PlayerEnable();

                PauseMenu.SetActive(false);
                pauseActivated = false;

                Time.timeScale = 1;
            }
            pressedOncePause = true;
        }
        else if(playerInput.pause == false){
            pressedOncePause =false;
        }
    } 

    //TEST CONDENSED CODE
    /*
    private void OnMenuChange(string menuType){
        if(playerInput.menuType && pressedOnce(menuType) == false){
            if (!pauseActivated && !inventoryActivated && !indexActivated){
                PlayerDisable();

                PauseMenu.SetActive(true);
                pauseActivated = true;

            }    
            else if(pauseActivated){
            
                Debug.Log("inventory open event");
            
                PlayerEnable();

                PauseMenu.SetActive(false);
                pauseActivated = false;

                Debug.Log("inventory closed");
            }
            pressedOncePause = true;
        }
        else if(playerInput.pause == false){
            pressedOncePause =false;
        }
    } 
    */


    //FISH INDEX MENUS
    
    public void ChangeIndex(string tag){
        //var indexChildren = FishIndex.GetComponentsInChildren<UnityEngine.UI.Image>(true);
        /*
        foreach(GameObject item in indexMenus){
            print("BALHHHH");
            if(item.gameObject.tag == tag){
                item.gameObject.SetActive(true);
                Debug.Log(item.gameObject.name+ " enabled");
            }
          else if(item.gameObject.tag!=tag && item.gameObject.tag!="Button"){
                item.gameObject.SetActive(false);
                print(item.gameObject.name + " disabled");
            }

        } 
        */

        // /*
        for(int i = 0; i < indexMenus.Count; i++){
            print("blahhh");
            print(indexMenus[i]);
            if(indexMenus[i].tag == tag){
                indexMenus[i].SetActive(true);
                Debug.Log(indexMenus[i].name+ " enabled");
            }
          else if(indexMenus[i].tag!=tag){
                indexMenus[i].SetActive(false);
                print(indexMenus[i].name + " disabled");
            }
        } 
        // */
    }
    
    
    public void OpenStarterIndex(){
        ChangeIndex("Starter");
        Debug.Log("starter clicked");

        starterActive = true;
        coralActive = false;
        caveActive = false;
        deepActive = false;

        
        print(starterActive);
    }

    public void OpenCoralIndex(){
        ChangeIndex("Coral");
        print("coral index");

        starterActive = false;
        coralActive = true;
        caveActive = false;
        deepActive = false;

        print(coralActive);

    }

    public void OpenUndergroundIndex(){
        ChangeIndex("Underground");
        print("cave index");

        starterActive = false;
        coralActive = false;
        caveActive = true;
        deepActive = false;

        print(caveActive);
        
    }

    public void OpenDeepIndex(){
        ChangeIndex("Deep");
        print("deep index");

        starterActive = false;
        coralActive = false;
        caveActive = false;
        deepActive = true;

        print(deepActive);
    }
    

    public void PlayerEnable(){
        Vector2 screenPosition = new Vector2(0,0);
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Player.enabled = true;
        //Camera.enabled = true;

        GetComponent<FirstPersonController>().enabled = true;
    }

    public void PlayerDisable(){
        Vector2 screenPosition = new Vector2(0,0);
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Player.enabled = false;
        //Camera.enabled = false;

        GetComponent<FirstPersonController>().enabled = false;
    }

    

}

