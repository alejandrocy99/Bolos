using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class controlLanzamiento : MonoBehaviour
{
    private Camera camara;
    public GameObject bola;
    private Rigidbody2D bolaRB ;

    private SpringJoint2D bolaSpringJoint;
    public Rigidbody2D pivote;
    private bool estaArrastrando;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main;
        bolaRB = bola.GetComponent<Rigidbody2D>();
        bolaSpringJoint = bola.GetComponent<SpringJoint2D>();
        bolaSpringJoint.connectedBody = pivote;
        estaArrastrando = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(bolaRB == null) return;
        //si no tocamos la pantalla
        if(!Touchscreen.current.primaryTouch.press.isPressed && !estaArrastrando){
            return;
        }
        else if(!Touchscreen.current.primaryTouch.press.isPressed && estaArrastrando){
            estaArrastrando = false;
            LanzaBola();
        
        }

        if(Touchscreen.current.primaryTouch.press.isPressed ){
            estaArrastrando = true;
            bolaRB.isKinematic = true;
            Vector2 nuevaPosicion = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 d = camara.ScreenToWorldPoint(nuevaPosicion);
            d.z = 0;
            bola.transform.position = d; 
            LanzaBola();
        }


        
        
    

        Debug.Log("presionado");
        //¿donde se a pulsado?
        Vector2 posicion = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log("posicion" + posicion);  
        Vector3 posicionGlobal = camara.ScreenToWorldPoint(posicion); 
         //screentoworlspoint
    }


    public void LanzaBola(){
        bolaRB.isKinematic = false;
        //if(bola.transform.position.x > pivote.transform.position.x){
            bolaSpringJoint.enabled = false;
        //}
    }
}
