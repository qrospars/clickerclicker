using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(GnomeManager))]
public class GnomeManagerManagerEditor : Editor
{

    private GnomeManager gnomeManager;


    struct gnome{
        public string name;
        public int price;
        public float damage;
    }

    private gnome templateGnome;

    private List<GnomeScriptableObject> gnomes;

    string path = "Assets/Resources/Gnomes";
     public override void OnInspectorGUI(){
         gnomeManager = (GnomeManager) target;
        

         if(GUILayout.Button("Load Gnomes!")){
            gnomes = new List<GnomeScriptableObject>();


             foreach (string file in System.IO.Directory.GetFiles(path))
            { 
                if(!file.Contains("meta"))
                gnomes.Add(LoadAsset<GnomeScriptableObject>(file));
            }

            Debug.Log(gnomes.Count);
         }
        if(gnomes != null)
            foreach (GnomeScriptableObject gnome in gnomes){
                EditorGUILayout.BeginFoldoutHeaderGroup(true, gnome.gnomeName);
                EditorGUILayout.TextField(gnome.damage.ToString());
                EditorGUILayout.TextField(gnome.price.ToString());
                EditorGUILayout.EndFoldoutHeaderGroup();
             }



        EditorGUILayout.BeginFoldoutHeaderGroup(true, "Create New Gnome!");

        templateGnome.name = EditorGUILayout.TextField("");
        templateGnome.damage = EditorGUILayout.FloatField(0f);
        templateGnome.price = EditorGUILayout.IntField(0);
        if(GUILayout.Button("Add Gnome!")){
            CreateNewGnome(templateGnome);
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
     }


     private void CreateNewGnome(gnome g){
         GnomeScriptableObject newGnome = new GnomeScriptableObject();
         newGnome.name = g.name;
         newGnome.damage = g.damage;
         newGnome.price = g.price;
         newGnome.amount = 0;
         CreateOrReplaceAsset<GnomeScriptableObject>(newGnome, path);
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


