using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Game_Controller gc;
    public GameObject ps;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<Game_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        gc.shake.CamShake();

        gc.sh.play_sound(5);
        gc.sh.play_sound(6);
        ps.SetActive(true);
        gc.hearts_killed += 1;
    }
}
