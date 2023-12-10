using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float velocidadMovimiento;
    private int siguientePlataforma = 0;
    private int direccion = 1;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position, velocidadMovimiento * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            siguientePlataforma += direccion;

            if (siguientePlataforma >= puntosMovimiento.Length)
            {
                siguientePlataforma = puntosMovimiento.Length - 1;
                direccion = -1;
            }
            else if (siguientePlataforma < 0)
            {
                siguientePlataforma = 0;
                direccion = 1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
