using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject _treePrefab;
    //[SerializeField] float _speed = 2f;
    [SerializeField] GameObject _gameState;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           // StartCoroutine(PlaySound());
            EventManager.TriggerEvent("CollectSound");
            Destroy(gameObject);
            GameState.Instance.IncreaseScore(1);
           
        }
    }

    IEnumerator PlaySound()
    {
        EventManager.TriggerEvent("CollectSound");
        yield return null;
    }
}
