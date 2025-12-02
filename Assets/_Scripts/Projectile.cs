using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if this is an enemy
        //if it is notify damage rating
        Enemy hitEnemy = collision.gameObject.GetComponent<Enemy>();
        
        if (hitEnemy != null)
        {
            hitEnemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
