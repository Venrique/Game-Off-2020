using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParallaxBackground : MonoBehaviour
{
    public float parallaxSpeedFrente= 0.01f;
    public float parallaxSpeedMedio = 0.02f;
    public float parallaxSpeedAtras = 0.05f;
        
    public RawImage BackgroundMedio;
    public RawImage BackgroundAtras;

     public RawImage BackgroundFrente;


    void Update()
    {
        float finalSpeedFrente = parallaxSpeedFrente *Time.deltaTime;
        float finalSpeedMedio = parallaxSpeedMedio *Time.deltaTime;
        float finalSpeedAtras = parallaxSpeedAtras *Time.deltaTime;
         
        if(Input.GetKey(KeyCode.D)){

        BackgroundFrente.uvRect = new Rect(BackgroundFrente.uvRect.x + finalSpeedFrente,0f,1f,1f);
        BackgroundMedio.uvRect = new Rect(BackgroundMedio.uvRect.x + finalSpeedMedio,0f,1f,1f);
        BackgroundAtras.uvRect = new Rect(BackgroundAtras.uvRect.x + finalSpeedAtras,0f,1f,1f);
        
        }

        if(Input.GetKey(KeyCode.A)){
       
        BackgroundFrente.uvRect = new Rect((BackgroundFrente.uvRect.x - finalSpeedFrente),0f,1f,1f);
        BackgroundMedio.uvRect = new Rect((BackgroundMedio.uvRect.x -finalSpeedMedio),0f,1f,1f);

        BackgroundAtras.uvRect = new Rect((BackgroundAtras.uvRect.x - finalSpeedAtras),0f,1f,1f);
        }
    }
}
