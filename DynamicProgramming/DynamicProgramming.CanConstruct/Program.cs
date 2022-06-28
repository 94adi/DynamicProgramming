namespace DynamicProgramming.CanConstruct
{

    internal class Program
    {
        static void Main(string[] args)
        {
           var result = CanConstructClass.CanConstruct("skateboard",
               new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar"});
            Console.WriteLine(result);
        }
    }

    internal class CanConstructClass
    {
        //CanConstruct(target, wordBank): accepts a target string and an array of strings

        //The method should return a boolean indicating whether or not the `target` can be constructed by
        //concatenating elements of the `wordBank` array

        //You may reuse elements of `wordBank` as many times as needed

        //m = target.length (height of recursion tree)
        //n = wordBank elements

        //Brute complexity
        //time: O(n ^ m * m)
        //space: O(m * m) -> O(m^2)

        //Memiozation complexity
        //time: O(n * m^2)
        //space: O(m^2) 

        private static IDictionary<string, bool> memo = new Dictionary<string, bool>();

        public static bool CanConstruct(string target, string[] wordBank)
        {
            if (memo.ContainsKey(target)) return memo[target];

            if(target.Length == 0 || target == "")  return true;
            
            foreach(var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    string newTarget = target.Replace(word, string.Empty);
                    var result = CanConstruct(newTarget, wordBank);
                    if (result == true)
                    {
                        memo[target] = true;
                        return true;
                    }
                }
            }
            memo[target] = false;
            return false;
        }
    }
}