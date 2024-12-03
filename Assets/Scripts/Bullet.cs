using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hiteEffect;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Destroy bullets after 2.5 sec
        if (timer > 2.5f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().currentHealth -= 20;
            //collision.gameObject.GetComponent<EnemyHealth>().damage(20);
            Debug.Log("Enemy hit!");
        }

        GameObject effect = Instantiate(hiteEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
}
