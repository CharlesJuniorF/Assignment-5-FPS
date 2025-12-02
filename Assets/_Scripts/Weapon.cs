using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ammo = 180;
    public GameObject ProjPrefab;
    public Transform MuzzlePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo--;
            Instantiate(ProjPrefab, MuzzlePoint.position, MuzzlePoint.rotation);
        }
    }
}
