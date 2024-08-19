// <copyright file="PaginatedList.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace Garuda.Utilities.Dtos.Response;

/// <summary>
/// Represents a paginated list of items.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class PaginatedList<T> where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
    /// Represents a paginated list of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        Page = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalData = count;
        Data = items;
    }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Page.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for TotalPages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for TotalData.
    /// </summary>
    public int TotalData { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Data.
    /// </summary>
    public List<T> Data { get; set; }

    /// <summary>
    /// Create a paginated list of items from a source IQueryable<T/>.
    /// </summary>
    /// <typeparam name="T">The type of the items in the paginated list.</typeparam>
    /// <param name="source">The source IQueryable<T/> to create paginated list from.</param>
    /// <param name="pageIndex">The page index of the paginated list.</param>
    /// <param name="pageSize">The page size of the paginated list.</param>
    /// <returns>A Task representing the asynchronous operation that returns a PaginatedList<T/> object.</returns>
    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}