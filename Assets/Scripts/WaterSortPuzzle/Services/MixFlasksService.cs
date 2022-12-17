using System.Collections.Generic;
using UnityEngine;
using WaterSortPuzzle.Data;
using WaterSortPuzzle.Models;
using Random = System.Random;

namespace WaterSortPuzzle.Services
{
  class MixFlasksService : IMixFlasksService
  {
    private readonly IStaticDataService _data;
    private readonly Random _random = new Random();

    private int _currentLevel;
  
    public MixFlasksService(IStaticDataService data) => 
      _data = data;


    public List<Flask> CreteFlasks(int levelNum)
    {
      _currentLevel = levelNum;
      List<Flask> flasks = new List<Flask>();
      List<int> usedColor = new List<int>();
      var levelData = _data.ForLevel(levelNum);
      var colorData = _data.ForColor();

      for (int i = 0; i < levelData.Flask; i++)
      {
        int k;
        do k = _random.Next(colorData.Colors.Length);
        while (usedColor.Contains(k));
        usedColor.Add(k);
        var flask = CreateFlask(colorData.Colors[k], i == levelData.Flask - 1);
        flasks.Add(flask);
      }

      Mix(flasks, levelNum);

      return flasks;
    }

    private Flask CreateFlask(Color color, bool last)
    {
      var flask = last ? new Flask() : new Flask(color);
      return flask;
    }

    private void Mix(List<Flask> flasks, int levelNum)
    {
      MixStep(flasks, 4);
      MixStep(flasks, 3);
      MixStep(flasks, 2);
    }

    private void MixStep(List<Flask> flasks, int identicalColors)
    {
      foreach (var target in flasks)
      {
        if (target.IdenticalColors() == identicalColors)
        {
          var target2 = flasks[0];

          for (int i = 0; i < _data.ForLevel(_currentLevel).RepeatedSearches; i++)
            FindSecondTarget(flasks, target, ref target2);
          
          var amountWater = target2.FreeSpace() > identicalColors - 1  ? Random(identicalColors -1) : Random(target2.FreeSpace());
          target.PourOut(target2, amountWater);
        }
      }
    }

    private  void FindSecondTarget(List<Flask> flasks, Flask target, ref Flask target2)
    {
      foreach (var flask in flasks)
      {
        if (flask == target) continue;
        if (flask.IsFull()) continue;
        if (flask.TopColor() == target.TopColor()) continue;
        if (flask.FreeSpace() < target2.FreeSpace()) continue;
        target2 = flask;
      }
    }

    private int Random(int maxValue)
    {
      var random = _random.Next(1, 100);
      if (maxValue == 3)
      {
        if (random < _data.ForLevel(_currentLevel).OneStepPercentageForOne) return 1;
        if (random < _data.ForLevel(_currentLevel).OneStepPercentageForTwo) return 2;
        if (random < 100) return 3;
      }
      
      if (maxValue == 2)
      {
        if (random < _data.ForLevel(_currentLevel).TwoStepPercentageForOne) return 1;
        if (random < 100) return 2;
      }

      if (maxValue == 1) return 1;

      
      throw new System.Exception($"Что то не так, пришло: {maxValue}");
    }
  }
}