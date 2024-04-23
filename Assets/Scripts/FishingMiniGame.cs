using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform TPivot;
    [SerializeField] Transform BPivot;
    [SerializeField] Transform Fish;

    float fishpos;
    float fishdestination;
    float fishTimer;

    [SerializeField] float timerMultiplier = 1f;

    float fishspeed;
    [SerializeField] float smoothmotion = 1f;

    [SerializeField] Transform Hook;
    float hookpos;
    [SerializeField] float hooksize = 0.1f;
    [SerializeField] float hookpower = 0.1f;
    float hookprogress;
    float timeprogress = 1f;
    float hookPullVelocity;
    [SerializeField] float hookpullpower = 0.01f;
    [SerializeField] float hookGravitypower = 0.005f;
    [SerializeField] float hookprogressloss = 0.1f;

    [SerializeField] Transform progressbarcontainer;
    [SerializeField] Transform timerbarcontainer;

    [SerializeField] StarterAssetsInputs playerinputs;

    public FishingRod fishingrod;
    
    public InventoryObject inventory;
    

    [SerializeField] float failtime = 10f;
    public int inventoryCount;


    public Animator FishAnimator;
    public Animator reelAnimator;



    //private void OnEnable()
    //{
    //    playerinputs.enabled = true;
    //}

    //private void OnDisable()
    //{
    //    playerinputs.enabled = false;   
    //}

    private void Start()
    {
        failtime = 10f;
    }


    void Update()
    {
        fish();
        hook();
        progresscheck();
    }

    void fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = Random.value * timerMultiplier;

            fishdestination = Random.value;

        }

        fishpos = Mathf.SmoothDamp(fishpos, fishdestination, ref fishspeed, smoothmotion);
        Fish.position = Vector3.Lerp(BPivot.position, TPivot.position, fishpos);
    }

    void hook()
    {
        if (Input.GetMouseButton(2)) 
        {
            hookPullVelocity += hookpullpower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravitypower * Time.deltaTime;

        hookpos += hookPullVelocity;

        if (hookpos - hooksize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }

        if (hookpos + hooksize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }
        hookpos = Mathf.Clamp(hookpos, hooksize / 2, 1-hooksize/2);
        Hook.position = Vector3.Lerp(BPivot.position, TPivot.position, hookpos);


    }
    private bool pressedOnceFishing =false;

    void progresscheck()
    {
        Vector3 ls = progressbarcontainer.localScale;
        ls.x = hookprogress;
        progressbarcontainer.localScale = ls;

        Vector3 tls = timerbarcontainer.localScale;
        tls.x = timeprogress;
        timerbarcontainer.localScale = tls;
        
        

        float min = hookpos - hooksize / 2;
        float max = hookpos + hooksize / 2;
        
        if (min < fishpos && fishpos < max)
        {
            hookprogress += hookpower * Time.deltaTime;
        }
        else
        {
            hookprogress -= hookprogressloss * Time.deltaTime;

            
            failtime -= Time.deltaTime;
            timeprogress -= failtime * Time.deltaTime / 100f * 2f;
            
            
            
            if (failtime < 0f)
            {
                Lose();
            }
            
        }

        if(hookprogress > 1)
        {
            Win();
        }
        hookprogress = Mathf.Clamp(hookprogress, 0f, 1f);
        timeprogress = Mathf.Clamp(timeprogress, 0f, 1f);
    }

    public void Win()
    {
        
        fishingrod.isCasted = false;
        Debug.Log("YOU CAUGHT A " + FishingSystem.Instance.fish.fishName);
        fishingrod.animator.SetBool("IsPulling", false);
        fishingrod.animator.SetBool("IsMinigame", false);
        fishingrod.FishingMinigame.SetActive(false);
        fishingrod.player.PlayerEnable();
        failtime = 10f;
        hookprogress = 0;
        timeprogress = 1f;
        Destroy(fishingrod.rope);
        Destroy(fishingrod.bait);

        FishAnimator.SetTrigger("FishCaught");
        reelAnimator.SetTrigger("minigameOver");
        
        inventory.AddFish(FishingSystem.Instance.fish, 1);

        inventoryCount++;
        FishStats.Instance.increaseFishValue(FishingSystem.Instance.Id);
        FishStats.Instance.currentFishAmount = inventoryCount;
        GameManager.Instance.SaveData();
        print(FishStats.Instance.currentFishAmount);

        


    }

    public void Lose()
    {
        
        fishingrod.isCasted = false;
        Debug.Log("YOU LOSE");
        fishingrod.animator.SetBool("IsPulling", false);
        fishingrod.animator.SetBool("IsMinigame", false);
        reelAnimator.SetTrigger("minigameOver");
        fishingrod.FishingMinigame.SetActive(false);
        Destroy(fishingrod.bait);
        Destroy(fishingrod.rope);
        fishingrod.player.PlayerEnable();
        failtime = 10f;
        hookprogress = 0;
        timeprogress = 1f;
        

    }
 
}
