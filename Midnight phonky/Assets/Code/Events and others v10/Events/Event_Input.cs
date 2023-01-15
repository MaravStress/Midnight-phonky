using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class Event_Input : MonoBehaviour
{

    [Tooltip("in: edit/proyect setting/input manager")] public string nombre_input;
    public fo forma;
    [System.Serializable]
    public enum fo
    {
        Down, UP, Continuo
    }

    public Button.ButtonClickedEvent action;
    public void z_Action() {
        action.Invoke();
    }

    void Update()
    {
        try
        {


            if (nombre_input != "")
                switch (forma)
                {
                    case fo.Down:
                        if (Input.GetButtonDown(nombre_input))
                        {

                            Comprovacion_y_ejecucion_de_acciones();
                            //   print("d");
                        }
                        break;
                    case fo.UP:
                        if (Input.GetButtonUp(nombre_input))
                        {
                            //   print("u");
                            Comprovacion_y_ejecucion_de_acciones();
                        }
                        break;
                    case fo.Continuo:
                        if (Input.GetButton(nombre_input))
                        {
                            //  print("c");
                            Comprovacion_y_ejecucion_de_acciones();
                        }
                        break;
                    default:
                        Debug.Log("¿Que fue lo que paso?");
                        break;
                }



            void Comprovacion_y_ejecucion_de_acciones()
            {
                z_Action();
            }
        }
        catch (System.Exception)
        {

        }
    }
}

#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Input))]
    [CanEditMultipleObjects]
    public class Editor_Evento_Input : Editor
    {

        SerializedProperty nombre_input, forma,Action;

        void OnEnable()
        {

            Action = serializedObject.FindProperty("action");
            nombre_input = serializedObject.FindProperty("nombre_input");
            forma = serializedObject.FindProperty("forma");

        }
        public override void OnInspectorGUI()
        {



            EditorGUILayout.PropertyField(nombre_input);
            EditorGUILayout.PropertyField(forma);


            EditorGUILayout.PropertyField(Action);

            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif
