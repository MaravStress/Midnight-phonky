using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGame : MonoBehaviour
{
    public player[] jugadores;
    public GameObject[] Carreras;
    public GameObject CarreraActual;
    public Brujula brujula;
    [Header("Cosas dentro de carrea")]
    public int contador = 3;
    public bool contando;
    [Range(0,1)]
    public float ventaja = 3;

    private void Start()
    {
        brujula.dejarDeIr();
    }
    public void termino(){
        Destroy(CarreraActual);
        foreach (var item in jugadores)
        {
            item.estaciones  = 0;
            item.posicion = 0;
        }
        brujula.dejarDeIr();
    }
    public void z_iniciar_Carrara(int i){
        if(CarreraActual != null){
            Debug.LogError("Ya hay una carrera activa, esto no deberia de salir. Doble click para llorar");
            return;
        } 
        CarreraActual = Instantiate(Carreras[i],Vector3.zero,Quaternion.Euler(0,0,0));
        MasterCarrera mc = CarreraActual.GetComponent<MasterCarrera>();
        mc.MG = this.gameObject.GetComponent<MasterGame>(); 

        contando = true;
        Invoke("inicio",contador);
    }
    private void Update() {
        if(!contando) return;

        foreach (var item in jugadores)
        {
            Moto m = item.Player.GetComponent<Moto>(); 
            m.activo = false;
            m.rg.velocity = new Vector3(0,m.rg.velocity.y,0);
            m.rg.rotation = Quaternion.Euler(0,0,0);
            MasterCarrera c = CarreraActual.GetComponent<MasterCarrera>();
            if(c.estaciones.Length>0)m.transform.LookAt(c.estaciones[0].gameObject.transform.position);
            
        }
    

    }
    void inicio(){
        contando = false;
        foreach (var item in jugadores)
        {
            item.Player.GetComponent<Moto>().activo = true;
        }
       
    }
}
[System.Serializable]
    public class player{
        public GameObject Player;
        public int estaciones;
        public IA_ControlMoto IA;
        public Transform ir;
        public int posicion;
    }