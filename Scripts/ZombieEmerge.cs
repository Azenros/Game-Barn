using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieEmerge : MonoBehaviour
{
    public GameObject zombieUp, zombieDown, zombieOut;
    public GameObject timeText, scoreText;

    public System.Random rand = new System.Random();
    //private BoxCollider box1, box2, box3;

    ZombieOnHit z1, z2, z3;

    //private AudioSource source;
    //public AudioClip zombiemoan;

    private float timer = 0f;
    public float randTimer = 5f;
    private int score = 0;
    private int prevZombie;

    void resetZombies()
    {
        zombieDown.transform.localPosition = new Vector3(2.066847f, 2.357f, 2.285088f);

        zombieUp.transform.localPosition = new Vector3(.036f, -1.6f);

        zombieOut.transform.localPosition = new Vector3(-0.317f, -0.4815f);

    }
    public bool Countdown()
    {
        timer += Time.deltaTime;
        timeText.GetComponent<Text>().text = "" + timer;
        if (timer > randTimer)
        {
            return true;
        }
        return false;
    }
    void oneZombie()
    {
        int choose = rand.Next(0, 3);
        while (choose == prevZombie)
        {
            choose = rand.Next(0, 3);
        }
        resetZombies();
        if (choose == 0)
        {
            zombieDown.transform.localPosition = new Vector3(2.066847f, 1.6f, 2.285088f);
           // source.PlayOneShot(zombiemoan, 0.5f);
            prevZombie = 0;
        }
        else if (choose == 1)
        {
            zombieUp.transform.localPosition = new Vector3(.036f, -0.33f);
            //source.PlayOneShot(zombiemoan, 0.5f);
            prevZombie = 1;
        }
        else
        {
            zombieOut.transform.localPosition = new Vector3(0.548f, -0.4815f, .041f);
            //source.PlayOneShot(zombiemoan, 0.5f);
            prevZombie = 2;
        }
    }
    void getSignals()
    {
        if (z1.hitBit == 1) { score++; z1.hitBit = 0; resetZombies(); }
        if (z2.hitBit == 1) { score++; z2.hitBit = 0; resetZombies(); }
        if (z3.hitBit == 1) { score++; z3.hitBit = 0; resetZombies(); }
    }
    /*
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        //Awake();
        resetZombies();
        z1 = zombieUp.GetComponentInChildren<ZombieOnHit>();
        z2 = zombieDown.GetComponentInChildren<ZombieOnHit>();
        z3 = zombieOut.GetComponentInChildren<ZombieOnHit>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown()) { oneZombie(); timer = 0; }
        getSignals();
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
