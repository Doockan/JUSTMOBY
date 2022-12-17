using UnityEngine;

namespace WaterSortPuzzle.Views
{
  public class LevelChoiceWindowView : MonoBehaviour
  {
    [SerializeField] private Transform _content;

    public Transform Content => _content;
  }
}