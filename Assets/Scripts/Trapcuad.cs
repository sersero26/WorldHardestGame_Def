using System;
using Unity.VisualScripting;
using UnityEngine;

public class Trapcuad : MonoBehaviour
{
   [SerializeField] private float velocidad;
   [SerializeField] Vector3 direccionInicial;
   [SerializeField] float tiempoA;
   private Vector3 direcciónActual;
   private float timer;
   private int direccion = 1;
    void Start()
    {
       direcciónActual = direccionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
            transform.Translate(direcciónActual * velocidad * Time.deltaTime);
            if (timer >= tiempoA)
            {
                if (direccion == 1)
                {
                    direcciónActual = new Vector3(0, 1, 0);
                    direccion++;
                    timer = 0;
                }
                else if (direccion == 2)
                {
                    direcciónActual = -direccionInicial;
                    direccion++;
                    timer = 0;
                }
                else if (direccion == 3)
                {
                    direcciónActual = new Vector3(0, -1, 0);
                    direccion++;
                    timer = 0;
                }
                else
                {
                    direcciónActual = direccionInicial;
                    direccion = 1;
                    timer = 0;
                }
            }
       
    }
     
}
