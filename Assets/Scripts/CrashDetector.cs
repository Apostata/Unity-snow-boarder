using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    Collider2D playerHead;
    [SerializeField] float timeToReload = 0.5f; // 1
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    
    bool hasCrashed = false;
    
    void Start() {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EdgeCollider2D ground = other.gameObject.GetComponent<EdgeCollider2D>();

        bool isColidding = playerHead.IsTouching(ground); 
        bool isTheGround = other.gameObject.CompareTag("Ground");

        if(isTheGround && isColidding && !hasCrashed){
            hasCrashed = true;
            GetComponent<PlayerController>().DisablePlayerController();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            crashEffect.Play();
            Invoke("ReloadScene", timeToReload);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
