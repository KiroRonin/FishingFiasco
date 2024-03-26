using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    
    public GameObject InventoryMenu;
    private bool menuActivated;
    
    private MenuControls menuControls;
    
    private void Awake() {
        menuControls = new MenuControls();
    }    
    
    private void OnEnable() {
        menuControls.Enable();

        menuControls.UI.Inventory.performed += Inventory;
    }

    private void OnDisable() {
        menuControls.Disable();

        menuControls.UI.Inventory.performed -= Inventory;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Inventory(InputAction.CallbackContext context){
        Debug.Log("inventory open event");
        if (menuActivated){
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Debug.Log("inventory closed");
        }
        else if (!menuActivated){
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Debug.Log("inventory opened");
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*if (menuControls.UI.Inventory.triggered){
            Debug.Log("inventory pressed!");
        }*/
        
        /*
        //code for activating and deactivating ui - STILL PENDING W. CONTROLS

        if (menuControls.UI.Inventory.triggered && menuActivated){
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Debug.Log("inventory pressed!");
        }
        else if (menuControls.UI.Inventory.triggered && !menuActivated){
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Debug.Log("inventory pressed!");
        }
        */

        
    }
}
