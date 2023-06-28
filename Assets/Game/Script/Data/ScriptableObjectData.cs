using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScriptableObjectData : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] mapLevel;
    [SerializeField] private tileManager tileManager;
    private int currentMapIndex;
    private void Awake()
    {
        changeMap(currentMapIndex);
    }
    public void changeMap(int index)
    {
        currentMapIndex += index;
        if (currentMapIndex < 0) currentMapIndex = mapLevel.Length - 1;
        if (currentMapIndex > mapLevel.Length - 1) currentMapIndex = 0;
        if (tileManager != null)
        {
            GameEvent.Instance.txtPlay.transform.DOScale(1,1f);
            GameEvent.Instance.txtScore.transform.DOScale(1, 1f);
            tileManager.updateMap((LevelData)mapLevel[currentMapIndex]);
            tileManager.SpawnTile();

        }
    }
}
