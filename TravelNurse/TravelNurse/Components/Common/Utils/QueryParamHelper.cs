using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using TravelNurse.Components.Common.Enums;
using TravelNurse.Components.Common.Utils.Dtos;
using TravelNurse.Components.Src.Tables;
using TravelNurseServer.Enums;

namespace TravelNurse.Components.Common.Utils;

public static class QueryParamHelper
{
    public static string? QueryParameterAccessor(Uri uri, string queryParamName)
    {
        QueryHelpers.ParseQuery(uri.Query).TryGetValue(queryParamName, out var data);
        return data;
    }

    public static object? QueryParameterValueConverter(
        QueryParamDto param, object? value)
    {
        switch (param.Type)
        {
            case QueryParamTypeEnum.Boolean:
                return value is int val && val == 1;
            case QueryParamTypeEnum.Number:
                return value is int intVal ? intVal : null;
            case QueryParamTypeEnum.String:
            case QueryParamTypeEnum.DateIsOnBefore:
            case QueryParamTypeEnum.DateIsOnAfter:
                return value;
        }
        return null;
    }
    
    public static string FindPropertyName(
        List<QueryParamFilterDto> queryParamFilters,
        string propertyName
    )
    {
        foreach (var obj in queryParamFilters)
        {
            if (obj.MatchingFilterNames.Contains(propertyName))
            {
                return obj.PropertyName;
            }
        }
        return "";
    }

    #region Handling Enum
    
    // Gotta update this as you go
    public static Type? GetEnumType(string propertyName)
    {
        return propertyName switch
        {
            JobsTableFilter.JobType => typeof(JobType),
            _ => null
        };
    }
    

    #endregion
    
    
    
    // Add query param section

    public static string? AddQueryParameter(
        NavigationManager navigation,
        string propertyName,
        string? value)
    {
        var cleanUri = RemoveQueryParameter(navigation, propertyName);
        var uri = navigation.ToAbsoluteUri(
            cleanUri != null ? cleanUri : navigation.Uri);
        
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        queryParams.Add(propertyName, value);
        
        var baseUri = uri.GetLeftPart(UriPartial.Path);
        var newQuery = queryParams.ToString();
        var newUri = string.IsNullOrWhiteSpace(newQuery) ? baseUri : $"{baseUri}?{newQuery}";

        navigation.NavigateTo(newUri, forceLoad: false);
        return newUri;
    }
    
    // Remove query param section
    public static string? RemoveQueryParameter(
        NavigationManager navigation, string propertyName,
        string? previousUri = null
    )
    {
        var uri = navigation.ToAbsoluteUri(previousUri ?? navigation.Uri);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        queryParams.Remove(propertyName);
        var baseUri = uri.GetLeftPart(UriPartial.Path);
        var newQuery = queryParams.ToString();
        var newUri = string.IsNullOrWhiteSpace(newQuery) ? baseUri : $"{baseUri}?{newQuery}";
        // Navigate to the new URL (without reloading the page)
        navigation.NavigateTo(newUri, forceLoad: false);
        return newUri;
    }

    
    // Might be useful later down the line
    public static string? RemoveAlternativeQueryParameter(
        List<QueryParamFilterDto> queryParamFilters,
        string propertyName, string nameSubString, NavigationManager navigation,
        string? previousUri = null)
    {
        var match = queryParamFilters.FirstOrDefault(x => x.PropertyName == propertyName);
        
        var uri = navigation.ToAbsoluteUri(
            previousUri ?? navigation.Uri);
        
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);

        if (match != null)
        {
            foreach (string key in match.MatchingFilterNames)
            {
                if (key?.Contains(nameSubString, StringComparison.OrdinalIgnoreCase) == true)
                {
                    queryParams.Remove(key);
                }
            }
        }
       
        var baseUri = uri.GetLeftPart(UriPartial.Path);
        var newQuery = queryParams.ToString();
        var newUri = string.IsNullOrWhiteSpace(newQuery) ? baseUri : $"{baseUri}?{newQuery}";

        navigation.NavigateTo(newUri, forceLoad: false);
        return newUri;
        
        // usage:
        // QueryParamHelper.RemoveAlternativeQueryParameter(
        //     QueryParamFilterDto, PropertyName, "After", Navigation, uri
        // );
        
        // This will be useful if we don't pass down the propertyName from the <FilterTemplate>
    }
}