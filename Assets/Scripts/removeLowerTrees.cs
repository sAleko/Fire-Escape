using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeLowerTrees : MonoBehaviour
{
    public TerrainData oldData;
    public bool replaceWithOld = false;

    private TerrainData currData;

    // Start is called before the first frame update
    void Start()
    {
        currData = Terrain.activeTerrain.terrainData;

        if (replaceWithOld)
        {
            currData = oldData;
            return;
        }

        TreeInstance[] trees = currData.treeInstances;


        for (int i = 0; i < trees.Length; i++)
        {
            Vector3 treeInstancePos = trees[i].position;
            Vector3 treePos = Terrain.activeTerrain.transform.TransformPoint(
                                new Vector3(treeInstancePos.x * currData.size.x, treeInstancePos.y * currData.size.y, treeInstancePos.z * currData.size.z)
                );
            
            Debug.Log(treePos.ToString() + "\n");



            if (treePos.y < transform.position.y)
            {
                trees[i] = new TreeInstance();
            }
        }

        currData.treeInstances = trees;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
