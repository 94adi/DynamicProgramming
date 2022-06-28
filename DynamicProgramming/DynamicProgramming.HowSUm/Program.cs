namespace DynamicProgramming.HowSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = HowSumClass.HowSum(300, new List<int> { 7, 14 });
            if (result != null && result.Count > 0)
            {
                foreach (var n in result)
                    Console.Write(n + " ");
            }
            else
            {
                Console.WriteLine("Can't be summed");
            }
        }
    }

    internal class HowSumClass
    {
        //Write a function `HowSum(targetSum, numbers)` that takes in a targetSum and an array of numbers as arguments
        //The function should return an array containing any combination of elements that add up to exactly the targetSum.
        //If there is no combination that adds up to the targetSum, then return null

        //m = target sum
        //n = numbers.length

        //Brute force
        //time: O(n ^ m * m)
        //space: O(m)

        //Memoized
        //time: O(m * n * m) = O(n * m^2)
        //space: O(m*m) = O(m^2)



        private static IDictionary<int, List<int>> memo = new Dictionary<int, List<int>>();

        public static IList<int> HowSum(int targetSum, List<int> numbers)
        {
            if (memo.ContainsKey(targetSum)) 
                return memo[targetSum];
            if (targetSum == 0)
                return new List<int>();
            if (targetSum < 0)
                return null;
            foreach (var number in numbers)
            {
                var result = HowSum(targetSum - number, numbers);
                if (result != null)
                {
                    result.Add(number);
                    memo[targetSum] = (List<int>)result;
                    return memo[targetSum];
                }
            }
            memo[targetSum] = null;
            return null;
        }
    }
}