using UnityEngine;

public class RaycastInventory : MonoBehaviour
{
    private Ray g_ray = new Ray();
    private RaycastHit g_hitObject;
    public LayerMask g_layerToHit;
    public float g_rayLength = 10f;
    public KeyCode g_boundKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        g_ray = Camera.main.ScreenPoint(Input.mousePosition);

        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, g_layerToHit))
        {
            Debug.Log(g_hitObject.transform.gameObject.name);
        }
    }
}
