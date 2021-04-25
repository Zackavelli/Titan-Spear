using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chant_Controller : MonoBehaviour
{

    Game_Controller gc;


    public List<int> Main_chant = new List<int>();
    public List<GameObject> Main_chant_obj = new List<GameObject>();


    public List<int> chant_1 = new List<int>();
    public List<int> chant_1_short = new List<int>();
    public List<int> chant_2 = new List<int>();
    public List<int> chant_2_short = new List<int>();
    public List<int> chant_3 = new List<int>();
    public List<int> chant_3_short = new List<int>();
    public List<int> chant_4 = new List<int>();
    public List<int> chant_4_short = new List<int>();

    public int num_of_chants;

    public GameObject[] chant_blocks;



    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<Game_Controller>();


        check_main_chant_length();
        set_main_chant_obj();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddChant(List<int> add_chant)
    {
        for(int i = 0; i < add_chant.Count; i++)
        {
            Main_chant.Add(add_chant[i]);
        }
    }

    public void Chant(int chant_sound)
    {
        if(chant_sound == Main_chant[0])
        {
            //correct sound

            if(chant_sound == 1)
            {
                Debug.Log("HUH");
                gc.sh.play_sound(0);
            }
            if (chant_sound == 2)
            {
                Debug.Log("HA");
                gc.sh.play_sound(1);
            }
            if (chant_sound == 3)
            {
                Debug.Log("CHI");
                gc.sh.play_sound(2);
            }

            gc.spirit += 4f;

            Main_chant.RemoveAt(0);
            Destroy(Main_chant_obj[0]);
            Main_chant_obj.RemoveAt(0);
            check_main_chant_length();
            set_main_chant_obj();

            //gc.move_level();
            //gc.Bar.transform.position = new Vector2(gc.Bar.transform.position.x - 2f, -4f);

        }
        else
        {
            //Incorrect sound
            Debug.Log("Wrong Key");
            gc.spirit -= 25f;
            gc.sh.play_sound(7);
        }
    }

    void check_main_chant_length()
    {
        if (Main_chant.Count <= 6)
        {
            int new_chant = Random.Range(1, num_of_chants + 1);
            int short_long = Random.Range(0, 2);

            Debug.Log(new_chant + "," + short_long);

            if (new_chant == 1 && short_long == 1)
            {
                AddChant(chant_1);
            }
            if (new_chant == 1 && short_long == 0)
            {
                AddChant(chant_1_short);
            }
            if (new_chant == 2 && short_long == 1)
            {
                AddChant(chant_2);
            }
            if (new_chant == 2 && short_long == 0)
            {
                AddChant(chant_2_short);
            }
            if (new_chant == 3 && short_long == 1)
            {
                AddChant(chant_3);
            }
            if (new_chant == 3 && short_long == 0)
            {
                AddChant(chant_3_short);
            }
            if (new_chant == 4 && short_long == 1)
            {
                AddChant(chant_4);
            }
            if (new_chant == 4 && short_long == 0)
            {
                AddChant(chant_4_short);
            }

            //Destroy(gc.Bar);

            gc.seperate_cadence();

        }
    }

    void set_main_chant_obj()
    {

        for (int i = 0; i < Main_chant_obj.Count; i++)
        {
            Destroy(Main_chant_obj[i]);
        }

        Main_chant_obj.Clear();


        for (int i = 0; i < Main_chant.Count; i++)
        {
            GameObject temp_chant_block;
            temp_chant_block = null;
            if(Main_chant[i] == 1)
            {
                temp_chant_block = Instantiate(chant_blocks[0]);
                temp_chant_block.transform.position = new Vector2(0, -4);
            }else if (Main_chant[i] == 2)
            {
                temp_chant_block = Instantiate(chant_blocks[1]);
                temp_chant_block.transform.position = new Vector2(0, -4);
            }
            else if (Main_chant[i] == 3)
            {
                temp_chant_block = Instantiate(chant_blocks[2]);
                temp_chant_block.transform.position = new Vector2(0, -4);
            }

            Main_chant_obj.Add(temp_chant_block);
        }

        for (int i = 0; i < Main_chant_obj.Count; i++)
        {
            Main_chant_obj[i].transform.position = new Vector2(i * 2, -4);
        }
    }
}
