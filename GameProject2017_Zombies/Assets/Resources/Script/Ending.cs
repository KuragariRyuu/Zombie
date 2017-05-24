using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    Fade fading;
    // Use this for initialization
    void Start () {
        fading = GameObject.Find("Fade").GetComponent<Fade>();
        fading.BeginFade(-1);
        StartCoroutine(endingalmost());

    }

    IEnumerator endingalmost()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitForSeconds(fading.BeginFade(1) *1.2f);
        Application.LoadLevel("StartPage");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
