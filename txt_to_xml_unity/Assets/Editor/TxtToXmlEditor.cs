using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TxtToXml))]
public class ObjectBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
        
		TxtToXml myScript = (TxtToXml)target;
		if(GUILayout.Button("TxtToXml"))
		{
			myScript.Convert();
		}
	}
}