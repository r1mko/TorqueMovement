using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;
    //[SerializeField] private GameObject vehicle;
    public GameManager GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.PlayPopSound();
            GameObject explosion = Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 0.75f);
            GameManager.targetsCount--;
           // vehicle.transform.localScale = new Vector3(vehicle.transform.localScale.x + 0.025f, vehicle.transform.localScale.y + 0.025f, vehicle.transform.localScale.z);

        }
    }
}
