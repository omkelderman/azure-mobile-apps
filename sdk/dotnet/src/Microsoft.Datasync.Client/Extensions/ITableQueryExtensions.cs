﻿// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using Microsoft.Datasync.Client.Extensions;
using Microsoft.Datasync.Client.Query;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Microsoft.Datasync.Client
{
    /// <summary>
    /// A set of extension methods for the <see cref="ITableQuery{T}"/> class.
    /// </summary>
    public static class ITableQueryExtensions
    {
        /// <summary>
        /// Creates an array from the result of a table query.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>An array of the results.</returns>
        public static ValueTask<TSource[]> ToArrayAsync<TSource>(this ITableQuery<TSource> query, CancellationToken cancellationToken = default)
            => query.ToAsyncEnumerable().ToZumoArrayAsync(cancellationToken);

        /// <summary>
        /// Creates a dictionary from the result of a table query according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="TKey">The type of the dictionary key computed for each element in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>A dictionary mapping unique key values onto the corresponding result's element.</returns>
        public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this ITableQuery<TSource> query, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToAsyncEnumerable().ToZumoDictionaryAsync(keySelector, cancellationToken);

        /// <summary>
        /// Creates a dictionary from the result of a table query according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="TKey">The type of the dictionary key computed for each element in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>A dictionary mapping unique key values onto the corresponding result's element.</returns>
        public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this ITableQuery<TSource> query, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToAsyncEnumerable().ToZumoDictionaryAsync(keySelector, comparer, cancellationToken);

        /// <summary>
        /// Converts the result of a table query to an enumerable sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <returns>The enumerable sequence containing the elements in the result set.</returns>
        public static IEnumerable<TSource> ToEnumerable<TSource>(this ITableQuery<TSource> query)
            => query.ToAsyncEnumerable().ToZumoEnumerable();

        /// <summary>
        /// Creates a hash set from the results of a table query.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>A hash set containing all the elements of the source sequence.</returns>
        public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this ITableQuery<TSource> query, CancellationToken cancellationToken = default)
            => query.ToAsyncEnumerable().ToZumoHashSetAsync(cancellationToken);

        /// <summary>
        /// Creates a hash set from the results of a table query.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="comparer">An equality comparer to compare elements of the sequence.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>A hash set containing all the elements of the source sequence.</returns>
        public static ValueTask<HashSet<TSource>> ToHashSetAsync<TSource>(this ITableQuery<TSource> query, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken = default)
            => query.ToAsyncEnumerable().ToZumoHashSetAsync(comparer, cancellationToken);

        /// <summary>
        /// Creates a list from the result set of the table query.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="query">The source table query.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>A list containing all the elements of the source sequence.</returns>
        public static ValueTask<List<TSource>> ToListAsync<TSource>(this ITableQuery<TSource> query, CancellationToken cancellationToken = default)
            => query.ToAsyncEnumerable().ToZumoListAsync(cancellationToken);
    }
}
