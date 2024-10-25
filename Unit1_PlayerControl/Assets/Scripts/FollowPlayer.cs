using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -7);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPosition();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        transform.position = player.transform.position + offset;
    }
}