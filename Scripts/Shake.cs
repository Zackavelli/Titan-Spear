using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator CamAni;

    public void CamShake()
    {
        CamAni.SetTrigger("Shake");
    }
    
}
