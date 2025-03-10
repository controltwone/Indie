using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerScript : MonoBehaviour
{
    public float health;
    public float damage;

    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

        collision.GetComponent<PlayerManagerScript>().getDamage(damage);
        
        }

        else if(collision.tag == "Bullet"){
            getDamage(collision.GetComponent<BulletManager>().bulletDamage);
            Destroy(collision.gameObject);
        }
    }

    public void getDamage(float damage){
        if(health - damage > 0)
        {
            health -= damage;
            slider.value = health;
        }
        else
        {
            health = 0;
            Debug.Log("you are dead!");
        }
        amIDead();
    }
    
    public void amIDead(){
        if(health == 0)
        {
           Destroy(gameObject);
        }
    }
}
