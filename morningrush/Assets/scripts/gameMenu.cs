using UnityEngine;
using System.Collections;

public class gameMenu : MonoBehaviour {

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
    }
}
