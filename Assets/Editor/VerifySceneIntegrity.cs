using System;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class VerifySceneIntegrity : MonoBehaviour
{
    public static string[] requirements =
    {
        "GoblinManager", "GnomeManager", "EventSystem", "UpgradeCanvas", "EnemyArea"
    };

    public static string message = "";

    [MenuItem("Tests/VerifyIntegrity")]
    private static void VerifyIntegrity()
    {
        var objectsInScene = FindObjectsOfType<GameObject>();
        var copyOfRequirements = requirements.ToList();
        foreach (var obj in objectsInScene) copyOfRequirements.Remove(obj.name);

        if (copyOfRequirements.Count != 0)
        {
            message = "You miss these elements:";
            foreach (var req in copyOfRequirements) message += "\n   • " + req;

            message = message;
            EditorUtility.DisplayDialog("VerifyIntegrity", message, "Ok", "");
        }
        else
        {
            EditorUtility.DisplayDialog("VerifyIntegrity", "Everything has been found!", "Ok", "");
        }
    }
}