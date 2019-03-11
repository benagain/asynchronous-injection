using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Ploeh.Samples.BookingApi
{
    public static class TaskMaybe
    {
        public static async Task<TResult> Match<T, TResult>(
            this Task<T?> source,
            TResult nothing,
            Func<T, TResult> just)
            where T : class
            where TResult : class
        {
            var m = await source;
            return m.Match(nothing: nothing, just: just);
        }

        public static async Task<TResult?> Select<T, TResult>(
            this Task<T?> source,
            Func<T, TResult> selector)
            where T : class
            where TResult : class
        {
            var m = await source;
            return m.Select(selector);
        }

        public static async Task<TResult?> SelectMany<T, TResult>(
            this Task<T?> source,
            Func<T, Task<TResult?>> selector)
            where T : class
            where TResult : class
        {
            T? m = await source;

            return await m.Match(
                nothing: Task.FromResult((TResult?)null),
                just: x => selector(x));
        }

        public static Task<TResult?> Traverse<T, TResult>(
            this T? source,
            Func<T, Task<TResult>> selector)
            where T : class
            where TResult : class
        {
            // avoids...
            // warning CS8619: Nullability of reference types in value of type 'Task<TResult>' doesn't match target type 'Task<TResult?>'.
            async Task<TResult?> taskifyAsync(T t) => await selector(t);

            return source.Match(
                nothing: Task.FromResult<TResult?> (null),
                just: taskifyAsync);
        }
    }
}
