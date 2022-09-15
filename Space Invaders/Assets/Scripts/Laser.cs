using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
public GameObject shotSpawn;
public GameObject shot;
float shotInterval = 0.7f;
float shotInstantiateTime = 0;  
//Script para o input do tiro do jogador e o cooldown dele.  
private void Update()
{
    if(Input.GetKey(KeyCode.Mouse0))
    {
        if (Time.time > shotInstantiateTime)
        {
        Instantiate(shot, shotSpawn.transform.position, transform.rotation);
        shotInstantiateTime = Time.time + shotInterval;
        }
    }
 
}
}
