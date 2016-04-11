using UnityEngine;
using System.Collections;

public class gameMenu : MonoBehaviour {
    public GameObject cards;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void main()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }
    public void showCards(bool act)
    {
        cards.SetActive(act);
    }
}
