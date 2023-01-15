using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_var_int : MonoBehaviour
{
    public int variable;

    public metodo method;
    public enum metodo
    {
        OneShot, Update, FixedUpdate
    }
    public List<acciones> actions;
    [System.Serializable]
    public class acciones
    {
        public metodo TheVariableIs;
        public enum metodo
        {
            greater, Less, same
        }
        public int than;
        public Button.ButtonClickedEvent action;

    }

    void comprovar() {
        foreach (var item in actions)
        {
            switch (item.TheVariableIs)
            {
                case acciones.metodo.greater:
                    if (variable > item.than) item.action.Invoke();
                    break;
                case acciones.metodo.Less:
                    if (variable < item.than) item.action.Invoke();
                    break;
                case acciones.metodo.same:
                    if (variable == item.than) item.action.Invoke();
                    break;
                default:
                    Debug.LogError("Reinstall asset");
                    break;
            }
        }
        
    }

    public void Add() {
        variable++;
        if (method == metodo.OneShot)
                comprovar();
    }
    public void Add(int i)
    {
        variable+= i;
        if (method == metodo.OneShot)
            comprovar();
    }


    public void subtraction()
    {
        variable--;
        if (method == metodo.OneShot)
            comprovar();
    }

    public void subtraction(int i)
    {
        variable-= i;
        if (method == metodo.OneShot)
            comprovar();
    }



    public void Same(int i)
    {
        variable = i;
        if (method == metodo.OneShot)
            comprovar();
    }




    void Update()
    {
        if (method == metodo.Update)
            comprovar();
    }
    void FixedUpdate()
    {
        if (method == metodo.FixedUpdate)
            comprovar();
    }
}





#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_var_int))]
    [CanEditMultipleObjects]
    public class Editor_Event_var_int : Editor
    {

        SerializedProperty variable, method, actions;

        void OnEnable()
        {

            variable = serializedObject.FindProperty("variable");
            method = serializedObject.FindProperty("method");
            actions = serializedObject.FindProperty("actions");

        }
        public override void OnInspectorGUI()
        {



            EditorGUILayout.PropertyField(variable);
            EditorGUILayout.PropertyField(method);


            EditorGUILayout.PropertyField(actions);

            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif