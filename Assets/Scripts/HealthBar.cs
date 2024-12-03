using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float health;
    public float lerpSpeed = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        health = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().currentHealth;
        //health = GameObject.FindFirstObjectByType<EnemyHealth>().currentHealth;

        //Debug.Log("currentHealth" + health);

        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            health -= 20f;

            //takeDamage(20f);
        }

     
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
