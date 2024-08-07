using UnityEngine;

public class JumpInput : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField][Min(0.0001f)] private float _jumpDellay = 0.2f;

    [Space()]

    [SerializeField] private ClickablePanel _clickablePanel;

    private IJumpable _jumpable;
    private float _currentJumpDellay;

    private bool _isJumping;

    private void OnValidate()
    {
        if (_playerObject.GetComponent<IJumpable>() == null)
        {
            Debug.LogError($"Error: Incorrect object -> gameObject with name <{_playerObject.gameObject}> are not conatins any script realises <{nameof(IJumpable)}> interface");
        }
    }

    private void Start()
    {
        _jumpable = _playerObject.GetComponent<IJumpable>();
        _clickablePanel.OnPointerClick += (bool isClicked) => { _isJumping = isClicked; };
    }

    private void FixedUpdate()
    {
        if (_currentJumpDellay <= 0)
        {
            if (_isJumping == true)
            {
                _jumpable.Jump();
                _currentJumpDellay = _jumpDellay;
            }
        }
        else
        {
            _currentJumpDellay -= Time.fixedDeltaTime;
        }
    }
}