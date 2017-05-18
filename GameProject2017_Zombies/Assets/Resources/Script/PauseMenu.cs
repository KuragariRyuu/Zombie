using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class PauseMenu : MonoBehaviour
{

    public static PauseMenu pMenu;

    public static bool isPaused;
    public bool isOnMenu;
    public float windowWidth = 256;
    public float windowHeight = 100;
    public GUISkin newSkin;
    public DialogueManager manager;

    // Use this for initialization
    void Awake()
    {
        if (pMenu != null)
            Destroy(gameObject);
        else
        {
            pMenu = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
     
        isPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartPage" || SceneManager.GetActiveScene().name == "CheatMenu")
            isOnMenu = true;
        else
            isOnMenu = false;

        if (Input.GetKeyUp("escape") && isOnMenu == false)
        {
            PauseMenu.isPaused = !PauseMenu.isPaused;
        }

    }

    void OnGUI()
    {
        GUI.skin = newSkin;

        if (isPaused == true)
        {
            Time.timeScale = 0;

            ShowPauseMenu();
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    IEnumerator waitingforload(int linenum)
    {
        yield return new WaitForSeconds(1);
        manager = FindObjectOfType<DialogueManager>();
        manager.lineNum = linenum;
    }

    void ShowPauseMenu()
    {
        float windowX = (Screen.width - windowWidth) / 2;
        float windowY = (Screen.height - windowHeight) / 2;

        GUILayout.BeginArea(new Rect(windowX, windowY, windowWidth, windowHeight));

        if (GUILayout.Button("Resume"))
        {
            isPaused = false;
        }
        if (GUILayout.Button("MainMenu"))
        {
            SceneManager.LoadScene("StartPage");
            Time.timeScale = 1;
            PauseMenu.isPaused = false;
        }
        if (GUILayout.Button("Save"))
        {
            Save();
        }
        if (GUILayout.Button("Load"))
        {
            Load();
        }
        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUILayout.EndArea();
    }

    void Save()
    {
        manager = FindObjectOfType<DialogueManager>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Info.sav",FileMode.Create);
        SaveLoadData data = new SaveLoadData();
        if(manager.lineNum != 0)
        data.lineNum = manager.lineNum - 1;
        else
        data.lineNum = manager.lineNum;
        data.currentScene = SceneManager.GetActiveScene().name;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Info.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Info.sav", FileMode.Open);
            SaveLoadData data = (SaveLoadData)bf.Deserialize(file);
            file.Close();



            // print(data.dataFile);
            SceneManager.LoadScene(data.currentScene);
            PauseMenu.isPaused = false;
            StartCoroutine(waitingforload(data.lineNum));
        }
        else
        {
            Debug.Log("Cannot Load");
        }
    }
}
   

[System.Serializable]
class SaveLoadData
{
    public int lineNum;
    public string currentScene;

}
