using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Repository
{
    public class databaseSingleton
    {
        private static databaseEntities1 instance;

        public static databaseEntities1 getInstance()
        {
            if (instance == null)
            {
                instance = new databaseEntities1();
            }
            return instance;
        }
    }
}