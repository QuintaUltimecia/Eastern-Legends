using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Transform _transform;

    public UnityEvent OnComplete;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Rotate(0, 0, _speed * Time.deltaTime);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        OnComplete.Invoke();    
    }
}