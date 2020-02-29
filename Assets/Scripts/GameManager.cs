using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject platePrefab = null;
    [SerializeField]
    private Canvas ui = null;
    
    private GameObject currentPlate = null;

    private float height = 2.0f;

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
        height += .5f;
        currentPlate = newPlate;
        transform.position += new Vector3(0, .3f, 0);
    }

    public void PlateHitGround()
    {
        gameOver = true;
        DropCurrentPlate();
        ui.GetComponent<Canvas>().enabled = true;
    }
}
