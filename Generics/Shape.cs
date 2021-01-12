using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Shape : MonoBehaviour
{

}

namespace GenericShapes
{
    //can not be add to a gameObject
    public class Shape<T> : Shape where T : Shape<T>
    {
        public static List<T> shapeList = new List<T>();

        protected void OnEnable()
        {
            shapeList.Add(this as T);
        }

        protected void OnDisable()
        {
            shapeList.Add(this as T);
        }
    }
}
