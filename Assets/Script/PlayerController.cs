using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float horizontalDir;
    private float verticalDir;

    public Vector2 Direction { get; private set; }
    private Rigidbody2D rb;

    [SerializeField] Transform gunHandler;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        PlayerMovement();
    }
    public void PlayerMovement()
    {

        horizontalDir = Input.GetAxis("Horizontal");
        verticalDir = Input.GetAxis("Vertical");
        Direction = new Vector2(horizontalDir, verticalDir).normalized;
        rb.velocity = Direction * (speed + Time.deltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PickUp>())
        {
            var a = Instantiate(collision.gameObject,gunHandler);
            a.transform.position = gunHandler.transform.position;
            a.GetComponent<Gun>().enabled = true;
            a.GetComponent<SpriteRenderer>().enabled = false;
            a.layer = 7;
            a.GetComponent<BoxCollider2D>().enabled = false;

            a.transform.localScale = gunHandler.localScale;
            a.transform.localRotation = gunHandler.localRotation;
            a.transform.localPosition = gunHandler.localPosition;


            Destroy(collision.gameObject);
        }
    }
   


}

