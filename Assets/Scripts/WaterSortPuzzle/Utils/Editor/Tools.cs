using UnityEditor;
using UnityEngine;

namespace WaterSortPuzzle.Utils.Editor
{
  public class Tools
  {
    [MenuItem("Tools/Clear prefs")]
    public static void ClearPrefs()
    {
      PlayerPrefs.DeleteAll();
      PlayerPrefs.Save();
    }
  }
}
