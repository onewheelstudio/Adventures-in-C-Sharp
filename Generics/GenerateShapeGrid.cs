using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class GenerateShapeGrid : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> shapePrefabs;
    [SerializeField]
    private List<Shape> shapesInScene;

    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    float spacing = 2f;

    [SerializeField]
    private Material selectedMaterial;
    [SerializeField]
    private Material unSelectedMaterial;

    [SerializeField]
    private Button selectCubeButton;
    [SerializeField]
    private Button selectSphereButton;
    [SerializeField]
    private Button selectCapsuleButton;

    public static System.Action GridGenerated;

    private void OnEnable()
    {
        selectCubeButton.onClick.AddListener(() => FindAllShapesOfType<Cube>());
        selectSphereButton.onClick.AddListener(() => FindAllShapesOfType<Sphere>());
        selectCapsuleButton.onClick.AddListener(() => FindAllShapesOfType<Capsule>());
    }
    
    [Button]
    public void GenerateGrid()
    {
        ClearGrid();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject newShape = Instantiate(shapePrefabs[Random.Range(0, shapePrefabs.Count)]);
                newShape.transform.position = new Vector3(i * spacing, 0, j * spacing);
                newShape.transform.SetParent(this.transform);

                shapesInScene.Add(newShape.GetComponent<Shape>());
            }
        }

        ToggleAllUnSelectedMaterial();
        GridGenerated?.Invoke();
    }

    [Button]
    private void ClearGrid()
    {
        foreach (Shape shape in shapesInScene)
        {
            if (Application.isEditor)
                DestroyImmediate(shape.gameObject);
            else
                Destroy(shape.gameObject);
        }

        shapesInScene.Clear();
    }

    private void ToggleSelectedMaterial(Shape shape)
    {
        shape.GetComponent<MeshRenderer>().material = selectedMaterial;
    }

    private void ToggleAllUnSelectedMaterial()
    {
        foreach (Shape shape in shapesInScene)
        {
            shape.GetComponent<MeshRenderer>().material = unSelectedMaterial;
        }
    }

    private List<Cube> FindAllCubes()
    {
        List<Cube> cubeList = new List<Cube>();

        foreach (Shape shape in shapesInScene)
        {
            if (shape is Cube)
            {
                cubeList.Add(shape as Cube);
            }
        }

        return cubeList;
    }

    private List<Sphere> FindAllSpheres()
    {
        ToggleAllUnSelectedMaterial();
        List<Sphere> sphereList = new List<Sphere>();

        foreach (Shape shape in shapesInScene)
        {
            if (shape is Sphere)
            {
                sphereList.Add(shape as Sphere);
                ToggleSelectedMaterial(shape);
            }
        }

        return sphereList;
    }

    private List<Capsule> FindAllCapsules()
    {
        ToggleAllUnSelectedMaterial();
        List<Capsule> capsuleList = new List<Capsule>();

        foreach (Shape shape in shapesInScene)
        {
            if (shape is Capsule)
            {
                capsuleList.Add(shape as Capsule);
                ToggleSelectedMaterial(shape);
            }
        }

        return capsuleList;
    }


    private List<T> FindAllShapesOfType<T>() where T : Shape
    {
        //toggles all shapes back to normal color
        ToggleAllUnSelectedMaterial();

        List<T> shapeList = new List<T>();

        foreach (Shape shape in shapesInScene)
        {
            if (shape is T)
            {
                shapeList.Add(shape as T);
                Debug.Log("Doing find shape");

                //toggles individual shapes to selected color
                ToggleSelectedMaterial(shape);
            }
        }

        return shapeList;
    }

    private List<TSubclass> FindTypesInList<TClass,TSubclass>(List<TClass> _list) 
        where TSubclass : TClass where TClass : MonoBehaviour
    {
        List<TSubclass> subClassList = new List<TSubclass>();

        foreach (TClass thing in _list)
        {
            if (thing is TSubclass)
            {
                subClassList.Add((TSubclass)thing);
            }
        }

        return subClassList;
    }

    private void DestoryAllObjectsOfType<T>() where T : Component
    {
        T[] _objectList = FindObjectsOfType<T>();

        foreach (T _object in _objectList)
        {
            if (Application.isPlaying)
                Destroy(_object.gameObject);
            else
                DestroyImmediate(_object.gameObject);
        }
    }

}
