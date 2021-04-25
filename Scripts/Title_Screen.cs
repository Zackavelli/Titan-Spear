using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Screen : MonoBehaviour
{

    public GameObject start_text;
    public GameObject howto_text;

    public bool start;
    public bool howto;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (start == false && howto == false)
            {
                start = true;
                start_text.SetActive(false);
                howto_text.SetActive(true);
            }else if (start == true && howto == false)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
