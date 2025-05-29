using PetrovvEgorkt_31_22.Models;

namespace petrovv_egor_kt_31_22.Tests
{
    public class CathedralTest
    {
        [Fact]
        public void IsValidCathedralName_True()
        {
            var test1 = new Cathedral { CathedralName = "Кафедра компьютерных технологий" };
            var test2 = new Cathedral { CathedralName = "Кафедра информатики и вычислительной техники" };
            var test3 = new Cathedral { CathedralName = "Кафедра права и юриспруденции" };
            var test4 = new Cathedral { CathedralName = "Кафедра акушерства и гинекологии" };

            var res1 = test1.IsValidCathedralName();
            var res2 = test2.IsValidCathedralName();
            var res3 = test3.IsValidCathedralName();
            var res4 = test4.IsValidCathedralName();

            Assert.True(res1);
            Assert.True(res2);
            Assert.True(res3);
            Assert.True(res4);
        }
        [Fact]
        public void IsValidCathedralName_False()
        {
            var test1 = new Cathedral { CathedralName = "Кафедра компьютерных технологий 2" };
            var test2 = new Cathedral { CathedralName = "123Кафедра информатики и вычислительной техники" };
            var test3 = new Cathedral { CathedralName = "Кафедра1права2и3юриспруденции" };
            var test4 = new Cathedral { CathedralName = "4Кафедра акушерства и гинекологии4" };

            var res1 = test1.IsValidCathedralName();
            var res2 = test2.IsValidCathedralName();
            var res3 = test3.IsValidCathedralName();
            var res4 = test4.IsValidCathedralName();

            Assert.False(res1);
            Assert.False(res2);
            Assert.False(res3);
            Assert.False(res4);
        }
    }
}


