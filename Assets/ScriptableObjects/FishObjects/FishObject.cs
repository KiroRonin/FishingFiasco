using UnityEngine;

[CreateAssetMenu(fileName = "Fish Object", menuName = "ScriptableObjects/FishObject")]
public class FishObject : ScriptableObject
{
    public float hookprogressloss = 0.1f;
    public float failtime = 10f;
    public float timerMultiplier = 1f;
    public int Id;
    public string fishName = "fishy";
    public int probability;
    [TextArea(15,20)]
    public string fishDescription;

    public GameObject prefabDisplay;
    public GameObject modelprefab;



}
