using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField]
    private float leftBorder = 0.0f;
    [SerializeField]
    private float rightBorder = 0.0f;
    [SerializeField]
    private float speed = 0.0f;

    // True: left => right
    private bool direction = true;
    
    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        } else
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        } 

        if (transform.position.x > rightBorder)
        {
            direction = false;
        }
        if (transform.position.x < leftBorder)
        {
            direction = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            GameManager.Instance.PlateHitGround();
        }
    }
}
