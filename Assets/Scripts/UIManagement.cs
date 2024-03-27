using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Cinemachine;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject FishIndex;
    [SerializeField] private GameObject PauseMenu;

    private bool inventoryActivated = false;
    private bool indexActivated = false;
    private bool pauseActivated = false;

    private GameObject starterIndex;
    private GameObject coralIndex;
    private GameObject undergroundIndex;
    private GameObject deepIndex;

    [SerializeField] private CharacterController Player;
    [SerializeField] private CinemachineVirtualCamera Camera;

    
    private MenuControls menuControls;
    
    void Start()
    {
        starterIndex = FishIndex.transform.GetChild(0).gameObject;
        coralIndex = FishIndex.transform.GetChild(1).gameObject;
        undergroundIndex = FishIndex.transform.GetChild(2).gameObject;
        deepIndex = FishIndex.transform.GetChild(3).gameObject;
    }

    private void Awake() {
        menuControls = new MenuControls();
    }

    private void OnEnable() {
        menuControls.Enable();

        menuControls.UI.Inventory.performed += Inventory;
        menuControls.UI.Index.performed += Index;
        menuControls.UI.Pause.performed += Pause;
    }

    private void OnDisable() {
        menuControls.Disable();

        menuControls.UI.Inventory.performed -= Inventory;
        menuControls.UI.Index.performed -= Index;
        menuControls.UI.Pause.performed -= Pause;
    }

    //INVENTORY MENU CODE
    private void Inventory(InputAction.CallbackContext context){
        Debug.Log("inventory open event");
        if (inventoryActivated){
            PlayerEnable();

            InventoryMenu.SetActive(false);
            inventoryActivated = false;
            Debug.Log("inventory closed");
        }
        else if (!inventoryActivated && !indexActivated && !pauseActivated){
            PlayerDisable();

            InventoryMenu.SetActive(true);
            inventoryActivated = true;
            Debug.Log("inventory opened");
            
        }


    }
    //INDEX MENU CODE
    private void Index(InputAction.CallbackContext context){
        Debug.Log("inventory open event");
        if (indexActivated){
            PlayerEnable();

            FishIndex.SetActive(false);
            indexActivated = false;
            Debug.Log("index closed");
          

        }
        else if (!indexActivated && !inventoryActivated && !pauseActivated){
            PlayerDisable();

            FishIndex.SetActive(true);
            indexActivated = true;
            Debug.Log("index opened");
        

        }
    }

    //PAUSE MENU CODE
    private void Pause(InputAction.CallbackContext context){
        Debug.Log("pause open event");
        if (pauseActivated){
            PlayerEnable();

            PauseMenu.SetActive(false);
            pauseActivated = false;
            Debug.Log("pause closed");


            Time.timeScale = 1;
        }
        else if (!pauseActivated && !indexActivated && !inventoryActivated){
            PlayerDisable();

            PauseMenu.SetActive(true);
            pauseActivated = true;
            Debug.Log("pause opened");
           

            Time.timeScale = 0;
        }


    }

    //FISH INDEX MENUS
    /*
    public void ChangeIndex(string objectName){
        var indexChildren = FishIndex.GetComponentsInChildren<UnityEngine.UI.Image>();
        foreach(UnityEngine.UI.Image item in indexChildren){
            print(item.gameObject.name);
            if(item.gameObject.name==objectName && item.gameObject.tag == "Index"){
                item.gameObject.SetActive(true);
                Debug.Log(objectName + " enabled");
            }
           /* else if(item.gameObject.name!=objectName && item.gameObject.tag == "Index"){
                item.gameObject.SetActive(false);
            }

        } 
    }
    */
    
    public void OpenStarterIndex(){
        //ChangeIndex("FishIndexMenu_Starter");
        starterIndex.SetActive(true);
        coralIndex.SetActive(false);
        undergroundIndex.SetActive(false);
        deepIndex.SetActive(false);
    }

    public void OpenCoralIndex(){
        //ChangeIndex("FishIndexMenu_Coral");
        //print("helloe");
        starterIndex.SetActive(false);
        coralIndex.SetActive(true);
        undergroundIndex.SetActive(false);
        deepIndex.SetActive(false);
    }

    public void OpenUndergroundIndex(){
        //ChangeIndex("FishIndexMenu_Underground");
        starterIndex.SetActive(false);
        coralIndex.SetActive(false);
        undergroundIndex.SetActive(true);
        deepIndex.SetActive(false);
    }

    public void OpenDeepIndex(){
        //ChangeIndex("FishIndexMenu_Deep");
        starterIndex.SetActive(false);
        coralIndex.SetActive(false);
        undergroundIndex.SetActive(false);
        deepIndex.SetActive(true);

    }



    void PlayerEnable(){
        Player.enabled = true;
        Camera.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void PlayerDisable(){
        Player.enabled = false;
        Camera.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        
    }
}
