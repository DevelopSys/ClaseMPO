using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoPlayer : MonoBehaviour
{
    private AudioSource audioSourceComponent;
    private bool estaSuelo = true;
    private Animator animatorComponent;
    [SerializeField] private AudioClip[] audios;

    [SerializeField] Transform disparo;
    [SerializeField] Transform disparos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
        audioSourceComponent = gameObject.GetComponent<AudioSource>();
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
                gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            }
            gameObject.transform.position += new Vector3(-1, gameObject.transform.position.y) * 2f * Time.deltaTime;
            animatorComponent.SetBool("andando", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            }
            gameObject.transform.position += new Vector3(1, gameObject.transform.position.y) * 2f * Time.deltaTime;
            animatorComponent.SetBool("andando", true);
        }
        else
        {
            animatorComponent.SetBool("andando", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            // gameObject.transform.position += new Vector3(transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z) * 2f * Time.deltaTime;
            if (estaSuelo)
            {
                audioSourceComponent.clip = audios[0];
                audioSourceComponent.Play();
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (disparos.childCount < 10)
            {
                audioSourceComponent.clip = audios[1];
                audioSourceComponent.Play();
                // disparo.GetComponent<ComportamientoBola>().SetDireccion(gameObject.transform.localScale.x > 0);
                Transform objeto = Instantiate(disparo, gameObject.transform.position, Quaternion.identity, disparos);
                objeto.GetComponent<ComportamientoBola>().SetDireccion(gameObject.transform.localScale.x > 0);

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            estaSuelo = true;
        }
        else if (collision.collider.tag == "Finish")
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            estaSuelo = false;
        }
    }

    public void ReproducirPisada()
    {
        audioSourceComponent.clip = audios[2];
        audioSourceComponent.Play();
    }
}
