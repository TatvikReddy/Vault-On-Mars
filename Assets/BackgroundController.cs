using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject cam;
    public GameObject[] backgrounds;
    private float length;

    private void Start()
    {
        if (backgrounds.Length < 2)
        {
            Debug.Log("BackgroundController needs 2 backgrounds");
            return;
        }

        length = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, cam.transform.position.y + 15, transform.position.z);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float camX = cam.transform.position.x;
            float bgX = backgrounds[i].transform.position.x;

            if (camX - bgX > length)
            {
                float newX = backgrounds[(i + 1) % backgrounds.Length].transform.position.x + length;
                backgrounds[i].transform.position = new Vector3(newX, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            }
            else if (bgX - camX > length)
            {
                float newX = backgrounds[(i + 1) % backgrounds.Length].transform.position.x - length;
                backgrounds[i].transform.position = new Vector3(newX, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            }
        }
    }
}