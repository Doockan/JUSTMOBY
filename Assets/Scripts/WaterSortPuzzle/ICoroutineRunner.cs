using System.Collections;
using UnityEngine;

namespace WaterSortPuzzle
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}