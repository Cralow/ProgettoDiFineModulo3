using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _gun;
    public int bDmg;
    [SerializeField] float force;

    private void Start()
    {
        Vector2 pos = _gun.GetComponent<Transform>().position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(pos * force, ForceMode2D.Impulse);
        Destroy( gameObject,5f);
    }


    
}
