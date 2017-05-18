﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{

    public string option;
    public DialogueManager box;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
    }

    public void SetOption(string newOption)
    {
        this.option = newOption;
    }

    public void ParseOption()
    {
        //since the choice is already made buttons can be cleared

        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        box.playerTalking = false;
        //box.buttonIsCreated = true;

        if (command == "line")
        {
            box.lineNum = int.Parse(commandModifier);
            box.ShowDialogue();     
            box.lineNum++;  
        }
        else if (command == "scene")
        {
            SceneManager.LoadScene("Scene" + commandModifier);

        }

    }
}