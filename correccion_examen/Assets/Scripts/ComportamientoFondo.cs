using UnityEngine;

public class ComportamientoFondo : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        gameObject.transform.position = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
    }
}
