using Microsoft.CSharp.RuntimeBinder;

namespace Final_Project_DSA.util;

public static class Sorter {

    private static int[] ParseInput(string input) {
        try {
            input = input
                .Replace("[", "")
                .Replace("]", "");

            if (input.IsWhiteSpace()) return ['@'];

            var arr = input.Split(",")
                .Select(c => c.Trim())
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(" ", arr));
            
            return arr.Length != 0 ? arr : ['#'];
        }
        catch (Exception _) {
            return ['#'];
        }
    }
    
    private static List<string> BubbleSort(string input) {
        int[] nums = ParseInput(input);

        if (nums[0] == '#') return ["Invalid input. Failed to parse the input."];
        if (nums[0] == '@') return ["Unable to sort. Blank array."];
        
        int n = nums.Length;
        var list = new List<string>();
        
        list.Add($"Used Algorithm: Bubble Sort {Environment.NewLine}");
        list.Add($"Unsorted Array: [{string.Join(", ", nums)}]" + Environment.NewLine);
        
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1 - i; j++) {
                if (nums[j] > nums[j + 1]) (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
            }
            
            list.Add($"Pass {i+1}: [{string.Join(", ", nums)}]" + Environment.NewLine);
        }

        return list;
    }

    public static List<string> Sort(String input, Algorithm algorithm) {
        switch (algorithm) {
            case Algorithm.BubbleSort: return BubbleSort(input);
            default: throw new RuntimeBinderException();
        }
    }
    
    
}