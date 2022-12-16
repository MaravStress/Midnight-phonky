using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_ControlMoto : MonoBehaviour
{
    public Moto moto;
    public NavMeshAgent nav;

    public float rangoMax = 3;
    public Vector3 move;
    public void Destino(Vector3 punto) {
        nav.SetDestination(punto);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, nav.transform.position) > rangoMax)
            nav.transform.position = transform.position;
        
        move = Vector3.Lerp(transform.forward , nav.transform.forward, 0.1f);
        moto.Muevete(new Vector2(move.x, move.z));
    }
}
