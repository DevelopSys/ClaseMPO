using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{


    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("andando", true);
            gameObject.transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("andando", true);
            gameObject.transform.position = new Vector3(-1, 0, 0);
        }
        else
        {
            animator.SetBool("andando", false);
        }

    }

}
