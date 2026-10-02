public class Solution {
    public int EvalRPN(string[] tokens)
    {
        var methods = new Dictionary<string, Func<int, int, int>>()
        {
            {"+", Add},
            {"-", Sub},
            {"*", Mul},
            {"/", Div},
        };

        var stack = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            if (methods.TryGetValue(tokens[i], out var method))
            {
                var b = stack.Pop();
                stack.Push(method.Invoke(stack.Pop(), b));
                //Console.WriteLine("Stack: {0}", string.Join(',', stack));
            }
            else
            {
                stack.Push(int.Parse(tokens[i]));
                //Console.WriteLine("Stack: {0}", string.Join(',', stack));
            }
        }

        return stack.Pop();
    }


    private static int Add(int a, int b)
    {
        return a + b;
    }
    private static int Sub(int a, int b)
    {
        return a - b;
    }

    private static int Mul(int a, int b)
    {
        return a * b;
    }
    private static int Div(int a, int b)
    {
        return a / b;
    }
}
