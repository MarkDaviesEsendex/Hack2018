using Esendexers.HomelessWays.EntityFrameworkCore;

namespace Esendexers.HomelessWays.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly HomelessWaysDbContext _context;

        public TestDataBuilder(HomelessWaysDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}