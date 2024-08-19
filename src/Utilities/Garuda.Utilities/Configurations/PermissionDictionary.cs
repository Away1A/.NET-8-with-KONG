// <copyright file="PermissionDictionary.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Utilities.Configurations
{
    public class PermissionDictionary
    {
        public static Dictionary<Guid, List<string>> Permissions = new();

        public static void AddToDictionary(Guid id, List<string> groups)
        {
            if (Permissions.All(x => x.Key != id))
            {
                Permissions.Add(id, groups);
            }
            else
            {
                Permissions.Remove(id);
                Permissions.Add(id, groups);
            }
        }
    }
}