using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField] BubbleTracker tracker;


    void Start()
    {
        FindObjectOfType<BubbleTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Trigger Entered");

        if (collision.gameObject.tag == "Bubble")
        {
            Object.Destroy(collision.gameObject);

            tracker.BubblesActive -= 1;
        }
    }
}
