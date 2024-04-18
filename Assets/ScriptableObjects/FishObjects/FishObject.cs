using UnityEngine;

[CreateAssetMenu(fileName = "Fish Object", menuName = "ScriptableObjects/FishObject")]
public class FishObject : ScriptableObject
{
    public int Id;
    public string fishName = "fishy";
    public int probability;
    [TextArea(15,20)]
    public string fishDescription;

    public GameObject prefabDisplay;




}
