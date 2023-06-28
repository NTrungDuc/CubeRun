using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageRun", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] public int levelNo;
    [SerializeField] public GameObject mapPrefabs;
}
