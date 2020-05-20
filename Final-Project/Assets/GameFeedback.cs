using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFeedback : MonoBehaviour
{
    public Text hit_txt;
    public Text miss_txt;


    void Start()
    {
        hit_txt.enabled = false;
        miss_txt.enabled = false;
    }

    //IEnumerator GetHit()
    //{
    //    hit_txt.enabled = true;
    //    yield return new WaitForSeconds(.1f);
    //}

    //IEnumerator GetMiss()
    //{
    //    miss_txt.enabled = true;
    //    yield return new WaitForSeconds(.1f);
    //}
}
