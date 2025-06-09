using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController controller;
    private Vector2 _direction;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<PlayerController>();


    }
    private void Update()
    {
        PlayerAnim();



    }

    private void PlayerAnim()
    {
      _direction = new Vector2(controller.Direction.x, controller.Direction.y).normalized;
        //horizontalll management
        if (_direction.x != 0)
        {
            anim.SetFloat("xDir", controller.Direction.x);
        }
        else anim.SetFloat("xDir", 0f);




        //verticalll managemnt

        if (_direction.y != 0)
        {
            anim.SetFloat("yDir", controller.Direction.y);
        }else anim.SetFloat("yDir", 0);


    }







}
