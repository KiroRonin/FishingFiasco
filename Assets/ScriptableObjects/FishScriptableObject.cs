using UnityEngine;

[CreateAssetMenu(fileName = "Fish Scriptable Object", menuName = "ScriptableObjects/Fish")]
public class FishScriptableObject : ScriptableObject
{
    public string fishName = "fishy";
    public int size = 10;

    public Sprite icon;

}
