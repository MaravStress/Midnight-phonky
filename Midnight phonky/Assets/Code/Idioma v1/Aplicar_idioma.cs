using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Aplicar_idioma : MonoBehaviour
{
    public Idioma confi;
    public int id;
    public bool esUnTexto;

    [Header("El texto")]
    public Text text;
    public TextMeshPro textMesh;
    public TextMeshProUGUI textMeshGUI;
    void Awake()
    {
    if(id != 0 ){
        string mensaje = confi.Buscar_Mensaje_Traducido(id);

        if (esUnTexto)
        {
            if (text != null) text.text = " ";
            if (textMeshGUI != null) textMeshGUI.text = " ";
            if (textMesh != null) textMesh.text = " ";


            string[] lineas = mensaje.Split('.');
            foreach (var item in lineas)
            {
               
                if (text != null) text.text += item +" "+ '\n';
                if (textMeshGUI != null) textMeshGUI.text += item + " " + '\n';
                if (textMesh != null) textMesh.text +=  item + " " + '\n';

            }

        }
        else {
            if (text != null) text.text = mensaje;
            if (textMeshGUI != null) textMeshGUI.text = mensaje;
            if (textMesh != null) textMesh.text = mensaje;
        
        }
    }
    }


    public string Cambiar_mensaje(int idAdd)
    {
       //Debug.Log("cambio mensaje: 1");
        
        string mensaje = confi.Buscar_Mensaje_Traducido(idAdd);
        
        //Debug.Log("cambio mensaje: 2");

        if (text != null) text.text = mensaje;
        if (textMeshGUI != null) textMeshGUI.text = mensaje;
        if (textMesh != null) textMesh.text = mensaje;

        //Debug.Log("cambio mensaje: 3 :"+ mensaje);

        return mensaje;
    }
    public void Z_Cambiar_mensaje(int idAdd)
    {
       //Debug.Log("cambio mensaje: 1");
        
        string mensaje = confi.Buscar_Mensaje_Traducido(idAdd);
        
        //Debug.Log("cambio mensaje: 2");

        if (text != null) text.text = mensaje;
        if (textMeshGUI != null) textMeshGUI.text = mensaje;
        if (textMesh != null) textMesh.text = mensaje;

        
    }

    public string sumar_mensaje(int idAdd) {
        string mensaje = confi.Buscar_Mensaje_Traducido(idAdd);

        if (text != null) text.text +='\n' + " "+ mensaje;
        if (textMeshGUI != null) textMeshGUI.text += '\n' + " " + mensaje;
        if (textMesh != null) textMesh.text += '\n' + " " + mensaje;
        return mensaje;
    }

    public void dos_carta_mensaje(int A, int B)
    {
        Cambiar_mensaje(A);
        sumar_mensaje(B);
      //  Debug.Log("sumó");
    }
}
