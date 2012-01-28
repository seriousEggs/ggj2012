using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class LoadLevel : MonoBehaviour 
{	
	int levelNumber;
	string[] fileNames = new string[9];
	public GameObject enemySMover;
	float lastSpawnTime;
    FileInfo theSourceFile = null;
    StreamReader reader = null;
    string text = " ";

	// Use this for initialization
	void Start () 
	{
		fileNames[0] = "map1.txt";
		loadFile();
	}

	void loadFile()
	{
		theSourceFile = new FileInfo ("Assets/data/level.txt");
        reader = theSourceFile.OpenText();		
		
		while(true)
		{
			text = reader.ReadLine();
			if (text != null) 
			{
				loadObject(text);
	        }	
			else
			{
				break;
			}
		}
	}
	
	void spawnSMover(Vector3 spawnPosition)
	{
		UnityEngine.Object enemy = Instantiate(enemySMover, spawnPosition, transform.rotation);	
	}
	
	void loadObject(string enemyDetails)
	{
		string[] enemyAttributes = enemyDetails.Split(',');
		Vector3 spawnPosition = new Vector3 (Convert.ToSingle(enemyAttributes[1]), Convert.ToSingle(enemyAttributes[2]), 0.0f);		
		UnityEngine.Object entity = Instantiate(enemySMover, spawnPosition, Quaternion.identity);
	}
}
