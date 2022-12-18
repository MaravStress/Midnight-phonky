using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_ControlMoto : MonoBehaviour
{
    public Moto moto;
    public NavMeshAgent nav;

    public float rangoMax = 3,speed = 1, giro = 2;
    public Vector2 move;
    public void Destino(Vector3 punto) {
        nav.SetDestination(punto);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, nav.transform.position) > rangoMax)
            nav.transform.position = transform.position;
        
        move.x = Vector3.Cross(transform.forward, nav.transform.forward).y *10* giro;
        move.y = speed;//((180 - Vector3.Angle(transform.forward, nav.transform.forward))/360)*speed;
        moto.Muevete(move);
    }
}
