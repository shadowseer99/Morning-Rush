using UnityEngine;
using System.Collections;

public class musicSystem : MonoBehaviour {
    public AudioSource music;
    public AudioClip[] musiclist;
    private int count = 1;
	// Use this for initialization
	void Awake ()
    {
        music.clip = musiclist[0];
        music.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!music.isPlaying)
        {
            music.clip = musiclist[count];
            music.Play();
            count++;
            if(count==musiclist.Length)
            {
                count = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            music.mute = !music.mute;
        }
	
	}
}
