using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //animator

        Vector3 directionVector = new Vector3(v, 0, h);
        Vector3 pos = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z+speed);


        animator.speed = 2;
        rigidbody.MovePosition(pos);   
        //rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;

    }
}