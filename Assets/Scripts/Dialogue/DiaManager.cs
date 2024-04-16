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
    public GameObject characterSprite;
    public string npcName;
    
    public bool dialoguePlaying;
    public bool playerInRange;
    private bool interactPressed;
    private bool canvasActivated;
    private bool dialogueContinue = true;

    private NPC currentNPC;
    private string currentKnot;

    [SerializeField] private CharacterController player;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
 

    void Start()
    {
        story = new Story(inkJSON.text);
    }


    void Update()
    {
        canvasState();
        chooseStoryChoice();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            currentNPC = collision.gameObject.GetComponent<NPC>();
            currentKnot = currentNPC.GetKnot();
            characterSprite.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            story.ChoosePathString(currentKnot);
            dialogueText.text = loadStoryChunk();

            npcName = collision.gameObject.name;
            print(npcName);


            playerInRange = true;
            print(playerInRange);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            playerInRange = false;
            print(playerInRange);
        }
    }

    void chooseStoryChoice(){
        if(starterAssetsInputs.interact && interactPressed == false && canvasActivated == true){
            if (story.canContinue == true){
                dialogueText.text = loadStoryChunk();
                print(story.canContinue);
                player.enabled = false;
            }
            else if (story.canContinue == false){
                dialogueCanvas.SetActive(false);
                print(story.canContinue);
                player.enabled = true;
                canvasActivated = false;
            }

            interactPressed = true;
        }
        else if(starterAssetsInputs.interact == false){
            interactPressed = false;
        }
        
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
        if (starterAssetsInputs.interact && playerInRange == true && canvasActivated == false && interactPressed == false){
            canvasActivated = true;
            dialogueCanvas.SetActive(true);
        }
    }
}
