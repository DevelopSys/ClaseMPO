using TMPro;
using UnityEngine;

public class ComportamientoCaja : MonoBehaviour
{


    private Animator animatorComponent;
    private AudioSource audioSourceComponent;
    private int vidas = 5;
    [SerializeField] private TMP_Text textoTMP;
    void Start()
    {
        textoTMP.text = vidas.ToString();
        animatorComponent = gameObject.GetComponent<Animator>();
        audioSourceComponent = gameObject.GetComponent<AudioSource>();
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
            textoTMP.text = vidas.ToString();
            if (vidas == 0)
            {
                audioSourceComponent.Play();
                animatorComponent.SetTrigger("roto");
                Destroy(gameObject, 1);
                textoTMP.enabled = false;
            }
        }
    }
}
