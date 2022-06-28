namespace DynamicProgramming.GridTraveler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = GridTraveler.gridTraveler(18, 18);
            Console.WriteLine(result);
        }
    }

    internal class GridTraveler
    {
        private static IDictionary<string, long?> memo = new Dictionary<string, long?>();
        //counts the # of valid paths to complete task
        //grid: matrix m x n
        //s(top, left) -> d(bottom, right)
        //can't travel on diagonal
        public static long gridTraveler(int m, int n)
        {
            string key = m + "," + n;
            if (memo.ContainsKey(key)) return memo[key].Value;
            if (m == 1 && n == 1) { 
                memo[key] = 1; return memo[key].Value; // 1 x 1 grid
            }

            if (m == 0 || n == 0) {
                memo[key] = 0; return memo[key].Value; //out of the grid
            }
 
            memo[key] = gridTraveler(m, n - 1) + gridTraveler(m - 1, n);
            return memo[key].Value;
        }
    }
}