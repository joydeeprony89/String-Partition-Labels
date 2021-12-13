using System;
using System.Collections.Generic;

namespace String_Partition_Labels
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "ababcbacadefeccbbbbdecegdehijhklij";  // ababcbacadefegdehijhklij // ababcbacadefegdehijhklij
      Program p = new Program();
      var result = p.PartitionLabels(s);
      foreach(int res in result)
        Console.WriteLine(res);
    }

    public IList<int> PartitionLabels(string s)
    {
      var result = new List<int>();
      if (string.IsNullOrWhiteSpace(s)) return result;
      int partitionBoundary = 0, start = 0;
      HashSet<char> visited = new HashSet<char>();
      for (int currentIndex = 0; currentIndex < s.Length; currentIndex++)
      {
        if(currentIndex > partitionBoundary)
        {
          result.Add(currentIndex - start);
          start = currentIndex;
        }
        if (!visited.Contains(s[currentIndex]))
        {
          visited.Add(s[currentIndex]);
          int foundAtIndex = LastAppearedIndex(s[currentIndex], s);
          partitionBoundary = Math.Max(partitionBoundary, foundAtIndex);
          if (partitionBoundary == s.Length - 1)
          {
            result.Add(partitionBoundary + 1 - start);
            return result;
          }
        }
      }
      return result;
    }

    int LastAppearedIndex(char c, string s)
    {
      return s.LastIndexOf(c);
    }
  }
}
