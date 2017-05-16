using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class PauseMenu : MonoBehaviour {

    public static PauseMenu pMenu;

    public static bool isPaused;
    public static bool canusemenu;
    public float windowWidth = 256;
    public float windowHeight = 100;
    public GUISkin newSkin;
    public DialogueManager manager;
    public DialogueParser parser;

    // Use this for initialization
    void Awake()
    {
            pMenu = this;
    }

    void Start () {
       isPaused = false;

       manager = FindObjectOfType<DialogueManager>();
       parser = FindObjectOfType<DialogueParser>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("escape"))
        {
            PauseMenu.isPaused = !PauseMenu.isPaused ;
        }

	}


    void OnGUI()
    {
        GUI.skin = newSkin;

        if(isPaused == true)
        {
            Time.timeScale = 0;
            if(canusemenu == true)
            ShowPauseMenu();
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    public void ShowPauseMenu()
    {
        float windowX = (Screen.width - windowWidth)/2;
        float windowY = (Screen.height - windowHeight)/2;

        GUILayout.BeginArea(new Rect(windowX,windowY,windowWidth,windowHeight));

        if (GUILayout.Button("MainMenu"))
        {
           SceneManager.LoadScene("StartPage");
        }
        if (GUILayout.Button("Save"))
        {
            Save();
        }
        if(GUILayout.Button("Load"))
        {
            Load();
        }
        if (GUILayout.Button("Exit"))
        {
           Application.Quit();
        }

        GUILayout.EndArea();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Info.dat");
        SaveLoadData data = new SaveLoadData();
        data.dataFile = parser.file;
        data.lineNum = manager.lineNum;
        data.currentScene = SceneManager.GetActiveScene().name;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Info.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Info.dat", FileMode.Open);
            SaveLoadData data = (SaveLoadData)bf.Deserialize(file);
            file.Close();



           // print(data.dataFile);
            manager.lineNum = data.lineNum;
            parser.file = data.dataFile;
            parser.onLoad = true;
            SceneManager.LoadScene(data.currentScene);

        }
    }
}

[System.Serializable]
class SaveLoadData
{
    public string dataFile;
    public int lineNum;
    public string currentScene;

}
