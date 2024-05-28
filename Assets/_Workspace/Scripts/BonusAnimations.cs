using UnityEngine;

public class BonusAnimations : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 500f;

    [SerializeField]
    private Transform[] _transforms;

    private Vector3[] _startPos;

    private bool _isPlaying = false;

    public void Play()
    {
        _isPlaying = true;

        for (int i = 0; i < _transforms.Length; i++)
        {
            _transforms[i].position = _startPos[i];
        }
    }

    private void Awake()
    {
        _startPos = new Vector3[_transforms.Length];

        for (int i = 0; i < _startPos.Length; i++)
        {
            _startPos[i] = _transforms[i].position;
        }
    }

    private void Update()
    {
        if (_isPlaying)
            Move();
    }

    private void Move()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            Vector3 position = _transforms[i].position;
            position.y = -700f;

            _transforms[i].position = Vector3.MoveTowards(
                _transforms[i].position,
                position,
                _moveSpeed * Time.deltaTime);
        }

        Vector3 position2 = _transforms[5].position;
        position2.y = -700f;

        if (_transforms[5].position == position2)
            _isPlaying = false;
    }
}
