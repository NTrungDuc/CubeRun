using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public int levelNo;
    public GameObject tilePrefabs;
    public void updateMap(LevelData _newMap)
    {
        levelNo = _newMap.levelNo;
        tilePrefabs = _newMap.mapPrefabs;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTile()
    {
        GameObject tmp = Instantiate(tilePrefabs);
        tmp.transform.parent = transform;
    }
    public void deleteOldTile()
    {
        Destroy(transform.GetChild(0).gameObject);
        GameEvent.Instance.resetPosPlayer();
    }
}
