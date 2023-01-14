using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brujula : MonoBehaviour
{

    public Transform player, ir;

    public Scrollbar brujula;
    public Scrollbar punto;
    public GameObject fisico;


    void LateUpdate()
    {
        
        brujula.value = carculo(player);

        if (ir != null)
        {
            transform.LookAt(ir);
            punto.value = carculo(transform);
        }
    }
    public void Ir(Transform t) {
        ir = t;
        fisico.SetActive(true);
        punto.gameObject.SetActive(true);
    }
    public void dejarDeIr()
    {
        fisico.SetActive(false);
        punto.gameObject.SetActive(false);
        ir = null;
    }
    float carculo(Transform p) {
        float angulo = p.rotation.normalized.eulerAngles.y;
        float carculo = (angulo / 360) + 0.5f;
        if (carculo > 1) carculo -= 1;

        return carculo;
    }
    
}
