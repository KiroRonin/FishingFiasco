using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] StarterAssetsInputs playerinputs;

    private void OnEnable()
    {
        playerinputs.enabled = true;
    }

    private void OnDisable()
    {
        playerinputs.enabled = false;   
    }


    void Update()
    {
        fish();
        hook();
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
        if (playerinputs.interact && )
        {
            hookPullVelocity += hookpullpower * Time.deltaTime;
            Debug.Log("fish reeling in");

        }


    }
}
