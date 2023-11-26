using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public HUD hud;
    public PlayerMovement Jugador;

    public void sumarPuntos(int puntosASumar)
    {
        puntosTotales = puntosTotales + puntosASumar;
        hud.ActualizarPuntos(puntosTotales);
    }
}
