using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public float zoomSize = 15;
    private Camera cam;

	private void Start()
	{
        cam = GetComponent<Camera>();
    }

	void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);

        cam.orthographicSize = 8;

        /*if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
            if (zoomSize > 10)
                zoomSize -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomSize < 20)
                zoomSize += 1;
        }*/

    }
}
