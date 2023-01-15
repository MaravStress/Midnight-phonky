using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Simple : MonoBehaviour
{
    public Button.ButtonClickedEvent  action;
    public void z_Action()
    {
        action.Invoke();
    }
}

#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Simple))]
    [CanEditMultipleObjects]
    public class Editor_evento_Simple : Editor
    {
        SerializedProperty action;



        void OnEnable()
        {

            action = serializedObject.FindProperty("action");
        }
        public override void OnInspectorGUI()
        {

            EditorGUILayout.PropertyField(action);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif
