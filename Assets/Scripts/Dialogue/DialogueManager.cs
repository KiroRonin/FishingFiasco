using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public TextAsset inkJSON;
    private Story story;

    private NPC currentNPC;
    private string currentKnot;

    //public InputAction pressUp;
    //public InputAction pressDown;

    public bool dialogueIsPlaying { get; private set; }
    private bool dialogueJustPlayed = false;
    public StarterAssetsInputs starterAssetsInputs;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;
    [SerializeField] private CharacterController player;

    
    //private Color chosen = new Color(1, 1, 1, 0.65f);
    //private Color notChosen = new Color(1, 1, 1, 0.3f);
    private List<Choice> curChoices;
    private int choiceInd = 0;
    private Choice playerChoice;
    

    public void Awake()
    {
        //pressUp = InputSystem.actions.FindAction("up");
        //pressDown = InputSystem.actions.FindAction("down");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        //pressUp = starterAssetsInputs.up;

        story = new Story(inkJSON.text);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
             index++;
        }
        Debug.Log(story.Continue());
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            currentNPC = collision.gameObject.GetComponent<NPC>();
            currentKnot = currentNPC.GetKnot();
            story.ChoosePathString(currentKnot);
        }
    }

    public void Update()
    {
        if (starterAssetsInputs.interact && dialogueIsPlaying == false)
        {
            //Debug.Log(story.Continue());
            EnterDialogueMode();
            starterAssetsInputs.interact = false;
        }

        if (starterAssetsInputs.interact && dialogueIsPlaying == true && curChoices.Count > 0)
        {
            MakeChoice(choiceInd);
            ExitDialogueMode();
        }
        //ends the dialogue
        if (starterAssetsInputs.interact && dialogueIsPlaying == true && curChoices.Count == 0)
        {
            ContinueStory();
            ExitDialogueMode();
        }
        /*
        if (starterAssetsInputs.up && choiceInd > 0)
        {
            //Debug.Log("UP");
            choiceInd--;
            ChangeChoice(choiceInd);
        }

        if (starterAssetsInputs.down && choiceInd < curChoices.Count - 1)
        {
            //Debug.Log("DOWN");
            choiceInd++;
            ChangeChoice(choiceInd);
        }
        */
    }

    private void FixedUpdate()
    {
        if (story.canContinue == false && dialogueIsPlaying == false)
        {
            dialoguePanel.SetActive(false);
        }
    }


    public void EnterDialogueMode()
    {
        //story = new Story(inkJSON.text);
        choiceInd = 0;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        
        dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);
        dialogueText.text = "";
        player.enabled = true;
        GameObject myEventSystem = GameObject.Find("UI_EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(choices[0]);
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
            DisplayChoices();
        }
        else
        {
            dialogueJustPlayed = true;
            dialoguePanel.SetActive(false);
            StartCoroutine(StopDialogue());
        }
        //GameObject myEventSystem = GameObject.Find("UI_EventSystem");
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(choices[0]);
    }
    
    private void DisplayChoices()
    {
        curChoices = story.currentChoices;
        if (curChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + curChoices.Count);
        }
        int index = 0;

        if(curChoices.Count == 0)
        {
            choicesText[0].text = "...";
        }

        foreach (Choice choice in curChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            /*
            if (curChoices.IndexOf(choice) == 0)
            {
                choicesText[index].GetComponent<TextMeshProUGUI>().color = chosen;
            }
            else
            {
                choicesText[index].GetComponent<TextMeshProUGUI>().color = notChosen;
            }
            */
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }
    
    public void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
    }

    /*
    void ChangeChoice(int cI)
    {
        //Debug.Log(cI);

        foreach (Choice choice in curChoices)
        {
            if (curChoices.IndexOf(choice) == cI)
            {
                choicesText[curChoices.IndexOf(choice)].GetComponent<TextMeshProUGUI>().color = chosen;
                playerChoice = choice;
            }
            else
            {
                choicesText[curChoices.IndexOf(choice)].GetComponent<TextMeshProUGUI>().color = notChosen;
            }
        }
        return;
    }
    */

    IEnumerator StopDialogue()
    {
        yield return new WaitForSeconds(10);
        dialogueJustPlayed = false;
    }
}