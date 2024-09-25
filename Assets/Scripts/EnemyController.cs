using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public float rangeToChase;
    private Vector3 moveDirection;

    public Animator anim;

    public int health = 100;
    public GameObject[] deathSplatter;

    void Start()
    {

    }

    void Update()
    {
        handleMovement();
    }

    void handleMovement()
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

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            int splatter = Random.Range(0, deathSplatter.Length);
            int rotation = Random.Range(0, 4);
            Instantiate(deathSplatter[splatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));

        }
    }
}
