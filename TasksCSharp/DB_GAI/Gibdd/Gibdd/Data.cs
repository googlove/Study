using Gibdd.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gibdd
{
    static class Data
    {
        static  int idOwner;
        static int idAuto;
        static OwnerFullInfo indOwnerFullInfo;
        static bool isEntity;

        public static int IdOwner { get => idOwner; set => idOwner = value; }
        public static OwnerFullInfo IndOwnerFullInfo { get => indOwnerFullInfo; set => indOwnerFullInfo = value; }
        public static bool IsEntity { get => isEntity; set => isEntity = value; }
        public static int IdAuto { get => idAuto; set => idAuto = value; }
    }
}
