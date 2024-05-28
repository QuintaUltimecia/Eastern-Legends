using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public int ItemID {  get; private set; }    

    public Vector3[] Positions = new Vector3[]
    {
        new Vector3(0, 400, 0),
        new Vector3(0, -400, 0),
    };

    private Vector3 _startPosition;

    [SerializeField]
    private Sprite[] _items;

    [SerializeField]
    private float _moveSpeed = 4f;

    private bool _isMove = false;

    private Transform _transform;
    private Image _image;

    public void SetItem()
    {
        int random = Random.Range(0, _items.Length);
        _image.sprite = _items[random];
        ItemID = random;
    }

    public void SetItemAt(int index)
    {
        int random = index;
        _image.sprite = _items[random];
        ItemID = random;
    }

    public void Move()
    {
        _isMove = true;
    }

    public void StopMove()
    {
        _isMove = false;
    }

    public void ResetPosition()
    {
        _transform.localPosition = _startPosition;
    }

    private void Awake()
    {
        _transform = transform;
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _startPosition = _transform.localPosition;
        SetItem();
    }

    private void Update()
    {
        if (_isMove)
        {
            _transform.localPosition = Vector3.MoveTowards(
                _transform.localPosition,
                Positions[4],
                _moveSpeed * Time.deltaTime);

            if (_transform.localPosition == Positions[4])
            {
                _transform.localPosition = Positions[0];
                SetItem();
            }
        }
    }
}