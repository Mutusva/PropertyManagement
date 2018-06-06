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
  public class PropertyImageRepository : IPropertyImageRepository
  {
    DbContextOptions<PropertyManagementContext> _dbContextOptions;
    public PropertyImageRepository(DbContextOptions<PropertyManagementContext> dbContextOptions)
    {
      _dbContextOptions = dbContextOptions;
    }
    public async Task<IEnumerable<PropertyImage>> getPropertyImages(int propertyDetailId)
    {
      using (var context = new PropertyManagementContext(_dbContextOptions))
      {
        return await context.PropertyImage.Where(x => x.PropertyDetailId == propertyDetailId)?.ToListAsync();
      }
    }
  }
}
