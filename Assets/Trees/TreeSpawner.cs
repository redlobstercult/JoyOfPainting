using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject _treePrefab;
    float _xMin;
    float _xMax;
    float _yMin;
    float _yMax;
    
    void Start()
    {
      
        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(.8f, 0, 0)).x;
        _yMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 0)).y;
        _yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, .9f, 0)).y;
        InvokeRepeating(nameof(SpawnTree), 0f, 3f);
    }

    

    void SpawnTree()
    {
       // Debug.Log("tree");
        float randX = Random.Range(_xMin, _xMax);
        float randY = Random.Range(_yMin, _yMax);
        Instantiate(_treePrefab, new Vector3(randX, randY, 0), Quaternion.identity);
        StartCoroutine(PlayNow());
        //EventManager.TriggerEvent("PlaySound");
       
    }

    IEnumerator PlayNow()
    {
        EventManager.TriggerEvent("PlaySound");
        yield return null;
    }
        
}
