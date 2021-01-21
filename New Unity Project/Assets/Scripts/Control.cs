using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject laserShot;
    public Transform laserGun;
    Rigidbody starShip;
    public float speed=10;
    public float rotationSpeed = 10;
    public float xMax, xMin, zMax, zMin;
    float moveHorizontal;//����/�����
    float moveVertical;//������/�����
    public float shotDelay;//�������� ����� ����������
    float nextShotTime;//������� ����� ����������
    // Start is called before the first frame update
    void Start()
    {
        starShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.isStarted)
        {
            return;
        }
        moveHorizontal =Input.GetAxis("Horizontal");//����/�����
        moveVertical = Input.GetAxis("Vertical");//������/�����
        if (nextShotTime>=shotDelay && Input.GetKey(KeyCode.Space)) 
        {
            Instantiate(laserShot, laserGun);
            nextShotTime = 0;
        }
        else
        {
            nextShotTime += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (!Controller.isStarted)
        {
            return;
        }
        starShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        float clampedX = Mathf.Clamp(starShip.position.x, xMin, xMax);//������������ ������� �������,���� ��������� �� � ��������� ���������� ��� ��� ����
        float clampedZ = Mathf.Clamp(starShip.position.z, zMin, zMax);//������������ ������� �������,���� ��������� �� � ��������� ���������� ��� ��� ����
        starShip.position = new Vector3(clampedX, 0, clampedZ);
        starShip.rotation = Quaternion.Euler(starShip.velocity.z*rotationSpeed,0,-starShip.velocity.x*rotationSpeed);
    }
}
