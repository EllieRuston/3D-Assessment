using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    Vector3 spawnPos;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] GameObject player;
     
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy Body"))
            {
                Respawn();
            }

            else if (collision.gameObject.CompareTag("Win"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
       
        }

    private void OnTriggerEnter(Collider other)
    {
                spawnPos = player.transform.position;
                Destroy(other.gameObject);
    }

     private void Respawn()
        {
            player.transform.position = spawnPos;
        }
   
}
