using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.BookingApi
{
    public static class TaskEnvy
    {
        // These methods create ambiguity with the nullable nullable 
        // versions in TaskMaybe.  It's likely that the nullable versions
        // can be put to use for both nullable and non-nullable selectors...

        //public async static Task<TResult> Select<T, TResult>(
        //    this Task<T> source,
        //    Func<T, TResult> selector)
        //{
        //    var x = await source;
        //    return selector(x);
        //}

        //public async static Task<TResult> SelectMany<T, TResult>(
        //    this Task<T> source,
        //    Func<T, Task<TResult>> selector)
        //{
        //    var x = await source;
        //    return await selector(x);
        //}
    }
}
