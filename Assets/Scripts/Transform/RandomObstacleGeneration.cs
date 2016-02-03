using UnityEngine;
using System.Collections;

public class RandomObstacleGeneration : MonoBehaviour {
    
    private float posSum = 0;
    public float minY;
    public float maxObstacleValue;
    public float maxY;
    public float spacingMin, spacingMax, obstacleSpacing;

	// Use this for initialization
	void Start () {
        Setup();
	}
	
    void Setup()
    {
        if (maxObstacleValue == 0) maxObstacleValue = 6;
        minY = Mathf.Max(60, minY);
        if (maxY == 0) maxY = 1000000;
        if (obstacleSpacing == 0) obstacleSpacing = 12;
        if (spacingMin == 0) spacingMin = 0.5f;
        if (spacingMax == 0) spacingMax = 1;
        posSum = minY;
    }

    bool CheckPhotonPrePosition()
    {
        if (GameObject.Find("Photon").transform.position.y > posSum - minY)
        {
            return true;
        }
        else return false;
    }

    void GenerateObstacle(int coef)
    {
        posSum += obstacleSpacing * RandomSpacing(Mathf.Abs(coef) - 2);
        Vector3 position = new Vector3(0, posSum, 0);
        Quaternion noRotation = new Quaternion(0, 0, 0, 0);
        if (coef > 0)
        {
            Instantiate(Resources.Load("Gravity " + coef.ToString()), position, noRotation);
        }
        else if (coef < 0)
        {
            Instantiate(Resources.Load("Dark Energy Band " + coef.ToString().TrimStart('-')), position, noRotation);
        }
    }

    int RandomObstacle()
    {
        int basis = Mathf.FloorToInt(Random.Range(2, maxObstacleValue + 0.99f));
        int coef = Mathf.FloorToInt(Random.Range(0.5f, 1.49f))
            * 2 - 1;
        return basis * coef;
    }

    float RandomSpacing(int coef)
    {
        float fooMin, fooMax;
        fooMin = spacingMin + 0.1f * coef;
        fooMax = spacingMax + 0.1f * coef;
        return Random.Range(fooMin, fooMax);
    }

	// Update is called once per frame
	void Update () {
	    if(CheckPhotonPrePosition() && posSum < maxY)
        {
            GenerateObstacle(RandomObstacle());
        }
	}
}
