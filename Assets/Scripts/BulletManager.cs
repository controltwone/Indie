using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
            
        
    }

    void Update()
    {
        
    }
}
