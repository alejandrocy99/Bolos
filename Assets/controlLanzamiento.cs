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
    //public GameObject pointZone;
    private SpringJoint2D bolaSpringJoint;
    public Rigidbody2D pivote;
    private bool estaArrastrando;
    private  int puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main;
        bola = GameObject.Find("Bola");
        bolaRB = bola.GetComponent<Rigidbody2D>();
        bolaSpringJoint = bola.GetComponent<SpringJoint2D>();
        bolaSpringJoint.connectedBody = pivote;
        estaArrastrando = false;
        //pointZone = GameObject.FindWithTag("pointzone");

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("puntuacion : " + puntuacion);

        if(bolaRB == null) return;
        //si no tocamos la pantalla
        if(!Touchscreen.current.primaryTouch.press.isPressed ){
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
    
    }


    public void LanzaBola(){
        if(estaArrastrando == false) {
            bolaRB.isKinematic = false;
        if(bola.transform.position.x > pivote.transform.position.x){
            bolaSpringJoint.enabled = false;
        }else{
            bolaSpringJoint.enabled = true;
        }
        
    }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "bolo"){
            Debug.Log("entro en la zona");
            puntuacion ++;

        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "bolo"){
            Debug.Log("salio de la zona");
            puntuacion --;
        }
    }
}
