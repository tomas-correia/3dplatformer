using TMPro;
using UnityEngine;

public class EnemyNametag : MonoBehaviour
{
    [SerializeField]
    private GameObject nametag;
    private Vector3 offset = new(0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        nametag.transform.LookAt(Camera.main.transform);
        // Flip the nametag around, since LookAt will face it backwards
        nametag.transform.Rotate(offset);
    }

    public void UpdateText()
    {
        nametag.GetComponent<TextMeshPro>().text = GetText();
    }

    private string GetText()
    {
        int health = GetComponent<EnemyCollision>().Health;
        return $"{health} HP";
    }
}
