using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    float speed;

    void Start()
    {
        SurfaceEffector2D groundEffector = GameObject.FindGameObjectWithTag("Ground").GetComponent<SurfaceEffector2D>();
        speed = groundEffector.speed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount * Time.deltaTime * speed);
        }
    }
}
