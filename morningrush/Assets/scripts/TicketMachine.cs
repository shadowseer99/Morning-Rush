using UnityEngine;
using System.Collections;

public class TicketMachine : MonoBehaviour {
    public int maxchild = 4;
    public GameObject ticketPrefab;
    private float cooldown=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldown -= Time.deltaTime;
        if(cooldown<0)
        {
            if (transform.childCount == 0)
            {
                GameObject temp = Instantiate(ticketPrefab);
                temp.transform.SetParent(transform);
                temp.transform.localPosition = new Vector3(0, 250, 0);
                cooldown = 3;
            }
            else if (transform.childCount < maxchild)
            {
                if (Random.Range(transform.childCount, maxchild * 100) < maxchild)
                {
                    GameObject temp = Instantiate(ticketPrefab);
                    temp.transform.SetParent(transform);
                    temp.transform.localPosition = new Vector3(0, 250, 0);
                    cooldown = 3;
                }
            }
        }
	    
	}
}
