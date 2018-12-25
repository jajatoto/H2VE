using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        moveSpeed = 10f;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 moveAcc = moveInput.normalized * moveSpeed;

        rb.MovePosition(rb.position + moveAcc * Time.deltaTime);
        

    }
}
