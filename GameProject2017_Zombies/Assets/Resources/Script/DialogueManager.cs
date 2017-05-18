﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager dManager;

    Fade fading;
    DialogueParser parser;
    public SoundManager soundManager;
    public string option;
    public string dialogue, characterName;
    public int lineNum;
    int pose;
    string position;
    string[] options;
    public bool playerTalking;
    List<Button> buttons = new List<Button>();
    public Text dialogueBox;
    public Text nameBox;

    public bool buttonIsCreated = false;
    public bool StringIsDisplaying = false;
    public KeyCode DialogueInput = KeyCode.Space;
    public GameObject choiceBox;
    public float SecondsBetweenCharacters = 0.5f;
    public float CharacterRateDivider = 100.0f;

    // Use this for initialization
    void Start()
    {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        fading = GameObject.Find("Fade").GetComponent<Fade>();
        fading.BeginFade(-1);
        lineNum = 0;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerTalking == false && StringIsDisplaying == false && PauseMenu.isPaused == false)
        {
            ShowDialogue();

            lineNum++;
        }

        UpdateUI();
    }

    public void ShowDialogue()
    {
        ResetImages();
        ParseLine();
        StartCoroutine(DisplayString(dialogue));
    }

    void UpdateUI()
    {
        if (!playerTalking)
        {
            //  ClearButtons();
        }

        //StartCoroutine(DisplayString(dialogue));
        nameBox.text = characterName;
    }



    void ParseLine()
    {
        if (parser.GetName(lineNum) == "Music")
        {
            AudioManager.instance.PlayMusic(parser.GetContent(lineNum), 1);
            lineNum++;
        }
        if (parser.GetName(lineNum) == "SoundEffect")
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";
            StartCoroutine(PlaySound(parser.GetContent(lineNum)));
            //StringIsDisplaying = false;
        }
        else if (parser.GetName(lineNum) == "LoadScenes")
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";
            Debug.Log("Entering Fading");
            StartCoroutine(FadingLoading(parser.GetContent(lineNum)));
        }
        else if (parser.GetName(lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            pose = parser.GetPose(lineNum);
            position = parser.GetPosition(lineNum);
            DisplayImages();
        }
        else
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";
            options = parser.GetOptions(lineNum);
            CreateButtons();

        }
    }

    IEnumerator FadingLoading(string level)
    {
        float fadetime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadetime * 1.2f);
        Debug.Log(fadetime);
        Application.LoadLevel(level);
    }

    public void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            print("Clearing buttons");
            Button b = buttons[i];
            //buttons.Remove(b); it will decrease the buttons.Count so I commented it out
            Destroy(b.gameObject);
        }
        buttons.Clear(); //clear of all elements in the button list
    }

    void CreateButtons()
    {

        for (int i = 0; i < options.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(choiceBox);
            Button b = button.GetComponent<Button>();
            ChoiceButton cb = button.GetComponent<ChoiceButton>();
            cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1];
            cb.box = this;
            b.transform.SetParent(this.transform);
            b.transform.localPosition = new Vector3(400, 200 + (i * 50));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
        }

    }


    void ResetImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName);
            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = null;
        }
    }

    void DisplayImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName);

            //SetSpritePositions(character);

            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        StringIsDisplaying = true;
        
        int stringLength = stringToDisplay.Length;
        int currentCharIndex = 0;

        dialogueBox.text = "";
        while (currentCharIndex < stringLength)
        {
            dialogueBox.text += stringToDisplay[currentCharIndex];
            currentCharIndex++;

            if (currentCharIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters / CharacterRateDivider);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }
        dialogueBox.text = dialogue;
        StringIsDisplaying = false;
        
    }

    private IEnumerator PlaySound(string name)
    {
        StringIsDisplaying = true;
        yield return new WaitForSeconds(AudioManager.instance.PlaySound2D(name));
        Debug.Log("Playsound done");
        playerTalking = false;
        StringIsDisplaying = false;
    }
}


