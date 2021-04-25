using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{

    Game_Controller gc;

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
        gc.obsticle_hit();
        gc.sh.play_sound(3);
    }
}
