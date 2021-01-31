using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carcontoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float carAcceleration;
    public Text resultText;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            carSpeed = carSpeed + carAcceleration * Time.deltaTime;
        }

        car.velocity = transform.up * carSpeed;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        timer += Time.deltaTime;

        if (timer >= 10.0f)
        {
            resultText.text = "You Failed!";
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            resultText.text = "Goal!";
            Destroy(this);
        }
    }
    

}
