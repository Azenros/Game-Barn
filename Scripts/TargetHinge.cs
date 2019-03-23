using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHinge : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject hinge1, hinge2, hinge3, hinge4, hinge5, 
                      hinge6, hinge7, hinge8, hinge9;
    public GameObject timeText, scoreText;
    public GameObject floor;
    private BoxCollider box;

    private float timer = 0f;
    public float randTimer = 5f;
    private int score = 0;
    private int flush = 0;
    private int open = 0;

    HingeBallCollision h1, h2, h3, h4, h5, h6, h7, h8, h9;
    public System.Random rand = new System.Random();

    public bool Countdown()
    {
        timer += Time.deltaTime;
        if (timer > randTimer)
        {
            return true;
        }
        return false;
    }
    void resetHinges() {
        hinge1.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge2.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge3.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge4.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge5.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge6.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge7.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge8.transform.rotation = new Quaternion(0, 0, 0, 0);
        hinge9.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    void newHinges()
    {
        int select = rand.Next(0, 8);
        int select2 = rand.Next(0, 8);
        while (select2 == select)
        {
            select2 = rand.Next(0, 8);
        }
        int select3 = rand.Next(0, 8);
        while (select3 == select || select3 == select2)
        {
            select3 = rand.Next(0, 8);
        }
        resetHinges();
        if (select == 0 || select2 == 0 || select3 == 0) { hinge1.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 1 || select2 == 1 || select3 == 1) { hinge2.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 2 || select2 == 2 || select3 == 2) { hinge3.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 3 || select2 == 3 || select3 == 3) { hinge4.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 4 || select2 == 4 || select3 == 4) { hinge5.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 5 || select2 == 5 || select3 == 5) { hinge6.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 6 || select2 == 6 || select3 == 6) { hinge7.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 7 || select2 == 7 || select3 == 7) { hinge8.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        if (select == 8 || select2 == 8 || select3 == 8) { hinge9.transform.rotation = new Quaternion(-.7071f, 0, 0, 0.7071f); }
        timer = 0f;
    }
    void getSignals()
    {
        if (h1.hitSignal == 1) { score++; h1.hitSignal = 0; }
        if (h2.hitSignal == 1) { score++; h2.hitSignal = 0; }
        if (h3.hitSignal == 1) { score++; h3.hitSignal = 0; }
        if (h4.hitSignal == 1) { score++; h4.hitSignal = 0; }
        if (h5.hitSignal == 1) { score++; h5.hitSignal = 0; }
        if (h6.hitSignal == 1) { score++; h6.hitSignal = 0; }
        if (h7.hitSignal == 1) { score++; h7.hitSignal = 0; }
        if (h8.hitSignal == 1) { score++; h8.hitSignal = 0; }
        if (h9.hitSignal == 1) { score++; h9.hitSignal = 0; }

    }

   
    void Start() {
        resetHinges();
        h1 = hinge1.GetComponentInChildren<HingeBallCollision>();
        h2 = hinge2.GetComponentInChildren<HingeBallCollision>();
        h3 = hinge3.GetComponentInChildren<HingeBallCollision>();
        h4 = hinge4.GetComponentInChildren<HingeBallCollision>();
        h5 = hinge5.GetComponentInChildren<HingeBallCollision>();
        h6 = hinge6.GetComponentInChildren<HingeBallCollision>();
        h7 = hinge7.GetComponentInChildren<HingeBallCollision>();
        h8 = hinge8.GetComponentInChildren<HingeBallCollision>();
        h9 = hinge9.GetComponentInChildren<HingeBallCollision>();
    }

    // Update is called once per frame
    void Update() {
        timeText.GetComponent<Text>().text = "" + (6 - timer);
        if (Countdown()) { newHinges(); flush++; }

        getSignals();
        scoreText.GetComponent<Text>().text = "Score: " + score;

        if (flush == 3)
        {
            box = floor.GetComponent<BoxCollider>();
            box.isTrigger = true;
            flush = 0;
            open = 1;
        }

        if (flush == 1 && open == 1)
        {
            box.isTrigger = false;
            open = 0;
        }
    }
}
