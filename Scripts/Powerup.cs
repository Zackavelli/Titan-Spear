using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    Game_Controller gc;
    public bool fury;


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


        if (fury == true)
        {
            gc.fury_powerup_hit();
        }
        else
        {
            gc.spirit_powerup_hit();
             

        }

        gc.sh.play_sound(4);
    }
}
