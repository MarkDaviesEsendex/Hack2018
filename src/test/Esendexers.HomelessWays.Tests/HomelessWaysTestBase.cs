using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Esendexers.HomelessWays.EntityFrameworkCore;
using Esendexers.HomelessWays.Tests.TestDatas;

namespace Esendexers.HomelessWays.Tests
{
    public class HomelessWaysTestBase : AbpIntegratedTestBase<HomelessWaysTestModule>
    {
        public HomelessWaysTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<HomelessWaysDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<HomelessWaysDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<HomelessWaysDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<HomelessWaysDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<HomelessWaysDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<HomelessWaysDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<HomelessWaysDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<HomelessWaysDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
