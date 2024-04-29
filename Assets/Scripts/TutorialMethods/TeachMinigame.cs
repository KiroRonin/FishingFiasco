using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeachMinigame : MonoBehaviour
{
    [SerializeField] private CharacterController Player;
    [SerializeField] private GameObject PlayerObject;

    public Transform target;
    public float rotationSpeed;

    public GameObject tutorialCollider;

    public GameObject fishTutorialPosition;

    public bool colliderEnter;

    
    void FixedUpdate()
    {
        if (colliderEnter)
        {
            if (DiaManager.instance.canvasActivated)
            {
                rotateBilly();
                Player.enabled = false;
                
            }
            else
            {
                Player.enabled = true;

                PlayerObject.transform.rotation = fishTutorialPosition.transform.rotation;
                PlayerObject.transform.position = fishTutorialPosition.transform.position;

                Debug.Log("Player teleported from " + PlayerObject.transform.position + " to " + fishTutorialPosition.transform.position);

                Destroy(tutorialCollider);
                colliderEnter = false;
                
            }
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
