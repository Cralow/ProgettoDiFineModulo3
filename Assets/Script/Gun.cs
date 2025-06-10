using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform bullet;
    [SerializeField] float weaponRange;
    public GameObject obj;





    [SerializeField] float fireRate;
    public float fireCoolDown;
    public AudioSource AudioSource;


    void Update()
    {
        fireCoolDown -= Time.deltaTime;

        if (fireCoolDown <= 0f)
        {
            Shoot();

            fireCoolDown = fireRate;



        }
    }
    void Shoot()
    {
        FindNearestEnemy();
        if (obj != null)
        {
             obj = FindNearestEnemy();

            var a = Instantiate(bullet,new Vector2(transform.position.x,transform.position.y),transform.rotation);
            a.GetComponent<Bullet>()._gun = obj;
            AudioSource.Play();
            
        }

    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] listaNemici = GameObject.FindGameObjectsWithTag("Enemy");



        if (listaNemici.Length > 0)
        {
            float distanzaAttuale;
            float distanza2 = 1000;


            foreach (GameObject go in listaNemici)
            {

                Vector3 diff = gameObject.transform.position - go.transform.position;
                distanzaAttuale = diff.magnitude;

                if (distanzaAttuale < distanza2 )
                {
                    if(distanzaAttuale < weaponRange)
                    {
                        distanza2 = distanzaAttuale;

                        obj = go;
                    }
                    else
                    {
                        obj = null;
                    }



                }





            }
        }


            return obj;


    }

}
