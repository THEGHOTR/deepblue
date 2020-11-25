using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    public float speed;

    public Vector3 axis;

    public float angle;

    public GameObject gameobject;

    public bool rotating;

    public bool moving;

    public Vector3 endLocation;

    public Vector3 spawnLocation;

    public float timeScale = 0.5f;

    public float scaleProgress = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnLocation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location = transform.position;
        
        if (rotating)
        {
            transform.RotateAround(gameobject.transform.position, axis * Time.deltaTime, angle);
        }

        if (moving)
        {
            location = Vector3.Lerp(location, endLocation, scaleProgress);

            scaleProgress += Time.deltaTime * timeScale;

        }
        
    }
}
