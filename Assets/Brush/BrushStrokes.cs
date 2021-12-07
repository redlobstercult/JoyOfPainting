using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushStrokes : MonoBehaviour
{
    [SerializeField] GameObject _brushPrefab;
    [SerializeField] float _speed = 2f;
    [SerializeField] GameObject _brushSpawn;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _gameState;
    float _initialX;
    float _initialY;
    
    void Start()
    {
        _initialX = transform.position.x;
        _initialY = transform.position.y;
    }

    
    void Update()
    {
        BrushStroke();
    }

    void BrushStroke() {
        if (_initialY > 9)  //top spawn
            transform.position -= new Vector3(0, Time.deltaTime * _speed, 0);
        else if (_initialX > 9) //right spawn
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
        else if(_initialY < -9)  //bottom spawn
            transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
        else if (_initialX < -9)  //left spawn
            transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            GameState.Instance.InitiateGameOver();
        }
    }



}
