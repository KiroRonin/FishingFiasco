using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using StarterAssets;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string scenename;
    
    public UIManagement PLayerUI;
    public FirstPersonController PlayerFPC;
    public GameObject FADEBL;
    public GameObject wasdstarterkeys;

    public Animator maincamanim;
    public Animator UIAnim;
    public Animator FishRodAnim;
    public Animator FOVslide;
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

    IEnumerator Tutorial()
    {
        maincamanim.enabled = true;
        FADEBL.SetActive(true);
        PlayerFPC.lockCam = true;
        maincamanim.SetTrigger("TutStart");
        FishRodAnim.SetTrigger("NewTavernScene");
        UIAnim.SetTrigger("NewTavern");
        FOVslide.SetTrigger("NewTavern");




        yield return new WaitForSeconds(10);
        print("tutdisabled");
        maincamanim.enabled = false;
        PlayerFPC.lockCam = false;
        FishRodAnim.SetTrigger("FishRodStart");
        UIAnim.SetTrigger("ZoomInTut");
        wasdstarterkeys.SetActive(true);


        FOVslide.SetTrigger("ZoomBack");
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

