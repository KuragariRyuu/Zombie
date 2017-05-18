using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CheatMenu : MonoBehaviour {

    public GameObject Branchingoption;
    public GameObject Root1;
    public GameObject Root2;
	// Use this for initialization
	void Start () {
        AudioManager.instance.PlayMusic("MainMenuSound",1);
        Root1.SetActive(false);
        Root2.SetActive(false);
        Branchingoption.SetActive(true);
    }

    public void  starting()
    {
        Root1.SetActive(false);
        Root2.SetActive(false);
        Branchingoption.SetActive(true);
    }

    public void Branch1()
    {
        Root1.SetActive(true);
        Root2.SetActive(false);
        Branchingoption.SetActive(false);
    }

    public void Branch2()
    {
        Root1.SetActive(false);
        Root2.SetActive(true);
        Branchingoption.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartPage");
    }

    public void Scene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Scene21()
    {
        SceneManager.LoadScene("Scene2.1");
    }

    public void Scene31()
    {
        SceneManager.LoadScene("Scene3.1");
    }

    public void Scene411()
    {
        SceneManager.LoadScene("Scene4.1.1");
    }

    public void Scene51()
    {
        SceneManager.LoadScene("Scene5.1");
    }

    public void Scene61()
    {
        SceneManager.LoadScene("Scene6.1");
    }
    public void Scene711()
    {
        SceneManager.LoadScene("Scene7.1.1");
    }
    public void Scene811()
    {
        SceneManager.LoadScene("Scene8.1.1");
    }
    public void Scene911()
    {
        SceneManager.LoadScene("Scene9.1.1");
    }

    public void Scene22()
    {
        SceneManager.LoadScene("Scene2.2");
    }

    public void Scene32()
    {
        SceneManager.LoadScene("Scene3.2");
    }

    public void Scene421()
    {
        SceneManager.LoadScene("Scene4.2.1");
    }

    public void Scene52()
    {
        SceneManager.LoadScene("Scene5.2");
    }

    public void Scene62()
    {
        SceneManager.LoadScene("Scene6.2");
    }
    public void Scene721()
    {
        SceneManager.LoadScene("Scene7.2.1");
    }
    public void Scene821()
    {
        SceneManager.LoadScene("Scene8.2.1");
    }
    public void Scene921()
    {
        SceneManager.LoadScene("Scene9.2.1");
    }
}
