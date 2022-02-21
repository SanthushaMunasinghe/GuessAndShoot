using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawnManager : MonoBehaviour
{
    [SerializeField] private MainScript mainScript;

    public List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private AudioSource correctSFX;

    private bool isSpawned = false;
    public GameObject spawnedTarget;
    public Vector2 spawnedTargetPos;

    private int score = 0;

    void Update()
    {
        if (!isSpawned && !mainScript.isGameOver)
        {
            TargetSpawn();
        }
    }

    private void TargetSpawn()
    {
        int currentPosition = Random.Range(0, spawnPoints.Count);

        spawnedTarget = Instantiate(targetPrefab, spawnPoints[currentPosition].transform.position, Quaternion.identity) as GameObject;
        isSpawned = true;
        spawnedTargetPos = spawnedTarget.transform.position;
    }

    public void DestroyTarget()
    {
        Destroy(spawnedTarget);
        isSpawned = false;
        score++;
        scoreTxt.text = score.ToString();
        correctSFX.Play();
    }
}
