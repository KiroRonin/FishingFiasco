using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeachMinigame : MonoBehaviour
{
    [SerializeField] private CharacterController Player;
    [SerializeField] private FirstPersonController PlayerFPC;
    [SerializeField] private GameObject PlayerObject;
    

    public Transform target;
    public float rotationSpeed;

    public GameObject tutorialCollider;

    public GameObject fishTutorialPosition;

    public bool colliderEnter;

    public GameObject fadeCanvas;
    public float fadeAlpha;
    public Color fadeColor;
    public float fadeSpeed = 5f;
    public GameObject instruction;

    private void Start() {
       //var trans = fadeCanvas.GetComponent<UnityEngine.UI.Image>();
        //fadeColor = trans.color;
    }
    
    void FixedUpdate()
    {
        if (colliderEnter == true && DiaManager.instance.canvasActivated == true)
        {
            rotateBilly();
            Player.enabled = false;
            PlayerFPC.lockCam = true;
            Destroy(tutorialCollider.gameObject);
            GameManager.Instance.wasdstarterkeys.SetActive(false);

        }

        if (colliderEnter == true && DiaManager.instance.canvasActivated == false)
        {
            instruction.SetActive(true);
            colliderEnter = false;
            PlayerObject.transform.rotation = fishTutorialPosition.transform.rotation;
            print("current pos: " + PlayerObject.transform.position);
            PlayerObject.transform.position = fishTutorialPosition.transform.position;
            //PlayerObject.transform.position = new Vector3(-36.55f, -1.85f, 35.28f);
            print("player teleported from " + fishTutorialPosition.transform.position + "to " + PlayerObject.transform.position);
            
            Player.enabled = true;
            PlayerFPC.lockCam = false;


        }
    }

    

    public void startTutorial()
    {
        var tutorial = "BillyTutorial";
        var knot = DiaManager.instance.currentKnot;
        knot = tutorial;

        DiaManager.instance.canvasActivated = true;

        DiaManager.instance.story.ChoosePathString(knot);
        DiaManager.instance.currentText = DiaManager.instance.loadStoryChunk();
        DiaManager.instance.dialogueText.text = DiaManager.instance.currentText;
        DiaManager.instance.dialogueCanvas.SetActive(true);

    }

    private void rotateBilly()
    {
        Vector3 dir = target.position - PlayerObject.transform.position;

        Quaternion rotation = Quaternion.Slerp(PlayerObject.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        rotation.x = 0;
        rotation.z = 0;

        PlayerObject.transform.rotation = rotation;
    }
    
}
