using UnityEngine;

public class ComportamientoPlayer : MonoBehaviour
{

    private Animator animator;
    private bool estaSuelo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale =
                new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            gameObject.transform.position -= new Vector3(1, 0, 0) * 2f * Time.deltaTime;
            animator.SetBool("andando", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale =
                new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            gameObject.transform.position += new Vector3(1, 0, 0) * 2f * Time.deltaTime;
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        if (Input.GetKey(KeyCode.W))
        {

            // gameObject.transform.position += new Vector3(0, 5, 0) * 2f * Time.deltaTime;
            if (estaSuelo)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Reward")
        {
            animator.SetTrigger("golpeado");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            estaSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            estaSuelo = false;
        }
    }
}
