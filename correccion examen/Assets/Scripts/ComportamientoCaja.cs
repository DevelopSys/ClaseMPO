using UnityEngine;

public class ComportamientoCaja : MonoBehaviour
{


    private Animator animatorComponent;
    private int vidas = 5;
    void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Debug.Log("Triiger detectado");
            Destroy(collision.gameObject);
            vidas--;
            if (vidas == 0)
            {
                animatorComponent.SetTrigger("roto");
                Destroy(gameObject, 1);
            }
        }
    }
}
