using UnityEngine;

namespace WaterSortPuzzle.StaticData
{
  [CreateAssetMenu(fileName = "ColorData", menuName = "StaticData/Color")]
  public class ColorStaticData : ScriptableObject
  {
    [SerializeField] private Color[] _colors;

    public Color[] Colors => _colors;
  }
}