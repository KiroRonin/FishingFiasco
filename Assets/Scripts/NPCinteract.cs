using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class NPCinteract : MonoBehaviour
{

    public GameObject interactMenu;
    public GameObject tradeMenu;
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private FirstPersonController player;


    private bool pressedOnceTrade;
    private bool tradeActivated;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            interactMenu.SetActive(true);
            OnTrade();
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            interactMenu.SetActive(false);
      
        }
    }

    private void OnTrade(){
        if(playerInput.interact && pressedOnceTrade == false){
            if (!tradeActivated){
                PlayerDisable();

                tradeMenu.SetActive(true);
                tradeActivated = true;

            }    
            else if(tradeActivated){
            
                Debug.Log("inventory open event");
            
                PlayerEnable();

                tradeMenu.SetActive(false);
                tradeActivated = false;

                Debug.Log("inventory closed");
            }
            pressedOnceTrade = true;
        }
        else if(playerInput.interact == false){
            pressedOnceTrade =false;
        }
    } 

    void PlayerDisable(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void PlayerEnable(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
