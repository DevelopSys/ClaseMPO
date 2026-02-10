using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    [SerializeField] private GameObject[] jugadores;
    [SerializeField] private TMP_Text textoNombre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject jugador = Instantiate(jugadores[PlayerPrefs.GetInt("contador")]);
        textoNombre.text = jugador.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>



}
