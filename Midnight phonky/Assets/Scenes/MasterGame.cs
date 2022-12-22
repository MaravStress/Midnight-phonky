using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGame : MonoBehaviour
{
    public player[] jugadores;
    public GameObject[] Carreras;
    public GameObject CarreraActual;
    public void termino(){
        Destroy(CarreraActual);
        foreach (var item in jugadores)
        {
            item.estaciones  = 0;
            item.posicion = 0;
        }
    }
    public void z_iniciar_Carrara(int i){
        if(CarreraActual != null){
            Debug.LogError("Ya hay una carrera activa, esto no deberia de salir. Doble click para llorar");
            return;
        } 
        CarreraActual = Instantiate(Carreras[i],Vector3.zero,Quaternion.Euler(0,0,0));
        MasterCarrera mc = CarreraActual.GetComponent<MasterCarrera>();
        mc.MG = this.gameObject.GetComponent<MasterGame>(); 
        mc.jugadores = jugadores;
    }
}
