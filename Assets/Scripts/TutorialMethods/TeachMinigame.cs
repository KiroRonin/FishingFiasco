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

    private bool triggered;

    public GameObject fishTutorialPosition;


    void Start()
    {

    }

    void Update()
    {
        if (triggered == true && DiaManager.instance.canvasActivated == true)
        {
            rotateBilly();
            Player.enabled = false;
        }

        if (triggered == true && DiaManager.instance.canvasActivated == false)
        {
            PlayerObject.transform.rotation = fishTutorialPosition.transform.rotation;
            PlayerObject.transform.position = fishTutorialPosition.transform.position;
            
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            print("minigame tutorial start");
            startTutorial();
        }
    }

    void startTutorial()
    {
        var tutorial = "BillyTutorial";
        var knot = DiaManager.instance.currentKnot;
        knot = tutorial;

        DiaManager.instance.canvasActivated = true;

        DiaManager.instance.story.ChoosePathString(knot);
        DiaManager.instance.currentText = DiaManager.instance.loadStoryChunk();
        DiaManager.instance.dialogueText.text = DiaManager.instance.currentText;
        DiaManager.instance.dialogueCanvas.SetActive(true);

        triggered = true;
    }

    private void rotateBilly()
    {
        UnityEngine.Vector3 dir = target.position - PlayerObject.transform.position;

        UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Slerp(PlayerObject.transform.rotation, UnityEngine.Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        rotation.x = 0;
        rotation.z = 0;

        PlayerObject.transform.rotation = rotation;
    }



}
