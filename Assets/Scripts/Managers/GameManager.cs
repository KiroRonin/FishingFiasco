using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using StarterAssets;
using System;
using System.Collections;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string scenename;
    
    public UIManagement PLayerUI;
    public FirstPersonController PlayerFPC;
    public GameObject FADEBL;
    public GameObject wasdstarterkeys;
    public StarterAssetsInputs playermov;

    public Animator maincamanim;
    public Animator UIAnim;
    public Animator FishRodAnim;
    public Animator FOVslide;
    public Animator Fadebl;

    public bool introOver;
    public bool introOccur = true;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadData();
        print(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json");
        scenename = SceneManager.GetActiveScene().name;
        if(scenename == "Tavern")
        {
            wasdstarterkeys.SetActive(false);

            StartCoroutine(Tutorial());

            

            
        }
    }

    //private void Update()
    //{
    //    if(introOccur && !DiaManager.instance.canvasActivated)
    //    {
    //        print("intro true");
    //        introOver = true;
    //    }
    //}

    IEnumerator Tutorial()
    {
        introOver = false;
        maincamanim.enabled = true;
        FADEBL.SetActive(true);
        PlayerFPC.lockCam = true;
        PlayerFPC.enabled = false;
        maincamanim.SetTrigger("TutStart");
        FishRodAnim.SetTrigger("NewTavernScene");
        UIAnim.SetTrigger("NewTavern");
        FOVslide.SetTrigger("NewTavern");
        yield return new WaitForSeconds(5f);
        introOver = false;
        introOccur = false;
        print("tutdisabled");
        FishRodAnim.SetTrigger("FishRodStart");
        FOVslide.SetTrigger("ZoomBack");
        UIAnim.SetTrigger("ZoomInTut");
        DiaManager.instance.canvasActivated = true;
        DiaManager.instance.dialogueCanvas.SetActive(true);

        yield return new WaitForSeconds(2f);

        maincamanim.enabled = false;
        PlayerFPC.lockCam = false;
        PlayerFPC.enabled = true;

        yield return new WaitForSeconds(1f);
        wasdstarterkeys.SetActive(true);
        

    }




    public void SaveData()
    {
        string json = JsonUtility.ToJson(FishStats.Instance);
        //Debug.Log("Data Saved");
        Debug.Log(json);


        using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            writer.Write(json);
        }
    }

    public void LoadData()
    {
        string json = string.Empty;
        using(StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        JsonUtility.FromJsonOverwrite(json,FishStats.Instance);
        //Debug.Log("Data Loaded");
        Debug.Log(json);
    }
}

