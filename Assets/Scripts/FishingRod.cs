using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public bool isEquipped;
    public bool isFishingAvailable;
    public bool isCasting = false;
    public bool isCasted;
    public bool isPulling;
    public Vector3 normalPositionOffset;
    public Transform parent;
    public Animator animator;
    public GameObject baitPrefab;
    public GameObject linePrefab;
    public Transform start_of_rod;
    public Transform baitPosition;
    private LineRenderer lineRenderer;
    private GameObject baitInstance;
    public GameObject FishingMinigame;
    public GameObject rope;
    public GameObject bait;
    public UIManagement player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isEquipped = true;
        FishingMinigame.SetActive(false);
    }

    void Update()
    {
        rope = GameObject.Find("Rope(Clone)");
        baitInstance = GameObject.Find("Bait(Clone)");

        if (isEquipped)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Fishing Area"))
                {
                    isFishingAvailable = true;
                    if (Input.GetMouseButtonDown(0) && !isCasted && !isPulling && !isCasting)
                    {
                        CastLine(hit.point);
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

        transform.rotation = parent.transform.rotation;
    }

    private void CastLine(Vector3 targetPosition)
    {
        isCasting = true;
        StartCoroutine(CastRod(targetPosition));
    }

    private IEnumerator CastRod(Vector3 targetPosition)
    {
        isCasted = true;
        player.PlayerDisable();
        animator.SetTrigger("Cast");

        GameObject lineInstance = Instantiate(linePrefab, start_of_rod.position, Quaternion.identity);
        lineRenderer = lineInstance.GetComponent<LineRenderer>();

        baitInstance = Instantiate(baitPrefab, start_of_rod.position, Quaternion.identity);

        float elapsedTime = 0f;
        float castDuration = 1f; // Adjust this value to control the casting duration

        while (elapsedTime < castDuration)
        {
            float t = elapsedTime / castDuration;
            lineRenderer.SetPosition(0, start_of_rod.position);
            lineRenderer.SetPosition(1, Vector3.Lerp(start_of_rod.position, targetPosition, t));
            baitInstance.transform.position = Vector3.Lerp(start_of_rod.position, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lineRenderer.SetPosition(0, start_of_rod.position);
        lineRenderer.SetPosition(1, targetPosition);
        baitInstance.transform.position = targetPosition;
        //baitPosition = baitInstance.transform;

        // ---- > Start Fish Bite Logic
        FishingSystem.Instance.StartFishing(WaterSource.Tavern);

        isCasting = false;
    }

    public void PullRod()
    {
        animator.SetBool("IsPulling", true);
        lineRenderer.SetPosition(1, start_of_rod.transform.position);
        FishingMinigame.SetActive(true);
        animator.SetBool("IsMinigame", true);
    }
}