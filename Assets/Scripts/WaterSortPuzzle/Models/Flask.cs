using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WaterSortPuzzle.Views;

namespace WaterSortPuzzle.Models
{
  public class Flask
  {
    public readonly List<Water> Stack;
    public FlaskView View;
    public Action<Flask> OnClick;

    private int MaxCount = 4;


    public Flask() => 
      Stack = new List<Water>(MaxCount);

    public Flask(Color color)
    {
      Stack = new List<Water>(MaxCount);
      InitialFullPour(color);
    }

    public void SetView(FlaskView view)
    {
      View = view;
      view.OnClick += Clicked;
    }

    public bool IsEmpty() => 
      Stack.Count == 0;

    public bool IsFull() => 
      Stack.Count == MaxCount;

    public Color TopColor()
    {
      if(IsEmpty()) return Color.black;
       return Stack.Last().Color;
    }

    public int IdenticalColors()
    {
      var i = 1;
      var j = 2;
      while (Stack.Count - j >= 0 && TopColor() == Stack[Stack.Count - j].Color)
      {
        i++;
        j++;
      }
      return i;
    }

    public int FreeSpace() => 
      MaxCount - Stack.Count;
    
    public void PourOut(Flask flask, int i)
    {
      for (int j = 0; j < i; j++)
      {
        var water = Stack.Last();
        flask.Pour(water);
        Stack.RemoveAt(Stack.Count - 1);
      }
    }

    private void Clicked() => 
      OnClick?.Invoke(this);

    private void InitialFullPour(Color color)
    {
      for (int i = 0; i < MaxCount; i++) 
        Stack.Add(new Water(color));
    }

    private void Pour(Water water)
    {
      Stack.Add(water);
      if(View == null) return;
      water.SetParent(View.FluidsPositions[Stack.Count - 1]);
    }
  }
}