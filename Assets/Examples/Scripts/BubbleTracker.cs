using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTracker : MonoBehaviour
{
    public int BubblesInteracted;

    public int BubblesActive;

    public int maxBubblesInteracted = 5;

    public int maxBubblesActive;

    public GameObject Bubble;

    public GameObject newBubble;

    public GameObject newBiolume;

    public GameObject Biolume1;
    public GameObject Biolume2;
    public GameObject Biolume3;
    public GameObject Biolume4;

    public Text BubblesInteractedText;

    public Text BubblesActiveText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBubble());

        BubblesActive = GameObject.FindGameObjectsWithTag("Bubble").Length;
    }

    // Update is called once per frame
    void Update()
    {
        BubblesInteractedText.text = "Bubbles Interacted: " + BubblesInteracted.ToString() + "/" + maxBubblesInteracted.ToString();

        BubblesActiveText.text = "Bubbles Active: " + BubblesActive.ToString() + "/" + maxBubblesActive.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BubblePopped();
        }
    }

    public void SpawnParticle()
    {
        Vector3 origin = new Vector3(0, -5, 0);

        switch (BubblesInteracted)
        {
            case 5:
                Debug.Log("Last one");
                break;
            case 4:
                Debug.Log("Four");
                break;
            case 3:
                Debug.Log("Three");
                break;
            case 2:
                newBiolume = Instantiate(Biolume2, origin, transform.rotation);
                Debug.Log("Two");
                break;
            case 1:
                newBiolume = Instantiate(Biolume1, origin, transform.rotation);
                Debug.Log("One");
                break;
            case 0:
                Debug.Log("Get Popping");
                break;
        }
    }

    public void BubblePopped()
    {
        BubblesInteracted += 1;

        BubblesActive -= 1;

        SpawnParticle();
    }

    IEnumerator SpawnBubble()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Vector3 newPosition = new Vector3(Random.Range(-5f, 5f), transform.position.y - 5f, transform.position.z + 2f);

            if (BubblesInteracted < maxBubblesInteracted || BubblesActive < maxBubblesActive)
            {
                newBubble = Instantiate(Bubble, newPosition, transform.rotation);

                BubblesActive = GameObject.FindGameObjectsWithTag("Bubble").Length;
            }

            Debug.Log("Bubble Spawned");
        }
        
    }
}
