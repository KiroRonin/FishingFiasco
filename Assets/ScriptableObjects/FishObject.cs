using UnityEngine;

[CreateAssetMenu(fileName = "Fish Object", menuName = "ScriptableObjects/FishObject")]
public class FishObject : ScriptableObject
{
    public int Id;
    public string fishName = "fishy";
    public int size = 10;

    public GameObject prefabDisplay;
}
