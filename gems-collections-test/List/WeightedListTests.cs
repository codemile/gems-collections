using gems_collections.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gems_collections_test.List
{
    [TestClass]
    public class WeightedListTests
    {
        [TestMethod]
        public void Add()
        {
            WeightedList<string> wl = new WeightedList<string> {{"one", 1}, {"two", 1}, {"three", 2}};

            Assert.AreEqual(wl.getWeight(0),0.25f);
            Assert.AreEqual(wl.getWeight(1), 0.25f);
            Assert.AreEqual(wl.getWeight(2), 0.5f);

            float t = 0.0f;
            for (int i = 0; i < wl.Count; i++)
            {
                t += wl.getWeight(i);
            }
            Assert.AreEqual(1.0f,t);
        }
    }
}