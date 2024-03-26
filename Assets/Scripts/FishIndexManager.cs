using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishIndexManager : MonoBehaviour
{
    public GameObject FishIndex;
    private bool indexActivated;


    public GameObject starterIndex;
    public GameObject coralIndex;
    public GameObject undergroundIndex;
    public GameObject deepwaterIndex;

    private MenuControls menuControls;
    
    private void Awake() {
        menuControls = new MenuControls();
    }    
    
    private void OnEnable() {
        menuControls.Enable();
    }

    private void OnDisable() {
        menuControls.Disable();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        //code for activating and deactivating ui - STILL PENDING W. CONTROLS

        if (menuControls.UI.Index.triggered && indexActivated){
            FishIndex.SetActive(false);
            indexActivated = false;
            Debug.Log("fish index pressed!");
        }
        else if (menuControls.UI.Index.triggered && !indexActivated){
            FishIndex.SetActive(true);
            indexActivated = true;
            Debug.Log("fish index pressed!");
        }
        
    }
}
