using System;
using UnityEngine;

public class ComportamientoInicial : MonoBehaviour
{

    [SerializeField] private int numeroVidas = 5;
    [SerializeField] private int velocidad = 1, numeroDisparos = 5;
    [SerializeField] private Transform disparo, grupoDisparo;
    private bool estaSuelo = false;
    private Animator animatorComponent;
    private SpriteRenderer spriteRendererComponent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();

        /* Debug.Log("Iniciando script");
        Debug.Log("Tu numero de vidas es " + numeroVidas);
        Debug.Log("Iniciando el script de " + gameObject.name);
        Debug.Log("Iniciando el script de " + gameObject.tag);

        System.Random random = new System.Random();

        int aleatorio = random.Next(1, 5);
        transform.position = new Vector2(aleatorio, transform.position.y);
 */
        /* Saludar("Borja");
        Saludar("Maria");
        Saludar("Juan"); */
        /* if (EstaVivo(4))
        {
            Debug.Log("Aun vive");
        }
        else
        {
            Debug.Log("Esta muerto");
        } */
        // Debug.Log(IndicarEstado(4));
    }

    // Update is called once per frame
    void Update()
    {
        // las actualizaciones de la parte logica
        // Debug.Log("Ejecutando actualizaciones desde Update");
    }

    void FixedUpdate()
    {
        // actualizaciones graficas (UI)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // spriteRendererComponent.flipX = true;
            // Debug.Log("Tecla A pulsada correctamente");
            //numeroVidas = numeroVidas + 1;
            // numeroVidas++;
            gameObject.transform.position += new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            animatorComponent.SetBool("andando", true);
            if (gameObject.transform.localScale.x >= 0)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,
                gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // numeroVidas--;
            // spriteRendererComponent.flipX = false;
            gameObject.transform.position += new Vector3(1, 0, 0) * velocidad * Time.deltaTime;
            animatorComponent.SetBool("andando", true);
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,
                gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        else
        {
            animatorComponent.SetBool("andando", false);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (estaSuelo)
            {
                gameObject.transform.position += new Vector3(0, 16, 0) * (velocidad * 2) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            animatorComponent.SetTrigger("atacando");


            if (grupoDisparo.childCount < numeroDisparos)
            {
                Instantiate(disparo, gameObject.transform.position, Quaternion.identity, grupoDisparo);
            }


            // crear un sprite -> imagen

        }
        /* else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Debug.Log(numeroVidas);
            gameObject.transform.position += new Vector3(0, -1, 0) * velocidad * Time.deltaTime;

        } */
    }

    void Saludar(string nombre)
    {
        Debug.Log("Primer método llamado correctamete por " + nombre);
    }

    bool EstaVivo(int vida)
    {
        if (vida <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    string IndicarEstado(int vida)
    {
        if (vida <= 0)
        {
            return "Estas muerto";
        }
        else if (vida < 3)
        {
            return "Estas jodido";
        }
        else if (vida < 6)
        {
            return "Estas bien";
        }
        else
        {
            return "Estas perfecto";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Has colisionado con un enemigo");
            numeroVidas--;
            if (numeroVidas == 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.collider.tag == "Ground")
        {
            estaSuelo = true;
        }


    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            // Debug.Log("Ya no estas en el sueldo");
            estaSuelo = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "life")
        {
            numeroVidas = 5;
            Debug.Log("Has recolectado una vida");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "life")
        {
            Debug.Log("Has de la vida");
        }
    }

}
