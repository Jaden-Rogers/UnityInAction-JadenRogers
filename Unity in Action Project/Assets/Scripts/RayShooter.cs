using UnityEngine;
using System.Collections;
public class RayShooter : MonoBehaviour
{
    private string coordinates;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnGUI()
    {
        int size = 1000;
        float posX = _camera.pixelWidth / 2 - 12 / 4;
        float posY = _camera.pixelHeight / 2 - 12 / 2;
        GUI.Label(new Rect(posX, posY, 100, 100), "o");
        GUI.Label(new Rect(posX + 100, posY + 100, 5000, 5000), coordinates);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
            pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                coordinates = hit.point.ToString();
                StartCoroutine(SphereIndicator(hit.point));
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    Debug.Log("Target hit");
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}