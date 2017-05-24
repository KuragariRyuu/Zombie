using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movie : MonoBehaviour {
    public MovieTexture movie;
    public DialogueManager manager;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        manager = GameObject.Find("Panel").GetComponent<DialogueManager>();
        StartCoroutine(movieplay());
    }
    IEnumerator movieplay()
    {
        manager.playerTalking = true;
        movie.Play();
        yield return new WaitForSeconds(5.01f);
        manager.playerTalking = false;
    }

}
