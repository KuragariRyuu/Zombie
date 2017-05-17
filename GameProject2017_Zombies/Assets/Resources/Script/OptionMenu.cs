using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{

    public Canvas quitMenu;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
    }
    public void Resume()
    {
        quitMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartPage");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenu.enabled = true;
            Time.timeScale = 0;
        }
    }
}
