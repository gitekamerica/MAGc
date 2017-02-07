using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFMoveDetailsRepository: IMoveDetails
    {


        private EFDbContext context = new EFDbContext();

        public IQueryable<MoveDetails> MoveDetails
        {
            get { return context.MoveDetails; }
        }

       

        public void SaveMoveDetails(MoveDetails movedetails)
        {

            if (movedetails.MoveID == 0)
            {
                context.MoveDetails.Add(movedetails);
            }
            else
            {
                MoveDetails dbEntry = context.MoveDetails.Find(movedetails.MoveID);
                if (dbEntry != null)
                {
                    dbEntry.MoveID = movedetails.MoveID;
                    dbEntry.MoveItemsID = movedetails.MoveItemsID;
                    dbEntry.ItemName = movedetails.ItemName;
                    //dbEntry.Quantity = movedetails.Quantity;
                    //dbEntry.Rate = movedetails.Rate;
                    //dbEntry.TotalAmount = movedetails.TotalAmount;
                        
                }
            }
            context.SaveChanges();
        }


    }
}