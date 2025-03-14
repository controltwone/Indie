using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagerScript : MonoBehaviour
{
    public float health;
    public bool isDead = false;
    public Transform bullet, muzzle, damageText, damageTextSection;

    public Slider slider;

    public float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }
    public void getDamage(float damage){

        Instantiate(damageText, damageTextSection.position, quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

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
            isDead = true;
        }
    }
    
    void shootBullet(){
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}
