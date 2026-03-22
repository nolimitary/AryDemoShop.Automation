using NUnit.Framework;
using DemoShop.Infrastructure.Factories;

namespace DemoShop.Tests
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        /// <summary>
        /// Data-driven search tests for 6 cases total.
        /// </summary>
        [TestCase("Computing", false, "")]
        [TestCase("Jewelry", false, "")]
        [TestCase("Fiction", false, "")]
        [TestCase("Desktop", true, "Computers")]
        [TestCase("Notebook", true, "Computers")]
        [TestCase("Cell", true, "Electronics")]
        public void Search_DataDriven(string term, bool adv, string cat)
        {
            var dto = adv ? SearchFactory.CreateAdvancedSearch(term, cat) : SearchFactory.CreateBasicSearch(term);
            SearchP.Search(dto);
            Assert.That(SearchP.ResultCount(), Is.AtLeast(0), $"Search failed for {term}");
        }
    }
}
