using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject target;
    public AudioClip background;
    public AudioSource musciSource;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3.0f && !musciSource.isPlaying)
        {
            musciSource.clip = background;
            musciSource.Play();
        }

        if(timer >= 20.0f)
        {
            musciSource.Stop();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }
}