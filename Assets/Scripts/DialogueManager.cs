using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public StarterAssetsInputs starterAssetsInputs;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;
    [SerializeField] private CharacterController player;

    public void Awake()
    {
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
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void Update()
    {
        if (starterAssetsInputs.submit)
        {
            ContinueStory();
            starterAssetsInputs.submit = false;
        }
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //Function that an be called from an inky story!
        currentStory.BindExternalFunction("changePanelColor", (string colorToChangeTo) => {
            if (colorToChangeTo == "Black")
            {
                dialoguePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            }
            else if (colorToChangeTo == "Red")
            {
                dialoguePanel.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
            }
            else
            {
                dialoguePanel.GetComponent<Image>().color = new Color(0, 1, 0, 0.5f);
            }
        });

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        player.enabled = true;
        GameObject myEventSystem = GameObject.Find("UI_EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(choices[0]);
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
}

