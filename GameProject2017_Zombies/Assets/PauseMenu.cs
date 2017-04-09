using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public float windowWidth = 256;
    public float windowHeight = 100;

    public GUISkin newSkin;

	// Use this for initialization
	void Start () {
        isPaused = false;
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

            ShowPauseMenu();
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    void ShowPauseMenu()
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
           // Save();
        }
        if(GUILayout.Button("Load"))
        {
           // Load();
        }
        if (GUILayout.Button("Exit"))
        {
           Application.Quit();
        }

        GUILayout.EndArea();
    }
}

