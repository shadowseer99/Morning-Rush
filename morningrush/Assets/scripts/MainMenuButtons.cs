using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void startButtonPress()
    {
        Application.LoadLevel("level1");
    }

    public void creditsButtonPress()
    {
        Application.LoadLevel("credits");
    }

    public void howToButtonPress()
    {
        Application.LoadLevel("tutorial");
    }

    public void toWebsiteButtonPress()
    {
        Application.OpenURL("http://www.starbucks.com/");
    }
}
