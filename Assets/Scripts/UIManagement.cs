using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject FishIndex;
    [SerializeField] private GameObject PauseMenu;

    private bool inventoryActivated = false;
    private bool indexActivated = false;
    private bool pauseActivated = false;

    [SerializeField] private CharacterController Player;
    [SerializeField] private CinemachineVirtualCamera Camera;

    
    private MenuControls menuControls;
    
    void Start()
    {
        
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
            InventoryMenu.SetActive(false);
            inventoryActivated = false;
            Debug.Log("inventory closed");
            PlayerEnable();
        }
        else if (!inventoryActivated && !indexActivated && !pauseActivated){
            InventoryMenu.SetActive(true);
            inventoryActivated = true;
            Debug.Log("inventory opened");
            PlayerDisable();
        }


    }
    //INDEX MENU CODE
    private void Index(InputAction.CallbackContext context){
        Debug.Log("inventory open event");
        if (indexActivated){
            FishIndex.SetActive(false);
            indexActivated = false;
            Debug.Log("index closed");
            PlayerEnable();

        }
        else if (!indexActivated && !inventoryActivated && !pauseActivated){
            FishIndex.SetActive(true);
            indexActivated = true;
            Debug.Log("index opened");
            PlayerDisable();

        }
    }

    //PAUSE MENU CODE
    private void Pause(InputAction.CallbackContext context){
        Debug.Log("pause open event");
        if (pauseActivated){
            PauseMenu.SetActive(false);
            pauseActivated = false;
            Debug.Log("pause closed");
            PlayerEnable();

            Time.timeScale = 1;
        }
        else if (!pauseActivated && !indexActivated && !inventoryActivated){
            PauseMenu.SetActive(true);
            pauseActivated = true;
            Debug.Log("pause opened");
            PlayerDisable();

            Time.timeScale = 0;
        }


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
