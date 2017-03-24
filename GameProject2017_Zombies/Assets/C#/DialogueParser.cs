//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.IO;

//public class DialogueParser : MonoBehaviour {

//    struct DialogueLine
//    {
//        string name;
//        string content;
//        int pose;
//        string imagePosition;
//        string[] options;

//        public DialogueLine(string Name, string Content, int Pose, string Position)
//        {
//            name = Name;
//            content = Content;
//            pose = Pose;
//            imagePosition = Position;
//            options = new string[0];
//        }

//        List<DialogueLine> lines;
//    }

//	// Use this for initialization: this function is called when the Gameobject(the script attached to) is created
//	void Start () {

//        string file = "Assets/Text/DialogueScene";
//        string sceneNum = EditorApplication.currentScene;

//        sceneNum = Regex.Replace(sceneNum, "[^0-9]", "");
//        file += sceneNum; // append the scene no. to the string
//        file += ".txt";

//        lines = new List<DialogueLine>();

//        LoadDialogue(file);		
//	}

//    void LoadDialogue(string fileName)
//    {
//        string line;
//        StreamReader reader = new StreamReader(fileName);

//        using (reader)
//        {
//            do
//            {
//                line = reader.ReadLine();
//                if(line != null)
//                {
//                   string[] lineContent = line.Split(';');
//                }

//            } while (line != null);





//        }








//    }












	
//	// Update is called once per frame
//	void Update () {
		
//	}
//}
