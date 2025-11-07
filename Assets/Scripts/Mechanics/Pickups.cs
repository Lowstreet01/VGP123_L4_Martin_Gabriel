using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickups : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
            {
            Destroy(gameObject);
        } 
    }

}
