using System;
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
    public Story story;

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
    public bool tradeActive;

    public float scrollSpeed = 0.05f;

    public bool dialoguePlaying;
    public bool playerInRange;
    public bool interactPressed;
    public bool canvasActivated;
    public bool diaActivated;

    public NPC currentNPC;
    public string currentKnot;
    public bool fillText;
    public GameObject fillUI;

    public SellManager sellManager;
    public DisplayTradeInventory displayTradeInv;

    [SerializeField] private CharacterController player;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private FirstPersonController PlayerFPC;
    public static DiaManager instance;


    void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        story = new Story(inkJSON.text);
        sellManager = GameObject.Find("SellManager").GetComponent<SellManager>();
        


    }


    void Update()
    {
        canvasState();
        chooseStoryChoice();
        tradeCanvasState();
        Playercontrol();

        if (fillText == true)
        {
            fillUI.SetActive(true);
        }
        else
        {
            fillUI.SetActive(false);
        }

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

            npcName = collision.gameObject.name;

            sellManager.npcInventory = currentNPC.npcInventory;
            displayTradeInv.tradeInventory = currentNPC.npcInventory;

            playerInRange = true;
            interactUI.SetActive(true);
            diaActivated = true;

        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            playerInRange = false;
            interactUI.SetActive(false);

            diaActivated = false;
        }
    }


    void chooseStoryChoice()
    {
        if (starterAssetsInputs.interact && interactPressed == false && canvasActivated == true && tradeActive == false)
        {
            if (story.canContinue == true)
            {
                StopAllCoroutines();
                if (fillText == false)
                {
                    dialogueText.text = currentText;
                    fillText = true;
                }
                else
                {
                    scrollText(loadStoryChunk());
                    player.enabled = false;
                    fillText = false;
                }

            }
            else if (story.canContinue == false)
            {
                StopAllCoroutines();

                if (fillText == false)
                {
                    dialogueText.text = currentText;
                    fillText = true;
                }
                else
                {
                    dialogueCanvas.SetActive(false);
                    player.enabled = true;
                    canvasActivated = false;

                    if (currentNPC.isTrade == true)
                    {
                        tradeActive = true;
                        tradeCanvas.SetActive(true);
                        playerDisable();
                        StopAllCoroutines();
                    }
                }

            }

            interactPressed = true;
        }
        else if (starterAssetsInputs.interact == false)
        {
            interactPressed = false;
        }

    }

    void scrollText(string text)
    {
        currentText = text;
        StartCoroutine(displayText());
    }

    public IEnumerator displayText()
    {
        dialogueText.text = "";

        foreach (char c in currentText.ToCharArray())
        {
            dialogueText.text += c;

            yield return new WaitForSecondsRealtime(scrollSpeed);

        }
        fillText = true;
        yield return null;
    }


    public string loadStoryChunk()
    {

        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;

    }



    void canvasState()
    {
        if (starterAssetsInputs.interact && playerInRange == true && canvasActivated == false && interactPressed == false && tradeActive == false)
        {
            
            canvasActivated = true;
            dialogueCanvas.SetActive(true);
            
            interactUI.SetActive(false);
            
        }



    }

    void tradeCanvasState()
    {
        if (starterAssetsInputs.interact && tradeActive == true && interactPressed == false)
        {

            tradeActive = false;
            tradeCanvas.SetActive(false);
            playerEnable();
            interactPressed = true;
            interactUI.SetActive(true);
        }
    }

    private void Playercontrol()
    {
        if(canvasActivated == true)
        {
            PlayerFPC.lockCam = true;
            player.enabled = false;
        }
        else if (canvasActivated == false)
        {
            PlayerFPC.lockCam = false;
            player.enabled = true;
        }
    }

    void playerEnable()
    {
        player.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void playerDisable()
    {
        player.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
