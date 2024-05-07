using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 5f;
    SurfaceEffector2D groundEffector;
    float speed;
    float baseSpeed;
    bool canMove = true;

    void Start()
    {

        groundEffector = FindObjectOfType<SurfaceEffector2D>();
        speed = groundEffector.speed;
        baseSpeed = groundEffector.speed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void DisablePlayerController (){
        canMove = false;
    }

    void RotatePlayer(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount * Time.deltaTime * speed);
        }
    }

    void BoostPlayer(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            groundEffector.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            groundEffector.speed = slowSpeed;
        }
        else{
            groundEffector.speed = baseSpeed;
        }
        
    }

    void stopMoving(){
        groundEffector.speed = 0;
    }

    void Update()
    {
        if(canMove){
            RotatePlayer();
            BoostPlayer();
        } else {
            stopMoving();
        }
    }
}
