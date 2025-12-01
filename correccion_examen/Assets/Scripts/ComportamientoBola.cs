using UnityEngine;

public class ComportamientoBola : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool direccion; // true > false <
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (direccion)
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * 10f * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= new Vector3(1, 0, 0) * 10f * Time.deltaTime;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDireccion(bool direccion)
    {
        this.direccion = direccion;
    }
}
