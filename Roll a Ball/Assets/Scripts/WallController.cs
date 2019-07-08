using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
public float min = 0f;
public float max = 0f;

void Start () 
{
    min = transform.position.z;
    max = transform.position.z+14;
}
void Update () 
{
    transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time*2, max-min)+min);
}
}
