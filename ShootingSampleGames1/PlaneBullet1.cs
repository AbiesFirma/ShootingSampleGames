using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBullet1 : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody rb;

    [SerializeField] ParticleSystem hitParticlePrefab;

    AudioSource audioSouce;
    //[SerializeField] AudioClip ac;

    //[SerializeField] GameObject wall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 vel = transform.forward * speed;

        rb.AddForce(vel, ForceMode.VelocityChange);
        audioSouce = GetComponent<AudioSource>();
        audioSouce.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(hitParticlePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(hitParticlePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
