using UnityEngine;

public class ComportamientoCamara : MonoBehaviour
{
    [SerializeField] private AudioClip[] sonidos;
    [SerializeField] private Transform target;
    private AudioSource audioSourceComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSourceComponent = gameObject.GetComponent<AudioSource>();
        // que musica reproduces
        int posicion = new System.Random().Next(2);
        audioSourceComponent.clip = sonidos[posicion];
        audioSourceComponent.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
        // gameObject.transform.position = target.position;
    }
}
