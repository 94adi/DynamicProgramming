using System.Text;

namespace DynamicProgramming.AllConstruct
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var target = "purple";
            AllConstructClass.AllConstruct(target, new string[] { "purp", "p", "ur", "le", "purpl" });
            var result = AllConstructClass.finalResult;
            var resultToIterate = result.ToList();

            //filter out invalid solutions generated
            foreach(var item in resultToIterate)
            {
                StringBuilder stringBuilder = new StringBuilder();
                item.Reverse();
                foreach(var item2 in item)
                {
                    stringBuilder.Append(item2);
                }
                if (stringBuilder.ToString() != target)
                    result.Remove(item);
            }

            //print out final solutions
            foreach(var item in result)
            {
                foreach(var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
        }
    }

    internal class AllConstructClass
    {

        public static List<List<string>> finalResult = new List<List<string>>();

        public static List<string> AllConstruct(string target, string[] wordBank)
        {
            
            if (target.Length == 0 || target == "")
            {
                return new List<string>();
            }

            var result = new List<string>();

            foreach(var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    string suffix = target.Substring(target.IndexOf(word) + word.Length);
                    var suffixWays = AllConstruct(suffix, wordBank);
                    if(suffixWays != null)
                    {
                        List<string> targetWays;
                        targetWays = suffixWays; 
                        targetWays.Add(word);
                        result = targetWays.ToList();

                    }

                }
            }

            if(result.Count > 0)
            {
                finalResult.Add(result);
            }
            return result;
        }

        private static bool VerifyResult(List<string> result, string target)
        {
            result.Reverse();
            StringBuilder sb = new StringBuilder();
            foreach(var item in result)
            {
                sb.Append(item);
            }
            if (sb.ToString() == target)
                return true;

            return false;
        }


    }
}