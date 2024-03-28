
using UnityEngine;
using StarterAssets;



public class DialogueTrigger : MonoBehaviour
{
    //public GameObject visualCue;
    private bool playerInRange;
    public TextAsset inkJson;
    public StarterAssetsInputs starterAssetsInputs;
    private Collider[] hitColliders;
    private CharacterController player;

    private void Awake()
    {
        playerInRange = false;
        //visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying)
        {
            //visualCue.SetActive(true);
            if (starterAssetsInputs.interact)
            {
                if (player)
                {
                    player.enabled = false;
                }

                DialogueManager.Instance.EnterDialogueMode(inkJson);
                starterAssetsInputs.interact = false;
            }
        }
        else
        {
            //visualCue.SetActive(false);
        }

        checkForPlayer();
    }

   private void checkForPlayer()
    {
       hitColliders = Physics.OverlapBox(transform.position, new Vector3(1f, 3f, 3f));
       foreach(Collider collison in hitColliders)
        {
            if(collison.gameObject.tag == "Player")
            {
                playerInRange = true;
                player = collison.gameObject.GetComponent<CharacterController>();
            }
            else
            {
                playerInRange = false;
            }
        
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 3f, 3f));
    }
}
