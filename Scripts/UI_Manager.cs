using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    Game_Controller gc;
    public Image spirit_bar;
    public Image fury_bar;
    public Image progress_bar;
    public GameObject End_text;
    public GameObject You_win_text;
    public bool remove_start_text;
    public GameObject start_text;


    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<Game_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        spirit_bar.fillAmount = gc.spirit / 100f;
        fury_bar.fillAmount = gc.fury / 100f;
        progress_bar.fillAmount = gc.progress;

        if(gc.spirit <= 0)
        {
            End_text.SetActive(true);
        }

        if(gc.tiles_passed == 60)
        {
            You_win_text.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(remove_start_text == false)
            {
                remove_start_text = true;
                start_text.SetActive(false);
            }
        }
    }
}
