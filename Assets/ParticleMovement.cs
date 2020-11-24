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
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            transform.RotateAround(gameobject.transform.position, axis * Time.deltaTime, angle);
        }

        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }
}
