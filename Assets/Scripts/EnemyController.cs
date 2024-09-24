using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public float rangeToChase;
    private Vector3 moveDirection;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChase)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;
    }
}
