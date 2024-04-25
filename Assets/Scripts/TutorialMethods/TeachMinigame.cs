using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachMinigame : MonoBehaviour
{
    [SerializeField] private CharacterController Player;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            //Player.transform.LookAt(Billy.transform.position);
            Destroy(this.gameObject);
            print("minigame tutorial start");

        }
    }
}
