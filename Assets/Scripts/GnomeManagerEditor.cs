using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GnomeManager))]
public class GnomeManagerManagerEditor : Editor
{

    private GnomeManager gnomeManager;


    struct gnome{
        string name;
        int price;
        float damage;
    }

    private List<GnomeScriptableObject> gnomes;

    string path = "Assets/Resources/Gnomes";
     public override void OnInspectorGUI(){
         gnomeManager = (GnomeManager) target;
        

         if(GUILayout.Button("Load Gnomes!")){
            gnomes = new List<GnomeScriptableObject>();


             foreach (string file in System.IO.Directory.GetFiles(path))
            { 
                //gnomes = AssetDatabase.LoadAllAssetsAtPath(path);
                gnomes.Add(LoadAsset<GnomeScriptableObject>(path + "\file"));
            }
         }

        foreach (GnomeScriptableObject gnome in gnomeManager.gnomes){
            EditorGUILayout.BeginFoldoutHeaderGroup(true, gnome.gnomeName);
            EditorGUILayout.TextField(gnome.damage.ToString());
            EditorGUILayout.TextField(gnome.price.ToString());
            EditorGUILayout.EndFoldoutHeaderGroup();
         }



        EditorGUILayout.BeginFoldoutHeaderGroup(true, "Create New Gnome!");

        string gnomename = EditorGUILayout.TextField("");
        //EditorGUILayout.TextField(gnome.price.ToString());

        GUILayout.Button("Add Gnome!");
     }


     public void CreateNewGnome(){

     }


     T LoadAsset<T> ( string path ) where T : Object {
		return AssetDatabase.LoadAssetAtPath<T> ( path );
	}

	T CreateOrReplaceAsset<T> ( T asset, string path ) where T : Object {
		T existingAsset = AssetDatabase.LoadAssetAtPath<T> ( path );

		if ( existingAsset == null ) {
			AssetDatabase.CreateAsset ( asset, path );
			existingAsset = asset;
		} else {
			EditorUtility.CopySerialized ( asset, existingAsset );
		}

		return existingAsset;
	}
}


