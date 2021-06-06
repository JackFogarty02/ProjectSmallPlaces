using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Ray g_ray = new Ray();
    private RaycastHit g_hitObject;
    private bool g_isHit = false;
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
        if (Input.GetKeyDown(g_boundKey))
            CastRay();
        else if (Input.GetKeyUp(g_boundKey))
            g_isHit = false;
    }

    private void CastRay()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, g_layerToHit))
        {
            if (g_isHit == false)
            {
                Debug.Log(g_hitObject.transform.gameObject.name);
                g_isHit = true;
            }
        }
    }
}
