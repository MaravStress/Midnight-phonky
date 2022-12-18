using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterCarrera : MonoBehaviour
{
    [System.Serializable]
    public class player{
        public GameObject Player;
        public int estaciones;
        public IA_ControlMoto IA;
        public int posicion;
    }
    public player[] jugadores;
    public estacion[] estaciones;
    
    public float radio;
    [Header("evetos")]
    public UnityEvent termina;
    void Start() {
        estaciones = GetComponentsInChildren<estacion>();
        estaciones = GetComponentsInChildren<estacion>();
        foreach (var item in estaciones)
        {
            item.colider = item.GetComponent<SphereCollider>();
            item.master = GetComponent<MasterCarrera>();
            item.colider.radius = radio;
            item.colider.isTrigger = true;
        }
        foreach (var item in jugadores)
        {
            if (item.IA != null) {
                item.IA.Destino(estaciones[0].transform.position);
            }
        }
        InvokeRepeating("posicion",0.1f,0.1f);
    }
    public void posicion(){    
    // ordena por estaciones
            int esDispo = 1;
           
            for (int i = estaciones.Length; i >= 0; i--)
            {
                 bool ubo = false;
                foreach (var item in jugadores)
                {
                    if(item.estaciones == i){
                        item.posicion = esDispo;
                        ubo = true;
                    }

                }
                if(ubo){
                    esDispo ++;
                }
            }
    // ordena por distancia
        foreach (var item in jugadores)
        {
           
            foreach (var item2 in jugadores)
            {
                if(item.posicion == item2.posicion && item.Player != item2.Player){
                    if(distancia(item) > distancia(item2)){
                        Debug.Log(item.ToString());
                        item.posicion ++;

                    }else{
                        item2.posicion++;
                    }
                    
                }
            }
           
        }
    }

    public float distancia(player p){
     return Vector3.Distance(p.Player.transform.position,estaciones[p.estaciones].transform.position) ;
    }
    public void Entro(player p){
        //Debug.Log("entro");
        if(p.estaciones >=  estaciones.Length-1){
            if(p.IA == null) termina.Invoke();
            return;
        }
        if(Vector3.Distance(p.Player.transform.position,estaciones[p.estaciones].transform.position) < (radio*2)){
                p.estaciones ++;
            if (p.IA != null){
                p.IA.Destino(estaciones[p.estaciones].transform.position);
            }
        }
        

    }
    
}
