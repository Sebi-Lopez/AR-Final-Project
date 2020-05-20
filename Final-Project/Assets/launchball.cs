using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid_b;

    [SerializeField] private float throw_force;
    #region private
    private bool thrown = false;
    private GameObject father_holder;
    private rotate_from_mouse pointer_script;
    private GameObject rotator;
    #endregion



    void Start()
    {
        rigid_b = gameObject.GetComponent<Rigidbody>();
        rigid_b.useGravity = false;
        father_holder = GameObject.FindGameObjectWithTag("BallHolder");
        pointer_script = father_holder.GetComponent<rotate_from_mouse>();
        rotator = GameObject.FindGameObjectWithTag("Arrow");
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Space) && !thrown)
       // {
       //     ThrowBall();
       // }
    }


    public void ThrowBall(Vector3 dir, int impulse = 1)
    {
        if(rigid_b == null)
            rigid_b = gameObject.GetComponent<Rigidbody>();

        rigid_b.useGravity = true;
        //rigid_b.AddForce(Vector3.forward);
        rigid_b.AddForce(dir.x, dir.y, dir.z, ForceMode.Impulse);
        thrown = true;
    }

    public void ResetBall()
    {
        if (rigid_b == null)
            rigid_b = gameObject.GetComponent<Rigidbody>();

        rigid_b.velocity = Vector3.zero;
        rigid_b.useGravity = false;
        rigid_b.MoveRotation(Quaternion.identity);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        pointer_script.ResetStates();
      //  pointer_script.ParentRotator();
        rotator.SetActive(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Lose Collider"))
        {
           GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().Miss();
        }
        else if(collision.gameObject.CompareTag("Cup Collider"))
        {
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().Hit();
            collision.transform.parent.gameObject.SetActive(false);
        }
    }
}

