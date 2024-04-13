using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;
    [SerializeField] private Transform _placeCreation;
    [SerializeField] private Catapult _catapult;

    private Coroutine _coroutine;
    private int _number—ubes = 1;

    private void OnEnable()
    {
        _catapult.CameBack += StartCreating;
    }

    private void OnDisable()
    {
        _catapult.CameBack -= StartCreating;
    }

    private void StartCreating()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        int currentNumberCubes = 0;
        float delay = 2f;

        while (currentNumberCubes < _number—ubes)
        {
            yield return new WaitForSeconds(delay);

            Instantiate(_prefabCube, _placeCreation.position, Quaternion.identity);
            currentNumberCubes++;
        }
    }
}
