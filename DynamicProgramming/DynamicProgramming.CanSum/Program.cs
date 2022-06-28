namespace DynamicProgramming.CanSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = CanSumClass.CanSum(300, new int[] { 7,14 });
            Console.WriteLine(result);
        }
    }

    internal class CanSumClass
    {
        private static IDictionary<int, bool> memo = new Dictionary<int, bool>();

        //write a fun canSum(targetSum, numbers)
        //returns a boolean indicating whether or not is possible to generate the targetSum using numbers in array
        //you may use a number in the array as many times as needed
        //all numbers in array are non negative
        //m = target sum
        //n = array length
        //Brute force complexity:
        //O(n^m) time
        //O(m) space
        //Memoized complexity:
        //O(m * n) time
        //O(m) space

        public static bool CanSum(int targetSum, int[] numbers)
        {
            if(memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0)
                return true;
            if (targetSum < 0)
                return false;
            foreach(var number in numbers)
            {
                if (CanSum(targetSum - number, numbers))
                {
                    memo[targetSum] = true;
                    return true;
                }
            }
            memo[targetSum] = false;
            return false;
        }

    }
}