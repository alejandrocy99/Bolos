using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class controlLanzamiento : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed){
            return;
        }

        Debug.Log("presionado");
        //¿donde se a pulsado?
        Vector2 posicion = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log("posicion" + posicion);
        //screentoworlspoint
    }
}
