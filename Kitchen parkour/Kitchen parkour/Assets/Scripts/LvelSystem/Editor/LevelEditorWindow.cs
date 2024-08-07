using UnityEditor;
using UnityEngine;

public class LevelEditorWindow : EditorWindow
{
    private LevelObjectsHolder _level;
    private LevelPreview _preview;

    private GameObject _newLevelProp;
    private float _newLevelPropIntervalDistance;

    private float _levelPreviewProcent;
    private bool _isInitialSpawned;

    private RandomLevelGenerator _levelGenerator;
    [SerializeField]private GameObject[] _prefabs;
    private int _generetaedLevelLength;

    private Vector2 _scrollPosition;

    private readonly Vector2 PREVIEW_CAMERADISPLAY_POSITION = new Vector2(0, 65);

    [MenuItem("Game design tools/LevelEditor")]
    public static void OpenWindow()
    {
        LevelEditorWindow window = GetWindow<LevelEditorWindow>();
    }

    private void OnDestroy()
    {
        if (_isInitialSpawned == true)
        {
            _preview.SetPreviewCameraPercentPosition(0);
        }

        _preview.DisposePreview();
    }

    private void OnGUI()
    {
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

        DisplayStandartMenu();
        HandleAddButton();

        DrawSpace(2);

        EditorGUILayout.LabelField("Level generation");

        HandleGenerateButton();
        _generetaedLevelLength = Mathf.Clamp(EditorGUILayout.IntField(_generetaedLevelLength), 0, int.MaxValue);
        DisplayArrayField(nameof(_prefabs));

        DrawSpace(3);

        HandleForceLevelViewUpdateButton();
        _preview.SetPreviewCameraPercentPosition(_levelPreviewProcent);

        DrawSpace(3);

        EditorGUILayout.EndScrollView();
    }

    private void DisplayStandartMenu()
    {
        InitializePreview();
        EditorGUILayout.LabelField("Level editor window");

        _level = (LevelObjectsHolder)EditorGUILayout.ObjectField(_level, typeof(LevelObjectsHolder));
        _levelPreviewProcent = EditorGUILayout.Slider(_levelPreviewProcent, 0f, 100f);

        EditorGUI.DrawPreviewTexture(new Rect(PREVIEW_CAMERADISPLAY_POSITION, new Vector2(_preview.renderingREsolution.x, _preview.renderingREsolution.y)), _preview.previewImage);

        DrawSpace(27);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("New gemeObject");
        _newLevelProp = (GameObject)EditorGUILayout.ObjectField(_newLevelProp, typeof(GameObject));

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("New level prop distance");
        _newLevelPropIntervalDistance = Mathf.Clamp(EditorGUILayout.FloatField(_newLevelPropIntervalDistance), 0, float.MaxValue);

        EditorGUILayout.EndHorizontal();
    }

    private void HandleAddButton()
    {
        if (GUILayout.Button("Add new node") == true)
        {
            LevelObjectNode newLevelNode = new LevelObjectNode(_newLevelProp, _newLevelPropIntervalDistance);
            _level.AddElement(newLevelNode);

            RefreshLevelPreview();
        }
    }

    private void HandleForceLevelViewUpdateButton()
    {
        if (GUILayout.Button("Update level view") == true)
        {
            RefreshLevelPreview();
        }
    }

    private void HandleGenerateButton()
    {
        if (GUILayout.Button("Generate level") == true)
        {
            LevelObjectNode[] newLevelNodes = _levelGenerator.GenerateLevel(_prefabs, _generetaedLevelLength, 10);

            for (int i = 0; i < newLevelNodes.Length; i++)
            {
                _level.AddElement(newLevelNodes[i]);
            }

            RefreshLevelPreview();
        }
    }

    private void DrawSpace(int space)
    {
        if (space < 1)
        {
            space = 1;
        }

        for (int i = 0; i < space; i++)
        {
            EditorGUILayout.LabelField(" ");
        }
    }

    private void InitializePreview()
    {
        if (_preview == null)
        {
            _preview = FindObjectOfType<LevelPreview>();
        }

        if (_level != null && _isInitialSpawned == false)
        {
            _preview.SpawnPreview(_level);
            _isInitialSpawned = true;
        }

        if (_levelGenerator == null)
        {
            _levelGenerator = new RandomLevelGenerator();
        }

        _preview.Initialize();
    }

    private void DisplayArrayField(string fieldName)
    {
        ScriptableObject target = this;
        SerializedObject serializedObject = new SerializedObject(target);
        SerializedProperty stringsProperty = serializedObject.FindProperty(fieldName);

        EditorGUILayout.PropertyField(stringsProperty, true);
        serializedObject.ApplyModifiedProperties();
    }

    private void RefreshLevelPreview()
    {
        _preview.SetPreviewCameraPercentPosition(0);
        _preview.SpawnPreview(_level);
        _preview.SetPreviewCameraPercentPosition(100);
    }
}