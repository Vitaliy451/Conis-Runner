using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private Wave[] wave;



    private float currentTime;

    List<float> remainingPosition = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;

    void Start()
    {
        currentTime = 0;
        remainingPosition.AddRange(xPositions);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            SelectWave();
        }
    }

    void SpawnCoin(float xPos)
    {
        //int r = Random.Range(0, 1);
        string coinName = "";
        //if (r == 0)
        coinName = "Coin";
        //if (r == 1)
           // coinName = "Coin";

        GameObject coin = ObjectPooling.instance.GetPooledObject(coinName);
        coin.transform.position = new Vector3(xPos, transform.position.y, 0);
        
        
        
        coin.SetActive(true);
    }
    void SelectWave()
    {
        remainingPosition = new List<float>();
        remainingPosition.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        if(wave[waveIndex].spawnAmount == 2)
        {
            xPos = Random.Range(-xLimit, xLimit);
        }
        else if(wave[waveIndex].spawnAmount > 2)
        {
            rand = Random.Range(0, remainingPosition.Count);
            xPos = remainingPosition[rand];
            remainingPosition.RemoveAt(rand);
            
        }
        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            SpawnCoin(xPos);
            rand = Random.Range(0, remainingPosition.Count);
            xPos = remainingPosition[rand];
            remainingPosition.RemoveAt(rand);
        }
    }

}
[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}
