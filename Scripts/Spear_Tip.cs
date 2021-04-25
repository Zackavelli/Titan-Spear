using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Tip : MonoBehaviour
{

    Game_Controller gc;

    public GameObject top_ps;
    public GameObject bot_ps;
    public Vector3 mp;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<Game_Controller>();
        top_ps.SetActive(false);
        bot_ps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (gc.gamestarted == true)
        {

            top_ps.SetActive(true);
            bot_ps.SetActive(true);



            mp = Input.mousePosition;
            mp = Camera.main.ScreenToWorldPoint(mp);

            if (mp.y > 4.2)
            {
                mp.y = 4.2f;
            }
            else if (mp.y < -2.25)
            {
                mp.y = -2.25f;
            }

            transform.position = new Vector3(transform.position.x, mp.y);
        }

        if(gc.gamestarted == false)
        {
            top_ps.SetActive(false);
            bot_ps.SetActive(false);
        }
    }
}
