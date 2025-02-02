using UnityEngine;

public class BattleBotController : MonoBehaviour
{
    public float movingSpeed = 10f;
    public float rotationSpeed = 180f;
    public bool isPlayerOne = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in childRenderers)
        {
            if (renderer.material != null)
            {
                renderer.material.color = isPlayerOne ? Color.white : Color.black;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis($"Vertical_{(isPlayerOne ? "P1" : "P2")}");
        float horizontalInput = Input.GetAxis($"Horizontal_{(isPlayerOne ? "P1" : "P2")}");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(movement * movingSpeed * Time.deltaTime, Space.World);

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision");
    }
}
