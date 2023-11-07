using UnityEngine;

public class ActionBox : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y - 4, player.position.z);
    }
}
