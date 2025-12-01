using UnityEngine;

public class ComportamientoPlataforma : MonoBehaviour
{

    private Rigidbody2D rigidbody2DComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2DComponent = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            rigidbody2DComponent.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
