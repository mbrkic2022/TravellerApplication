﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellerApp.Model;
using Xamarin.Forms;

namespace TravellerApp.Helper
{
    public interface IFirestore
    {
        bool Insert(Post post);
        Task<bool> Delete(Post post);
        Task<bool> Update(Post post);
        Task<List<Post>> Read();
    }
    public class Firestore
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();
        public static bool Insert(Post post)
        {
            return firestore.Insert(post);
        }
        public static async Task<bool> Delete(Post post)
        {
            return await firestore.Delete(post);
        }
        public static async Task<bool> Update(Post post)
        {
            return await firestore.Update(post);
        }
        public static async Task<List<Post>> Read()
        {
            return await firestore.Read();
        }
    }
}
