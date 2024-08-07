using UnityEngine;

public class RandomLevelGenerator
{
    public LevelObjectNode[] GenerateLevel(GameObject[] prefabs, int levelLenght, int standratInterval)
    {
        if (levelLenght < 1)
        {
            Debug.LogError($"Can`t create a level with {levelLenght} lenght");
            levelLenght = 1;
        }

        if (standratInterval < 1)
        {
            Debug.LogError("Can`t create a level with to short intervals");
            standratInterval = 1;
        }

        if (prefabs.Length == 0 || prefabs == null)
        {
            Debug.LogError("Can`t create a level with empty prefabs");
            return null;
        }

        LevelObjectNode[] resultLevel = new LevelObjectNode[levelLenght];

        for (int i = 0; i < levelLenght; i++)
        {
            resultLevel[i] = new LevelObjectNode(prefabs[Random.Range(0, prefabs.Length)], standratInterval);
        }
        
        return resultLevel;
    }
}