using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text tips;
    public Text fails;
    public Text timer;
    public Text endsplash;
    public GameObject levelend;
    public float money=0.00f;
    private int fail = 0;
    public bool timeattack;
    public bool satisfaction;
    private float time = 0;


	// Use this for initialization
	void Start () {
        tips.text = "Tips: $" + money;
        fails.text = "Angry Customers " + fail;
        if(timeattack||satisfaction)
        {
            levelend.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(timeattack)
        {
            time += Time.deltaTime;
            int mins = (int)time / 60;
            int secs = (int)time % 60;
            timer.text = "Time: " + mins + ":" + secs;

        }
	
	}
    public void getTip(int dosh)
    {
        money += dosh / 100f;
        tips.text = "Tips: $ " + money;
        if(timeattack&&money>=20)
        {
            Time.timeScale = 0;
            levelend.SetActive(true);
            int mins = (int)time / 60;
            int secs = (int)time % 60;
            endsplash.text = "Congradulations\n\nIt took you " + mins + ":" + secs + " to reach your goal\n\nYou also angered " + fail + " customers";
        }
    }
    public void failed()
    {
        fail++;
        fails.text = "Angry Customers " + fail;
        if(satisfaction&&fail==10)
        {
            Time.timeScale = 0;
            levelend.SetActive(true);
            endsplash.text = "You're Fired!\n\nYou angered too many customers\n\nAt least you earned $"+money+" in tips";
        }
    }

}
