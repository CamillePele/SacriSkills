using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaserShooter : MonoBehaviour
{
    public Laser laserObject;

    private List<Laser> laserList = new List<Laser>();
    
    public float frequency = 1;
    public float offset = 0;
    
    private float timer = 0;
    private float offsetTimer;

    private void Start()
    {
        offsetTimer = offset;
    }


    private void Update()
    {
        if (offsetTimer <= 0)
        {
            timer += Time.deltaTime;
            if (timer >= frequency)
            {
                Laser shoot;
                List<Laser> disabled = laserList.AsEnumerable().Where(x => !x.gameObject.activeSelf).ToList();
                if (disabled.Count == 0)
                {
                    shoot = Instantiate(laserObject, transform.position, transform.rotation);
                    //shoot.transform.position = transform.position;
                    shoot.transform.parent = transform;
                }
                else
                {
                    shoot = disabled[0];
                    shoot.gameObject.SetActive(true);
                    shoot.transform.position = transform.position;
                }

                shoot.Init(transform.right * -1);
                laserList.Add(shoot);

                timer = 0;
            }
        }
        else
        {
            offsetTimer -= Time.deltaTime;
        }
    }
    
    
}
