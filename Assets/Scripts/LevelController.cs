using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] int sceneToLoadOnWin = 2;

    int numberOfBlocks;

    public void AddBlock()
    {
        numberOfBlocks++;
    }

    public void RemoveBlock()
    {
        numberOfBlocks--;

        if (numberOfBlocks <= 0)
        {
            sceneLoader.ChangeScene(sceneToLoadOnWin);
        }
    }
}
