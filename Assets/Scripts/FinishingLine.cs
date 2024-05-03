using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingLine : MonoBehaviour
{
    Collider2D finishLine;

    void Start() {
        finishLine = GetComponent<BoxCollider2D>();
    }
   void OnTriggerEnter2D(Collider2D other) {        
    bool isPlayer = other.CompareTag("Player");
    CircleCollider2D playerHead = other.GetComponent<CircleCollider2D>();
    bool isColidding = playerHead.IsTouching(finishLine);

        if(isPlayer && isColidding){
            Debug.Log("Player has reached the finish line!");
            SceneManager.LoadScene(0);
        }
    }
}
