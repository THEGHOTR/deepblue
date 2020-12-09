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

    public float countdownTimer;

    private Vector3 origin = new Vector3(0, 0, 0);

    public GameObject Bubble;

    public GameObject newBubble;

    public GameObject newBiolume;
    public GameObject newBiolume2;
    public GameObject newBiolume3;
    public GameObject newBiolume4;
    public GameObject newBiolume5;

    public GameObject Biolume1;
    public GameObject Biolume2;
    public GameObject Biolume3;
    public GameObject Biolume4;
    public GameObject Biolume5;

    public Text BubblesInteractedText;

    public Text BubblesActiveText;

    [SerializeField] whale whalesound;

    // Start is called before the first frame update
    void Start()
    {
        BubblesActive = GameObject.FindGameObjectsWithTag("Bubble").Length;

        whalesound = FindObjectOfType<whale>();

        StartCoroutine(CountdownTimer());

        newBiolume = Instantiate(Biolume1, origin, transform.rotation);
        Biolume1.SetActive(false);

        newBiolume2 = Instantiate(Biolume2, origin, transform.rotation);
        Biolume2.SetActive(false);

        newBiolume3 = Instantiate(Biolume3, origin, transform.rotation);
        Biolume3.SetActive(false);

        newBiolume4 = Instantiate(Biolume4, origin, transform.rotation);
        Biolume4.SetActive(false);

        newBiolume5 = Instantiate(Biolume5, origin, transform.rotation);
        Biolume5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BubblesInteractedText.text = "Bubbles Interacted: " + BubblesInteracted.ToString() + "/" + maxBubblesInteracted.ToString();

        BubblesActiveText.text = "Bubbles Active: " + BubblesActive.ToString() + "/" + maxBubblesActive.ToString();

        if(countdownTimer > 0)
        {
            countdownTimer -= 1 * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BubblePopped();
        }
    }

    public void SpawnParticle()
    {
        switch (BubblesInteracted)
        {
            case 5:
                newBiolume5.SetActive(true);
                Debug.Log("Last one");              
                break;
            case 4:
                newBiolume4.SetActive(true);
                Debug.Log("Four");              
                break;
            case 3:
                newBiolume3.SetActive(true);
                whalesound.audiodata.Play();
                Debug.Log("Three");                
                break;
            case 2:
                newBiolume2.SetActive(true);
                Debug.Log("Two");
                break;
            case 1:
                newBiolume.SetActive(true);
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

    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(countdownTimer);

        StartCoroutine(SpawnBubble());

        yield break;
    }

    IEnumerator SpawnBubble()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

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
