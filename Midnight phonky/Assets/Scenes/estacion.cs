using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estacion : MonoBehaviour
{
    public SphereCollider colider;
    public MasterCarrera master;
    public int soy;
    public GameObject senal,flecha;
    private void OnTriggerEnter(Collider other) {
        
        foreach (var item in master.jugadores)
        {
            if(item.Player.CompareTag(other.tag)){
                master.Entro(item);
            }
        }
    }
}
