using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieOnHit : MonoBehaviour
{
    public GameObject zombie;
    public int hitBit;

    private AudioSource source;
    public AudioClip smack;

    private void OnTriggerEnter(Collider other)
    {
        hitBit = 1;
        source.PlayOneShot(smack, 0.5f);
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
