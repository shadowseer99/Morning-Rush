using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {
    public GameObject credits;
    public GameObject instructions;
    public GameObject dropdown;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void startButtonPress()
    {
        Application.LoadLevel(dropdown.GetComponent<Dropdown>().value+1);
    }

    public void creditsButtonPress()
    {
        credits.gameObject.SetActive(true);
    }

    public void closeCredits()
    {
        credits.gameObject.SetActive(false);
    }
    public void howToButtonPress()
    {
        instructions.gameObject.SetActive(true);
    }
    public void closeInst()
    {
        instructions.gameObject.SetActive(false);
    }

    public void toWebsiteButtonPress()
    {
        Application.OpenURL("http://www.starbucks.com/");
    }
}
