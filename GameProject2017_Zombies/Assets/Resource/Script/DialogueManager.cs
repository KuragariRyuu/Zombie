using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    DialogueParser parser;
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

    public float eachCharDelay; //time delay between each char

    // Use this for initialization
    void Start()
    {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        lineNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerTalking == false)
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
        }


        //StartCoroutine(DisplayString(dialogue));
        nameBox.text = characterName;
    }

  

    void ParseLine()
    {
        if (parser.GetName(lineNum) == "LoadScenes")
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";

            SceneManager.LoadScene("Scene2");
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


    void SetSpritePositions(GameObject spriteObj)
    {
        //if (position == "L")
        //{
        //    spriteObj.transform.position = new Vector3(-500, -10);
        //}
        //else if (position == "R")
        //{
        //    spriteObj.transform.position = new Vector3(500, -10);
        //}
        //spriteObj.transform.position = new Vector3(spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        playerTalking = true;
        int stringLength = stringToDisplay.Length;
        int currentCharIndex = 0;

        dialogueBox.text = "";
        while (currentCharIndex < stringLength)
        {
            dialogueBox.text += stringToDisplay[currentCharIndex];
            currentCharIndex++;

            if (currentCharIndex < stringLength)
            {
                yield return new WaitForSeconds(eachCharDelay);
            }
            else
            {
                break;
            }
        }
        dialogueBox.text = dialogue;
        playerTalking = false;
    }




}
