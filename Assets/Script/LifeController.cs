using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public bool isEnemy;
    [SerializeField] int maxLife;    

    

    [SerializeField]private int life;
    int danno;
    public ON_DEFEAT_BEHAVIOUR defeatBehaviour;


    private bool isTouchingPlayer = false;
    private bool isTouchingEnemy = false;
    private float attackCooldown = 1f;
    private float attackTimer = 0f;

    public AudioSource EnemyHittedSound;
    public AudioSource PlayerHittedSound;
    public AudioSource EnemyDeathSound;
    public AudioSource PlayerDeathSound;

    public enum ON_DEFEAT_BEHAVIOUR
    {
        NONE,
        DISABLE,
        DESTROY,
    }
    void Awake()
    {
        
        life = maxLife;

        Enemy e = GetComponent<Enemy>();
        if (e != null)
        {
            isEnemy = true;
        }
        else
        {
            PlayerController playerController = GetComponent<PlayerController>();
        }



    }
    public void SetHp(int hp)
    {
        life = hp;
        if (life <= 0)
        {

            defeatBehaviour = ON_DEFEAT_BEHAVIOUR.DESTROY;


            if(isEnemy)EnemyDeathSound.Play();
            if (!isEnemy) PlayerDeathSound.Play();



        }

    }
    public void AddHp(int amount)
    {
        if (life <= maxLife)
        {

            int hp = amount += life;
            SetHp(hp);
            if (!isEnemy&&defeatBehaviour==ON_DEFEAT_BEHAVIOUR.NONE)
            {
                PlayerHittedSound.Play();
               
            }
            if(isEnemy && defeatBehaviour == ON_DEFEAT_BEHAVIOUR.NONE)
            {
                EnemyHittedSound.Play();
            }

            
             
        }
       
      
    }
    public void Defeat()
    {
        switch (defeatBehaviour)
        {
            case ON_DEFEAT_BEHAVIOUR.NONE:
                break;

            case ON_DEFEAT_BEHAVIOUR.DESTROY:
               

                if (isEnemy)
                {

                   
                    gameObject.GetComponent<Enemy>().isAlive = false;
                    gameObject.GetComponent<Animator>().Play("DeathAnimTree");
                    Destroy(gameObject, 1f);
                }
                if (!isEnemy)
                {
                    
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    gameObject.GetComponent<Animator>().Play("DeathAnimTree");
                    Destroy(gameObject, 1f);

                }
                break;



        }
        }
    private void Update()
    {
        Defeat();
        if (isEnemy && isTouchingPlayer)
        {
            attackTimer -= Time.deltaTime;
    
            if (attackTimer <= 0f)
            {
                GetComponent<Animator>().Play("EnemyAttackTree");
                GetComponent<Enemy>().SwingAudioVSX();
                AddHp(-danno);
                attackTimer = attackCooldown;
            }
        }

        if (!isEnemy && isTouchingEnemy)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                GetComponent<Animator>().Play("PlayerHitTree");
                AddHp(-danno);
                attackTimer = attackCooldown;
            }
        }

       

       
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            isTouchingEnemy = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            isTouchingEnemy = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEnemy && collision.transform.tag=="Bullet")
        {
             danno = collision.gameObject.GetComponent<Bullet>().bDmg;
            Destroy(collision.gameObject);
            gameObject.GetComponent<Animator>().Play("EnemyHitted");
            AddHp(-danno);    
        }

        if (!isEnemy&& collision.transform.tag == "Enemy")
        {
            
             danno = collision.gameObject.GetComponent<Enemy>().danno;



            

        }
      

    }

}
