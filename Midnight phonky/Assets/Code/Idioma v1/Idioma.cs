using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new idioma config", menuName = "Idioma")]
public class Idioma : ScriptableObject
{
    string saveIdioma = "Idioma";

    [Header("Idiomas")]
    public ido idioma;
    [System.Serializable]
    public enum ido
    {
        Español, Ingles
    }
    [Tooltip("no motificar")] public TextAsset traduccionActual;
    [Tooltip("no motificar")] public List<Trans> varTranslate;



    #region  Cosas de las traducciones

    public void Cambiar_Idioma_esp_ing(string leng)
    {
  
        switch (leng)
        {
            case "esp":
                idioma = ido.Español;
                PlayerPrefs.SetString(saveIdioma,"esp");
                break;
            default:
                idioma = ido.Ingles;
                PlayerPrefs.SetString(saveIdioma,"ing");
                break;
        }
    }
   
    
    public string Buscar_Mensaje_Traducido(int id)
    {

        switch (idioma)
        {
            case ido.Español:

                for (int i = 0; i < varTranslate.Count; i++)
                {
                    if (varTranslate[i].id == id ) {
                       // Debug.Log(varTranslate[i].esp);
                        return varTranslate[i].esp;
                        
                    }
                }
                return "";
                

            case ido.Ingles:

                for (int i = 0; i < varTranslate.Count; i++)
                {
                    if (varTranslate[i].id == id)
                    {
                        return varTranslate[i].ing;
                    }
                }
                return "";

            default:
                Debug.LogError("Idioma no encontrado");
                return "hola mundo OwO";

        }
    }
    public void cargarTraduccion(TextAsset translate)
    {
        Cambiar_Idioma_esp_ing(PlayerPrefs.GetString(saveIdioma,"ing"));
        varTranslate.Clear();
        traduccionActual = translate;
        char celda = '☺', fila = '☻';

        string nivel_a = translate.text.ToString(System.Globalization.CultureInfo.InvariantCulture).Replace(';', celda).Replace('\n',fila);

        //Debug.Log(nivel_a);

        string[] filas_string = nivel_a.Split(fila);
        foreach (var item in filas_string)
        {
            string[] celdas = item.Split(celda);
            Trans t = new Trans();
            try
            {

                t.id = Convert.ToInt32(celdas[0]);
                t.esp = celdas[1];
                t.ing = celdas[2];
                varTranslate.Add(t);

            }
            catch (Exception)
            {

            }

        }
    }

        #endregion

}



//     idioma

[System.Serializable]
public class Trans
{
    
    public int id;
    public string esp;
    public string ing;
}

