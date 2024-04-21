public static class ExtensionMethods
{
    private static Random rng = new();

    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
    {
        var list = source.ToList();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }
}