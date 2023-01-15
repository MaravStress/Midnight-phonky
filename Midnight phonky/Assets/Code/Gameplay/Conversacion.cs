using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversacion : MonoBehaviour
{
    public float ShowTime = 2;
    public GameObject panel;
    public Image character;
    public TextMeshProUGUI txt;  
    [Header("cosas")]
    public Sprite[] personajes;
    public Idioma idioma;
    public conver[] conversacionesPredefinidas;
    [System.Serializable]
    public class conver{
        public string Contexto;
        public int personaje,idTxt;
    }
    public void Z_ShowPredefinidas(int i){
        panel.SetActive(true);
        character.sprite = personajes[conversacionesPredefinidas[i].personaje];
        txt.text =  idioma.Buscar_Mensaje_Traducido(conversacionesPredefinidas[i].idTxt);
        Invoke("Quitar",ShowTime);
    }
    public void ShowPersonalizadas(int personaje, int idTxt){
        panel.SetActive(true);
        character.sprite = personajes[personaje];
        txt.text =  idioma.Buscar_Mensaje_Traducido(idTxt);
        Invoke("Quitar",ShowTime);
    }
    public void Quitar(){
        panel.SetActive(false);
        
    }
}
