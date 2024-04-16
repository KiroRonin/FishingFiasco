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
    
    public bool dialoguePlaying;
    public bool playerInRange;
    private bool interactPressed;
    private bool canvasActivated;
    

    private NPC currentNPC;
    private string currentKnot;
    private List<Choice> curChoices;

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
            curChoices = story.currentChoices;
            print(curChoices);

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
            if (curChoices.Count < 1){
                dialogueCanvas.SetActive(false);
                print("dialouge done");
            }
            else if (curChoices.Count > 0){
                story.ChooseChoiceIndex(0);
                dialogueText.text = loadStoryChunk();
                print("dialogue continue");
                player.enabled = false;
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
            text = story.ContinueMaximally();
        }

        return text;
        
    }

    void canvasState(){
        if (starterAssetsInputs.interact && playerInRange == true && canvasActivated == false){
            canvasActivated = true;
            dialogueCanvas.SetActive(true);
        }
    }
}
