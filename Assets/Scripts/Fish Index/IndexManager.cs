using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IndexManager : MonoBehaviour
{
    public UIManagement UI;
    
    [SerializeField] private TextMeshProUGUI slot1Name;
    [SerializeField] private TextMeshProUGUI slot1Caught;

    [SerializeField] private TextMeshProUGUI slot2Name;
    [SerializeField] private TextMeshProUGUI slot2Caught;

    [SerializeField] private TextMeshProUGUI slot3Name;
    [SerializeField] private TextMeshProUGUI slot3Caught;

    private int slot1ID;
    private int slot2ID;
    private int slot3ID;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.indexActivated == true){
            if (UI.starterActive == true){
                changeSlot1("Sea Carp", FishStats.Instance.carp);
                changeSlot2("Croaker", FishStats.Instance.croaker);
                changeSlot3("Crawfish", FishStats.Instance.crawfish);
                //Debug.Log("starter active");
            }
            if (UI.coralActive == true){
                changeSlot1("Sea Carp", FishStats.Instance.carp);
                changeSlot2("Coral Grouper", FishStats.Instance.grouper);
                changeSlot3("Reef Shark", FishStats.Instance.shark);
                Debug.Log("coral activity: "+ UI.coralActive);
            }
            if (UI.caveActive == true){
                changeSlot1("Blindfish", FishStats.Instance.blindfish);
                changeSlot2("Hyaline Fish", FishStats.Instance.hyaline);
                changeSlot3("Dragon Snakehead", FishStats.Instance.snakehead);
                //Debug.Log("coral activity: "+ UI.coralActive);
            }
            if (UI.deepActive == true){
                changeSlot1("Seapig", FishStats.Instance.seapig);
                changeSlot2("creature??", FishStats.Instance.creature);
                changeSlot3("Weird Squid", FishStats.Instance.squid);
                //Debug.Log("coral activity: "+ UI.coralActive);
            }
            
            
        }
        
    }

    void changeSlot1(string fishName, int fishCaught){
        if (fishCaught < 1){
            slot1Name.text = "???";
            slot1Caught.text = "Not Found";
        }
        else{
            slot1Name.text = fishName;
        
            switch (fishName)
            {
                case "Sea Carp":
                        slot1Caught.text = "Caught: " +FishStats.Instance.carp.ToString();
                        break;   
                case "Coral Grouper":
                        slot1Caught.text = "Caught: " +FishStats.Instance.grouper.ToString();
                        break;
                case "Blindfish":
                        slot2Caught.text = "Caught: " +FishStats.Instance.blindfish.ToString();
                        break;   
                case "Seapig":
                        slot2Caught.text = "Caught: " +FishStats.Instance.seapig.ToString();
                        break;
                    
            }
        }
    }

    void changeSlot2(string fishName, int fishCaught){
        if (fishCaught < 1){
            slot2Name.text = "???";
            slot2Caught.text = "Not Found";
        }
        else{
            slot2Name.text = fishName;
        
            switch (fishName)
            {
                case "Croaker":
                        slot2Caught.text = "Caught: " +FishStats.Instance.croaker.ToString();
                        break;   
                case "Coral Grouper":
                        slot2Caught.text = "Caught: " +FishStats.Instance.grouper.ToString();
                        break;
                case "Hyaline Fish":
                        slot2Caught.text = "Caught: " +FishStats.Instance.hyaline.ToString();
                        break;   
                case "creature??":
                        slot2Caught.text = "Caught: " +FishStats.Instance.creature.ToString();
                        break;
            }
        }
    }

    void changeSlot3(string fishName, int fishCaught){
        if (fishCaught < 1){
            slot3Name.text = "???";
            slot3Caught.text = "Not Found";
        }
        else{
            slot3Name.text = fishName;
        
            switch (fishName)
            {
                case "Crawfish":
                        slot3Caught.text = "Caught: " +FishStats.Instance.crawfish.ToString();
                        break;   
                case "Reef Shark":
                        slot3Caught.text = "Caught: " +FishStats.Instance.shark.ToString();
                        break;
                case "Dragon Snakehead":
                        slot3Caught.text = "Caught: " +FishStats.Instance.snakehead.ToString();
                        break;
                case "Weird Squid":
                        slot3Caught.text = "Caught: " +FishStats.Instance.squid.ToString();
                        break;
                    
            }
        }
    }
   
    
}
