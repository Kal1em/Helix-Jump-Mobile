using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       audioManager.Play("Bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //The ball hit the safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //The ball hit the unsafe area
            audioManager.Play("Game Over");
            GameManager.gameOver = true;
        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            //The ball hit the last ring
            audioManager.Play("Level Win");
            GameManager.levelCompleted = true;
        }
    }
}
