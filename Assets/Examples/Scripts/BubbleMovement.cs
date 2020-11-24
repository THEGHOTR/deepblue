using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float movementSpeed = 1;

    private float scaleProgress = 0;

    public float timeScale = 0.5f;

    public Vector3 startingScale = new Vector3(0.25f, 0.25f, 0.25f);

    public Vector3 endScale = new Vector3(1f, 1f, 1f);
    
    
    // Start is called before the first frame update

    void Start()
    {
        transform.localScale = startingScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(startingScale, endScale, scaleProgress);

        scaleProgress += Time.deltaTime * timeScale;

        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
