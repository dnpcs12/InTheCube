using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;

    private float firetime = 0.1f;
    public void Fire()
    {
        print("fire");
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
