using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TicketTimer : MonoBehaviour {

    
    public float speed;
    public float yPos;
    public Text order;
    private bool correct = false;
    public float reward=500;
    public ScoreScript scoring;

    public AudioClip orderUp;
    public AudioClip tip;
    AudioSource audio;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD

        scoring = GameObject.FindGameObjectWithTag("Store").GetComponent<ScoreScript>();
=======
        audio = GetComponent<AudioSource>();

        startpos = transform.position;
        transform.localScale = new Vector3(1, 1, 1);
>>>>>>> origin/master
        gameObject.GetComponent<Button>().interactable = true;
        audio.PlayOneShot(orderUp, 1);
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
<<<<<<< HEAD
            scoring.getTip((int)reward);
=======
            audio.PlayOneShot(tip, 1);
>>>>>>> origin/master
            order.text = "Satisfied";
        }
    }


}
