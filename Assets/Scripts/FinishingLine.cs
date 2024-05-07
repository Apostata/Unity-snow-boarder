using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingLine : MonoBehaviour
{
    Collider2D finishLine;
    [SerializeField] float timeToReload = 1f; // 1
    [SerializeField] ParticleSystem fireWorks;


    void Start() {
        finishLine = GetComponent<BoxCollider2D>();
    }
   void OnTriggerEnter2D(Collider2D other) {   
    AudioSource audioSource = GetComponent<AudioSource>();     
    bool isPlayer = other.CompareTag("Player");
    CircleCollider2D playerHead = other.GetComponent<CircleCollider2D>();
    bool isColidding = playerHead.IsTouching(finishLine);

        if(isPlayer && isColidding){
            audioSource.Play();
            fireWorks.Play();
            Invoke("ReloadScene", timeToReload);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
