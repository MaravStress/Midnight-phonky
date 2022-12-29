using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brujula : MonoBehaviour
{

    public Transform player;

    public Scrollbar brujula;
    public Scrollbar punto;
    public GameObject fisico;


    void Update()
    {
        
        brujula.value = carculo(player);
        punto.value = carculo(transform);
    }
    float carculo(Transform p) {
        float angulo = p.rotation.normalized.eulerAngles.y;
        float carculo = (angulo / 360) + 0.5f;
        if (carculo > 1) carculo -= 1;

        return carculo;
    }
    
}
