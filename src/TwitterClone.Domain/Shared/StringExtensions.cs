using System;
using System.Text;

namespace TwitterClone.Domain.Shared
{
  public static class StringExtensions
  {
    
    public static string TruncateByWord(this string input, int maxLength, string suffix = "...")
    {
      if (string.IsNullOrWhiteSpace(input) || input.Length <= maxLength)
      {
        return input ?? string.Empty;
      }

      int maxContentLength = maxLength - suffix.Length;
      if (maxContentLength <= 0)
      {
        return suffix[..Math.Min(suffix.Length, maxLength)];
      }

      string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      
      if (words.Length > 0 && words[0].Length > maxContentLength)
      {
        return string.Concat(words[0].AsSpan(0, maxContentLength), suffix);
      }

      var result = new StringBuilder();

      foreach (var word in words)
      { 
        int additionalLength = (result.Length == 0 ? 0 : 1) + word.Length;

        if (result.Length + additionalLength > maxContentLength)
        {
          break;
        }

        if (result.Length > 0)
        {
          result.Append(' ');
        }

        result.Append(word);
      }

      return result.Append(suffix).ToString();
    }
  }
}