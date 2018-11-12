using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    /// <summary>
    /// Represents generic methods Filter and Transformer
    /// </summary>
    public static class CollectionFilter
    {
        /// <summary>
        /// Filter source data for a given predicate
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source IEnumerable type</param>
        /// <param name="predicate">Delegate </param>
        /// <returns>Filter source for a given predicate</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.Filtration(predicate);
        }

        /// <summary>
        /// Filter source data for a given predicate
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source IEnumerable type</param>
        /// <param name="predicate">Interface</param>
        /// <returns>Filter source for a given predicate</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, IFilter<T> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.Filtration(predicate);
        }

        /// <summary>
        /// Transformer source data for a given predicate
        /// </summary>
        /// <typeparam name="TSource">Type source</typeparam>
        /// <typeparam name="TResult">Type result</typeparam>
        /// <param name="source">Source IEnumerable type</param>
        /// <param name="predicate">Interface</param>
        /// <returns>Transform source for a given predicate</returns>
        public static IEnumerable<TResult> Transformer<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.Transformation(predicate);
        }

        /// <summary>
        /// Transformer source data for a given predicate
        /// </summary>
        /// <typeparam name="TSource">Type source</typeparam>
        /// <typeparam name="TResult">Type result</typeparam>
        /// <param name="source">Source IEnumerable type</param>
        /// <param name="predicate">Delegate</param>
        /// <returns>Transform source for a given predicate</returns>
        public static IEnumerable<TResult> Transformer<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.Transformation(predicate);
        }

        #region Private methods
        private static IEnumerable<T> Filtration<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<TResult> Transformation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> predicate)
        {
            foreach (TSource item in source)
            {
                yield return predicate(item);
            }
        }

        private static IEnumerable<T> Filtration<T>(this IEnumerable<T> source, IFilter<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate.Filter(source, item))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<TResult> Transformation<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> predicate)
        {
            foreach (TSource item in source)
            {
                yield return predicate.Transform(item);
            }
        }
        #endregion
    }
}
