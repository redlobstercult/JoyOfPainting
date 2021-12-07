using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSpawn : MonoBehaviour
{
    [SerializeField] GameObject _brushPrefab;
    
    float _topX;
    float _topY;
    float _rightX;
    float _rightY;
    float _bottomX;
    float _bottomY;
    float _leftX;
    float _leftY;
    private enum BrushPosition{ Top, Right, Bottom, Left};
    public static BrushSpawn Instance;
    Vector3 _top;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _topX = Camera.main.ViewportToWorldPoint(new Vector3((float)0.5, 0, 0)).x;
        _topY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        _rightX = Camera.main.ViewportToWorldPoint(new Vector3((float)1, 0, 0)).x;
        _rightY = Camera.main.ViewportToWorldPoint(new Vector3((float)0, (float)0.5f, 0)).y;
        _bottomX = Camera.main.ViewportToWorldPoint(new Vector3((float)1, 0, 0)).x;
        _bottomY = Camera.main.ViewportToWorldPoint(new Vector3((float)0, 0, 0)).y;
        _leftX = Camera.main.ViewportToWorldPoint(new Vector3((float)0, 0, 0)).x;
        InvokeRepeating(nameof(SpawnBrush), 3f, 2f);
       
    }

   

    void SpawnBrush() {
        int randEnumMan = Random.Range(0, 4);
       

          switch (randEnumMan) {
              case 0: 
                  Instantiate(_brushPrefab, new Vector3(_topX, _topY, 0), Quaternion.identity);
               BrushPosition.Top.Equals(true);
                  break;
              case 1:
                  Instantiate(_brushPrefab, new Vector3(_rightX, _rightY, 0), Quaternion.Euler(0, 0, -90));
                BrushPosition.Right.Equals(true);
                break;
              case 2:
                  Instantiate(_brushPrefab, new Vector3(_topX, _bottomY, 0), Quaternion.identity);
                BrushPosition.Bottom.Equals(true);
                break;
              case 3:
                  Instantiate(_brushPrefab, new Vector3(_leftX, _rightY, 0), Quaternion.Euler(0, 0, -90));
                BrushPosition.Left.Equals(true);
                break;
              default:
                  break;

          } 

    }
}
