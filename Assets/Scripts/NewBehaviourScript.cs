using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _cameras;
    // Start is called before the first frame update
    void Start()
    {
  
        _cameras = new List<GameObject>();

        var ChildsCount = transform.childCount;

        for (int i = 0; 1 < ChildsCount; i++)
        {

            var child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            _cameras.Add(child);

            if (i == 0)
            {
                child.SetActive(true);
            }

        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int NumberOfCurrentCamera = GetNumberOfCurrentCamera();
            if (NumberOfCurrentCamera + 1 < _cameras.Count)
            {
                Debug.Log("Numero de camara a activar: " + NumberOfCurrentCamera);
                SelectCamera(NumberOfCurrentCamera + 1);
            }
            else
            {
                Debug.Log("Numero de camara a activar: " + NumberOfCurrentCamera);
                SelectCamera(0);
            }

        }
    }

    public void SelectCamera(int CameraNumber)
    {
        if (_cameras.Count > CameraNumber)
        {
            for (int i = 0; 1 < _cameras.Count; i++)
            {
                if (i == CameraNumber)
                {
                    _cameras[i].SetActive(true);
                }
                else
                {
                    _cameras[i].SetActive(false);
                }
            }
        }
        else
        {
            return;
        }
    }

    public int GetNumberOfCurrentCamera()
    {
        for (int i = 0; 1 < _cameras.Count; i++)
        {
            if(_cameras[i].activeSelf)
            {
                return i;
            }
        }
        Debug.LogError("No hay camara activada");
        return -1;
    }
}
