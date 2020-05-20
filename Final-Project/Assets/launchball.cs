﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid_b;

    [SerializeField] private float throw_force;
    [SerializeField] private GameObject rotator;
    #region private
    private bool thrown = false;
    #endregion



    void Start()
    {
        rigid_b = gameObject.GetComponent<Rigidbody>();
        rigid_b.useGravity = false;
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
        rigid_b.useGravity = true;
        //rigid_b.AddForce(Vector3.forward);
        rigid_b.AddForce(dir.x, dir.y, dir.z, ForceMode.Impulse);
        thrown = true;
    }

    public void ResetBall()
    {
        rigid_b.velocity = Vector3.zero;
        rigid_b.useGravity = false;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
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
        }
    }
}

