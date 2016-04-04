using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text tips;
    public Text fails;
    public float money=0.00f;
    private int fail = 0;

	// Use this for initialization
	void Start () {
        tips.text = "Tips: $" + money;
        fails.text = "Angry Customers " + fail;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void getTip(int dosh)
    {
        money += dosh / 100f;
        tips.text = "Tips: $ " + money;
    }
    public void failed()
    {
        fail++;
        fails.text = "Angry Customers " + fail;
    }

}
