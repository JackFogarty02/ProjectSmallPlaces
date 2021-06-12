using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]

public class ClueItem : ScriptableObject
{
    [SerializeField]
    private string _name = "Enter Clue Name... ";

    public string Name { get { return _name; } }
}
