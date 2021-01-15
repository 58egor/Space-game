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
    // Start is called before the first frame update
    void Start()
    {
        starShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal=Input.GetAxis("Horizontal");//����/�����
        moveVertical = Input.GetAxis("Vertical");//������/�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserShot, laserGun);
        }
    }
    private void FixedUpdate()
    {
        starShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        float clampedX = Mathf.Clamp(starShip.position.x, xMin, xMax);//������������ ������� �������,���� ��������� �� � ��������� ���������� ��� ��� ����
        float clampedZ = Mathf.Clamp(starShip.position.z, zMin, zMax);//������������ ������� �������,���� ��������� �� � ��������� ���������� ��� ��� ����
        starShip.position = new Vector3(clampedX, 0, clampedZ);
        starShip.rotation = Quaternion.Euler(starShip.velocity.z*rotationSpeed,0,-starShip.velocity.x*rotationSpeed);
    }
}
