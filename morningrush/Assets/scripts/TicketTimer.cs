using UnityEngine;
using UnityEngine.UI;

public class TicketTimer : MonoBehaviour {

    
    public float speed;
    public float yPos;
    public Text order;
    private bool correct = false;
    public float reward=500;
    public ScoreScript scoring;

	// Use this for initialization
	void Start () {

        scoring = GameObject.FindGameObjectWithTag("Store").GetComponent<ScoreScript>();
        gameObject.GetComponent<Button>().interactable = true;
    }
	
	
	void Update () {
        reward -= Time.deltaTime*15;
        yPos = transform.position.y;
        if (yPos > 158)
        {
            speed = -20;
        }
        else if (yPos <= 158 & yPos > 70)
        {

            speed = -15;
        }
        else if (yPos <= 70 & yPos > 34)
        {
            speed = -10;
        }
        else
        {
            scoring.failed();
            Destroy(this.gameObject);
        }
        if(correct)
        {
            speed = -20f;
        }
        transform.Translate(0, speed*Time.deltaTime, 0);
	}

    public void getOrder()
    {
        expressobar bar = GameObject.FindGameObjectWithTag("Bar").GetComponent<expressobar>();
        correct = bar.orderup(order.text);
        if(correct)
        {
            gameObject.GetComponent<Button>().interactable = false;
            scoring.getTip((int)reward);
            order.text = "Satisfied";
        }
    }


}
