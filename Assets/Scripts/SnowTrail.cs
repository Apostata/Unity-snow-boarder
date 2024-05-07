using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    // Start is called before the first frame update
    SurfaceEffector2D groundEffector;
    [SerializeField] ParticleSystem snowTrail;

    void Start() {
        groundEffector = FindObjectOfType<SurfaceEffector2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        ParticleSystem.EmissionModule emission = snowTrail.emission;
        float spreadRate;
        if(groundEffector.speed > 15){
            spreadRate = groundEffector.speed * 10;
        }
        else if(groundEffector.speed > 5 && groundEffector.speed <= 15){
            spreadRate = groundEffector.speed;
        }
        else{
            spreadRate = groundEffector.speed * 0.5f;
        }

        emission.rateOverTime = spreadRate;
        snowTrail.Play();
    }

    void OnCollisionExit2D(Collision2D other) {
        snowTrail.Stop();
    }
}
