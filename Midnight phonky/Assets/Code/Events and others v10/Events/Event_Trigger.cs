using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Event_Trigger : MonoBehaviour
{
    
    public qui Quien;
    [System.Serializable]
      public enum qui
    {
        Tag, No_Tag,Todos
    }


    public mo Modo;
    [System.Serializable]
    public enum mo
    {
        Enter, stay, exit
    }

    public string Tag = "Player";

    public Button.ButtonClickedEvent action;

    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    // ///////////////////////////////////////////////////////////////////////////////////////////////////////



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Modo == mo.Enter )
        {
            toto(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Modo == mo.exit  )
        {
            toto(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Modo == mo.stay  )
        {
            toto(collision);
        }
    }
    

    // ///////////////////////////////////////////////////////////////////////////////////////////////////////



    void toto(Collider2D collision) {
        switch (Quien)
        {
           
            case qui.No_Tag:

                if (collision.tag != Tag)
                {
                    z_Action();
                }

                break;

            case qui.Tag:
                if (collision.tag == Tag)
                {
                    z_Action();
                }
                break;

            default:
                z_Action();
                break;
        }
    }
   
    public void z_Action() {
        action.Invoke();
    }
    

}
















#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Trigger))]
    [CanEditMultipleObjects]
    public class Editor_Evento_Trigger : Editor
    {


        SerializedProperty Quien, Modo, Tag, Action;

        void OnEnable()
        {

            Action = serializedObject.FindProperty("action");
            Quien = serializedObject.FindProperty("Quien");
            Modo = serializedObject.FindProperty("Modo");
            Tag = serializedObject.FindProperty("Tag");

        }
        public override void OnInspectorGUI()
        {

            EditorGUILayout.PropertyField(Quien);
            EditorGUILayout.PropertyField(Modo);
            
            EditorGUILayout.PropertyField(Tag);


            EditorGUILayout.PropertyField(Action);

            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif

