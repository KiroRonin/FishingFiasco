using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
public class FishingRod : MonoBehaviour
{
    public FirstPersonController playerFPC;
    public bool isEquipped;
    public bool isFishingAvailable;
    public bool isCasting = false;
    public bool isCasted;
    public bool isPulling;
    public Vector3 normalPositionOffset;
    
    public Animator animator;
    public GameObject baitPrefab;
    public GameObject linePrefab;
    public Transform start_of_rod;
    //public Transform baitPosition;
    private LineRenderer lineRenderer;
    private GameObject baitInstance;
    public GameObject FishingMinigame;
    public GameObject rope;
    public GameObject bait;
    public UIManagement playerUI;

    public GameObject playercollidor;

    public Animator FOVanimator;
    public Animator reelAnimator;

    private string sceneName;

    private GameObject fishcaughtobject;

    public GameObject fishcaughtanimator;

    private GameObject FishCaught;

    public bool wonminigame = false;

    public bool OnFishingDock=false;

    public float downrange;

    






    private void Start()
    {
        animator = GetComponent<Animator>();
        isEquipped = true;
        FishingMinigame.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        //isEquipped = false;
    }

    public void OnFishingDockArea()
    {
        Collider[] colliders = Physics.OverlapSphere(playercollidor.transform.position, downrange);

        
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("FishDock"))
            {
                //Debug.Log("ONFISHINGDOCK");
                OnFishingDock = true;
                break;
            }

            if (!collider.CompareTag("FishDock"))
            {
                //Debug.Log("ONFISHINGDOCK");
                OnFishingDock = false;
            }


        }
        
    }
    public void Update()
    {
        
        OnFishingDockArea();


        rope = GameObject.Find("Rope(Clone)");
        bait = GameObject.Find("Bait(Clone)");

        if (OnFishingDock == true)
        {
            
            playerUI.fishingyesUI.SetActive(true);
            playerUI.fishingnoUI.SetActive(false);
            if (isEquipped && playerFPC.Grounded)
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
        }

        if (OnFishingDock == false) {
            playerUI.fishingyesUI.SetActive(false);
            playerUI.fishingnoUI.SetActive(true);
            isFishingAvailable = false;
        }

        

    }

    private void CastLine(Vector3 targetPosition)
    {
        StartCoroutine(CastedTimer());
        StartCoroutine(CastRod(targetPosition));
    }

    IEnumerator CastedTimer()
    {
        isCasting = true;
        yield return new WaitForSeconds(4f);
        isCasting = false;

    }

    private IEnumerator CastRod(Vector3 targetPosition)
    {
        isCasted = true;
        playerFPC.enabled = false;
        animator.SetTrigger("Cast");
        FOVanimator.SetTrigger("FOVCast");
        reelAnimator.SetTrigger("Reeling");
        
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
        while (isCasting)
        {
            lineRenderer.SetPosition(0, start_of_rod.position);
            lineRenderer.SetPosition(1, targetPosition);
            baitInstance.transform.position = targetPosition;

            yield return null;
            
        }

        if (sceneName == "Tavern")
        {
            FishingSystem.Instance.StartFishing(WaterSource.Tavern);
        }

        if (sceneName == "CoralReef")
        {
            FishingSystem.Instance.StartFishing(WaterSource.Coral);
        }

        if (sceneName == "Deep")
        {
            FishingSystem.Instance.StartFishing(WaterSource.Deep);
        }

        if(sceneName == "Cave")
        {
            FishingSystem.Instance.StartFishing(WaterSource.Cave);
        }

        if (sceneName == "Sandbox 2")
        {
            FishingSystem.Instance.StartFishing(WaterSource.Tavern);
        }



        //lineRenderer.SetPosition(0, start_of_rod.position);
        //lineRenderer.SetPosition(1, targetPosition);
        //baitInstance.transform.position = targetPosition;

        //baitPosition = baitInstance.transform;

        // ---- > Start Fish Bite Logic
        
        

    }

    public void PullRod()
    {
        animator.SetBool("IsPulling", true);
        lineRenderer.SetPosition(1, start_of_rod.transform.position);
        FishingMinigame.SetActive(true);
        animator.SetBool("IsMinigame", true);
    }

    public void Winfish()
    {
        fishcaughtobject = FishingSystem.Instance.fish.modelprefab  ;
        FishCaught = Instantiate(fishcaughtobject, new Vector3(0, 0, 1), Quaternion.identity);
        FishCaught.AddComponent<FishRotation>();
        Debug.Log("fishcaught instantiated");
        StartCoroutine(KillFishInstance());
       

    }

    IEnumerator KillFishInstance()
    {
        FishCaught.transform.SetParent(fishcaughtanimator.transform, false);
        yield return new WaitForSeconds(3f);
        Destroy(FishCaught);
    }


}