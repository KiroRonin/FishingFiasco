using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    public GameObject mapUI;
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private CharacterController Player;
    public SellManager SellManager;


    public string nextScene;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {

            if (playerInput.interact)
            {
                print("player hit interact on boat");
                if (tradeCompletionCheck.Instance.allTradeDone == true){
                    StartCoroutine(animateSceneChange());
                    GameManager.Instance.resetInventory();
                    FishStats.Instance.currentFishAmount = 0;

                }
                else
                {
                    //code here to bring up a canvas that says you ahvent finished all quests
                }
            }
           
        }
    }

    IEnumerator animateSceneChange()
    {
        //if ( GameManager.Instance.scenename == "Tavern")
        //{
        //    GameManager.Instance.Fadebl.SetTrigger("FADEBL");
        //}
        //else
        //{
        //    FishingSystem.Instance.Fadebl.SetTrigger("FADEBL");
        //}
        //yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(nextScene);
        yield return new WaitForEndOfFrame();
    }


}
