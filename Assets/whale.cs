using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whale : MonoBehaviour
{
    public AudioSource audiodata;

    public AudioClip audioclip;
    
    // Start is called before the first frame update
    void Start()
    {
        audiodata = GetComponent<AudioSource>();

        audioclip = audiodata.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
