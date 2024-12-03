using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemyHealth;
    public float maxHealth = 100f;
    public float currentHealth;
    public Component component;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // component = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthBar>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("currentHealth " + currentHealth);

        if (currentHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Debug.Log(gameObject.name + " has been destroyed!");
        Destroy(gameObject);

        //Add effect when enemies dies
        //Instantatiet
    }

    public void damage(float damage)
    {
        currentHealth -= damage;
      //  enemyHealth.GetComponent<HealthBar>().health -= damage;
    }
}
