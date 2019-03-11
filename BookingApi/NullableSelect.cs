using System;

#nullable enable

namespace Ploeh.Samples.BookingApi
{
    public static class NullableMaybe
    {
        public static TResult Match<T, TResult>(this T? source, TResult nothing, Func<T, TResult> just)
            where T : class
            where TResult : class
        {
            return source != null ? just(source) : nothing;
        }

        public static TOut? Select<TIn, TOut>(this TIn? source, Func<TIn, TOut> selector)
            where TIn : class
            where TOut : class
        {
            return source != null ? selector(source) : null;
        }

        public static TOut? SelectMany<TIn, TOut>(this TIn? self, Func<TIn, TOut?> bind)
            where TIn : class
            where TOut : class
        {
            return self == null ? null : bind(self);
        }

        public static TOut? SelectMany<TIn, B, TOut>(this TIn? self, Func<TIn, B?> bind, Func<TIn, B, TOut> project)
            where TIn : class
            where B : class
            where TOut : class
        {
            if (self == null) return null;
            var bound = bind(self);
            return bound == null ? null : project(self, bound);
        }
    }
}
