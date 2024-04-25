using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    public GameObject mapUI;
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private CharacterController Player;

    public bool mapOpen;
    private bool mapPressed;
    private bool inRange;

    public string currentScene = "Tavern";
    
    void Start()
    {
        
    }

    void Update()
    {
        if (inRange == true)
        {
            print(inRange);
            mapState();
        }
    }
    

    void mapState(){
        if (playerInput.interact && mapPressed == false){
            if (mapOpen == false){
                mapOpen = true;
                mapUI.SetActive(true);

                Player.enabled = false;
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (mapOpen == true){
                mapOpen = false;
                mapUI.SetActive(false);

                Player.enabled = true;

                cursorLock();
            }
            mapPressed = true;
        }
        else if (playerInput.interact == false){
            mapPressed = false;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            print("player enter");
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    ///
    /// /// BUTTON FUNCTIONS
    ///

    public void changeTavern()
    {
        if (SceneManager.GetActiveScene().name != "Tavern")
        {
            SceneManager.LoadScene("Tavern");
            currentScene = "Tavern";
            print("scene changed: "+currentScene);
            cursorLock();
        }

    }

    public void changeReef()
    {
        if (SceneManager.GetActiveScene().name != "Reef")
        {
            SceneManager.LoadScene("Reef");
            currentScene = "Reef";
            print("scene changed: "+currentScene);
            cursorLock();

        }
    }

    public void changeCave()
    {
        if (SceneManager.GetActiveScene().name != "Cave")
        {
            SceneManager.LoadScene("Cave");
            currentScene = "Cave";
            print("scene changed: "+currentScene);
            cursorLock();
        }
    }

    public void changeDeep()
    {
        if (SceneManager.GetActiveScene().name != "Deep")
        {
            SceneManager.LoadScene("Deep");
            currentScene = "Deep";
            print("scene changed: "+currentScene);
            cursorLock();
        }
    }

    void cursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
