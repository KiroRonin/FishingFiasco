using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public bool isEquipped;
    public bool isFishingAvailable;
    public bool isCasted;
    public bool isPulling;
    public Vector3 normalPositionOffset;
    public Transform parent;
    public Animator animator;
    public GameObject baitPrefab;
    public GameObject linePrefab; 
    public GameObject start_of_rod; // --- > IF USING ROPE
    Transform baitPosition;
    private LineRenderer lineRenderer;

    public GameObject FishingMinigame;
    //public FishingMiniGame fishingminigamecode;


    public UIManagement player;
    private void Start()
    {
        animator = GetComponent<Animator>();
        isEquipped = true;
        FishingMinigame.SetActive(false);
    }

    void Update()
    {
        if (isEquipped)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Fishing Area"))
                {
                    isFishingAvailable = true;
                    if (Input.GetMouseButtonDown(0) && !isCasted && !isPulling)
                    {
                        StartCoroutine(CastRod(hit.point));
                    }
                }
                else
                {
                    isFishingAvailable = false;
                }
            }
            else
            {
                isFishingAvailable = false;
            }
        }

        if (isCasted || isPulling)
        {
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(1, baitPosition.position);
            }
        }

        if (isCasted && Input.GetMouseButtonDown(1))
        {
            PullRod();
        }

        //Vector3 rotatedOffset = parent.rotation * normalPositionOffset;
        transform.rotation = parent.transform.rotation;
    }

    IEnumerator CastRod(Vector3 targetPosition)
    {
        isCasted = true;
        player.PlayerDisable();
        animator.SetTrigger("Cast");

        // Create a delay between the animation and when the bait appears in the water
        yield return new WaitForSeconds(1f);

        GameObject instantiatedBait = Instantiate(baitPrefab);
        instantiatedBait.transform.position = targetPosition;
        baitPosition = instantiatedBait.transform;

        // Instantiate the line prefab and get the LineRenderer component
        GameObject lineInstance = Instantiate(linePrefab, start_of_rod.transform.position, Quaternion.identity);
        lineRenderer = lineInstance.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, start_of_rod.transform.position);
        lineRenderer.SetPosition(1, baitPosition.position);

        // ---- > Start Fish Bite Logic
    }

    private void PullRod()
    {
        animator.SetBool("IsPulling", true);


        // Update the line prefab position
        lineRenderer.SetPosition(1, start_of_rod.transform.position);

        FishingMinigame.SetActive(true);
        animator.SetBool("IsMinigame", true);
    }
}