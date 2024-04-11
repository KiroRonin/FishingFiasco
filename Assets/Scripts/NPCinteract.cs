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

    private bool pressedOnceInteract;
    

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
        if (playerInput.interact && pressedOnceInteract == false){
            print("interacted");
            tradeMenu.SetActive(true);

            pressedOnceInteract = true;
            player.enabled = false;
        }
        else if(playerInput.interact == false){
            pressedOnceInteract = false;
        }

    }

}
