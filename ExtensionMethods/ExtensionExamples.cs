using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtensionExamples
{
        public class ExtensionExamples : MonoBehaviour
        {

        public List<int> someList = new List<int>();
        UnityEngine.UI.Image image;
        UnityEngine.UI.Text text;

        SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            //Vector3 vectorFloat = new Vector3();

            //Vector3Int vectorInt = new Vector3Int();

            ////nope
            ////vectorInt = (Vector3Int)vectorFloat;
            ////vectorInt = vectorFloat as Vector3Int;

            ////yes
            //vectorFloat = vectorInt;

            ////it works but only exists in this class
            //vectorInt = ConvertToVector3Int(vectorFloat);

            ////Static helper class solves some problems
            ////but it's long...
            //vectorInt = HelperFunctions.ConvertToVector3Int(vectorFloat);

            ////yes!!! Short. Clean. Reusable!
            //vectorInt = vectorFloat.ToVector3Int();

            //image.SetAlpha(0.5f);
            //text.SetAlpha(0.75f);

            //foreach (int value in intList.GetEveryOther<int>())
            //{
            //    Debug.Log(value);
            //}

            List<int> everyOther = new List<int>();

            everyOther = someList.GetEveryOther();

            //this.transform.Reset();

            //this.transform.LocalReset();

            Vector3 someVector3 = new Vector3();

            someVector3 = new Vector3(1, 2, 3);
            Debug.Log(someVector3);

            someVector3 = someVector3.SwapYZ();
            
            Debug.Log(someVector3);


            //spriteRenderer.SetAlpha(0.5f);

        }

        private Vector3Int ConvertToVector3Int(Vector3 vector3)
        {
            Vector3Int vector3Int = new Vector3Int();
            vector3Int.x = Mathf.RoundToInt(vector3.x);
            vector3Int.y = Mathf.RoundToInt(vector3.y);
            vector3Int.z = Mathf.RoundToInt(vector3.z);

            return vector3Int;
        }
    }

    public static class HelperFunctions
    {
        public static Vector3Int ToVector3Int(this Vector3 vector3)
        {
            Vector3Int vector3Int = new Vector3Int();
            vector3Int.x = Mathf.RoundToInt(vector3.x);
            vector3Int.y = Mathf.RoundToInt(vector3.y);
            vector3Int.z = Mathf.RoundToInt(vector3.z);

            return vector3Int;
        }

        public static Vector3Int ConvertToVector3Int(Vector3 vector3)
        {
            Vector3Int vector3Int = new Vector3Int();
            vector3Int.x = Mathf.RoundToInt(vector3.x);
            vector3Int.y = Mathf.RoundToInt(vector3.y);
            vector3Int.z = Mathf.RoundToInt(vector3.z);

            return vector3Int;
        }

        public static Vector3 SwapYZ(this Vector3 vector3)
        {
            float oldY = vector3.y;
            float oldZ = vector3.z;

            vector3.z = oldY;
            vector3.y = oldZ;

            return vector3;
        }

        public static void SetAlpha(this UnityEngine.UI.Graphic graphic, float alpha)
        {
            Color color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }

        public static int RoundToInt(this float value)
        {
            return Mathf.RoundToInt(value);
        }

        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }

        public static string ToConsole(this string message)
        {
            Debug.Log(message);
            return message;
        }

        public static void LocalReset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            //can't directly set global scale
            transform.localScale = Vector3.one; 
        }

        public static void SetXPosition(this Transform transform, float xValue)
        {
            Vector3 position = transform.position;
            position.x = xValue;
            transform.position = position;
        }

        public static List<T> GetEveryOther<T>(this List<T> list)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                    newList.Add(list[i]);
            }
            return newList;
        }

        //works with inheritance
        public static void SomeShadeFunction(this Shape shape)
        {
            //do something useful
        }

        //works with generics too
        public static void SomeShadeFunction<T>(this T shape) where T : Shape
        {
            //do fancy generic stuff
        }

    }


    public class Shape
    {

    }

    public class Cube : Shape
    {

    }

    public class Sphere : Shape
    {

    }

}