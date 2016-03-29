using UnityEngine;
using UnityEngine.UI;

public class TicketTimer : MonoBehaviour {

    
    public float speed;
    public float yPos;
    public Text order;
    private Vector3 startpos;
    private bool correct = false;

	// Use this for initialization
	void Start () {
        
        startpos = transform.position;
        transform.localScale = new Vector3(1, 1, 1);
        gameObject.GetComponent<Button>().interactable = true;
    }
	
	// Update is called once per frame
    //The positions and speed of the ticket are arbitrary 
    //the amount of time alloted for each order will later be determined by difficulty
	void Update () {
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
            GameObject newTicket = Instantiate(this.gameObject) as GameObject;
            newTicket.transform.position = startpos;
            newTicket.transform.SetParent(transform.parent);
            Destroy(this.gameObject);
        }
        if(correct)
        {
            speed = -5f;
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
            order.text = "Satisfied";
        }
    }


}
