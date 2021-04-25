using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{

    public SoundHandler sh;
    public Shake shake;


    public int hearts_killed;
    public GameObject main_camera;
    public GameObject HAAAAA_prefab;
    public GameObject HAAA_inst;
    public Animator startertiles_ani;
    public Animator spear_ani;
    public bool gamestarted;
    public float spirit;
    public float fury;
    public bool invinceable;
    public int tiles_passed;
    public float progress;
    //public GameObject Bar;
    //public GameObject Bar_prefab;


    Chant_Controller cc;

    public List<GameObject> Level_Tiles_active = new List<GameObject>();

    public float level_move_speed;
    public float stored_move_speed;

    //Maybe split this into easy/hard
    public GameObject[] level_tiles_dex;

    public GameObject[] level_tiles_harder;

    public GameObject[] level_tiles_boss;


    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectOfType<Chant_Controller>();
        sh = FindObjectOfType<SoundHandler>();
        shake = main_camera.GetComponent<Shake>();
        spirit = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestarted == true)
        {

            chant_input();
            move_level();
            spirit_Decay();

            progress = tiles_passed / 60f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("start_seq");
            start_move();
            
        }


    }

    void chant_input()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cc.Chant(1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            cc.Chant(2);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            cc.Chant(3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fury > 0)
            {
                invinceable = true;
                stored_move_speed = level_move_speed;
                level_move_speed = 6.5f;

                HAAA_inst = Instantiate(HAAAAA_prefab);

            }
           


        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (fury > 0)
            {

                float step_decay;

                step_decay = 50f * Time.deltaTime;

                fury -= step_decay;

                float step_gain;

                step_gain = 10f * Time.deltaTime;

                spirit += step_gain;

                Debug.Log("AAAAAAAAAHHHH");

                //sh.play_haaaaa();
            }
            else
            {
                invinceable = false;
                //stored_move_speed -= .5f;
                if (stored_move_speed < 1f)
                {
                    stored_move_speed = 1f;
                }
                level_move_speed = stored_move_speed;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            invinceable = false;
            //stored_move_speed -= .5f;
            if (stored_move_speed < 1f)
            {
                stored_move_speed = 1f;
            }
            level_move_speed = stored_move_speed;

            Destroy(HAAA_inst);

        }
    }

    public void move_level()
    {
        foreach (GameObject tile in Level_Tiles_active)
        {

            Vector2 endPosition = new Vector2(tile.transform.position.x - 6, tile.transform.position.y);
            float step = level_move_speed * Time.deltaTime;


            tile.transform.position = Vector2.Lerp(tile.transform.position, endPosition, step);

            //tile.transform.position = new Vector2(tile.transform.position.x - 6, tile.transform.position.y);
        }
    }

    public void start_move()
    {
        
    }

    public void update_level()
    {
        if(Level_Tiles_active.Count < 3)
        {

            if(tiles_passed == 12)
            {
                GameObject temp_tile_boss;
                temp_tile_boss = Instantiate(level_tiles_boss[0]);
                temp_tile_boss.transform.position = new Vector2(36, 0);
                Level_Tiles_active.Add(temp_tile_boss);
                //level_move_speed = 1.5f;
            }else if(tiles_passed == 32){
                GameObject temp_tile_boss;
                temp_tile_boss = Instantiate(level_tiles_boss[1]);
                temp_tile_boss.transform.position = new Vector2(36, 0);
                Level_Tiles_active.Add(temp_tile_boss);
                //level_move_speed = 1.5f;
            }
            else if (tiles_passed == 57)
            {
                GameObject temp_tile_boss;
                temp_tile_boss = Instantiate(level_tiles_boss[2]);
                temp_tile_boss.transform.position = new Vector2(36, 0);
                Level_Tiles_active.Add(temp_tile_boss);
            }
            else if (tiles_passed == 58)
            {
                GameObject temp_tile_boss;
                temp_tile_boss = Instantiate(level_tiles_boss[3]);
                temp_tile_boss.transform.position = new Vector2(36, 0);
                Level_Tiles_active.Add(temp_tile_boss);
            }
            else
            {
                int randnum;
                randnum = Random.Range(0, level_tiles_dex.Length);


                GameObject temp_tile;
                temp_tile = Instantiate(level_tiles_dex[randnum]);
                temp_tile.transform.position = new Vector2(36, 0);
                Level_Tiles_active.Add(temp_tile);
            }


            if(tiles_passed == 15)
            {
                level_move_speed = 1.5f;
            }
            else if(tiles_passed == 35)
            {
                level_move_speed = 1.5f;
            }
            else if (tiles_passed == 60)
            {
                level_move_speed = .025f;
                
                

            }

            if(hearts_killed >= 4)
            {
                StartCoroutine("end_seq");
                invinceable = true;
            }



            level_move_speed += .05f;

        }

    }

    public void obsticle_hit()
    {

        if (invinceable == false)
        {
            Debug.Log("Hit Obsticle");
            spirit -= 30f;
        }
    }

    public void fury_powerup_hit()
    {
        Debug.Log("Hit Fury Powerup");
        fury += 33f;

        if(fury > 100)
        {
            fury = 100f;
        }
    }

    public void spirit_powerup_hit()
    {
        Debug.Log("Hit Spirit Powerup");
        spirit += 40f;

        if (spirit > 100)
        {
            spirit = 100f;
        }
    }

    public void spirit_Decay()
    {
        if (invinceable == false)
        {

            float step_decay;

            step_decay = 8f * Time.deltaTime;

            spirit -= step_decay;

            if (spirit > 100)
            {
                spirit = 100;
            }

            if (spirit <= 0)
            {
                Debug.Log("Game Over");
                level_move_speed = 0;
                gamestarted = false;
                StartCoroutine("end_seq");
            }
        }
    }

    public void seperate_cadence()
    {
        //Bar = Instantiate(Bar_prefab);
        //Bar.transform.position = new Vector2(11, 0);
    }

    public IEnumerator start_seq()
    {

        startertiles_ani.Play("Start_tile_ani");
        spear_ani.Play("Spear_start_ani");

        yield return new WaitForSeconds(5);
        spear_ani.enabled = false;
        gamestarted = true;

    }

    public IEnumerator end_seq()
    {

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(0);

    }
}
