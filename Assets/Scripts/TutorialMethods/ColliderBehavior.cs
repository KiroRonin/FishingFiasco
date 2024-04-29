using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehavior : MonoBehaviour
{
    public TeachMinigame tutorialScript;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            print("minigame tutorial start");
            tutorialScript.startTutorial();
            tutorialScript.colliderEnter = true;

        }
    }

}
