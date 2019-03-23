using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HingeBallCollision : MonoBehaviour
{
    public GameObject hinge;
    public GameObject cube;

    public int hitSignal;

    private AudioSource source;
    public AudioClip ballHit;

    private void OnTriggerEnter(Collider other)
    {
            //Debug.Log("score Triggered");
            hinge.transform.rotation = new Quaternion(0, 0, 0, 0);
            hitSignal = 1;
            source.PlayOneShot(ballHit, 0.5f);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
