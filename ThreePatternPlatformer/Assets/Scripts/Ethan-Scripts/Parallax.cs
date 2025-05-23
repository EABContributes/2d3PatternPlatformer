using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float changeFromCamera = (cam.transform.position.x) * (1-parallaxEffect);
        float dist = (cam.transform.position.x) * parallaxEffect;
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (changeFromCamera > startpos + length) startpos += length;
        else if (changeFromCamera < startpos -  length) startpos -= length;
    }
}
