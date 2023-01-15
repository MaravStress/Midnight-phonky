using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    
    public void z_Play_layer_0(string i) {
        animator.Play(i,0);    
    }
    public void z_Play_layer_1(string i)
    {
        animator.Play(i, 1);
    }
    public void z_Play_layer_2(string i)
    {
        animator.Play(i, 2);
    }

    public void z_Play_crosFade(string i)
    {
        animator.CrossFade(i, 0.3f);
    }

}


#if UNITY_EDITOR
[CustomEditor(typeof(AnimationControl))]
[CanEditMultipleObjects]
public class Editor_AnimationControl : Editor
{
    bool desplegado;


    SerializedProperty animator;
    void OnEnable()
    {
        animator = serializedObject.FindProperty("animator");
    }
    public override void OnInspectorGUI()
    {
       

        EditorGUILayout.PropertyField(animator);
       
        serializedObject.ApplyModifiedProperties();

    }


}
#endif
