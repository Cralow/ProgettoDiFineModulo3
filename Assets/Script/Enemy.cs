using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController playerTransform;
    [SerializeField] float speed;


    public int danno;
    private Animator anim;
    public bool isAlive = true;

    [SerializeField]private AudioSource swingAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindAnyObjectByType<PlayerController>();
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        EnemyAnimator();
    }

    public void SwingAudioVSX()
    {
        swingAudio.Play();
    }
    void EnemyMovement()
    {
        if (playerTransform != null&&isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.transform.position, speed * Time.deltaTime);
        }

    }

    private void EnemyAnimator()
    {
        Vector2 _direction = new Vector2(transform.position.x, transform.position.y);
        if (playerTransform != null)
        {
            Vector2 dir2 = _direction - new Vector2(playerTransform.transform.position.x, playerTransform.transform.position.y);
            anim.SetFloat("xDir", dir2.x);




        }



    }









}





