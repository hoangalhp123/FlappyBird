using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float flapHeight = 8;
    public Rigidbody2D rb;
    private GameObject gameController;
    private GameObject obj;

    public AudioClip audioFlyClip;
    public AudioClip audioGameOverClip;
    private AudioSource audioSource;
    private bool isGameEnded;

    private Animator anim; 

    void Start()
    {
        obj = gameObject;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
        isGameEnded = false;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = audioFlyClip;

        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameEnded)
        {
            rb.velocity = new Vector2(rb.velocity.x, flapHeight);
            rb.isKinematic = false;
            audioSource.Play();
        }
        anim.SetFloat("flyPower", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetPoint();
    }

    void GetPoint()
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    void EndGame()
    {
        if (!isGameEnded)
        {
            audioSource.clip = audioGameOverClip;
            audioSource.Play();
        }
        isGameEnded = true;
        gameController.GetComponent<GameController>().EndGame();
        anim.SetBool("isDead", true);
    }
}
