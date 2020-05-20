using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_from_mouse : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject arrow;
    private GameObject ball;

    [SerializeField]
    private GameObject direction_bar;

    [SerializeField]
    private int max_intensity = 20;
    enum SHOT
    {
        HORIZONTAL,
        VERTICAL,
        INTENSITY,
        LAUNCH,
        LAUNCHED
    }
    SHOT launch_states = SHOT.HORIZONTAL;

    #region vars
    public float horizontalSpeed = 200;
    public float verticalSpeed = 200;
    private bool changeH_dir = false;
    private bool changeV_dir = false;
    private float verticalLimits=20;
    private int times_pressed = 0;
    private bool pressed = false;
    //private Transform arrow_trans;
    private Vector3 initial_arrow_scale;
    private int max_time_pressed = 500;
    private Transform arrow_trans;

    #endregion


    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        ball = GameObject.FindGameObjectWithTag("Ball");
        arrow_trans = arrow.GetComponent<Transform>();
        initial_arrow_scale = arrow_trans.localScale;
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
                Intensity();
                break;

            case SHOT.LAUNCH:
                LaunchBall();
                break;
            case SHOT.LAUNCHED:
                ResetBar();
                break;

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (launch_states == SHOT.HORIZONTAL)
                launch_states = SHOT.VERTICAL;
            
            else if (launch_states == SHOT.VERTICAL)
                //launch_states = SHOT.INTENSITY;
                launch_states = SHOT.INTENSITY;
            
        }

    }

    void Intensity()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          
            pressed = true;

        }

        if(Input.GetKey(KeyCode.Space)&& pressed)
        {
            if (max_time_pressed > times_pressed)
            {
                times_pressed += 1;
                VisualFeedBack();
            }
           // Debug.Log(times_pressed);
           
        }
        else if(Input.GetKeyUp(KeyCode.Space) && times_pressed >0)
        {
            launch_states = SHOT.LAUNCH;
        }
        
    }

    void VisualFeedBack() 
    {
        //conversio dels times a la escala

        float updated_scale = times_pressed * ( initial_arrow_scale.y) / 500.0f;
        updated_scale = initial_arrow_scale.y - updated_scale;

        if(updated_scale < 0.2f*initial_arrow_scale.y)
            arrow.transform.localScale = new Vector3(arrow_trans.localScale.x, arrow_trans.localScale.y, arrow_trans.localScale.z);

        else arrow.transform.localScale = new Vector3(arrow_trans.localScale.x, updated_scale, arrow_trans.localScale.z);

        //Color color;
        //color.a = 1;
        //color.r = times_pressed * 255 / 500;
        //color.g = 0;
        //color.b = 0;
        //direction_bar.GetComponent<Material>().SetColor("_Color",color);


       //Vector3 scala = max_time_pressed* arr
    }

    void LaunchBall()
    {
        launchball script = ball.GetComponent<launchball>();
        Vector3 vec;
        vec.x = arrow.transform.rotation.y;
        vec.y = arrow.transform.rotation.x;
        vec.z = arrow.transform.rotation.z;
        //vec.Normalize();
        launch_states = SHOT.LAUNCHED;

        Vector3 rotated_vec;
        rotated_vec.x = vec.x;


        //////Z axis
        //float rad_angle = -90 * Mathf.PI / 180;
        //rotated_vec.x = vec.x * Mathf.Cos(rad_angle) - vec.y * Mathf.Sin(rad_angle);
        //rotated_vec.y = vec.x * Mathf.Sin(rad_angle) + vec.y * Mathf.Cos(rad_angle);

        //X axis
        float rad_angle = 50 * Mathf.PI / 180;
        rotated_vec.y = vec.y * Mathf.Cos(rad_angle)-vec.z*Mathf.Sin(rad_angle);
        rotated_vec.z = vec.y * Mathf.Sin(rad_angle) + vec.z * Mathf.Cos(rad_angle);

        float relative_intensity = times_pressed * max_intensity / max_time_pressed;


        script.ThrowBall(rotated_vec*relative_intensity,1);


        // 50* Mathf.PI / 180
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


    void ResetBar()
    {
        //arrow.transform.position.x = 0.0f;
        times_pressed = 0;
        arrow.transform.localScale = new Vector3(initial_arrow_scale.x, initial_arrow_scale.y, initial_arrow_scale.z);

        arrow.transform.rotation = Quaternion.Euler(90,0,50);
        //arrow.SetActive(false);
    }
}
