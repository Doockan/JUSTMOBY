using System.Collections.Generic;
using WaterSortPuzzle.Models;

namespace WaterSortPuzzle.Services
{
  public interface IMixFlasksService : IService
  {
    List<Flask> CreteFlasks(int levelNum);
  }
}