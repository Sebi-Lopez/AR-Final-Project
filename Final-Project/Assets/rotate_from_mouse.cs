using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_from_mouse : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject arrow;
    private GameObject ball;

    #region vars
    public float horizontalSpeed = 200;
    public float verticalSpeed = 200;
    bool changeH_dir = false;
    bool changeV_dir = false;
    public float verticalLimits=20;
    #endregion

    enum SHOT
    {
        HORIZONTAL,
        VERTICAL,
        INTENSITY,
        LAUNCH
    }
    SHOT launch_states = SHOT.HORIZONTAL;
    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        ball = GameObject.FindGameObjectWithTag("Ball");

    }


    // Update is called once per frame
    void Update()
    {
        switch (launch_states)
        {
            case SHOT.HORIZONTAL:
                ZAxisRot();
                break;
            case SHOT.VERTICAL:
                XAxisRot();
                break;

            case SHOT.INTENSITY:
                break;

            case SHOT.LAUNCH:
                LaunchBall();
                break;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (launch_states == SHOT.HORIZONTAL)
                launch_states = SHOT.VERTICAL;
            
            else if (launch_states == SHOT.VERTICAL)
                //launch_states = SHOT.INTENSITY;
                launch_states = SHOT.LAUNCH;
            
        }

    }

    void LaunchBall()
    {
        launchball script = ball.GetComponent<launchball>();
        Vector3 vec;
        vec.x = 0;
        vec.y = arrow.transform.rotation.x;
        vec.z = arrow.transform.rotation.z;
        Vector3 vv = arrow.transform.eulerAngles;
        script.ThrowBall(vec);
        
    }
    void ZAxisRot()
     {
        float a = arrow.transform.rotation.z;
        float b = a*180 / Mathf.PI;
        if (!changeH_dir && b < 20)
            RotateLeft();
        else if (changeH_dir && b > -20)
            RotateRight();
        else
        {
            if (!changeH_dir)
                changeH_dir = true;
            else changeH_dir = false;
        }
    }

    void RotateLeft()
    {
        arrow.transform.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);

    }

    void RotateRight()
    {
        arrow.transform.Rotate(Vector3.forward * -horizontalSpeed * Time.deltaTime);

    }

    void XAxisRot()
    {
        float a = arrow.transform.rotation.x;
        float b = a * 180 / Mathf.PI;


        if (!changeV_dir && b < 50 && b > 22) //22 esta en lo alto
            RotateUp();
        else if (changeV_dir && b-1 < 40)
            RotateDown();
        else
        {
            if (!changeV_dir)
                changeV_dir = true;
            else changeV_dir = false;
        }
    }

    void RotateUp()
    {
        arrow.transform.Rotate(Vector3.right * -verticalSpeed * Time.deltaTime);
    }
    void RotateDown()
    {
        arrow.transform.Rotate(Vector3.right * verticalSpeed * Time.deltaTime);

    }
}
