using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public Animator startPageAnim;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;
	}


    // Update is called once per frame
    void Update () {
		
	}
    public void EnterGame()
    {
        startPageAnim.SetBool("Play", true);

        StartCoroutine( StartGame());

        //SceneManager.LoadScene("Scene1");
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Scene1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {

    }
}
