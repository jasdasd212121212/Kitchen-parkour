using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "GameDesign/Level")]
public class LevelObjectsHolder : ScriptableObject
{
    [SerializeField] private LevelObjectNode[] _levelObjects;

    public LevelObjectNode[] levelObjects => _levelObjects;

#if UNITY_EDITOR
    public void AddElement(LevelObjectNode levelNode)
    {
        if (Application.isPlaying == true)
        {
            return;
        }

        List<LevelObjectNode> levelObjects = _levelObjects.ToList();

        levelObjects.Add(levelNode);

        _levelObjects = levelObjects.ToArray();
        EditorUtility.SetDirty(this);
    }
#endif
}