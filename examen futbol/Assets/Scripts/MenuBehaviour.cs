using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{

    [SerializeField] private TMP_Text textoJugador;
    private int contador = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButonJ1()
    {
        textoJugador.text = "Jugador 1";
        contador = 0;
    }

    public void ButonJ2()
    {
        textoJugador.text = "Jugador 2";
        contador = 1;
    }

    public void ButonComenzar()
    {
        PlayerPrefs.SetInt("contador", contador);
        SceneManager.LoadScene(1);
    }
}
