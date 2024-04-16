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

    [SerializeField] float timerMultiplier = 3f;

    float fishspeed;
    [SerializeField] float smoothmotion = 1f;

    [SerializeField] Transform Hook;
    float hookpos;
    [SerializeField] float hooksize = 0.1f;
    [SerializeField] float hookpower = 0.5f;
    float hookprogress;
    float hookPullVelocity;
    [SerializeField] float hookpullpower = 0.01f;
    [SerializeField] float hookGravitypower = 0.005f;
    [SerializeField] float hookprogressloss = 0.1f;

    [SerializeField] Transform progressbarcontainer;

    [SerializeField] StarterAssetsInputs playerinputs;

    public FishingRod fishingrod;
    bool pause = false;

    [SerializeField] float failtime = 10f;

    //private void OnEnable()
    //{
    //    playerinputs.enabled = true;
    //}

    //private void OnDisable()
    //{
    //    playerinputs.enabled = false;   
    //}


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
    }

    private void Win()
    {
        pause = true;
        fishingrod.isCasted = false;
        Debug.Log("YOU CAUGHT A FISH");
        fishingrod.animator.SetBool("IsPulling", false);
        fishingrod.animator.SetBool("IsMinigame", false);
        fishingrod.FishingMinigame.SetActive(false);
        fishingrod.player.PlayerEnable();
    }

    private void Lose()
    {
        pause = false;
        fishingrod.isCasted = false;
        Debug.Log("YOU LOSE");
        fishingrod.animator.SetBool("IsPulling", false);
        fishingrod.animator.SetBool("IsMinigame", false);
        fishingrod.FishingMinigame.SetActive(false);
        fishingrod.player.PlayerEnable();
    }
 
}
