using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    Collider2D playerHead;

    void Start() {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        EdgeCollider2D ground = other.gameObject.GetComponent<EdgeCollider2D>();
        bool isColidding = playerHead.IsTouching(ground); 
        bool isTheGround = other.gameObject.CompareTag("Ground");

        if(isTheGround && isColidding){
            SceneManager.LoadScene(0);
        }
    }
}
