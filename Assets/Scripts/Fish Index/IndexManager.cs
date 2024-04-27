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
    [SerializeField] private GameObject slot1Image;

    [SerializeField] private TextMeshProUGUI slot2Name;
    [SerializeField] private TextMeshProUGUI slot2Caught;
    [SerializeField] private GameObject slot2Image;

    [SerializeField] private TextMeshProUGUI slot3Name;
    [SerializeField] private TextMeshProUGUI slot3Caught;
    [SerializeField] private GameObject slot3Image;

    private int slot1ID;
    private int slot2ID;
    private int slot3ID;

    [SerializeField] private Sprite carpImage;
    [SerializeField] private Sprite croakerImage;
    [SerializeField] private Sprite crawfishImage;

    [SerializeField] private Sprite angelfishImage;
    [SerializeField] private Sprite grouperImage;
    [SerializeField] private Sprite sharkImage;

    [SerializeField] private Sprite blindfishImage;
    [SerializeField] private Sprite hyalineImage;
    [SerializeField] private Sprite snakeheadImage;

    [SerializeField] private Sprite seapigImage;
    [SerializeField] private Sprite catfishImage;
    [SerializeField] private Sprite squidImage;

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
            }
            if (UI.coralActive == true){
                changeSlot1("Angelfish", FishStats.Instance.angelfish);
                changeSlot2("Coral Grouper", FishStats.Instance.grouper);
                changeSlot3("Reef Shark", FishStats.Instance.shark);
            }
            if (UI.caveActive == true){
                changeSlot1("Blindfish", FishStats.Instance.blindfish);
                changeSlot2("Hyaline Fish", FishStats.Instance.hyaline);
                changeSlot3("Dragon Snakehead", FishStats.Instance.snakehead);
            }
            if (UI.deepActive == true){
                changeSlot1("Seapig", FishStats.Instance.seapig);
                changeSlot2("creature??", FishStats.Instance.creature);
                changeSlot3("Weird Squid", FishStats.Instance.squid);
            }
            
            
        }
        
    }

    void changeSlot1(string fishName, int fishCaught){
        
        slot1Name.text = fishName;
        slot1Image.GetComponentInChildren<Image>().color = Color.white;

        switch (fishName)
        {
            case "Sea Carp":
                    slot1Caught.text = "Caught: " +FishStats.Instance.carp.ToString();
                    slot1Image.GetComponent<Image>().sprite = carpImage;
                    if (fishCaught < 1){
                        slot1Name.text = "???";
                        slot1Caught.text = "Not Caught";
                        slot1Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;   
            case "Angelfish":
                    slot1Caught.text = "Caught: " +FishStats.Instance.angelfish.ToString();
                    slot1Image.GetComponent<Image>().sprite = angelfishImage;
                    if (fishCaught < 1){
                        slot1Name.text = "???";
                        slot1Caught.text = "Not Caught";
                        slot1Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
            case "Blindfish":
                    slot1Caught.text = "Caught: " +FishStats.Instance.blindfish.ToString();
                    slot1Image.GetComponent<Image>().sprite = blindfishImage;
                    if (fishCaught < 1){
                        slot1Name.text = "???";
                        slot1Caught.text = "Not Caught";
                        slot1Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;   
            case "Seapig":
                    slot1Caught.text = "Caught: " +FishStats.Instance.seapig.ToString();
                    slot1Image.GetComponent<Image>().sprite = seapigImage;
                    if (fishCaught < 1){
                        slot1Name.text = "???";
                        slot1Caught.text = "Not Caught";
                        slot1Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
                
        }
        
    }

    void changeSlot2(string fishName, int fishCaught){

        slot2Name.text = fishName;
        slot2Image.GetComponentInChildren<Image>().color = Color.white;
    
        switch (fishName)
        {
            case "Croaker":
                    slot2Caught.text = "Caught: " +FishStats.Instance.croaker.ToString();
                    slot2Image.GetComponent<Image>().sprite = croakerImage;
                    if (fishCaught < 1){
                        slot2Name.text = "???";
                        slot2Caught.text = "Not Caught";
                        slot2Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;   
            case "Coral Grouper":
                    slot2Caught.text = "Caught: " +FishStats.Instance.grouper.ToString();
                    slot2Image.GetComponent<Image>().sprite = grouperImage;
                    if (fishCaught < 1){
                        slot2Name.text = "???";
                        slot2Caught.text = "Not Caught";
                        slot2Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
            case "Hyaline Fish":
                    slot2Caught.text = "Caught: " +FishStats.Instance.hyaline.ToString();
                    slot2Image.GetComponent<Image>().sprite = hyalineImage;
                    if (fishCaught < 1){
                        slot2Name.text = "???";
                        slot2Caught.text = "Not Caught";
                        slot2Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;   
            case "creature??":
                    slot2Caught.text = "Caught: " +FishStats.Instance.creature.ToString();
                    slot2Image.GetComponent<Image>().sprite = catfishImage;
                    if (fishCaught < 1){
                        slot2Name.text = "???";
                        slot2Caught.text = "Not Caught";
                        slot2Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
        }
    }

    void changeSlot3(string fishName, int fishCaught){
        
        slot3Name.text = fishName;
        slot3Image.GetComponentInChildren<Image>().color = Color.white;

        switch (fishName)
        {
            case "Crawfish":
                    slot3Caught.text = "Caught: " +FishStats.Instance.crawfish.ToString();
                    slot3Image.GetComponent<Image>().sprite = crawfishImage;
                    if (fishCaught < 1){
                        slot3Name.text = "???";
                        slot3Caught.text = "Not Caught";
                        slot3Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;   
            case "Reef Shark":
                    slot3Caught.text = "Caught: " +FishStats.Instance.shark.ToString();
                    slot3Image.GetComponent<Image>().sprite = sharkImage;
                    if (fishCaught < 1){
                        slot3Name.text = "???";
                        slot3Caught.text = "Not Caught";
                        slot3Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
            case "Dragon Snakehead":
                    slot3Caught.text = "Caught: " +FishStats.Instance.snakehead.ToString();
                    slot3Image.GetComponent<Image>().sprite = snakeheadImage;
                    if (fishCaught < 1){
                        slot3Name.text = "???";
                        slot3Caught.text = "Not Caught";
                        slot3Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
            case "Weird Squid":
                    slot3Caught.text = "Caught: " +FishStats.Instance.squid.ToString();
                    slot3Image.GetComponent<Image>().sprite = squidImage;
                    if (fishCaught < 1){
                        slot3Name.text = "???";
                        slot3Caught.text = "Not Caught";
                        slot3Image.GetComponentInChildren<Image>().color = Color.black;
                    }
                    break;
                
        }
        
    }
   
    
}
