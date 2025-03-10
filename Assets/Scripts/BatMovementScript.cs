using UnityEngine;

public class BatMovementScript : MonoBehaviour
{
   public float speed = 5f; // Uçuş hızı
    private Vector2 screenBounds; // Ekranın sınırlarını kontrol etmek için

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Eğer karakter ekranın sağından çıkarsa, tekrar sol tarafa geçir
        if (transform.position.x > screenBounds.x + 1)
        {
            transform.position = new Vector3(-screenBounds.x - 1, transform.position.y, transform.position.z);
        }
    }
}
