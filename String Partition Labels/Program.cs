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
        // When current index crossed the last max partitionBoundary.
        // we have found a new partition
        // update the start position
        if (currentIndex > partitionBoundary)
        {
          result.Add(currentIndex - start);
          start = currentIndex;
        }
        if (!visited.Contains(s[currentIndex]))
        {
          visited.Add(s[currentIndex]);
          // serach for the last appeared index for a char.
          int foundAtIndex = LastAppearedIndex(s[currentIndex], s);
          // update the partition boundary.
          partitionBoundary = Math.Max(partitionBoundary, foundAtIndex);
          // if at any position for the current char we get the foundAtIndex value as the last char position 
          // which means no more partiton is possible
          // add the distance and return the result.
          if (foundAtIndex == s.Length - 1)
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
