using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float minXPos = -0.01f;
    [SerializeField] private float maxXPos = 288.2f;

    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!target)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (!player)
            {
                Debug.LogError("CameraFollow: No GameObject with tag 'Player' found in the scene.");
                return;
            }
            target = player.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!target) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(target.position.x, minXPos, maxXPos);
        transform.position = pos;
    }
}
