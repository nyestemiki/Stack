using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject platePrefab = null;
    [SerializeField]
    private Canvas ui = null;
    [SerializeField]
    private Material[] materials = null;
    
    private GameObject currentPlate = null;

    private float height = 2.8f;

    private bool gameOver = false;

    void Awake()
    {
        NewPlate();
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DropCurrentPlate();
            NewPlate();
        }
    }

    private void DropCurrentPlate()
    {
        currentPlate.GetComponent<Plate>().enabled = false;
        currentPlate.GetComponent<Rigidbody>().useGravity = true;
        currentPlate.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void NewPlate()
    {
        Vector3 position = new Vector3(0, height, 0);
        GameObject newPlate = Instantiate(platePrefab, position, Quaternion.identity);
        var x = UnityEngine.Random.Range(2, 15);
        var y = UnityEngine.Random.Range(.5f, 2);
        var z = UnityEngine.Random.Range(2, 15);
        newPlate.transform.localScale = new Vector3(x, y, z);
        height += y;
        var materialIndex = UnityEngine.Random.Range(0, materials.Length);
        newPlate.GetComponent<Renderer>().material = materials[materialIndex];
        currentPlate = newPlate;
        transform.position += new Vector3(0, y, 0);
    }

    public void PlateHitGround()
    {
        gameOver = true;
        DropCurrentPlate();
        ui.GetComponent<Canvas>().enabled = true;
    }
}
