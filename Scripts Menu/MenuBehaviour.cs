using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputNombre;
    [SerializeField] private GameObject[] personajes;
    private int contador = 0;
    private GameObject personajeActual, personajeSeleccionado;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personajeActual = personajes[contador];
        personajeSeleccionado = Instantiate(personajeActual, new Vector3(0, 2, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SeleccinadoAnterior()
    {
        if (contador == 0)
        {
            contador = 2;
        }
        else
        {
            contador--;
        }

        EliminarSeleccionActual();
        personajeActual = personajes[contador];
        personajeSeleccionado = Instantiate(personajeActual, new Vector3(0, 2, 0), Quaternion.identity);

    }



    public void SeleccinadoSiguiente()
    {
        if (contador == 2)
        {
            contador = 0;
        }
        else
        {
            contador++;
        }
        EliminarSeleccionActual();
        personajeActual = personajes[contador];
        personajeSeleccionado = Instantiate(personajeActual, new Vector3(0, 2, 0), Quaternion.identity);
    }

    public void EliminarSeleccionActual()
    {
        Destroy(personajeSeleccionado);
    }

    public void ComenzarJuego()
    {
        /* Debug.Log("Boton comenzar pulsado");
        Debug.Log("El nombre seleccionado es " + inputNombre.text); */
        if (inputNombre.text.Length > 0)
        {
            DontDestroyOnLoad(personajeSeleccionado);
            PlayerPrefs.SetString("nombre", inputNombre.text);
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("No se han introducido nombres");
        }

    }
}

