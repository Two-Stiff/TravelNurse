using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Core.Http.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Core.Extensions;

public static class LinqExtensions
{
    public static IQueryable<T> If<T>(this IQueryable<T> query, 
        bool should,
        params Func<IQueryable<T>, IQueryable<T>>[] transforms
        )
    {
        return should 
            ? transforms.Aggregate(query, (current, transform) => transform(current))
            : query;
    }
    
    public static IQueryable<TResult> SelectOnly<TSource, TResult>(
        this IQueryable<TSource> query,
        Expression<Func<TSource, TResult>> selector)
    {
        return (IQueryable<TResult>)query;
    }

    /// <summary>
    /// Alternative to single or default that requires handling of the case where more than one matching instance exists
    /// </summary>
    /// <param name="query">Original query</param>
    /// <param name="callback">Callback to handles the case where more than one matching instance exists</param>
    public static async Task<T?> SafeSingleOrDefault<T>(this IQueryable<T> query, Func<List<T>, T?> callback)
    {
        var list = await query.ToListAsync();

        if (list.Count == 0)
        {
            return default;
        }

        if (list.Count == 1)
        {
            return list[0];
        } 
        
        return callback(list);
    }

    
    /// <summary>
    ///  Return element from the query if there is exactly one or else throws the provided exception
    /// </summary>
    /// <param name="query">Original query</param>
    /// <param name="exception">Exception to be thrown</param>
    public static async Task<T> SingleOrThrowAsync<T>(this IQueryable<T> query, Exception exception)
    {
        var list = await query.ToListAsync();

        if (list.Count != 1)
        {
            throw exception;
        }
        
        return list[0];
    }
    
    
    /// <summary>
    ///     Return the first element from the query if there is any or else throws the provided exception
    /// </summary>
    /// <param name="query">Original query</param>
    /// <param name="exception">Exception to be thrown</param>
    public static async Task<T> FirstOrThrowAsync<T>(this IQueryable<T> query, Exception exception)
    {
        var item = await query.FirstOrDefaultAsync();
        
        if (item == null)
        {
            throw exception;
        }

        return item;
    }

    
    /// <summary>
    ///  Return the element from the query if there is exactly one or else throws the provided exception
    /// </summary>
    /// <param name="query">Original query</param>
    /// <param name="exception">Exception to be thrown</param>
    public static T SingleOrThrow<T>(this IQueryable<T> query, Exception exception)
    {
        var list = query.ToList();

        if (list.Count != 1)
        {
            throw exception;
        }
        
        return list[0];
    }

    /// <summary>
    ///     Return the first element from the query if there is any or else throws the provided exception
    /// </summary>
    /// <param name="query">Original query</param>
    /// <param name="exception">Exception to be thrown</param>
    public static T FirstOrThrow<T>(this IQueryable<T> query, Exception exception)
    {
        var item = query.FirstOrDefault();

        if (item == null)
        {
            throw exception;
        }

        return item;
    }

    public static IEnumerable<T> If<T>(this IEnumerable<T> query,
        bool should,
        params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
    {
        return should
            ? transforms.Aggregate(query, (current, transform) => transform.Invoke(current))
            : query;
    }

    /// <summary>
    ///     this method validates that all keys exist and returns their records
    /// </summary>
    /// <param name="list">IEnumerable to query</param>
    /// <param name="keys">List of keys to check are present</param>
    /// <typeparam name="T">Type in IEnumerable</typeparam>
    /// <returns>Return objects based on the keys</returns>
    /// <exception cref="NotFoundException{T}">Not Found if a key isn't found</exception>
    public static List<T> GetAll<T>(this IEnumerable<T> list, List<int> keys) where T : Entity
    {
        var objects = list.Where(x => keys.Contains(x.Id)).ToList();

        if (objects.Count != keys.Count)
        {
            throw new NotFoundException<T>();
        }

        return objects;
    }
    
    
    /// <summary>
    ///     This method validates that all keys exist and returns their records
    /// </summary>
    /// <param name="list">IQueryable ti qyer</param>
    /// <param name="keys">List of keys to check are present</param>
    /// <typeparam name="T">Type in IQueryable</typeparam>
    /// <returns>Return objects based on the keys</returns>
    /// <Exception cref="ApiException">Not found if a key isn't found</Exception>
    public static List<T> GetAll<T>(this IQueryable<T> list, List<int> keys) where T : Entity
    {
        return list.GetAllAsync(keys).Result;
    }


    /// <summary>
    ///     This method validates that all keys exist and returns their records
    /// </summary>
    /// <param name="list">IQueryable to query</param>
    /// <param name="keys">List of keys to check are present</param>
    /// <typeparam name="T">Type in IQueryable</typeparam>
    /// <returns>Returns objects based on the keys</returns>
    /// <exception cref="NotFoundException{T}">Not found if a key isn't found</exception>
    public static async Task<List<T>> GetAllAsync<T>(this IQueryable<T> list, List<int> keys) where T : Entity
    {
        var entities = await list.Where(x => keys.Contains(x.Id)).ToListAsync();

        if (entities.Count != keys.Count)
        {
            throw new NotFoundException<T>();
        }
        
        return entities;
    }

    /// <summary>
    ///     This method validates that key exist and returns it's record
    /// </summary>
    /// <param name="list"></param>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>(this IEnumerable<T> list, int key) where T : Entity
    {
        return list.GetAll(new List<int>{key}).Single();
    }


    /// <summary>
    ///     This method validates that the key exist and return it's record
    /// </summary>
    /// <param name="list">IQueryable to query</param>
    /// <param name="key">key to check it's present</param>
    /// <typeparam name="T">Type in IQueryable</typeparam>
    /// <returns>Return objects based on the key</returns>
    public static Task<T> Get<T>(this IQueryable<T> list, int key) where T : Entity
    {
        return list.GetAsync(x => x.Id == key);
    }

    /// <summary>
    ///     This method validates that they key exist and return it's record
    /// </summary>
    /// <param name="list">IQueryable to query</param>
    /// <param name="predicate">condition to match on</param>
    /// <param name="notFoundException"></param>
    /// <typeparam name="T">type in your IQueryable</typeparam>
    /// <returns>object based on the key</returns>
    /// <exception cref="NotFoundException"></exception>
    public static async Task<T> GetAsync<T>(this IQueryable<T> list, Expression<Func<T, bool>> predicate,
        NotFoundException? notFoundException = null
        ) where T : Entity
    {
        var entity = await list.SingleOrDefaultAsync(predicate);

        if (entity == null)
        {
            throw notFoundException ?? new NotFoundException<T>();
        }
        return entity;
    }
    
    public static async Task<T> GetAsync<T>(
        this IQueryable<T> list,
        int id,
        NotFoundException? notFoundException = null
    ) where T : Entity
    {
        var entity = await list.SingleOrDefaultAsync(e => e.Id == id);

        if (entity == null)
        {
            throw notFoundException ?? new NotFoundException<T>();
        }

        return entity;
    }



    /// <summary>
    ///     Validate that a list has keys and they all exist in the list
    /// </summary>
    /// <param name="list">IEnumerable to check against</param>
    /// <param name="key">List of keys to check</param>
    /// <typeparam name="T">Object in IEnumerable</typeparam>
    public static void Exists<T>(this IEnumerable<T> list, List<int>? key) where T : Entity
    {
        if (key == null)
        {
            return;
        }

        if (list.Select(x => x.Id).Intersect(key).Count() != key.Count)
        {
            throw new NotFoundException<T>();
        }
    }

    
    /// <summary>
    ///     Validate that a list has keys and they all exist in the list
    /// </summary>
    /// <param name="list">IEnumerable to check against</param>
    /// <param name="key">List of keys to check</param>
    /// <typeparam name="T">Object in IEnumerable</typeparam>
    public static void Exists<T>(this IEnumerable<T> list, int? key) where T : Entity
    {
        if (key == null)
        {
            return;
        }

        if (!list.Any(x => key == x.Id))
        {
            throw new NotFoundException<T>();
        }
    }
    
    
} 