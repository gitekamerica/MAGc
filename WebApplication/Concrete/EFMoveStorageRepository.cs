using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFMoveStorageRepository: IMoveStorage
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<MoveStorage> MoveStorages
        {
            get { return context.MoveStorages; }
        }

        public void SaveMoveStorage(MoveStorage movestorage)
        {
      
            if (movestorage.MoveID == 0)
            {
                context.MoveStorages.Add(movestorage);
            }
            else
            {
                MoveStorage dbEntry = context.MoveStorages.Find(movestorage.MoveID);
                if (dbEntry != null)
                {
                    dbEntry.MoveID = movestorage.MoveID;
                    dbEntry.MoveNo = movestorage.MoveNo;
                    dbEntry.MoveDate = movestorage.MoveDate;
                    dbEntry.MoveDescription = movestorage.MoveDescription;

                }
            }
            context.SaveChanges();
        }


    }
}