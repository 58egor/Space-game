using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmiterScript : MonoBehaviour
{
    public GameObject ast;
    public float minDelay, maxDelay;
    float nextLaunchTime;
    float timer;
    private void Start()
    {
        timer = 0;
        nextLaunchTime = Random.Range(minDelay, maxDelay);
    }
    // Update is called once per frame
    void Update()
    {
        if (!Controller.isStarted)
        {
            return;
        }
        if (timer >= nextLaunchTime)
        {
            float xSize = transform.localScale.x / 2;
            Vector3 asteroidPosition = new Vector3(
                Random.Range(-xSize, xSize),
                0,
                transform.position.z); 
            timer = 0;
            nextLaunchTime = Random.Range(minDelay, maxDelay);
            Instantiate(ast, asteroidPosition, Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
