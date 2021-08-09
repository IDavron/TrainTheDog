using UnityEngine;

public class EnviromentControllerScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer trayMeshRenderer;
    [SerializeField] private Material SuccessMaterial;
    [SerializeField] private Material FailMaterial;

    [SerializeField] private Transform Dog;
    [SerializeField] private Transform Tray;

    private bool training = false;

    public void Success()
    {
        trayMeshRenderer.material = SuccessMaterial;
    }

    public void Fail()
    {
        trayMeshRenderer.material = FailMaterial;
    }

    public void ResetWorld()
    {
        Dog.localPosition = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));

        if (training)
        {
            Tray.localPosition = new Vector3(Random.Range(-14.5f, 14.5f), -0.9f, Random.Range(-14.5f, 14.5f));
            DestroyPoos();
        }
    }

    private void DestroyPoos()
    {
        GameObject[] Poos = GameObject.FindGameObjectsWithTag("Poo");
        foreach (GameObject poo in Poos)
        {
            Destroy(poo);
        }
    }

    public void SetTrainingMode(bool x)
    {
        training = x;
    }
}
