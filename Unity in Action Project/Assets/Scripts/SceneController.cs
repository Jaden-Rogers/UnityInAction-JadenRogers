using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            // random localscale y axis
            _enemy.transform.localScale = new Vector3(_enemy.transform.localScale.x, Random.Range(0.5f, 2.0f), _enemy.transform.localScale.z);
            // enemy is a random color
            _enemy.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}