using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGod : MonoBehaviour {

	public GameObject[] SphereSpawnPoints;
	public GameObject[] TofuSpawnPoints;
	public GameObject Sphere;
	public GameObject Tofu;
	public int SphereSpawnRate = 70;
	public int TofuSpawnRate = 70;
	
	void Start () {
		SpawnSpheres();
		SpawnTofu();
	}

	void Update (){
		CheckKey();
	}

	void CheckKey (){
		if (Input.GetKey(KeyCode.C))
		{
			Reset();
		}
	}

	void Reset (){
		
		GameObject[] spheres = GameObject.FindGameObjectsWithTag ("Sphere");
		GameObject[] tofus = GameObject.FindGameObjectsWithTag ("Tofu");
		for(var i = 0 ; i < spheres.Length ; i ++){
			Destroy(spheres[i]);
		}
		for(var i = 0 ; i < tofus.Length ; i ++){
			Destroy(tofus[i]);
		}

		SpawnTofu();
		SpawnSpheres();
	}

	void SpawnSpheres () {
		for (int i = 0; i < SphereSpawnPoints.Length; i++){
			if (Random.Range(0, 100) < SphereSpawnRate){
				Instantiate(Sphere, SphereSpawnPoints[i].transform.position, Quaternion.identity);
			}
		}
	}

	void SpawnTofu () {
		for (int i = 0; i < TofuSpawnPoints.Length; i++){
			if (Random.Range(0, 100) < TofuSpawnRate){
				Instantiate(Tofu, TofuSpawnPoints[i].transform.position, Quaternion.identity);
			}
		}
	}
}
