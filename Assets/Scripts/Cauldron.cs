using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public float totalObject = 0;
    private void Start()
    {
        totalObject = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        
        Destroy(other.gameObject);
        totalObject ++;
    }
}
