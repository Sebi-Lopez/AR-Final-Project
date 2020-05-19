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
}
