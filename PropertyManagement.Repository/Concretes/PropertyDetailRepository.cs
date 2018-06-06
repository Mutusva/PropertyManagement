using Microsoft.EntityFrameworkCore;
using PropertyManagement.Model.Models;
using PropertyManagement.Repository.Context;
using PropertyManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Repository.Concretes
{
  public class PropertyDetailRepository : IPropertyDetailRepository
  {
    DbContextOptions<PropertyManagementContext> _dbContextOptions;

    public PropertyDetailRepository(DbContextOptions<PropertyManagementContext> dbContextOptions)
    {
      _dbContextOptions = dbContextOptions;
    }

    public async Task<IEnumerable<PropertyDetail>> getAllPropertyDetails()
    {
      using (var context = new PropertyManagementContext(_dbContextOptions))
      {
        return await context.PropertyDetail.Include(x=>x.PropertyImage).Include(x=>x.OwnerHistory).ToListAsync();
      }
    }

    public async Task<PropertyDetail> getPropertyDetails(int propertyDetailId)
    {
      using (var context = new PropertyManagementContext(_dbContextOptions))
      {
        return await context.PropertyDetail.Include(x=>x.PropertyImage).Include(y=>y.OwnerHistory).Where(x => x.Id == propertyDetailId).FirstOrDefaultAsync();
      }
    }

    public async Task<IEnumerable<PropertyDetail>> searchPropertyDetails(PropertySearchModel searchModel)
    {
      using (var context = new PropertyManagementContext(_dbContextOptions))
      {
        var result = context.PropertyDetail.Include(x=>x.PropertyImage).Include(x=>x.OwnerHistory).AsQueryable();
      
        if (searchModel != null)
        {
          if (!string.IsNullOrEmpty(searchModel.OwnerName))
          {
            bool containsOwner = false;
            foreach(var item in result)
            {
              var owners = item.OwnerHistory.Select(x => x.OwnerName);
              foreach (var owner in owners)
              {
                if (owner.Contains(searchModel.OwnerName))
                {
                  containsOwner = true;                 
                }
              }
              result = (!containsOwner) ? result.Where(y=>y.Id != item.Id): result;
            }
          }           
          if (!string.IsNullOrEmpty(searchModel.Address))
            result = result.Where(x=>x.PropertyAddress.Contains(searchModel.Address));
          if (searchModel.NumOfBedrooms.HasValue && searchModel.NumOfBedrooms.Value!=0)
            result = result.Where(x => x.NumOfBedrooms == searchModel.NumOfBedrooms);
          if (searchModel.NumOfBathrooms.HasValue && searchModel.NumOfBathrooms.Value != 0)
            result = result.Where(x => x.NumOfbathrooms == searchModel.NumOfBathrooms);
        }
        return await result?.ToListAsync();
      }
    }
  }
}
