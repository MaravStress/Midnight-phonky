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
    }
    private void OnDrawGizmos() {
        // Start();
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
