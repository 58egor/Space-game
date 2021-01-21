using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject asteroidExplosion;
    public float rotation;
    public float maxSpeed,minSpeed;
    public float speed=60;
    float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = Random.Range(0.5f, 2f);
       Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        asteroid.velocity = new Vector3(0, 0, -speed/multiplier);
        transform.localScale *= multiplier;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "asteroid" || other.tag=="Deleter")
        {
            return;
        }
        if (other.tag == "Player")
        {
            GameObject newExplosion=Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            newExplosion.transform.localScale *= multiplier;
        }
        Controller.score += 10;
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
