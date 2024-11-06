using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cauldron : MonoBehaviour
{
    public float totalObject = 0;
    private string totalObjectText; 
    public ParticleSystem particles;
    public TMP_Text points;
    public AudioSource audioSource;

    private void Start()
    {
        totalObject = 0;
        totalObjectText = totalObject.ToString();
        points.text = "Points = " + totalObjectText; 
    }

    private void Update()
    {
        if (totalObject == 10) 
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        
        Destroy(other.gameObject);
        totalObject++;
        particles.Play();
        totalObjectText = totalObject.ToString();
        points.text = "Points = " + totalObjectText; 
    }
}