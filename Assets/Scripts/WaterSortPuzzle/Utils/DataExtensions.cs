using System;
using UnityEngine;

namespace WaterSortPuzzle.Utils
{
  public static class DataExtensions
  {
    public static string ToJson(this object obj) =>
      JsonUtility.ToJson(obj);
    
    public static T ToDeserialized<T>(this string json) => 
      JsonUtility.FromJson<T>(json);

    public static int ToInt(this string obj) =>
      Int32.Parse(obj);
  }
}