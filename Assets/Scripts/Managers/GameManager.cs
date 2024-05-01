using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string scenename;
    
    public UIManagement PLayerUI;
    public FirstPersonController PlayerFPC;
    public GameObject FADEBL;

    public Animator maincamanim;
    public Animator UIAnim;
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
            FADEBL.SetActive(true); 
            PlayerFPC.lockCam = true;
            maincamanim.SetTrigger("TutStart");
            UIAnim.SetTrigger("ZoomInTut");
        }
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

