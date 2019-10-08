using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/GnomeScriptableObject", order = 1)]
public class GnomeScriptableObject : ScriptableObject
{
    public string gnomeName = "default";
    public int amount = 0;
    public float damage = 1f;
    public int price = 10;
}