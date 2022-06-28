namespace DynamicProgramming.BestSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = BestSumClass.BestSum(100, new List<int> { 1, 2 , 5, 25});
            if(result != null)
            {
                foreach(var number in result)
                {
                    Console.Write(number + " ");
                }
            }
            else
            {
                Console.WriteLine("No result found");
            }
        }
    }

    internal class BestSumClass
    {
        //Write a function `BestSum(targetSum, numbers)` that takes in a targetSum and an array of numbers as arguments
        //The function should return an array containing the shortest combination of elements that add up to exactly the targetSum.
        //If there is a tie for the shortest combination, you may return any one of the shortest

        //m = target sum
        //n = numbers.length

        //Brute force
        //time: O(n ^ m * m)
        //space: O(m^2)

        //Memoized
        //time: O(m * n * m) = O(m^2 * n)
        //space: O(m*m) = O(m^2)



        private static IDictionary<int, IList<int>> memo = new Dictionary<int, IList<int>>();

        public static IList<int> BestSum(int targetSum, List<int> numbers)
        {
            if (memo.ContainsKey(targetSum))
                return memo[targetSum];
            if (targetSum == 0)
                return new List<int>();
            if (targetSum < 0)
                return null;

            IList<int> shortestComb = null;

            foreach(var number in numbers)
            {
                var result = BestSum(targetSum - number, numbers);
                if(result != null)
                {
                    IList<int> tempResult =  result.ToList();
                    tempResult.Add(number);
                    if(shortestComb == null || tempResult.Count < shortestComb.Count)
                    {
                        shortestComb = tempResult;
                    }
                }
            }
            memo[targetSum] = shortestComb;
            return shortestComb;
        }
    }
}