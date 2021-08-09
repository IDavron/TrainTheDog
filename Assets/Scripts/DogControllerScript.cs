using UnityEngine;

public class DogControllerScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSpeed;

    [SerializeField] private GameObject Poo;
    private bool allowed;
    // Start is called before the first frame update
    void Start()
    {
        allowed = false;
    }

    public void DoTheJob()
    {
        Vector3 pos = transform.position - transform.forward;
        Instantiate(Poo, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tray")
        {
            allowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tray")
        {
            allowed = false;
        }
    }
    public void Move(float movement)
    {
        transform.position += transform.forward * movement * movementSpeed * Time.deltaTime;
    }

    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.up * angle * turnSpeed * Time.deltaTime);
    }

    public bool IsAllowed()
    {
        return allowed;
    }
}
