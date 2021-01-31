using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carcontoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float carAcceleration;
    public Text resultText;

    public AudioClip lightsOne;
    public AudioClip engine;
    public AudioClip cheer;
    public AudioClip boo;
    public AudioSource soundSource;

    private float carSpeed;
    private Rigidbody2D car;

    private float timer = 0f;



    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        resultText.text = "";
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3.0f && Input.GetKeyDown(KeyCode.Space))
        {
            carSpeed = carSpeed + carAcceleration * Time.deltaTime;
            soundSource.clip = engine;
            if(!soundSource.isPlaying)
            {
                soundSource.Play();
            }
            
        }

        car.velocity = transform.up * carSpeed;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        timer += Time.deltaTime;

        if (timer >= 11.0f)
        {
            resultText.text = "You Failed!";
            soundSource.clip = boo;
            soundSource.Play();
            Destroy(this);
        }

        if(timer >= 0.9f && timer <= 1.1f)
        {
            soundSource.clip = lightsOne;
            soundSource.Play();
        }

        if (timer >= 1.9f && timer <= 2.1f)
        {
            soundSource.clip = lightsOne;
            soundSource.Play();
        }

        if (timer >= 2.9f && timer <= 3.1f)
        {
            soundSource.clip = lightsOne;
            soundSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            resultText.text = "Goal!";
            soundSource.clip = cheer;
            soundSource.Play();
            Destroy(this);
        }
    }
    

}
