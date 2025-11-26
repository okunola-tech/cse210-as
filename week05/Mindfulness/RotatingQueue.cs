using System;
using System.Collections.Generic;
using System.Linq;

public class RotatingQueue<T>
{
    private readonly List<T> source;
    private Queue<T> queue;
    private readonly Random rng;

    public RotatingQueue(List<T> items, Random rng)
    {
        this.source = items;
        this.rng = rng;
        Refill();
    }

    private void Refill()
    {
        queue = new Queue<T>(source.OrderBy(_ => rng.Next()));
    }

    public T Next()
    {
        if (queue.Count == 0)
            Refill();

        return queue.Dequeue();
    }
}
