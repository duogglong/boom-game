using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.enabled == false)
        {
            return;
        }
        else{
            bool player1 = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
            bool player2 = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
            if(player1 || player2)
            {
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else{
                audioSource.Stop();
            }
        }
    }
}
