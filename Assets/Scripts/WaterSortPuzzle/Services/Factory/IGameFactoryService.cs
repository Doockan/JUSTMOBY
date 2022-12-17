using System;
using System.Collections.Generic;
using WaterSortPuzzle.Models;

namespace WaterSortPuzzle.Services.Factory
{
  public interface IGameFactoryService : IService
  {
    List<Flask> InitializedFlasks { get;}
    void CreateLevelChoiceWindow();
    void CreateUIRoot();
    void InitializeFlasks(List<Flask> flasks, Action onInit);
    void SetCamera();
  }
}