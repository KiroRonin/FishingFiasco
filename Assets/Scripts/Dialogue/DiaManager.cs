using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaManager : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;

    public GameObject dialogueCanvas;
    public TextMeshProUGUI dialogueText;
    public string currentText;
    public GameObject characterSprite;
    public string npcName;
    public GameObject interactUI;
    public GameObject crosshair;

    public GameObject tradeCanvas;
    public TextMeshProUGUI tradeDescription;
    public GameObject tradeSprite;
    private bool tradeActive;

    public float scrollSpeed = 0.05f;
    
    public bool dialoguePlaying;
    public bool playerInRange;
    private bool interactPressed;
    private bool canvasActivated;
    //private bool dialogueContinue = true;

    public NPC currentNPC;
    private string currentKnot;
    private bool fillText;

    public SellManager sellManager;

    [SerializeField] private CharacterController player;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    public static DiaManager instance;
 

    void Start()
    {
        if(instance == null)
            instance = this;
        else{
            Destroy(this);
        }
        story = new Story(inkJSON.text);


    }


    void Update()
    {
        canvasState();
        chooseStoryChoice();
        tradeCanvasState();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            currentNPC = collision.gameObject.GetComponent<NPC>();
            currentKnot = currentNPC.GetKnot();
            characterSprite.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            tradeSprite.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            story.ChoosePathString(currentKnot);
            currentText = loadStoryChunk();
            //dialogueText.text = loadStoryChunk();

            npcName = collision.gameObject.name;
            print(npcName);

            sellManager.npcInventory = currentNPC.npcInventory;

            playerInRange = true;
            print(playerInRange);
            interactUI.SetActive(true);
            crosshair.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            playerInRange = false;
            print(playerInRange);
            interactUI.SetActive(false);
            crosshair.SetActive(true);
        }
    }

    
    void chooseStoryChoice(){
        if(starterAssetsInputs.interact && interactPressed == false && canvasActivated == true && tradeActive == false){
            if (story.canContinue == true){
                StopAllCoroutines();
                if (fillText == false){
                    dialogueText.text = currentText;
                    fillText = true;
                }
                else{
                    scrollText(loadStoryChunk());
                    //dialogueText.text = loadStoryChunk();
                    print(story.canContinue);
                    player.enabled = false;
                    fillText = false;
                }
                
            }
            else if (story.canContinue == false){
                StopAllCoroutines();
                if (fillText == false){
                    dialogueText.text = currentText;
                    fillText = true;
                }
                else{
                    dialogueCanvas.SetActive(false);
                    print(story.canContinue);
                    player.enabled = true;
                    canvasActivated = false;
                    //StopAllCoroutines();

                    if (currentNPC.isTrade == true){
                        print("trade can activate!!");
                        tradeCanvas.SetActive(true);
                        tradeActive = true;
                        player.enabled = false;
                        StopAllCoroutines();
                    }
                }

            }

            interactPressed = true;
        }
        else if(starterAssetsInputs.interact == false){
            interactPressed = false;
        }
        
    }

    void scrollText(string text){
        currentText = text;
        StartCoroutine(displayText());
    }

    public IEnumerator displayText(){
        dialogueText.text = "";

        foreach(char c in currentText.ToCharArray()){
            dialogueText.text += c;

            yield return new WaitForSecondsRealtime(scrollSpeed);
    
        }
        print("loop done?");
        fillText = true;
        yield return null;
    }


    string loadStoryChunk(){

        string text = "";
        
        if(story.canContinue){
            text = story.Continue();
            //dialogueContinue = true;
            Debug.Log("can continue story");
        }

        return text;
        
    }



    void canvasState(){
        if (starterAssetsInputs.interact && playerInRange == true && canvasActivated == false && interactPressed == false && tradeActive == false){
            print(playerInRange);
            canvasActivated = true;
            dialogueCanvas.SetActive(true);
            interactUI.SetActive(false);
        }
    }

    void tradeCanvasState(){
        if (starterAssetsInputs.interact && tradeActive == true && interactPressed == false){
            
            tradeActive = false;
            tradeCanvas.SetActive(false);
            player.enabled = true;
            print("exit trade screen");
            interactPressed = true;
            interactUI.SetActive(true);
        }
    }


}
