using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_tile : MonoBehaviour
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
        if(transform.position.x <= -18)
        {
            gc.tiles_passed += 1;
            gc.Level_Tiles_active.Remove(this.gameObject);
            Destroy(this.gameObject);

            gc.update_level();
        }
    }
}
